sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/ui/core/routing/History",
	"ui5/cod3rsgrowth/modelos/Servicos/ServicoEmpresas",
	"sap/viz/ui5/types/layout/Stack",
	"ui5/cod3rsgrowth/modelos/Servicos/ServicoEnderecos",
	"sap/ui/core/date/UI5Date",
	"sap/m/MessageBox",
	"sap/ui/model/json/JSONModel"
], function (
	Controller,
	History,
	ServicoEmpresas,
	Stack,
	ServicoEnderecos,
	UI5Date,
	MessageBox,
	JSONModel
) {
	"use strict";

	const NOME_ROTA_EMPRESA_EDITAR = "EmpresaEditar";
	const NOME_MODELO_EMPRESA = "EmpresaCriarEditar";
	const NOME_MODELO_ENDERECO_EMPRESA = "EnderecoEmpresaCriarEditar";
	const NOME_MODELO_VALORES_PADRAO = "valoresPadrao";
	return Controller.extend("ui5.cod3rsgrowth.controller.CriarEditarEmpresas", {
		_idEmpresaAtualizar: 0,
		_idEnderecoAtualizar: 0,
		_rotaAtual: "",
		_nomeModeloI18n: "i18n",
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
			var modeloEmpresa =  new JSONModel(dadosEmpresa);
			this.getView().setModel(modeloEmpresa, NOME_MODELO_EMPRESA);
			const dadosEstado = {
				cep:undefined,
				estado:undefined,
				municipio:undefined,
				bairro:undefined,
				rua:undefined,
				numero:undefined,
				complemento:undefined
			}
			var modeloEstadoEmpresa = new JSONModel(dadosEstado);
			this.getView().setModel(modeloEstadoEmpresa, NOME_MODELO_ENDERECO_EMPRESA);
		},
		_aoCoincidirComRotaEmpresaEditar(oEvent) {
			this._configuraModeloDeDadosDaTela();
			const i18nMensagemDeErro = "CriarEditarEmpresas.ErroCoincidirRotaEditar";
			const parametroNomeRota = "name";
			this._rotaAtual = oEvent.getParameter(parametroNomeRota);
			this._trataErros(i18nMensagemDeErro,async () => {
				const nomeArgumentosCaminhoEmpresa = "arguments";
				let idEmpresa = oEvent.getParameter(nomeArgumentosCaminhoEmpresa).caminhoEmpresa;
				let empresa = await ServicoEmpresas.obterEmpresaPorId(idEmpresa);
				this._populaTelaComValoresEmpresaEditar(empresa);
				this._populaTelaComValoresEnderecoDaEmpresaEditar(empresa.idEndereco);
				const i18TituloEmpresaEditar = "CriarEditarEmpresas.TituloEditar";
				const i18n = this._retornaModeloI18n();
				this.byId(this._idCriarEditarEmpresas).setTitle(i18n.getText(i18TituloEmpresaEditar));
			});
		},
		_aoCoincidirComRotaEmpresaCriar(oEvent) {
			this._configuraModeloDeDadosDaTela();
			const i18nMensagemDeErro = "CriarEditarEmpresas.ErroCoincidirRotaCriar";
			const parametroNomeRota = "name";
			this._rotaAtual = oEvent.getParameter(parametroNomeRota);
			this._trataErros(i18nMensagemDeErro, () => {
				const i18TituloEmpresaCriar = "CriarEditarEmpresas.TituloCriar";
				const i18n = this._retornaModeloI18n();
				this.byId(this._idCriarEditarEmpresas).setTitle(i18n.getText(i18TituloEmpresaCriar));
			});
		},
		_retornaValoresEmpresa(){
			let valoresEmpresa =  this.getView().getModel(NOME_MODELO_EMPRESA).getData(); 
			valoresEmpresa.situacaoCadastral = valoresEmpresa.situacaoCadastral == 1 ? true : false;
			valoresEmpresa.dataSituacaoCadastral = new Date();
			return valoresEmpresa;
		},
		_populaTelaComValoresEmpresaEditar: async function (empresa) {
			empresa.situacaoCadastral = empresa.situacaoCadastral ? 1 : 0;
			empresa = new JSONModel(empresa); 
			this.getView().setModel(empresa, NOME_MODELO_EMPRESA);
		},
		_populaTelaComValoresEnderecoDaEmpresaEditar: async function (id) {;
			let endereco = await ServicoEnderecos.obterEnderecoPorId(id);
			this._idEnderecoAtualizar = id;
			endereco = new JSONModel(endereco);
			this.getView().setModel(endereco, NOME_MODELO_ENDERECO_EMPRESA);
		},
		_retornaValoresEndereco() {
			return this.getView().getModel(NOME_MODELO_ENDERECO_EMPRESA).getData();
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
			this._trataErros(i18nMensagemDeErro, async () => {	
				let respostaEndereco;
				let respostaEmpresa;
				if (this._rotaAtual == "EmpresaCriar") {
					const modelo = this.getView().getModel(NOME_MODELO_VALORES_PADRAO);
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
						textoErro += this._retornaTextoErro(respostaEndereco);
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
						textoErro += this._retornaTextoErro(respostaEmpresa);
					}
					if (respostaEmpresa.Status != undefined &&
						respostaEmpresa.Status == status500) {
						textoErro += respostaEmpresa.Detail;
					}
					if (this._rotaAtual == "EmpresaCriar" &&
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
			this._trataErros(i18nMensagemDeErro, () => {
				const historico = History.getInstance();
				const hashAnterior = historico.getPreviousHash();
				const modelo = this.getView().getModel();
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
		_mostraMensagemDeErro(mensagemDeErro, erro) {
			MessageBox.show(erro.message, {
				icon: MessageBox.Icon.ERROR,
				title: mensagemDeErro,
				actions: [MessageBox.Action.CLOSE]
			});
		},
		_retornaTextoErro(resposta) {
			let textoRetorno = "";
			const chavesErro = Object.keys(resposta.errors);
			chavesErro.forEach((erro => {
				textoRetorno += `${erro}:\n`;
				resposta.errors[erro].forEach((erro => {
					textoRetorno += erro + "\n";
				}));
			}));
			return textoRetorno;
		},
		_trataErros(nomeModeloTituloErro, funcao) {
			const modelo = this.getView().getModel();
			const nomePropriedadeOcupado = "/ocupado";
			modelo.setProperty(nomePropriedadeOcupado, true);
			let erroPego;
			return Promise.resolve(funcao())
				.catch(erro => {
					erroPego = erro;
				})
				.finally(() => {
					modelo.setProperty(nomePropriedadeOcupado, false)
					if (erroPego != null) {
						const i18n = this._retornaModeloI18n();
						const TituloErro = i18n.getText(nomeModeloTituloErro);
						this._mostraMensagemDeErro(TituloErro, erroPego);
					}
				});
		},
		_retornaModeloI18n() {
			return this.getOwnerComponent().getModel(this._nomeModeloI18n).getResourceBundle();
		}
	});
});