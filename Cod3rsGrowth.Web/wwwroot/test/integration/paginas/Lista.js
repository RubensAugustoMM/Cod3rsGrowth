sap.ui.define([
    "sap/ui/test/Opa5"
], function (Opa5) {
    "use strict";

    Opa5.createPageObjects({
        naPaginaDeListagem: {

            assertions: {
                iDeveMostarPaginaListagemEmpresas: function () {
                    return this.waitFor({
                        controlType: "sap.m.Page",
                        matchers: new sap.ui.test.matchers.PropertyStrictEquals({ name: "title", value: "Empresas" }),
                        success: function () {
                            Opa5.assert.ok(true, "A página de listagem de empresas foi exibida.");
                        },
                        errorMessage: "A página de listagem de empresas não foi exibida."
                    });
                },
                iDeveMostarPaginaListagemEscolas: function () {
                    return this.waitFor({
                        controlType: "sap.m.Page",
                        matchers: new sap.ui.test.matchers.PropertyStrictEquals({ name: "title", value: "Escolas" }),
                        success: function () {
                            Opa5.assert.ok(true, "A página de listagem de Escolas foi exibida.");
                        },
                        errorMessage: "A página de listagem de Escolas não foi exibida."
                    });
                }
            }

        }
    });
});