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
        sIdLista: "lista",
        sIdTabela: "tabela",
        sIdPainelFiltro: "painelFiltros",
        sNomeI18n: "i18n",
        sNomePropriedadePainelExpandido: "/painelExpandido",
        sNomePropriedadeTabelaItems: "/items",

        oOpcoesFormatadorDecimais: {
            minIntegerDigits: 1,
            MaxIntegerDigits: 3,
            minFractionsDigits: 2,
            maxFractionDigits: 2,
            style: "short"
        },
        oOpcoesFormatadorData: {
            pattern: 'yyyy-MM-ddTHH:mm:ss'
        },

        onInit() {
            const nomeRotaEmpresa = "Empresas";
            const nomeRotaEscolas = "Escolas";
            const oRouter = this.getOwnerComponent().getRouter();

            oRouter.getRoute(nomeRotaEmpresa).attachMatched(this._aoCoincidirComRotaEmpresas, this);
            oRouter.getRoute(nomeRotaEscolas).attachMatched(this._aoCoincidirComRotaEscolas, this);
        },

        _aoCoincidirComRotaEmpresas: function () {
            const si18nTituloEmpresas = "tituloEmpresas";
            let oModel = this.getView().getModel();
            let i18n = this.getOwnerComponent().getModel(this.sNomeI18n).getResourceBundle();
            this.byId(this.sIdLista).setTitle(i18n.getText(si18nTituloEmpresas))
            oModel.setProperty(this.sNomePropriedadePainelExpandido, false);

            this._removerFragmentoFiltroEmpresas();
            this._removerFragmentoFiltroEscolas();
            this._carregaFragmentoFiltroEmpresas();
            this._populaTabelaEmpresaComDados({});
            this._formataElementosTabelaEmpresas();
        },

        _aoCoincidirComRotaEscolas: function () {
            const si18nTituloEscolas = "tituloEsocolas";
            let oModel = this.getView().getModel();
            let i18n = this.getOwnerComponent().getModel(this.sNomeI18n).getResourceBundle();
            this.byId(this.sIdLista).setTitle(i18n.getText(si18nTituloEscolas));
            oModel.setProperty(this.sNomePropriedadePainelExpandido, false);

            this._removerFragmentoFiltroEmpresas();
            this._removerFragmentoFiltroEscolas();
            this._carregaFragmentoFiltroEscolas();
            this._populaTabelaEscolaComDados({});
            this._formataElementosTabelaEscola();
        },

        _carregaFragmentoFiltroEmpresas() {
            const sNomeFragmentoFiltroEmpresas = "ui5.cod3rsgrowth.view.FiltroEmpresas";
            const oView = this.getView();

            Fragment.load({
                id: oView.getId(),
                name: sNomeFragmentoFiltroEmpresas,
                controller: this
            }).then((oPanel) => {
                const oMainToolbar = oView.byId(this.sIdPainelFiltro);
                oMainToolbar.addContent(oPanel);
            });
        },

        _removerFragmentoFiltroEmpresas() {
            const oView = this.getView();
            const oPainelFiltro = this.byId(this.sIdPainelFiltro);
            const oConteudoPainelFiltro = this.byId(oView.getId() + "--filtroEmpresasFragment");

            if (oConteudoPainelFiltro) {
                oPainelFiltro.removeContent(oConteudoPainelFiltro);
                oConteudoPainelFiltro.destroy();
            }
        },

        _carregaFragmentoFiltroEscolas() {
            const sNomeFragmentoFiltroEscolas = "ui5.cod3rsgrowth.view.FiltroEscolas";
            const oView = this.getView();

            Fragment.load({
                id: oView.getId(),
                name: sNomeFragmentoFiltroEscolas,
                controller: this
            }).then((oPanel) => {
                const oMainToolbar = oView.byId(this.sIdPainelFiltro);
                oMainToolbar.addContent(oPanel);
            });
        },

        _removerFragmentoFiltroEscolas() {
            const oView = this.getView();
            const oPainelFiltro = this.byId(this.sIdPainelFiltro);
            const oConteudoPainelFiltro = oView.byId(oView.getId() + "--filtroEscolasFragment");

            if (oConteudoPainelFiltro) {
                oPainelFiltro.removeContent(oConteudoPainelFiltro);
                oConteudoPainelFiltro.destroy();
            }
        },

        aoPressionarBotaoFiltrarEmpresa() {
            let oFiltro = this._retornaFiltroEmpresas();
            this._populaTabelaEmpresaComDados(oFiltro);
            this._formataElementosTabelaEmpresas();
        },

        aoPressionarBotaoFiltrarEscola() {
            let oFiltro = this._retornaFiltroEscolas();
            this._populaTabelaEscolaComDados(oFiltro);
            this._formataElementosTabelaEscola();
        },
        _retornaFiltroEmpresas() {
            let oModel = this.getView().getModel();
            const sNomePropriedadeSituacaoCadastralSelecioada = "/situacaoCadastralSelecionada";
            const sNomePropriedadeNomeEmpresa = "/nomeEmpresa";
            const sNomePropriedadeCnpjEmpresa = "/cnpjEmpresa";
            const sNomePropriedadeCapitalSocialEmpresa = "/capitalSocialEmpresa";
            const sNomePropriedadeDataAbertura = "/dataAbertura";
            const sNomePropriedadeNaturezaJuridicaSelecionada = "/naturezaJuridicaSelecionada";
            const sNomePropriedadeEstadoSelecionado = "/estadoSelecionado";

            return {
                SituacaoCadastralFiltro: oModel.getProperty(sNomePropriedadeSituacaoCadastralSelecioada),
                RazaoSocialFiltro: oModel.getProperty(sNomePropriedadeNomeEmpresa),
                CnpjFiltro: oModel.getProperty(sNomePropriedadeCnpjEmpresa),
                CapitalSocialFiltro: oModel.getProperty(sNomePropriedadeCapitalSocialEmpresa),
                DataAberturaFiltro: oModel.getProperty(sNomePropriedadeDataAbertura),
                NaturezaJuridicaFiltro: oModel.getProperty(sNomePropriedadeNaturezaJuridicaSelecionada),
                EstadoFiltro: oModel.getProperty(sNomePropriedadeEstadoSelecionado)
            }
        },

        _retornaFiltroEscolas() {
            let oModel = this.getView().getModel();
            const sNomePropriedadeNomeEscola = "/nomeEscola";
            const sNomePropriedadeCodigoMec = "/codigoMec";
            const sNomePropriedadeStatusAtividadeSelecionada = "/statusAtividadeSelecionada";
            const sNomePropriedadeOrganizacaoAcademicaSelecioada = "/organizacaoAcademicaSelecioada";
            const sNomePropriedadeEstadoSelecionado = "/estadoSelecionado";

            return {
                NomeFiltro: oModel.getProperty(sNomePropriedadeNomeEscola),
                CodigoMecFiltro: oModel.getProperty(sNomePropriedadeCodigoMec),
                StatusAtividadeFiltro: oModel.getProperty(sNomePropriedadeStatusAtividadeSelecionada),
                OrganizacaoAcademicaFiltro: oModel.getProperty(sNomePropriedadeOrganizacaoAcademicaSelecioada),
                EstadoFiltro: oModel.getProperty(sNomePropriedadeEstadoSelecionado)
            }
        },

        _populaTabelaEmpresaComDados(oFiltro) {
            const DataRepository = this.getOwnerComponent().DataRepository;
            const oTabela = this.byId(this.sIdTabela);
            const oModel = this.getView().getModel();

            oTabela.removeAllColumns();

            DataRepository.obterTodasEmpresas(oFiltro)
                .then(aEmpresas => {
                    oModel.setProperty(this.sNomePropriedadeTabelaItems, aEmpresas);
                })
                .catch(oError => {
                    const sMensagemDeErro = "Erro ao obter Empresas:";
                    console.error(sMensagemDeErro, oError);
                });
        },

        _formataElementosTabelaEmpresas() {
            const oTabela = this.byId(this.sIdTabela);
            oTabela.removeAllColumns();
            const oCamposEmpresas = {
                nomeFantasia: "nome",
                cnpj: "CNPJ",
                situacaoCadastral: "Situação Cadastral",
                dataAbertura: "Data Abertura",
                naturezaJuridica: "Natureaza Juridica",
                capitalSocial: "Capital Social",
                estado: "Estado"
            }


            Object.entries(oCamposEmpresas).forEach(([sCampo, sHeader]) => {
                oTabela.addColumn(new sap.m.Column({
                    header: new sap.m.Label({ text: sHeader })
                }));
            });

            let oView = this.getView();

            oTabela.bindItems({
                path: this.sNomePropriedadeTabelaItems,
                template: new sap.m.ColumnListItem({
                    cells: Object.keys(oCamposEmpresas).map(sCampo => {
                        if (sCampo === oCamposEmpresas["estado"]) {
                            return new sap.m.Text({
                                text: {
                                    path: sCampo,
                                    formatter: this.formatador.textoEstado
                                }
                            });
                        }

                        const arrayChavesCamposEmpresas = Object.keys(oCamposEmpresas);
                        const posicaoArrayNaturezaJuridica = 4;
                        if (sCampo === arrayChavesCamposEmpresas[posicaoArrayNaturezaJuridica]) {
                            return new sap.m.Text({
                                text: {
                                    path: sCampo,
                                    formatter: function (naturezaJuridica) {
                                        return this.formatador.textoNaturezaJuridica(naturezaJuridica, oView);
                                    }.bind(this)
                                }
                            });
                        }

                        const posicaoArraySituacaoCadastral = 2;
                        if (sCampo === arrayChavesCamposEmpresas[posicaoArraySituacaoCadastral]) {
                            return new sap.m.Text({
                                text: {
                                    path: sCampo,
                                    formatter: function (situacaoCadastral) {
                                        return this.formatador.textoSituacaoCadastral(situacaoCadastral, oView);
                                    }.bind(this)
                                }
                            });
                        }

                        const posicaoArrayCapitalSocial = 5;
                        if (sCampo === arrayChavesCamposEmpresas[posicaoArrayCapitalSocial]) {
                            return new sap.m.Text({
                                text: {
                                    path: sCampo,
                                    formatter: function (capitalSocial) {
                                        let oFormatadorFloat = NumberFormat.getFloatInstance(this.oOpcoesFormatadorDecimais);
                                        return oFormatadorFloat.format(capitalSocial);
                                    }.bind(this)
                                }
                            })
                        }

                        const posicaoArrayDataAbertura = 3;
                        if (sCampo === arrayChavesCamposEmpresas[posicaoArrayDataAbertura]) {
                            return new sap.m.Text({
                                text: {
                                    path: sCampo,
                                    formatter: function (dataAbertura) {
                                        let oFormatadorData = DateFormat.getDateInstance(this.oOpcoesFormatadorData);
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

        _populaTabelaEscolaComDados(oFiltro) {
            const DataRepository = this.getOwnerComponent().DataRepository;
            const oModel = this.getView().getModel();

            DataRepository.obterTodasEscolas(oFiltro)
                .then(aEscolas => {
                    oModel.setProperty(this.sNomePropriedadeTabelaItems, aEscolas);
                })
                .catch(oError => {
                    const sMensagemDeErro = "Erro ao obter Escolas:"
                    console.error(sMensagemDeErro, oError);
                });
        },

        _formataElementosTabelaEscola() {
            const oTabela = this.byId(this.sIdTabela);

            oTabela.removeAllColumns();

            const oCamposEscolas = {
                nome: "Nome",
                codigoMec: "Código MEC",
                statusAtividade: "Status Atividade",
                organizacaoAcademica: "Organização Acadêmica",
                estado: "Estado"
            };

            let oView = this.getView();

            Object.entries(oCamposEscolas).forEach(([sCampo, sHeader]) => {
                oTabela.addColumn(new sap.m.Column({
                    header: new sap.m.Label({ text: sHeader })
                }));
            });

            oTabela.bindItems({
                path: this.sNomePropriedadeTabelaItems,
                template: new sap.m.ColumnListItem({
                    cells: Object.keys(oCamposEscolas).map(sCampo => {
                        if (sCampo === "estado") {
                            return new sap.m.Text({
                                text: {
                                    path: sCampo,
                                    formatter: this.formatador.textoEstado
                                }
                            });
                        }
 
                        const posicaoArrayOrganizacaoAcademica = 3;
                        const arrayChavesCamposEscolas = Object.keys(oCamposEscolas);                       
                        if (sCampo === arrayChavesCamposEscolas[posicaoArrayOrganizacaoAcademica]) {
                            return new sap.m.Text({
                                text: {
                                    path: sCampo,
                                    formatter: function (organizacaoAcademica) {
                                        return this.formatador.textoOrganizacaoAcademica(organizacaoAcademica, oView);
                                    }.bind(this)
                                }
                            });
                        }

                        const posicaoArrayStatusAtividade = 2;
                        if (sCampo === arrayChavesCamposEscolas[posicaoArrayStatusAtividade]) {
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