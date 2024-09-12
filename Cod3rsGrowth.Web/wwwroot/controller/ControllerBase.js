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
        modeloEmpresa(modelo) {
            const nomeModelo = "empresa";
            return this.modelo(nomeModelo, modelo);
        },
        modeloEndereco(modelo) {
            const nomeModelo = "endereco";
            return this.modelo(nomeModelo, modelo);
        },
		modeloEscola: function (modelo) {
			const nomeModelo = "escola";
			return this.modelo(nomeModelo, modelo);
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
        obterTextoDoEstado: function (codigo) {
            const modelo = this._modeloEstados().getData();
            return this._filtraModeloEnum(modelo.Estados, codigo).Valor;
        },
        obterTextoDaCategoriaAdministrativa: function (codigo) {
            const modelo = this._modeloCategoriaAdministrativa().getData();
            return this._filtraModeloEnum(modelo.CategoriaAdministrativa, codigo).Valor;
        },
        obterTextoDoHabilitado: function (codigo) {
            const modelo = this._modeloHabilitado().getData();
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
            const modelo = this._modeloNaturezaJuridica().getData();
            return this._filtraModeloEnum(modelo.NaturezaJuridica, codigo).Valor;
        },
        obterTextoDaOrganizacaoAcademica: function (codigo) {
            const modelo = this._modeloOrganizacaoAcademica().getData();
            return this._filtraModeloEnum(modelo.OrganizacaoAcademica, codigo).Valor;
        },
        obterTextoDoPorte: function (codigo) {
            const modelo = this._modeloPorte().getData();
            return this._filtraModeloEnum(modelo.Porte, codigo).Valor;
        },
        obterTextoDaMatrizFilial: function (codigo) {
            const modelo = this._modeloMatrizFilial().getData();
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