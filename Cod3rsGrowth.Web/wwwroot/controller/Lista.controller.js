sap.ui.define([
    "sap/ui/core/mvc/Controller",
    "ui5/cod3rsgrowth/modelos/DataRepository",
	"sap/ui/model/Filter",
    "sap/ui/model/FilterOperator",
    "ui5/cod3rsgrowth/modelos/Formatador",
    "ui5/cod3rsgrowth/utilitarios/config",
    "sap/ui/core/Fragment"
], (Controller,
	DataRepository,
	Filter,
	FilterOperator,
	Formatador,
    config,
    Fragment) => {
    "use strict";

    return Controller.extend("ui5.cod3rsgrowth.controller.Lista", {

        formatador: Formatador,

        onInit() {
            const oRouter = this.getOwnerComponent().getRouter();

            oRouter.getRoute("Empresas").attachMatched(this._onRouteMatched, this);
            oRouter.getRoute("Escolas").attachMatched(this._onRouteMatched, this);
        },

        _onRouteMatched(oEvent) {
            var nomeRota = oEvent.getParameter("name");
            console.log("Rota ativada:", nomeRota);

            var i18n = this.getOwnerComponent().getModel("i18n").getResourceBundle();

            var titulo;

            switch (nomeRota) {
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
                default:
                    console.log("Rota não reconhecida.");
            }
        },

        _handleEmpresasRoute: function () {
            const DataRepository = this.getOwnerComponent().DataRepository;
            const oTable = this.byId("tabela");
            const oModel = this.getView().getModel();

            this.RemoverFragmentoFiltroEmpresas();

            this.CarregaFragmentoFiltroEmpresas();

            oTable.removeAllColumns();

            const aCampos = {
                nomeFantasia: "nome",
                cnpj: "CNPJ",
                situacaoCadastral: "Situação Cadastral",
                dataAbertura: "Data Abertura",
                naturezaJuridica: "Natureaza Juridica",
                capitalSocial: "Capital Social",
                estado: "Estado"
            };
            
            Object.entries(aCampos).forEach(([sCampo, sHeader]) => {
                oTable.addColumn(new sap.m.Column({
                    header: new sap.m.Label({ text: sHeader })
                }));
            });
            DataRepository.obterTodasEmpresas()
                .then(aEmpresas => {
                    oModel.setProperty("/items", aEmpresas);
                })
                .catch(oError => {
                    console.error("Erro ao obter convênios:", oError);
                });

            var oView = this.getView(); 
       
            oTable.bindItems({
                path: "/items",
                template: new sap.m.ColumnListItem({
                    cells: Object.keys(aCampos).map(sCampo => {
                        if (sCampo === "estado") {
                            return new sap.m.Text({
                                text: {
                                    path: sCampo,
                                    formatter:  this.formatador.textoEstado
                                }
                            });
                        }
                        if (sCampo === "naturezaJuridica") {
                            return new sap.m.Text({
                                text: {
                                    path: sCampo,
                                    formatter: function (naturezaJuridica) {
                                        return this.formatador.textoNaturezaJuridica(naturezaJuridica, oView);
                                    }.bind(this)
                                }
                            });
                        }
                        if (sCampo === "situacaoCadastral") {
                            return new sap.m.Text({
                                text: {
                                    path: sCampo,
                                    formatter: function (situacaoCadastral) {
                                        return this.formatador.textoSituacaoCadastral(situacaoCadastral, oView);
                                    }.bind(this)
                                }
                            });
                        }
                        return new sap.m.Text({ text: "{" + sCampo + "}" });
                    })
                })
            })
        },

        _handleEscolasRoute: function () {
            const DataRepository = this.getOwnerComponent().DataRepository;
            const oTable = this.byId("tabela");
            const oModel = this.getView().getModel();

            this.RemoverFragmentoFiltroEmpresas();
            
            oTable.removeAllColumns();

            const aCampos = {
                nome: "Nome",
                codigoMec: "Código MEC",
                statusAtividade: "Status Atividade",
                organizacaoAcademica: "Organização Acadêmica",
                estado: "Estado"
            };

            Object.entries(aCampos).forEach(([sCampo, sHeader]) => {
                oTable.addColumn(new sap.m.Column({
                    header: new sap.m.Label({ text: sHeader })
                }));
            });
            DataRepository.obterTodasEscolas()
                .then(aEscolas => {
                    oModel.setProperty("/items", aEscolas);
                })
                .catch(oError => {
                    console.error("Erro ao obter convênios:", oError);
                });
        
                var oView = this.getView(); 


            oTable.bindItems({
                path: "/items",
                template: new sap.m.ColumnListItem({
                    cells: Object.keys(aCampos).map(sCampo => {
                        if (sCampo === "estado") {
                            return new sap.m.Text({
                                text: {
                                    path: sCampo,
                                    formatter: this.formatador.textoEstado
                                }
                            });
                        }

                        if (sCampo === "organizacaoAcademica") {
                            return new sap.m.Text({
                                text: {
                                    path: sCampo,
                                    formatter: function (organizacaoAcademica) {
                                        return this.formatador.textoOrganizacaoAcademica(organizacaoAcademica, oView);
                                    }.bind(this)
                                }
                            });
                        }
                        if (sCampo === "statusAtividade") {
                            return new sap.m.Text({
                                text: {
                                    path: sCampo,
                                    formatter: function (statusAtividade) {
                                        return this.formatador.textoSituacaoCadastral(statusAtividade, oView);
                                    }.bind(this)
                                }
                            });
                        }

                        return new sap.m.Text({ text: "{" + sCampo + "}" });
                    })
                })
            })
        },
        aoFiltrarTabela(oEvent) {
            const sQuery = oEvent.getParameter("query");
            const oRouter = this.getOwnerComponent().getRouter();
            const oModel = this.getView().getModel();
        
            const sRotaAtual = oRouter.getRouteInfoByHash(window.location.hash).name;
            let sURL = config.getBaseURL();
            
            if (sRotaAtual === "Empresas") {
                sURL += "/api/Empresas?nomeFantasia=" + encodeURIComponent(sQuery);
            } else if (sRotaAtual === "Escolas") {
                sURL += "/api/Escolas?nome=" + encodeURIComponent(sQuery);
            }
        
            jQuery.ajax({
                url: sURL,
                method: "GET",
                success: function(aData) {
                    oModel.setProperty("/items", aData);
                },
                error: function(oError) {
                    console.error("Erro ao filtrar dados:", oError);
                }
            });
        },

        CarregaFragmentoFiltroEmpresas()
        {
            const oView = this.getView();

            Fragment.load({
                id: oView.getId(), 
                name: "ui5.cod3rsgrowth.view.FiltroEmpresas",
                controller: this 
            }).then(function (oPanel) {
                const oMainToolbar = oView.byId("painelFiltros");
                oMainToolbar.addContent(oPanel);
            });          
        }, 

        RemoverFragmentoFiltroEmpresas: function () {
            const oView = this.getView();
            const oMainToolbar = oView.byId("painelFiltros");
            const oFragmentContent = oView.byId(oView.getId() + "--filtroEmpresasFragment");

            if (oFragmentContent) {
                oMainToolbar.removeContent(oFragmentContent);
                oFragmentContent.destroy();
            }
        },

        aoPressionarBotaoFiltrar() {

        }
    });
});