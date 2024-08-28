sap.ui.define(["sap/m/MessageBox"
], function(
	MessageBox) {
    return {
        _urlBase: "api/Empresas",
        _nomeModeloI18n: "i18n",
        
        obterTodasEmpresas: async function (parametroFiltro) {
            try { 
                const resposta = await fetch(this._urlBase + parametroFiltro);
                if (!resposta.ok) throw new Error(resposta.status);
                return await resposta.json();
            }
            catch (erro) {
                const i18nMensagemDeErro = "RepositorioEmpresas.ErroObterTodasEmpresas";
                const i18n = this.getOwnerComponent().getModel(this._nomeModeloI18n).getResourceBundle();
                const mensagemDeErro = i18n.getText(i18nMensagemDeErro);
                this._mostraMensagemDeErro(mensagemDeErro, erro);
            }
        },
        criarEmpresa: async function (parametros) {
            try {
                const resposta = fetch(this._urlBase, {
                    method: "POST",
                    body: JSON.stringify({
                        
                    })
                }) 
            } 
            catch (erro) {
                const i18nMensagemDeErro = "RepositorioEmpresas.ErroCriarEmpresa";
                const i18n = this.getOwnerComponent().getModel(this._nomeModeloI18n).getResourceBundle();
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