sap.ui.define(["sap/m/MessageBox"
], function (
    MessageBox) {
    "use strict";

    return {
        urlBase: "/api",
        async retornaModeloEstadoEnum() {
            try {
                const rotaEnum = "/EstadoEnum";
                const resposta = await fetch(this.urlBase + rotaEnum);
                if (!resposta.ok) throw new Error(resposta.status);
                return await resposta.json();
            }
            catch (erro) {
                const nomeModeloI18n = "i18n";
                const i18nMensagemDeErro = "ServicoEnums.ErroRetornaEstadoEnum";
                const i18n = this.getOwnerComponent().getModel(nomeModeloI18n).getResourceBundle();
                const mensagemDeErro = i18n.getText(i18nMensagemDeErro);
                this._mostraMensagemDeErro(mensagemDeErro, erro);
            }
        },
        async retornaModeloHabilitadoEnum() {
            try {
                const rotaEnum = "/HabilitadoEnum";
                const resposta = await fetch(this.urlBase + rotaEnum);
                if (!resposta.ok) throw new Error(resposta.status);
                return await resposta.json();
            }
            catch (erro) {
                const nomeModeloI18n = "i18n";
                const i18nMensagemDeErro = "ServicoEnums.ErroRetornaHabilitadoEnum";
                const i18n = this.getOwnerComponent().getModel(nomeModeloI18n).getResourceBundle();
                const mensagemDeErro = i18n.getText(i18nMensagemDeErro);
                this._mostraMensagemDeErro(mensagemDeErro, erro);
            }
        },
        async retornaModeloNaturezaJuridicaEnum() {
            try {
                const rotaEnum = "/NaturezaJuridicaEnum";
                const resposta = await fetch(this.urlBase + rotaEnum);
                if (!resposta.ok) throw new Error(resposta.status);
                return await resposta.json();
            }
            catch (erro) {
                const nomeModeloI18n = "i18n";
                const i18nMensagemDeErro = "ServicoEnums.ErroRetornaNaturezaJuridicaEnum";
                const i18n = this.getOwnerComponent().getModel(nomeModeloI18n).getResourceBundle();
                const mensagemDeErro = i18n.getText(i18nMensagemDeErro);
                this._mostraMensagemDeErro(mensagemDeErro, erro);
            }
        },
        async retornaModeloOrganizacaoAcademicaEnum() {
            try {
                const rotaEnum = "/OrganizacaoAcademicaEnum";
                const resposta = await fetch(this.urlBase + rotaEnum);
                if (!resposta.ok) throw new Error(resposta.status);
                return await resposta.json();
            }
            catch (erro) {
                const nomeModeloI18n = "i18n";
                const i18nMensagemDeErro = "ServicoEnums.ErroRetornaOrganizacaoAcademicaEnum";
                const i18n = this.getOwnerComponent().getModel(nomeModeloI18n).getResourceBundle();
                const mensagemDeErro = i18n.getText(i18nMensagemDeErro);
                this._mostraMensagemDeErro(mensagemDeErro, erro);
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
    }
});