sap.ui.define([
    "sap/ui/test/Opa5"
], function (Opa5) {
    "use strict";

    return Opa5.extend("ui5.cod3rsgrowth.test.integration.arrangements.Startup", {
        iInicializoMinhaAplicacao: function (configuracao) {
                this.iStartMyAppInAFrame(configuracao.hash);
        }

    });
});