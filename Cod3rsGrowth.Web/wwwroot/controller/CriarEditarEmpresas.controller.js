sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/ui/core/routing/History"
], function (
	Controller,
	History
) {
	"use strict";

	return Controller.extend("ui5.cod3rsgrowth.controller.CriarEditarEmpresas", {
		_rotaAtual: "",
		_nomeModeloI18n: "i18n",
		_idCriarEditarEmpresas: "criarEditarEmpresas",
		onInit() {
			const nomeRotaEmpresaCriar = "EmpresaCriar";
			try {
				const roteador = this.getOwnerComponent().getRouter();

				roteador.getRoute(nomeRotaEmpresaCriar).attachMatched(this._aoCoincidirComRotaEmpresaCriar, this);
			}
			catch (erro) {
				const i18nMensagemDeErro = "CriarEditarEmpresas.ErroIniciarTela";
				const i18n = this.getOwnerComponent().getModel(this._nomeModeloI18n).getResourceBundle();
				const mensagemDeErro = i18n.getText(i18nMensagemDeErro);
				this._mostraMensagemDeErro(mensagemDeErro, erro);
			}
		},
		_aoCoincidirComRotaEmpresaCriar(oEvent) {
			try {
				const parametroNomeRota = "name";
				this._rotaAtual = oEvent.getParameter(parametroNomeRota);
				const i18TituloEmpresaCriar = "CriarEditarEmpresas.TituloCriar";
				let i18n = this.getOwnerComponent().getModel(this._nomeModeloI18n).getResourceBundle();
				this.byId(this._idCriarEditarEmpresas).setTitle(i18n.getText(i18TituloEmpresaCriar));
			}
			catch (erro) {
				const i18nMensagemDeErro = "CriarEditarEmpresas.ErroCoincidirRotaCriar";
				const i18n = this.getOwnerComponent().getModel(this._nomeModeloI18n).getResourceBundle();
				const mensagemDeErro = i18n.getText(i18nMensagemDeErro);
				this._mostraMensagemDeErro(mensagemDeErro, erro);
			}
		},
		aoPressionarSalvar: async function () {
			try {

			}
			catch (erro) {
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

			if (hashAnterior != undefined) {
				window.history.go(-1);
			}
			else {
				const roteador = this.getOwnerComponent().getRouter();
				roteador.navTo("Empresas", {}, {}, true);
			}
		},
		_mostraMensagemDeErro(mensagemDeErro, erro) {
			console.error(mensagemDeErro + erro.message);
			MessageBox.show(erro.message, {
				icon: MessageBox.Icon.ERROR,
				title: mensagemDeErro,
				actions: [MessageBox.Action.CLOSE]
			});
		}
	});
});