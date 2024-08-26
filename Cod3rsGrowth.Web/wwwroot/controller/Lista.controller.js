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

            try {
                const oRouter = this.getOwnerComponent().getRouter();

                oRouter.getRoute(nomeRotaEmpresa).attachMatched(this._aoCoincidirComRotaEmpresas, this);
                oRouter.getRoute(nomeRotaEscolas).attachMatched(this._aoCoincidirComRotaEscolas, this);
            }
            catch (erro) {
                const mensagemDeErro = "Erro ao inicializar a tela de listagem:\n";
                console.error(mensagemDeErro + erro);
            }
        },

        _aoCoincidirComRotaEmpresas: function () {
            const si18nTituloEmpresas = "tituloEmpresas";

            try {
                let oModel = this.getView().getModel();
                let i18n = this.getOwnerComponent().getModel(this.sNomeI18n).getResourceBundle();
                this.byId(this.sIdLista).setTitle(i18n.getText(si18nTituloEmpresas))
                oModel.setProperty(this.sNomePropriedadePainelExpandido, false);

                this._removerFragmentoFiltroEmpresas();
                this._removerFragmentoFiltroEscolas();
                this._carregaFragmentoFiltroEmpresas();
                this._populaTabelaEmpresaComDados({});
                this._formataElementosTabelaEmpresas();
            }
            catch (erro) {
                const mensagemDeErro = "Erro ao carregar rota 'Empresas':\n";
                console.error(mensagemDeErro + erro);
            }
        },

        _aoCoincidirComRotaEscolas: function () {
            const si18nTituloEscolas = "tituloEsocolas";

            try {
                let oModel = this.getView().getModel();
                let i18n = this.getOwnerComponent().getModel(this.sNomeI18n).getResourceBundle();
                this.byId(this.sIdLista).setTitle(i18n.getText(si18nTituloEscolas));
                oModel.setProperty(this.sNomePropriedadePainelExpandido, false);

                this._removerFragmentoFiltroEmpresas();
                this._removerFragmentoFiltroEscolas();
                this._carregaFragmentoFiltroEscolas();
                this._populaTabelaEscolaComDados({});
                this._formataElementosTabelaEscola();
            }
            catch (erro) {
                const mensagemDeErro = "Erro ao carregar rota 'Escolas':\n";
                console.error(mensagemDeErro + erro);
            }
        },

        _carregaFragmentoFiltroEmpresas() {
            const sNomeFragmentoFiltroEmpresas = "ui5.cod3rsgrowth.view.FiltroEmpresas";

            try {
                const oView = this.getView();

                Fragment.load({
                    id: oView.getId(),
                    name: sNomeFragmentoFiltroEmpresas,
                    controller: this
                }).then((oPanel) => {
                    const oMainToolbar = oView.byId(this.sIdPainelFiltro);
                    oMainToolbar.addContent(oPanel);
                });
            }
            catch (erro) {
                const mensagemDeErro = "Erro ao carregar fragmento filtor empresas:\n";
                console.error(mensagemDeErro + erro);
            }
        },

        _removerFragmentoFiltroEmpresas() {
            try {
                const oView = this.getView();
                const oPainelFiltro = this.byId(this.sIdPainelFiltro);
                const oConteudoPainelFiltro = this.byId(oView.getId() + "--filtroEmpresasFragment");

                if (oConteudoPainelFiltro) {
                    oPainelFiltro.removeContent(oConteudoPainelFiltro);
                    oConteudoPainelFiltro.destroy();
                }
            }
            catch (erro) {
                const mensagemDeErro = "Erro ao remover fragmento filtro Empresas:\n";
                console.error(mensagemDeErro + erro);
            }
        },

        _carregaFragmentoFiltroEscolas() {
            const sNomeFragmentoFiltroEscolas = "ui5.cod3rsgrowth.view.FiltroEscolas";

            try {
                const oView = this.getView();

                Fragment.load({
                    id: oView.getId(),
                    name: sNomeFragmentoFiltroEscolas,
                    controller: this
                }).then((oPanel) => {
                    const oMainToolbar = oView.byId(this.sIdPainelFiltro);
                    oMainToolbar.addContent(oPanel);
                });
            }
            catch (erro) {
                const mensagemDeErro = "Erro ao carregar fragmento filtro escolas:\n";
                console.error(mensagemDeErro + erro);
            }
        },

        _removerFragmentoFiltroEscolas() {
            try {
                const oView = this.getView();
                const oPainelFiltro = this.byId(this.sIdPainelFiltro);
                const oConteudoPainelFiltro = oView.byId(oView.getId() + "--filtroEscolasFragment");

                if (oConteudoPainelFiltro) {
                    oPainelFiltro.removeContent(oConteudoPainelFiltro);
                    oConteudoPainelFiltro.destroy();
                }
            }
            catch (erro) {
                const mensagemDeErro = "Erro ao remover fragmento de filtro de escolas:\n";
                console.error(mensagemDeErro + erro);
            }
        },

        aoPressionarBotaoFiltrarEmpresa() {
            try {
                let oFiltro = this._retornaFiltroEmpresas();
                this._populaTabelaEmpresaComDados(oFiltro);
                this._formataElementosTabelaEmpresas();
            }
            catch (erro) {
                const mensagemDeErro = "Erro ao pressionar botão filtrar empresas:\n";
                console.error(mensagemDeErro + erro);
            }
        },

        aoPressionarBotaoFiltrarEscola() {
            try { 
                let oFiltro = this._retornaFiltroEscolas();
                this._populaTabelaEscolaComDados(oFiltro);
                this._formataElementosTabelaEscola();
            }
            catch (erro) {
                const mensagemDeErro = "Erro ao pressionar botão para filtrar Escolas:\n";
                console.error(mensagemDeErro + erro);
            }
        },
        _retornaFiltroEmpresas() {
            const sNomePropriedadeSituacaoCadastralSelecioada = "/situacaoCadastralSelecionada";
            const sNomePropriedadeNomeEmpresa = "/nomeEmpresa";
            const sNomePropriedadeCnpjEmpresa = "/cnpjEmpresa";
            const sNomePropriedadeCapitalSocialEmpresa = "/capitalSocialEmpresa";
            const sNomePropriedadeDataAbertura = "/dataAbertura";
            const sNomePropriedadeNaturezaJuridicaSelecionada = "/naturezaJuridicaSelecionada";
            const sNomePropriedadeEstadoSelecionado = "/estadoSelecionado";
            
            try {
                let oModel = this.getView().getModel();
                return {
                    SituacaoCadastralFiltro: oModel.getProperty(sNomePropriedadeSituacaoCadastralSelecioada),
                    RazaoSocialFiltro: oModel.getProperty(sNomePropriedadeNomeEmpresa),
                    CnpjFiltro: oModel.getProperty(sNomePropriedadeCnpjEmpresa),
                    CapitalSocialFiltro: oModel.getProperty(sNomePropriedadeCapitalSocialEmpresa),
                    DataAberturaFiltro: oModel.getProperty(sNomePropriedadeDataAbertura),
                    NaturezaJuridicaFiltro: oModel.getProperty(sNomePropriedadeNaturezaJuridicaSelecionada),
                    EstadoFiltro: oModel.getProperty(sNomePropriedadeEstadoSelecionado)
                }
            }
            catch (erro) {
                const mensagemDeErro = "Erro ao retornar valores do filtro empresas:\n";
                console.error(mensagemDeErro + erro);
            }
        },

        _retornaFiltroEscolas() {
            const sNomePropriedadeNomeEscola = "/nomeEscola";
            const sNomePropriedadeCodigoMec = "/codigoMec";
            const sNomePropriedadeStatusAtividadeSelecionada = "/statusAtividadeSelecionada";
            const sNomePropriedadeOrganizacaoAcademicaSelecioada = "/organizacaoAcademicaSelecioada";
            const sNomePropriedadeEstadoSelecionado = "/estadoSelecionado";
            
            try {
                let oModel = this.getView().getModel();
                return {
                    NomeFiltro: oModel.getProperty(sNomePropriedadeNomeEscola),
                    CodigoMecFiltro: oModel.getProperty(sNomePropriedadeCodigoMec),
                    StatusAtividadeFiltro: oModel.getProperty(sNomePropriedadeStatusAtividadeSelecionada),
                    OrganizacaoAcademicaFiltro: oModel.getProperty(sNomePropriedadeOrganizacaoAcademicaSelecioada),
                    EstadoFiltro: oModel.getProperty(sNomePropriedadeEstadoSelecionado)
                }
            }
            catch (erro) {
                const mensagemDeErro = "Erro ao retornar valores do filtro escolas:\n"
                console.error(mensagemDeErro + erro);
            }
        },

        _populaTabelaEmpresaComDados(oFiltro) {
            try {
                const DataRepository = this.getOwnerComponent().DataRepository;
                const oTabela = this.byId(this.sIdTabela);
                const oModel = this.getView().getModel();

                oTabela.removeAllColumns();

                DataRepository.obterTodasEmpresas(oFiltro)
                    .then(aEmpresas => {
                        oModel.setProperty(this.sNomePropriedadeTabelaItems, aEmpresas);
                    })
                    .catch(oError => {
                        const sMensagemDeErro = "Erro ao obter Empresas:\n";
                        console.error(sMensagemDeErro, oError);
                    });
            }
            catch (erro) {
                const mensagemDeErro = "Erro ao popular tabela Empresas com dados:\n";
                console.error(mensagemDeErro + erro);
            }
        },

        _formataElementosTabelaEmpresas() {
            const oCamposEmpresas = {
                nomeFantasia: "nome",
                cnpj: "CNPJ",
                situacaoCadastral: "Situação Cadastral",
                dataAbertura: "Data Abertura",
                naturezaJuridica: "Natureza Juridica",
                capitalSocial: "Capital Social",
                estado: "Estado"
            }

            const arrayChavesCamposEmpresas = Object.keys(oCamposEmpresas);
            const posicaoArrayEstado = 6;
            const posicaoArrayCapitalSocial = 5;
            const posicaoArrayNaturezaJuridica = 4;
            const posicaoArrayDataAbertura = 3;
            const posicaoArraySituacaoCadastral = 2;

            try {
                const oTabela = this.byId(this.sIdTabela);
                oTabela.removeAllColumns();


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

                            if (sCampo === arrayChavesCamposEmpresas[posicaoArrayEstado]) {
                                return new sap.m.Text({
                                    text: {
                                        path: sCampo,
                                        formatter: this.formatador.textoEstado
                                    }
                                });
                            }

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
            }
            catch (erro)
            {
                const mensagemDeErro = "Erro ao formatar elementos da tabela Empresa:\n";
                console.error(mensagemDeErro + erro);
            }
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