sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"ui5/cod3rsgrowth/modelos/DataRepository"
], (Controller,
	DataRepository) =>  {
	"use strict";

    return Controller.extend("ui5.cod3rsgrowth.controller.Lista", {
        onInit() {
			const oRouter = this.getOwnerComponent().getRouter();
			const DataRepository = this.getOwnerComponent().DataRepository;
			DataRepository.obterTodosConvenios();

			oRouter.getRoute("Convenios").attachMatched(this._onRouteMatched, this);
			oRouter.getRoute("Empresas").attachMatched(this._onRouteMatched, this);
			oRouter.getRoute("Escolas").attachMatched(this._onRouteMatched, this);
			oRouter.getRoute("Enderecos").attachMatched(this._onRouteMatched, this);
		},

		_onRouteMatched(oEvent) {
			var nomeRota = oEvent.getParameter("name");
			console.log("Rota ativada:", nomeRota);

            var i18n = this.getOwnerComponent().getModel("i18n").getResourceBundle();

            var titulo;

			switch (nomeRota) {
			  case "Convenios":
				titulo = i18n.getText("tituloConvenios");
				this.byId("lista").setTitle(titulo)
				this._handleConveniosRoute();
				break;
			  case "Empresas":
				titulo = i18n.getText("tituloEmpresas");
				this.byId("lista").setTitle(titulo)
				this._handleEmpresasRoute();
				break;
			  case "Escolas":
				titulo = i18n.getText("tituloEscolas");
				this.byId("lista").setTitle(titulo)
				this._handleEscolasRoute();
				break;
			  case "Enderecos":
				titulo = i18n.getText("tituloEnderecos");
				this.byId("lista").setTitle(titulo)
				this._handleEnderecosRoute();
				break;
			  default:
				console.log("Rota não reconhecida.");
			}
		  },
	  
		  _handleConveniosRoute() {
			// Lógica específica para a rota 'convenios'
			console.log("Tratando a rota de Convênios.");
		  },
	  
		  _handleEmpresasRoute: function() {
			// Lógica específica para a rota 'empresas'
			console.log("Tratando a rota de Empresas.");
		  },
	  
		  _handleEscolasRoute: function() {
			// Lógica específica para a rota 'escolas'
			console.log("Tratando a rota de Escolas.");
		  },
	  
		  _handleEnderecosRoute: function() {
			// Lógica específica para a rota 'enderecos'
			console.log("Tratando a rota de Endereços.");
		  }
	  
	});
});