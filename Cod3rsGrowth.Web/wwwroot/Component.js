sap.ui.define([
    "sap/ui/core/UIComponent",
    "sap/ui/model/resource/ResourceModel",
    "sap/ui/model/json/JSONModel",
    "sap/ui/Device",
    "ui5/cod3rsgrowth/modelos/Repositorios/ServicoEnums",
], (UIComponent,
    ResourceModel,
    JSONModel,
	Device,
	ServicoEnums,) => {
    "use strict";

    return UIComponent.extend("ui5.cod3rsgrowth.Component", {
        metadata : {
            interfaces: ["sap.ui.core.IAsyncContentCreation"],
            manifest: "json"
         },

        async init() {
            UIComponent.prototype.init.apply(this, arguments);
             const modeloI18n = new ResourceModel({
                bundleName: "ui5.cod3rsgrowth.i18n.i18n"
             });

            const modelo = new JSONModel();
            this.setModel(modelo);

            let nomeModeloi18n = "i18n";
            this.setModel(modeloI18n, nomeModeloi18n); 

            let nomeModeloSituacaoCadastral = "habilitado"; 
            let modeloSituacaoCadastral =
                new JSONModel(await ServicoEnums.retornaModeloHabilitadoEnum());
            this.setModel(modeloSituacaoCadastral, nomeModeloSituacaoCadastral);

            let nomeModeloNaturezaJuridica = "naturezaJuridica";
            let modeloNaturezaJuridica =
                new JSONModel(await ServicoEnums.retornaModeloNaturezaJuridicaEnum());
            this.setModel(modeloNaturezaJuridica, nomeModeloNaturezaJuridica);

            let nomeModeloOrganizacaoAcademica = "organizacaoAcademica";
            let modeloOrganizacaoAcademica =
                new JSONModel(await ServicoEnums.retornaModeloOrganizacaoAcademicaEnum());
            this.setModel(modeloOrganizacaoAcademica, nomeModeloOrganizacaoAcademica);

            let nomeModeloEstados = "estados";
            let modeloEstados =
                new JSONModel(await ServicoEnums.retornaModeloEstadoEnum());
            this.setModel(modeloEstados, nomeModeloEstados);

            this.getRouter().initialize();
        }
    });
});
