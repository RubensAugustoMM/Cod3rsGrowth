sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/ui/core/routing/History"
], function(
	Controller,
	History
) {
	"use strict";

	return Controller.extend("ui5.cod3rsgrowth.controller.CriarEditarEmpresas", {
		_nomeRotaAtual: "",
        onInit() {
            
        
        },

		aoPressionarBotaoDeNavegacao() {
			const historico = History.getInstance();
			const hashAnterior = historico.getPreviousHash();

			if (hashAnterior != undefined) {
				window.history.go(-1);
			}
			else {
				const roteador = this.getOwnerComponent().getRouter();
				roteador.navTo("Empresas", {}, {}, true);
			}
		}
	}); 
});