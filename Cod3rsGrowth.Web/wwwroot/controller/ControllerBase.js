sap.ui.define([
    "sap/ui/core/mvc/Controller",
    "sap/m/MessageBox"
], function (
    Controller,
	MessageBox
) {
    "use strict";

    return Controller.extend("ui5.cod3rsgrowth.controller.ControllerBase", {
        modelo: function (nome, modelo) {
            let view = this.getView();
            if (modelo != undefined) view.setModel(modelo, nome);
            return view.getModel(nome);
        },
        modeloI18n: function () {
            const nomeModelo = "i18n";
            return this.getOwnerComponent().getModel(nomeModelo).getResourceBundle();
        },
        modeloPadrao: function () {
            return this.getView().getModel();
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
            const modeloPadrao = this.modeloPadrao();
            const nomePropriedadeOcupado = "/ocupado";
            modeloPadrao.setProperty(nomePropriedadeOcupado, true);
            let erroPego;
            return Promise.resolve(funcao())
                .catch(erro => {
                    erroPego = erro;
                })
                .finally(() => {
                    modeloPadrao.setProperty(nomePropriedadeOcupado, false)
                    if (erroPego != null) {
                        const i18n = this.modeloI18n();
                        const TituloErro = i18n.getText(nomeModeloTituloErro);
                        this._mostraMensagemDeErro(TituloErro, erroPego);
                    }
                });
        },
    });
});