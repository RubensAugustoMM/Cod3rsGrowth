sap.ui.define([
    "sap/ui/base/Object",
    "sap/ui/model/json/JSONModel",
    "./ServicoConvenios",
    "ui5/cod3rsgrowth/utilitarios/config"
], function (
    baseObject,
    JSONModel,
    ServicoConvenios,
    config
) {
    "use strict";
    var commonAPIs =
    {
        baseData: {
            convenios: []
        },
        /**
         * @override
         * @returns {sap.ui.base.Object}
         */
        constructor: function (oComp) {
            this.oComp = oComp;
            var oModel = new JSONModel(jQuery.extend(true, {}, this.baseData));
            this.oComp.setModel(oModel);
        },
        getDataModel : function()
        {
            return this.oComp.getModel();
        }
    },

        oServicoFinal = jQuery.extend(true, commonAPIs, ServicoConvenios, config),
        oServico = baseObject.extend("ui5.cod3rsgrowth.modelos.DataRepository", oServicoFinal)
    return oServico;
});