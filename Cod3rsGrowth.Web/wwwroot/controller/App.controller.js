sap.ui.define([
	"sap/ui/core/mvc/Controller"
], (Controller) => {
	"use strict";


	return Controller.extend("ui5.cod3rsgrowth.controller.App", {
		onInit() {
		},

        aoClicarEmpresas() {
			const nomeRotaEmpresas = "Empresas";
			const oRouter = this.getOwnerComponent().getRouter();
			oRouter.navTo(nomeRotaEmpresas);
        },

        aoClicarEscolas() {
			const nomeRotaEscolas = "Escolas";
			const oRouter = this.getOwnerComponent().getRouter();
			oRouter.navTo(nomeRotaEscolas);
        }
	});
});