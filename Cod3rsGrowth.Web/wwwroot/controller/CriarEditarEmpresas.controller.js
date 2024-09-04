sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/ui/core/routing/History",
	"ui5/cod3rsgrowth/modelos/Servicos/ServicoEmpresas",
	"sap/viz/ui5/types/layout/Stack",
	"ui5/cod3rsgrowth/modelos/Servicos/ServicoEnderecos",
	"sap/ui/core/date/UI5Date",
	"sap/m/MessageBox"
], function (
	Controller,
	History,
	ServicoEmpresas,
	Stack,
	ServicoEnderecos,
	UI5Date,
	MessageBox
) {
	"use strict";

	return Controller.extend("ui5.cod3rsgrowth.controller.CriarEditarEmpresas", {

		_nomePropriedadeCepEmpresa: "/cepEmpresaEntrado",
		_nomePropriedadeEstadoEmpresa: "/estadoSelecionadoEmpresa",
		_nomePropriedadeMunicipioEmpresa: "/municipioEmpresaEntrado",
		_nomePropriedadeBairroEmpresa: "/bairroEmpresaEntrado",
		_nomePropriedadeRuaEmpresa: "/ruaEmpresaEntrado",
		_nomePropriedadeNumeroEmpresa: "/numeroEmpresaEntrado",
		_nomePropriedadeComplementoEmpresa: "/complementoEmpresaEntrado",
		_nomePropriedadeRazaoSocialEmpresa: "/razaoSocialEmpresaEntrada",
		_nomePropriedadeNomeFantasiaEmpresa: "/nomeFantasiaEmpresaEntrada",
		_nomePropriedadeCnpjEmpresa: "/cnpjEmpresaEntrada",
		_nomePropriedadeCapitalSocialEmpresa: "/capitalSocialEmpresaEntrada",
		_nomePropriedadeNaturezaJuridicaEmpresa: "/naturezaJuridicaSelecionada",
		_nomePropriedadePorteEmpresa: "/porteSelecionado",
		_nomePropriedadeMatrizFilialEmpresa: "/matrizFilialSelecionado",
		_nomePropriedadeSituacaoCadastralEmpresa: "/situacaoCadastralSelecionado",
		_nomePropriedadeDataAberturaEmpresa: "/dataAberturaSelecionada",
		_rotaAtual: "",
		_nomeModeloI18n: "i18n",
		_idCriarEditarEmpresas: "criarEditarEmpresas",
		onInit() {
			const nomeRotaEmpresaCriar = "EmpresaCriar";
			const roteador = this.getOwnerComponent().getRouter();
			roteador.getRoute(nomeRotaEmpresaCriar).attachMatched(this._aoCoincidirComRotaEmpresaCriar, this);
		},
		_aoCoincidirComRotaEmpresaCriar(oEvent) {
			try {
				const idDataAberturaDatePicker = "dataAberturaDatePicker";
				const parametroNomeRota = "name";
				this._rotaAtual = oEvent.getParameter(parametroNomeRota);
				const i18TituloEmpresaCriar = "CriarEditarEmpresas.TituloCriar";
				let i18n = this.getOwnerComponent().getModel(this._nomeModeloI18n).getResourceBundle();
				this.byId(this._idCriarEditarEmpresas).setTitle(i18n.getText(i18TituloEmpresaCriar));
				let dataAtual = new Date();
				this.byId(idDataAberturaDatePicker).setMaxDate(
					UI5Date.getInstance(
						dataAtual.getFullYear(),
						dataAtual.getMonth(),
						dataAtual.getDay()));
			}
			catch (erro) {
				const i18nMensagemDeErro = "CriarEditarEmpresas.ErroCoincidirRotaCriar";
				const i18n = this.getOwnerComponent().getModel(this._nomeModeloI18n).getResourceBundle();
				const mensagemDeErro = i18n.getText(i18nMensagemDeErro);
				this._mostraMensagemDeErro(mensagemDeErro, erro);
			}
		},
		_retornaValoresEmpresa() {
			const modelo = this.getView().getModel();
			return {
				razaoSocial: modelo.getProperty(this._nomePropriedadeRazaoSocialEmpresa),
				nomeFantasia: modelo.getProperty(this._nomePropriedadeNomeFantasiaEmpresa),
				cnpj: String(modelo.getProperty(this._nomePropriedadeCnpjEmpresa)),
				situacaoCadastral: modelo.getProperty(this._nomePropriedadeSituacaoCadastralEmpresa),
				dataSituacaoCadastral: new Date(),
				dataAbertura: modelo.getProperty(this._nomePropriedadeDataAberturaEmpresa),
				naturezaJuridica: modelo.getProperty(this._nomePropriedadeNaturezaJuridicaEmpresa),
				porte: modelo.getProperty(this._nomePropriedadePorteEmpresa),
				matrizFilial: modelo.getProperty(this._nomePropriedadeMatrizFilialEmpresa),
				capitalSocial: modelo.getProperty(this._nomePropriedadeCapitalSocialEmpresa),
				idEndereco: 0
			}
			const i18nMensagemDeErro = "CriarEditarEmpresas.ErroRecebeDadosTela";
			const i18n = this.getOwnerComponent().getModel(this._nomeModeloI18n).getResourceBundle();
			const mensagemDeErro = i18n.getText(i18nMensagemDeErro);
			this._mostraMensagemDeErro(mensagemDeErro, erro);
		},
		_retornaValoresEndereco() {
			const modelo = this.getView().getModel();
			return {
				numero: String(modelo.getProperty(this._nomePropriedadeNumeroEmpresa)),
				cep: String(modelo.getProperty(this._nomePropriedadeCepEmpresa)),
				municipio: modelo.getProperty(this._nomePropriedadeMunicipioEmpresa),
				bairro: modelo.getProperty(this._nomePropriedadeBairroEmpresa),
				rua: modelo.getProperty(this._nomePropriedadeRuaEmpresa),
				complemento: modelo.getProperty(this._nomePropriedadeComplementoEmpresa),
				estado: modelo.getProperty(this._nomePropriedadeEstadoEmpresa)
			}
			const i18nMensagemDeErro = "CriarEditarEmpresas.ErroRecebeDadosTela";
			const i18n = this.getOwnerComponent().getModel(this._nomeModeloI18n).getResourceBundle();
			const mensagemDeErro = i18n.getText(i18nMensagemDeErro);
			this._mostraMensagemDeErro(mensagemDeErro, erro);
		},
		aoPressionarSalvar: async function () {
			let respostaEndereco;
			let textoErro = "";
			try {
				if (this._rotaAtual == "EmpresaCriar") {
					respostaEndereco = await ServicoEnderecos.criarEndereco(this._retornaValoresEndereco());
					let empresaCriar = this._retornaValoresEmpresa();
					debugger;
					empresaCriar.idEndereco = respostaEndereco.id;
					let respostaEmpresa = await ServicoEmpresas.criarEmpresa(empresaCriar)
					debugger;
					if (!respostaEmpresa.ok && !respostaEndereco.ok &&
						respostaEmpresa.ok != undefined && respostaEndereco.ok != undefined ||
						respostaEmpresa.Status != undefined || respostaEndereco.Status != undefined) {
						debugger;
						const status500 = 500;
						const status400 = 400;
						if (respostaEndereco.Status == undefined) {
							ServicoEnderecos.deletarEndereco(respostaEndereco.id);
						}
						if (respostaEmpresa.Status == status400) {
							textoErro += this._retornaTextoErro(respostaEmpresa);
						}
						if (respostaEmpresa.Status == status500) {
							textoErro += respostaEmpresa.Detail;
						}
						if (respostaEndereco.Status == status400) {
							textoErro += this._retornaTextoErro(respostaEndereco);
						}
						if (respostaEndereco.Status == status500) {
							textoErro += respostaEndereco.Detail;
						}

						throw new Error(textoErro);
					}
					this.aoPressionarBotaoDeNavegacao();
				}
			} catch (erro) {
				let i18nMensagemDeErro;
				if (this._rotaAtual == "EmpresaCriar") {
					i18nMensagemDeErro = "CriarEditarEmpresas.ErroAoTentarCriarEmpresa";
				}
				else {
					i18nMensagemDeErro = "CriarEditarEmpresas.ErroTentarEditarEmpresa";
				}
				const i18n = this.getOwnerComponent().getModel(this._nomeModeloI18n).getResourceBundle();
				const mensagemDeErro = i18n.getText(i18nMensagemDeErro);
				this._mostraMensagemDeErro(mensagemDeErro, erro);
			}
		},

		aoPressionarBotaoDeNavegacao() {

			const historico = History.getInstance();
			const hashAnterior = historico.getPreviousHash();
			const modelo = this.getView().getModel();
			modelo.setProperty(this._nomePropriedadeRazaoSocialEmpresa, undefined);
			modelo.setProperty(this._nomePropriedadeNomeFantasiaEmpresa, undefined);
			modelo.setProperty(this._nomePropriedadeCnpjEmpresa, undefined);
			modelo.setProperty(this._nomePropriedadeSituacaoCadastralEmpresa, undefined);
			modelo.setProperty(this._nomePropriedadeDataAberturaEmpresa, undefined);
			modelo.setProperty(this._nomePropriedadeNaturezaJuridicaEmpresa, undefined);
			modelo.setProperty(this._nomePropriedadePorteEmpresa, undefined);
			modelo.setProperty(this._nomePropriedadeMatrizFilialEmpresa, undefined);
			modelo.setProperty(this._nomePropriedadeCapitalSocialEmpresa, undefined);
			modelo.setProperty(this._nomePropriedadeNumeroEmpresa, undefined);
			modelo.setProperty(this._nomePropriedadeCepEmpresa, undefined);
			modelo.setProperty(this._nomePropriedadeMunicipioEmpresa, undefined);
			modelo.setProperty(this._nomePropriedadeBairroEmpresa, undefined);
			modelo.setProperty(this._nomePropriedadeRuaEmpresa, undefined);
			modelo.setProperty(this._nomePropriedadeComplementoEmpresa, undefined);
			modelo.setProperty(this._nomePropriedadeEstadoEmpresa, undefined);
			if (hashAnterior != undefined) {
				window.history.go(-1);
			}
			else {
				const roteador = this.getOwnerComponent().getRouter();
				roteador.navTo("Empresas", {}, {}, true);
			}
		},
		_mostraMensagemDeErro(mensagemDeErro, erro) {
			debugger;
			console.error(mensagemDeErro + erro.message);
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
		}
	});
});