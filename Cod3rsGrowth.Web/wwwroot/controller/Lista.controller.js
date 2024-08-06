sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"ui5/cod3rsgrowth/modelos/DataRepository"
], (Controller,
	DataRepository) =>  {
	"use strict";

    return Controller.extend("ui5.cod3rsgrowth.controller.Lista", {
        onInit() {
			const oRouter = this.getOwnerComponent().getRouter();
			
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
            const DataRepository = this.getOwnerComponent().DataRepository;

            DataRepository.obterTodosConvenios()
                .then(aConvenios => {
                    const oTable = this.byId("tabela");
                    const oModel = this.getView().getModel();

                    oTable.removeAllColumns();

                    const aCampos = {
                        numeroProcesso: "Número do processo",
                        nomeEscola: "Escola",
                        razaoSocialEmpresa: "Empresa",
                        valor: "Valor",
                        dataInicio: "Início",
                        dataTermino: "Termino"
                    };

                    Object.entries(aCampos).forEach(([sCampo, sHeader]) => {
                        oTable.addColumn(new sap.m.Column({
                            header: new sap.m.Label({ text: sHeader })
                        }));
                    });

                    oTable.bindItems({
                        path: "/items",
                        template: new sap.m.ColumnListItem({
                            cells: Object.keys(aCampos).map(sCampo => new sap.m.Text({ text: "{" + sCampo + "}" }))
                        })
                    });

                    // Define os dados no modelo
                    oModel.setProperty("/items", aConvenios);
                })
                .catch(oError => {
                    console.error("Erro ao obter convênios:", oError);
                });
        },
	  
		  _handleEmpresasRoute: function() {
            const DataRepository = this.getOwnerComponent().DataRepository;

            DataRepository.obterTodasEmpresas()
                .then(aEmpresas => {
                    const oTable = this.byId("tabela");
                    const oModel = this.getView().getModel();

                    oTable.removeAllColumns();

                    if (aEmpresas.length > 0) {
                        const aKeys = Object.keys(aEmpresas[0]);

                        aKeys.forEach(sKey => {
                            oTable.addColumn(new sap.m.Column({
                                header: new sap.m.Label({ text: sKey })
                            }));
                        });

                        oTable.bindItems({
                            path: "/items",
                            template: new sap.m.ColumnListItem({
                                cells: aKeys.map(sKey => new sap.m.Text({ text: "{" + sKey + "}" }))
                            })
                        });
                    }

                    oModel.setProperty("/items", aEmpresas);
                })
                .catch(oError => {
                    console.error("Erro ao obter empresas:", oError);
                });
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