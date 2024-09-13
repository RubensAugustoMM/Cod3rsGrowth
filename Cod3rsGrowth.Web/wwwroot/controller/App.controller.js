sap.ui.define([
	"sap/ui/core/mvc/Controller"
], (Controller) => {
	"use strict";


	return Controller.extend("ui5.cod3rsgrowth.controller.App", {
		onInit() {
		},

        aoClicarEmpresas() {
			const nomeRotaEmpresas = "Empresas";
			const roteador = this.getOwnerComponent().getRouter();
			roteador.navTo(nomeRotaEmpresas);
        },

        aoClicarEscolas() {
			const nomeRotaEscolas = "Escolas";
			const roteador = this.getOwnerComponent().getRouter();
			roteador.navTo(nomeRotaEscolas);
        }
	});
});