sap.ui.define([
    "sap/ui/test/Opa5",
    "sap/ui/test/actions/Press"
], function (Opa5, Press) {
    "use strict";

    Opa5.createPageObjects({
        naPaginaAPP: {

            actions: {
                iPressionaBotaoLateralEmpresa: function () {
                    return this.waitFor({
                        controlType: "sap.m.StandardListItem",
                        success: function (itemsListaLateral) {
                            new Press().executeOn(itemsListaLateral[0]);
                        },
                        errorMessage: "Não foi possível encontrar o botaoLateralEmpresa na lista lateral."
                    });
				},
				
				iPressionaBotaoLateralEscolas: function () {
					return this.waitFor({
						controlType: "sap.m.StandardListItem",
						success: function (itemsListaLateral) {
							new Press().executeOn(itemsListaLateral[1]);
						},
						errorMessage:"Não foi possivel encontrar o botalLateralEscola na lista lateral"
					})
				}
            }
        }
    });
});
