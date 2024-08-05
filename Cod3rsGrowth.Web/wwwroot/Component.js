sap.ui.define([
    "sap/ui/core/UIComponent",
   "sap/ui/model/resource/ResourceModel",
   "ui5/cod3rsgrowth/modelos/DataRepository"
], (UIComponent,
	ResourceModel,
	DataRepository) => {
    "use strict";

    return UIComponent.extend("ui5.cod3rsgrowth.Component", {
        metadata : {
            interfaces: ["sap.ui.core.IAsyncContentCreation"],
            manifest: "json"
         },

        init() {
            UIComponent.prototype.init.apply(this, arguments);
             // set i18n model
             const i18nModel = new ResourceModel({
                bundleName: "ui5.cod3rsgrowth.i18n.i18n"
             });
             this.setModel(i18nModel, "i18n");

            this.DataRepository = new DataRepository(this);

            this.getRouter().initialize();
        }
    });
});
