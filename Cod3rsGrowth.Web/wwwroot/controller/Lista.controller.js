sap.ui.define([
    "sap/ui/core/mvc/Controller",
    "ui5/cod3rsgrowth/modelos/Repositorios/DataRepository",
    "sap/ui/model/Filter",
    "sap/ui/model/FilterOperator",
    "ui5/cod3rsgrowth/modelos/Formatador",
    "ui5/cod3rsgrowth/utilitarios/config",
    "sap/ui/core/Fragment",
    "sap/ui/core/routing/HashChanger",
    "sap/ui/core/format/NumberFormat",
    "sap/ca/ui/model/format/DateFormat",
    "sap/ui/model/json/JSONModel"
], (Controller,
    DataRepository,
    Filter,
    FilterOperator,
    Formatador,
    config,
    Fragment,
    HashChanger,
    NumberFormat,
    DateFormat,
    JSONModel) => {
    "use strict";

    return Controller.extend("ui5.cod3rsgrowth.controller.Lista", {

        formatador: Formatador,
        oOpcoesFormatadorDecimais: {
            minIntegerDigits: 1,
            MaxIntegerDigits: 3,
            minFractionsDigits: 2,
            maxFractionDigits: 2,
            style: "short"
        },
        oOpcoesFormatadorData: {
            format: "ddmmyyyy"
        },

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
            let oModel = this.getView().getModel();
            oModel.setProperty('/painelExpandido', false);

            this.RemoverFragmentoFiltroEmpresas();
            this.RemoverFragmentoFiltroEscolas();
            this.CarregaFragmentoFiltroEmpresas();
            this.populaTabelaEmpresaComDados({});
            this.formataElementosTabelaEmpresas();
        },

        _handleEscolasRoute: function () {
            let oModel = this.getView().getModel();
            oModel.setProperty('/painelExpandido', false);

            this.RemoverFragmentoFiltroEmpresas();
            this.RemoverFragmentoFiltroEscolas();
            this.CarregaFragmentoFiltroEscolas();
            this.populaTabelaEscolaComDados({});
            this.formataElementosTabelaEscola();
        },
        aoFiltrarTabela(oEvent) {
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
                success: function (aData) {
                    oModel.setProperty("/items", aData);
                },
                error: function (oError) {
                    console.error("Erro ao filtrar dados:", oError);
                }
            });
        },

        CarregaFragmentoFiltroEmpresas() {
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

        RemoverFragmentoFiltroEmpresas() {
            const oView = this.getView();
            const oMainToolbar = oView.byId("painelFiltros");
            const oFragmentContent = oView.byId(oView.getId() + "--filtroEmpresasFragment");

            if (oFragmentContent) {
                oMainToolbar.removeContent(oFragmentContent);
                oFragmentContent.destroy();
            }
        },

        CarregaFragmentoFiltroEscolas() {
            const oView = this.getView();

            Fragment.load({
                id: oView.getId(),
                name: "ui5.cod3rsgrowth.view.FiltroEscolas",
                controller: this
            }).then(function (oPanel) {
                const oMainToolbar = oView.byId("painelFiltros");
                oMainToolbar.addContent(oPanel);
            }); 
        },

        RemoverFragmentoFiltroEscolas() {
            const oView = this.getView();
            const oMainToolbar = oView.byId("painelFiltros");
            const oFragmentContent = oView.byId(oView.getId() + "--filtroEscolasFragment");

            if (oFragmentContent) {
                oMainToolbar.removeContent(oFragmentContent);
                oFragmentContent.destroy();
            }
        },

        aoPressionarBotaoFiltrarEmpresa(oEvent) {
            let oFiltro = this.retornaFiltroEmpresas();
            this.populaTabelaEmpresaComDados(oFiltro);
            this.formataElementosTabelaEmpresas();
        },
        
        aoPressionarBotaoFiltrarEscola(oEvent)
        {
            let oFiltro = this.retornaFiltroEscolas();
            this.populaTabelaEscolaComDados(oFiltro);
            this.formataElementosTabelaEscola();
        },

        retornaFiltroEmpresas() {
            var oModel = this.getView().getModel();
            return {
                SituacaoCadastralFiltro: oModel.getProperty("/situacaoCadastralSelecionada"),
                RazaoSocialFiltro: oModel.getProperty("/nomeEmpresa"),
                CnpjFiltro: oModel.getProperty("/cnpjEmpresa"),
                CapitalSocialFiltro: oModel.getProperty("/capitalSocialEmpresa"),
                DataAberturaFiltro: oModel.getProperty("/dataAbertura"),
                NaturezaJuridicaFiltro: oModel.getProperty("/naturezaJuridicaSelecionada"),
                EstadoFiltro: oModel.getProperty("/estadoSelecionado")
            }
        },

        retornaFiltroEscolas() {
            var oModel = this.getView().getModel();
            return {
                NomeFiltro: oModel.getProperty("/nomeEscola"),
                CodigoMecFiltro: oModel.getProperty("/codigoMec"),
                StatusAtividadeFiltro: oModel.getProperty("/statusAtividadeSelecionada"),
                OrganizacaoAcademicaFiltro: oModel.getProperty("/organizacaoAcademicaSelecionada"),
                EstadoFiltro: oModel.getProperty("/estadoSelecionado")
            }
        },

        populaTabelaEmpresaComDados(oFiltro)
        {
            const DataRepository = this.getOwnerComponent().DataRepository;
            const oTabela = this.byId("tabela");
            const oModel = this.getView().getModel();

            oTabela.removeAllColumns();

            const aCampos = {
                nomeFantasia: "nome",
                cnpj: "CNPJ",
                situacaoCadastral: "Situação Cadastral",
                dataAbertura: "Data Abertura",
                naturezaJuridica: "Natureaza Juridica",
                capitalSocial: "Capital Social",
                estado: "Estado"
            };

            DataRepository.obterTodasEmpresas(oFiltro)
                .then(aEmpresas => {
                    oModel.setProperty("/items", aEmpresas);
                })
                .catch(oError => {
                    console.error("Erro ao obter convênios:", oError);
                });
        },

        formataElementosTabelaEmpresas() {
            const oTabela = this.byId("tabela");
            oTabela.removeAllColumns();

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
                oTabela.addColumn(new sap.m.Column({
                    header: new sap.m.Label({ text: sHeader })
                }));
            });

            var oView = this.getView();

            oTabela.bindItems({
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
                        if (sCampo === "capitalSocial") {
                            return new sap.m.Text({
                                text: {
                                    path: sCampo,
                                    formatter: function (capitalSocial) {
                                        var oFormatadorFloat = NumberFormat.getFloatInstance(this.oOpcoesFormatadorDecimais);
                                        return oFormatadorFloat.format(capitalSocial);
                                    }.bind(this)
                                }
                            })
                        }
                        if (sCampo === "dataAbertura") {
                            return new sap.m.Text({
                                text: {
                                    path: sCampo,
                                    formatter: function (dataAbertura) {
                                        var oFormatadorData = DateFormat.getDateInstance(this.oOpcoesFormatadorData);
                                        return oFormatadorData.format(dataAbertura);
                                    }
                                }
                            })
                        }
                        return new sap.m.Text({ text: "{" + sCampo + "}" });
                    })
                })
            })
        },

        populaTabelaEscolaComDados(oFiltro) {
            const DataRepository = this.getOwnerComponent().DataRepository;
            const oTabela = this.byId("tabela");
            const oModel = this.getView().getModel();

            const aCampos = {
                nome: "Nome",
                codigoMec: "Código MEC",
                statusAtividade: "Status Atividade",
                organizacaoAcademica: "Organização Acadêmica",
                estado: "Estado"
            };

            DataRepository.obterTodasEscolas(oFiltro)
                .then(aEscolas => {
                    oModel.setProperty("/items", aEscolas);
                })
                .catch(oError => {
                    console.error("Erro ao obter convênios:", oError);
                });
        },

        formataElementosTabelaEscola() {
            const oTabela = this.byId("tabela");

            oTabela.removeAllColumns();

            const aCampos = {
                nome: "Nome",
                codigoMec: "Código MEC",
                statusAtividade: "Status Atividade",
                organizacaoAcademica: "Organização Acadêmica",
                estado: "Estado"
            };

            var oView = this.getView();

            Object.entries(aCampos).forEach(([sCampo, sHeader]) => {
                oTabela.addColumn(new sap.m.Column({
                    header: new sap.m.Label({ text: sHeader })
                }));
            });

            oTabela.bindItems({
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
        }
    });
});