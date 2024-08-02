sap.ui.define([
	"sap/ui/core/mvc/Controller"
], (Controller) => {
	"use strict";

	return Controller.extend("ui5.cod3rsgrowth.controller.App", {
		onInit() {
		},
        aoClicarConvenios(){ 
			const oRouter = this.getOwnerComponent().getRouter();
			oRouter.navTo("Convenios");
        },

        aoClicarEmpresas() {
			const oRouter = this.getOwnerComponent().getRouter();
			oRouter.navTo("Empresas");
        },

        aoClicarEscolas() {
			const oRouter = this.getOwnerComponent().getRouter();
			oRouter.navTo("Escolas");
        },

        aoClicarEnderecos() {
			const oRouter = this.getOwnerComponent().getRouter();
			oRouter.navTo("Enderecos");
		}
	});
});