sap.ui.define([
    "sap/ui/test/Opa5",
    "./arrangements/Startup",
    "./AppListaJourney"
], function (Opa5, Startup,  AppListaEmpresasJourney) {
    "use strict";

    Opa5.extendConfig({
        arrangements: new Startup(),
        viewNamespace: "ui5.cod3rsgrowth.view",
        autoWait: true
    });
});