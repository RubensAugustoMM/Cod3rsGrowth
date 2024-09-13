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
			
			this.modeloEmpresa(new JSONModel(dadosEmpresa));
			const dadosEstado = {
				cep:undefined,
				estado:undefined,
				municipio:undefined,
				bairro:undefined,
				rua:undefined,
				numero:undefined,
				complemento:undefined
			}
			this.modeloEndereco(new JSONModel(dadosEstado));
		},
		_aoCoincidirComRotaEmpresaEditar(oEvent) {
			const i18nMensagemDeErro = "CriarEditarEmpresas.ErroCoincidirRotaEditar";
			const parametroNomeRota = "name";
			this._rotaAtual = oEvent.getParameter(parametroNomeRota);
			this.tratarErros(i18nMensagemDeErro,async () => {
				const nomeArgumentosCaminhoEmpresa = "arguments";
				let idEmpresa = oEvent.getParameter(nomeArgumentosCaminhoEmpresa).caminhoEmpresa;
				let empresa = await ServicoEmpresas.obterEmpresaPorId(idEmpresa);
				this._popularTelaComValoresEmpresaEditar(empresa);
				this._popularTelaComValoresEnderecoDaEmpresaEditar(empresa.idEndereco);
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
			this.tratarErros(i18nMensagemDeErro, () => {
				const i18TituloEmpresaCriar = "CriarEditarEmpresas.TituloCriar";
				const i18n = this.modeloI18n();
				this.byId(this._idCriarEditarEmpresas).setTitle(i18n.getText(i18TituloEmpresaCriar));
			});
		},
		_obterValoresEmpresaDaTela(){
			let valoresEmpresa =  this.modeloEmpresa().getData(); 
			const valorHabilitado = 1;
			valoresEmpresa.situacaoCadastral =
				valoresEmpresa.situacaoCadastral == valorHabilitado ? true : false;
			valoresEmpresa.dataSituacaoCadastral = new Date();
			return valoresEmpresa;
		},
		_popularTelaComValoresEmpresaEditar: async function (empresa) {
			empresa.situacaoCadastral = empresa.situacaoCadastral ? 1 : 0;
			this._idEmpresaAtualizar = empresa.id;
			this.modeloEmpresa(new JSONModel(empresa));
		},
		_popularTelaComValoresEnderecoDaEmpresaEditar: async function (id) {;
			let endereco = await ServicoEnderecos.obterEnderecoPorId(id);
			this._idEnderecoAtualizar = id;
			this.modeloEndereco(new JSONModel(endereco));
		},
		_obterValoresEnderecoDaTela() {	
			return this.modeloEndereco().getData();
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
			this.tratarErros(i18nMensagemDeErro, async () => {	
				let respostaEndereco;
				let respostaEmpresa;
				if (this._rotaAtual == "EmpresaCriar") {
					const modelo = this.modeloValoresPadrao();
					respostaEndereco = await ServicoEnderecos.criarEndereco(this._obterValoresEnderecoDaTela(), modelo);
					let empresaCriar = this._obterValoresEmpresaDaTela();
					empresaCriar.idEndereco = respostaEndereco.id;
					respostaEmpresa = await ServicoEmpresas.criarEmpresa(empresaCriar, modelo);
				}
				else {
					respostaEndereco = this._obterValoresEnderecoDaTela();
					respostaEndereco.id = this._idEnderecoAtualizar;
					respostaEndereco = await ServicoEnderecos.editarEndereco(respostaEndereco);
					let empresaEditar = this._obterValoresEmpresaDaTela();
					empresaEditar.id = this._idEmpresaAtualizar;
					empresaEditar.idEndereco = this._idEnderecoAtualizar;
					respostaEmpresa = await ServicoEmpresas.editarEmpresa(empresaEditar);
				}
				const status500 = 500;
				const status400 = 400;
				if (respostaEndereco != undefined) {
					if (respostaEndereco.status != undefined &&
						respostaEndereco.status == status400) {
						textoErro += this.formatarMensagemDeErro(respostaEndereco);
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
						textoErro += this.formatarMensagemDeErro(respostaEmpresa);
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
			this.tratarErros(i18nMensagemDeErro, () => {
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
		}
	});
});