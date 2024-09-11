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
        mostraMensagemDeErro(mensagemDeErro, erro) {
            MessageBox.show(erro.message, {
                icon: MessageBox.Icon.ERROR,
                title: mensagemDeErro,
                actions: [MessageBox.Action.CLOSE]
            });
        },
        retornaTextoErro(resposta) {
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
        trataErros(nomeModeloTituloErro, funcao) {
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
                        this.mostraMensagemDeErro(TituloErro, erroPego);
                    }
                });
        },

        modeloValoresPadrao: function (modelo) {
            const nomeModelo = "valoresPadrao";
            return this.modelo(nomeModelo, modelo);
        },
        _modeloEstados: function () {
            const nomeModelo = "estados";
            return this.getOwnerComponent().getModel(nomeModelo);
        },
        _modeloHabilitado: function () {
            const nomeModelo = "habilitado";
            return this.getOwnerComponent().getModel(nomeModelo);
        },
        _modeloNaturezaJuridica: function () {
            const nomeModelo = "naturezaJuridica";
            return this.getOwnerComponent().getModel(nomeModelo);
        },
        _modeloOrganizacaoAcademica: function () {
            const nomeModelo = "organizacaoAcademica";
            return this.getOwnerComponent().getModel(nomeModelo);
        },
        _modeloPorte: function () {
            const nomeModelo = "porte";
            return this.getOwnerComponent().getModel(nomeModelo);
        },
        _modeloMatrizFilial: function () {
            const nomeModelo = "matrizFilial";
            return this.getOwnerComponent().getModel(nomeModelo);
        },
        _modeloCategoriaAdministrativa: function () {
            const nomeModelo = "categoriaAdministrativa";
            return this.getOwnerComponent().getModel(nomeModelo);
        },
        textoEstado: function (codigo) {
            const modelo = this._modeloEstados().getData();
            return this._filtraEnum(modelo.Estados, codigo).Valor;
        },
        textoCategoriaAdministrativa: function (codigo) {
            const modelo = this._modeloCategoriaAdministrativa().getData();
            return this._filtraEnum(modelo.CategoriaAdministrativa, codigo).Valor;
        },
        textoHabilitado: function (codigo) {
            const modelo = this._modeloHabilitado().getData();
            if (codigo)
                codigo = 1;
            else
                codigo = 0;
            return this._filtraEnum(modelo.Habilitado, codigo).Valor;
        },
        textoNaturezaJuridica: function (codigo) {
            const modelo = this._modeloNaturezaJuridica().getData();
            return this._filtraEnum(modelo.NaturezaJuridica, codigo).Valor;
        },
        textoOrganizacaoAcademica: function (codigo) {
            const modelo = this._modeloOrganizacaoAcademica().getData();
            return this._filtraEnum(modelo.OrganizacaoAcademica, codigo).Valor;
        },
        textoPorte: function (codigo) {
            const modelo = this._modeloPorte().getData();
            return this._filtraEnum(modelo.Porte, codigo).Valor;
        },
        textoMatrizFilial: function (codigo) {
            const modelo = this._modeloMatrizFilial().getData();
            return this._filtraEnum(modelo.MatrizFilial, codigo).Valor;
        },
        _filtraEnum: function (array, codigo) {
            let item = array.filter((items) => {
                return items.Codigo == codigo;
            });
            return item[0];
        }
    });
});