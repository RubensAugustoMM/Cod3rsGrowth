sap.ui.define([
	"sap/ui/core/routing/History",
	"ui5/cod3rsgrowth/modelos/Servicos/ServicoEmpresas",
	"sap/viz/ui5/types/layout/Stack",
	"ui5/cod3rsgrowth/modelos/Servicos/ServicoEnderecos",
	"sap/ui/core/date/UI5Date",
	"sap/m/MessageBox",
	"sap/ui/model/json/JSONModel",
	"./ControllerBase"
], function (
	History,
	ServicoEmpresas,
	Stack,
	ServicoEnderecos,
	UI5Date,
	MessageBox,
	JSONModel,
	ControllerBase
) {
	"use strict";

	const NOME_ROTA_EMPRESA_EDITAR = "EmpresaEditar";
	return ControllerBase.extend("ui5.cod3rsgrowth.controller.CriarEditarEmpresas", {
		_idEmpresaAtualizar: 0,
		_idEnderecoAtualizar: 0,
		_rotaAtual: "",
		_idCriarEditarEmpresas: "criarEditarEmpresas",
		onInit() {
			const roteador = this.getOwnerComponent().getRouter();
			const nomeRotaEmpresaCriar = "EmpresaCriar";
			roteador.getRoute(nomeRotaEmpresaCriar).attachMatched(this._aoCoincidirComRotaEmpresaCriar, this);
			roteador.getRoute(NOME_ROTA_EMPRESA_EDITAR).attachMatched(this._aoCoincidirComRotaEmpresaEditar, this);
			const idDataAberturaDatePicker = "dataAberturaDatePicker";
			let dataAtual = new Date();
			this.byId(idDataAberturaDatePicker).setMaxDate(
				UI5Date.getInstance(
					dataAtual.getFullYear(),
					dataAtual.getMonth(),
					dataAtual.getDay()));
		},
		_configuraModeloDeDadosDaTela() {
			const dadosEmpresa = {
				razaoSocial:undefined,
				nomeFantasia:undefined,
				cnpj: undefined,
				situacaoCadastral: undefined,
				dataAbertura:undefined,
				naturezaJuridica:undefined,
				porte:undefined,
				matrizFilial:undefined,
				capitalSocial:undefined
			};	
			
			this._modeloEmpresa(new JSONModel(dadosEmpresa));
			const dadosEstado = {
				cep:undefined,
				estado:undefined,
				municipio:undefined,
				bairro:undefined,
				rua:undefined,
				numero:undefined,
				complemento:undefined
			}
			this._modeloEnderecoEmpresa(new JSONModel(dadosEstado));
		},
		_aoCoincidirComRotaEmpresaEditar(oEvent) {
			this._configuraModeloDeDadosDaTela();
			const i18nMensagemDeErro = "CriarEditarEmpresas.ErroCoincidirRotaEditar";
			const parametroNomeRota = "name";
			this._rotaAtual = oEvent.getParameter(parametroNomeRota);
			this.trataErros(i18nMensagemDeErro,async () => {
				const nomeArgumentosCaminhoEmpresa = "arguments";
				let idEmpresa = oEvent.getParameter(nomeArgumentosCaminhoEmpresa).caminhoEmpresa;
				let empresa = await ServicoEmpresas.obterEmpresaPorId(idEmpresa);
				this._populaTelaComValoresEmpresaEditar(empresa);
				this._populaTelaComValoresEnderecoDaEmpresaEditar(empresa.idEndereco);
				const i18TituloEmpresaEditar = "CriarEditarEmpresas.TituloEditar";
				const i18n = this.modeloI18n();
				this.byId(this._idCriarEditarEmpresas).setTitle(i18n.getText(i18TituloEmpresaEditar));
			});
		},
		_aoCoincidirComRotaEmpresaCriar(oEvent) {
			this._configuraModeloDeDadosDaTela();
			const i18nMensagemDeErro = "CriarEditarEmpresas.ErroCoincidirRotaCriar";
			const parametroNomeRota = "name";
			this._rotaAtual = oEvent.getParameter(parametroNomeRota);
			this.trataErros(i18nMensagemDeErro, () => {
				const i18TituloEmpresaCriar = "CriarEditarEmpresas.TituloCriar";
				const i18n = this.modeloI18n();
				this.byId(this._idCriarEditarEmpresas).setTitle(i18n.getText(i18TituloEmpresaCriar));
			});
		},
		_retornaValoresEmpresa(){
			
			let valoresEmpresa =  this._modeloEmpresa(undefined).getData(); 
			valoresEmpresa.situacaoCadastral = valoresEmpresa.situacaoCadastral == 1 ? true : false;
			valoresEmpresa.dataSituacaoCadastral = new Date();
			return valoresEmpresa;
		},
		_populaTelaComValoresEmpresaEditar: async function (empresa) {
			empresa.situacaoCadastral = empresa.situacaoCadastral ? 1 : 0;
			this._idEmpresaAtualizar = empresa.id;
			this._modeloEmpresa(new JSONModel(empresa));
		},
		_populaTelaComValoresEnderecoDaEmpresaEditar: async function (id) {;
			let endereco = await ServicoEnderecos.obterEnderecoPorId(id);
			this._idEnderecoAtualizar = id;
			this._modeloEnderecoEmpresa(new JSONModel(endereco));
		},
		_retornaValoresEndereco() {
			
			return this._modeloEnderecoEmpresa(undefined).getData();
		},
		aoPressionarSalvar: async function () {
			let textoErro = "";
			let i18nMensagemDeErro;
			if (this._rotaAtual == "EmpresaCriar") {
				i18nMensagemDeErro = "CriarEditarEmpresas.ErroAoTentarCriarEmpresa";
			}
			else {
				i18nMensagemDeErro = "CriarEditarEmpresas.ErroTentarEditarEmpresa";
			}
			this.trataErros(i18nMensagemDeErro, async () => {	
				debugger;
				let respostaEndereco;
				let respostaEmpresa;
				if (this._rotaAtual == "EmpresaCriar") {
					const modelo = this.modeloValoresPadrao(undefined);
					respostaEndereco = await ServicoEnderecos.criarEndereco(this._retornaValoresEndereco(), modelo);
					let empresaCriar = this._retornaValoresEmpresa();
					empresaCriar.idEndereco = respostaEndereco.id;
					respostaEmpresa = await ServicoEmpresas.criarEmpresa(empresaCriar, modelo);
				}
				else {
					respostaEndereco = this._retornaValoresEndereco();
					respostaEndereco.id = this._idEnderecoAtualizar;
					respostaEndereco = await ServicoEnderecos.editarEndereco(respostaEndereco);
					let empresaEditar = this._retornaValoresEmpresa();
					empresaEditar.id = this._idEmpresaAtualizar;
					empresaEditar.idEndereco = this._idEnderecoAtualizar;
					respostaEmpresa = await ServicoEmpresas.editarEmpresa(empresaEditar);
				}
				const status500 = 500;
				const status400 = 400;
				if (respostaEndereco != undefined) {
					if (respostaEndereco.status != undefined &&
						respostaEndereco.status == status400) {
						textoErro += this.retornaTextoErro(respostaEndereco);
					}
					if (respostaEndereco.Status != undefined &&
						respostaEndereco.Status == status500) {
						textoErro += respostaEndereco.Detail;
					}
					if (respostaEndereco.ok != undefined && !respostaEndereco.ok ||
						respostaEndereco.status != undefined
					) {
						throw new Error(textoErro);
					}
				}
				if (respostaEmpresa != undefined) {
					if (respostaEmpresa.status != undefined &&
						respostaEmpresa.status == status400) {
						textoErro += this.retornaTextoErro(respostaEmpresa);
					}
					if (respostaEmpresa.Status != undefined &&
						respostaEmpresa.Status == status500) {
						textoErro += respostaEmpresa.Detail;
					}
					if (this._rotaAtual == "EmpresaCriar" &&
						respostaEmpresa.id == undefined &&
						respostaEndereco != undefined &&
						respostaEndereco.Status == undefined) {
						ServicoEnderecos.deletarEndereco(respostaEndereco.id);
					}
					if (respostaEmpresa.Status != undefined||
						respostaEmpresa.status != undefined
					) {
						throw new Error(textoErro);
					}
				}
				this.aoPressionarBotaoDeNavegacao();

			});
		},

		aoPressionarBotaoDeNavegacao() {
			let i18nMensagemDeErro = "CriarEditarEmpresas.ErroAoClicarBotaoNavegacao";
			this.trataErros(i18nMensagemDeErro, () => {
				const historico = History.getInstance();
				const hashAnterior = historico.getPreviousHash();
				if (hashAnterior != undefined) {
					window.history.go(-1);
				}
				else {
					const roteador = this.getOwnerComponent().getRouter();
					const nomeRotaEmpresas = "Empresas";
					roteador.navTo(nomeRotaEmpresas, {}, {}, true);
				}
			})
		},	
		_modeloEnderecoEmpresa: function(modelo) {
			const nomeModelo = "EnderecoEmpresaCriarEditar";
			return this.modelo(nomeModelo, modelo);
		},
		_modeloEmpresa: function(modelo) {
			const nomeModelo = "EmpresaCriarEditar";	
			return this.modelo(nomeModelo, modelo);
		}
	});
});