sap.ui.define([
    "sap/ui/core/mvc/Controller",
    "sap/m/MessageBox"
], function (
    Controller,
    MessageBox
) {
    "use strict";

    return Controller.extend("ui5.cod3rsgrowth.controller.ControllerBase", {
        obterModelo: function (nome, modelo) {
            let view = this.getView();
            if (modelo != undefined) view.setModel(modelo, nome);
            return view.getModel(nome);
        },
        obterModeloI18n: function () {
            const nomeModelo = "i18n";
            return this.getOwnerComponent().getModel(nomeModelo).getResourceBundle();
        },
        obterModeloPadrao: function () {
            return this.getView().getModel();
        },
        mostraMensagemDeErro(mensagemDeErro, erro) {
            MessageBox.show(erro.message, {
                icon: MessageBox.Icon.ERROR,
                title: mensagemDeErro,
                actions: [MessageBox.Action.CLOSE]
            });
        },
        formatarMensagemDeErro(resposta) {
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
        tratarErros(nomeModeloTituloErro, funcao) {
            const modeloPadrao = this.obterModeloPadrao();
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
                        const i18n = this.obterModeloI18n();
                        const TituloErro = i18n.getText(nomeModeloTituloErro);
                        this.mostraMensagemDeErro(TituloErro, erroPego);
                    }
                });
        },

        obterModeloValoresPadrao: function (modelo) {
            const nomeModelo = "valoresPadrao";
            return this.obterModelo(nomeModelo, modelo);
        },
        _obterModeloEstados: function () {
            const nomeModelo = "estados";
            return this.getOwnerComponent().getModel(nomeModelo);
        },
        _obterModeloHabilitado: function () {
            const nomeModelo = "habilitado";
            return this.getOwnerComponent().getModel(nomeModelo);
        },
        _obterModeloNaturezaJuridica: function () {
            const nomeModelo = "naturezaJuridica";
            return this.getOwnerComponent().getModel(nomeModelo);
        },
        _obterModeloOrganizacaoAcademica: function () {
            const nomeModelo = "organizacaoAcademica";
            return this.getOwnerComponent().getModel(nomeModelo);
        },
        _obterModeloPorte: function () {
            const nomeModelo = "porte";
            return this.getOwnerComponent().getModel(nomeModelo);
        },
        _obterModeloMatrizFilial: function () {
            const nomeModelo = "matrizFilial";
            return this.getOwnerComponent().getModel(nomeModelo);
        },
        _obterModeloCategoriaAdministrativa: function () {
            const nomeModelo = "categoriaAdministrativa";
            return this.getOwnerComponent().getModel(nomeModelo);
        },
        obterTextoDoEstado: function (codigo) {
            const modelo = this._obterModeloEstados().getData();
            return this._filtraModeloEnum(modelo.Estados, codigo).Valor;
        },
        obterTextoDaCategoriaAdministrativa: function (codigo) {
            const modelo = this._obterModeloCategoriaAdministrativa().getData();
            return this._filtraModeloEnum(modelo.CategoriaAdministrativa, codigo).Valor;
        },
        obterTextoDoHabilitado: function (codigo) {
            const modelo = this._obterModeloHabilitado().getData();
            if (codigo)
            {
                const habilitado = 1;
                codigo = habilitado;
            }
            else
            {
                const desabilitado = 0;                
                codigo = desabilitado;
            }
            return this._filtraModeloEnum(modelo.Habilitado, codigo).Valor;
        },
        obterTextoDaNaturezaJuridica: function (codigo) {
            const modelo = this._obterModeloNaturezaJuridica().getData();
            return this._filtraModeloEnum(modelo.NaturezaJuridica, codigo).Valor;
        },
        obterTextoDaOrganizacaoAcademica: function (codigo) {
            const modelo = this._obterModeloOrganizacaoAcademica().getData();
            return this._filtraModeloEnum(modelo.OrganizacaoAcademica, codigo).Valor;
        },
        obterTextoDoPorte: function (codigo) {
            const modelo = this._obterModeloPorte().getData();
            return this._filtraModeloEnum(modelo.Porte, codigo).Valor;
        },
        obterTextoDaMatrizFilial: function (codigo) {
            const modelo = this._obterModeloMatrizFilial().getData();
            return this._filtraModeloEnum(modelo.MatrizFilial, codigo).Valor;
        },
        _filtraModeloEnum: function (array, codigo) {
            let item = array.filter((items) => {
                return items.Codigo == codigo;
            });
            return item[0];
        }
    });
});