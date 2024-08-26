sap.ui.define([
    "sap/ui/test/Opa5",
    "sap/ui/test/actions/Press"
], function (Opa5, Press) {
    "use strict";

    let viewName = ".App"
    
    Opa5.createPageObjects({
        naPaginaAPP: {

            actions: {
                aoPressionarBotaoLateralEmpresas: function () {
                    return this.waitFor({
                        viewName: viewName,
                        controlType: "sap.m.StandardListItem",
                        id: "botaoLateralEmpresas",
                        actions:  new Press(),
                        errorMessage: "Não foi possível encontrar o botaoLateralEmpresa na lista lateral."
                    })
				},
				
				aoPressionarBotaoLateralEscolas: function () {
					return this.waitFor({
                        viewName: viewName,
						controlType: "sap.m.StandardListItem",
                        id: "botaoLateralEscolas",
						actions: new Press(),
						errorMessage:"Não foi possivel encontrar o botaolLateralEscola na lista lateral"
					})
				}
            },
            assertions: {

            }
        }
    });
});
