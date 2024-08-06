sap.ui.define([
    "sap/ui/base/Object",
    "sap/ui/model/json/JSONModel",
    "./ServicoEscolas",
    "ui5/cod3rsgrowth/utilitarios/config",
    "ui5/cod3rsgrowth/modelos/ServicoEmpresas"
], function (
    baseObject,
	JSONModel,
	ServicoEscolas,
	config,
	ServicoEmpresas
) {
    "use strict";
    var commonAPIs =
    {
        baseData: {
            items: []
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

        oServicoFinal = jQuery.extend(true, commonAPIs, ServicoEscolas, ServicoEmpresas, config),
        oServico = baseObject.extend("ui5.cod3rsgrowth.modelos.DataRepository", oServicoFinal)
    return oServico;
});