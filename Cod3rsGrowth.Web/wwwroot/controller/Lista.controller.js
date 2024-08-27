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
                const roteador = this.getOwnerComponent().getRouter();

                roteador.getRoute(nomeRotaEmpresa).attachMatched(this._aoCoincidirComRotaEmpresas, this);
                roteador.getRoute(nomeRotaEscolas).attachMatched(this._aoCoincidirComRotaEscolas, this);
            }
            catch (erro) {
                const mensagemDeErro = "Erro ao inicializar a tela de listagem:\n";
                console.error(mensagemDeErro + erro);
            }
        },

        _aoCoincidirComRotaEmpresas: function () {
            const i18nTituloEmpresas = "tituloEmpresas";

            try {
                let modelo = this.getView().getModel();
                let i18n = this.getOwnerComponent().getModel(this.sNomeI18n).getResourceBundle();
                this.byId(this.sIdLista).setTitle(i18n.getText(i18nTituloEmpresas))
                modelo.setProperty(this.sNomePropriedadePainelExpandido, false);

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
            const i18nTituloEscolas = "tituloEsocolas";

            try {
                let modelo = this.getView().getModel();
                let i18n = this.getOwnerComponent().getModel(this.sNomeI18n).getResourceBundle();
                this.byId(this.sIdLista).setTitle(i18n.getText(i18nTituloEscolas));
                modelo.setProperty(this.sNomePropriedadePainelExpandido, false);

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
            const nomeFragmentoFiltroEmpresas = "ui5.cod3rsgrowth.view.FiltroEmpresas";

            try {
                const view = this.getView();

                Fragment.load({
                    id: view.getId(),
                    name: nomeFragmentoFiltroEmpresas,
                    controller: this
                }).then((panel) => {
                    const mainToolbar = view.byId(this.sIdPainelFiltro);
                    mainToolbar.addContent(panel);
                });
            }
            catch (erro) {
                const mensagemDeErro = "Erro ao carregar fragmento filtor empresas:\n";
                console.error(mensagemDeErro + erro);
            }
        },

        _removerFragmentoFiltroEmpresas() {
            try {
                const view = this.getView();
                const painelFiltro = this.byId(this.sIdPainelFiltro);
                const conteudoPainelFiltro = this.byId(view.getId() + "--filtroEmpresasFragment");

                if (conteudoPainelFiltro) {
                    painelFiltro.removeContent(conteudoPainelFiltro);
                    conteudoPainelFiltro.destroy();
                }
            }
            catch (erro) {
                const mensagemDeErro = "Erro ao remover fragmento filtro Empresas:\n";
                console.error(mensagemDeErro + erro);
            }
        },

        _carregaFragmentoFiltroEscolas() {
            const nomeFragmentoFiltroEscolas = "ui5.cod3rsgrowth.view.FiltroEscolas";

            try {
                const view = this.getView();

                Fragment.load({
                    id: view.getId(),
                    name: nomeFragmentoFiltroEscolas,
                    controller: this
                }).then((panel) => {
                    const mainToolbar = view.byId(this.sIdPainelFiltro);
                    mainToolbar.addContent(panel);
                });
            }
            catch (erro) {
                const mensagemDeErro = "Erro ao carregar fragmento filtro escolas:\n";
                console.error(mensagemDeErro + erro);
            }
        },

        _removerFragmentoFiltroEscolas() {
            try {
                const view = this.getView();
                const painelFiltro = this.byId(this.sIdPainelFiltro);
                const conteudoPainelFiltro = view.byId(view.getId() + "--filtroEscolasFragment");

                if (conteudoPainelFiltro) {
                    painelFiltro.removeContent(conteudoPainelFiltro);
                    conteudoPainelFiltro.destroy();
                }
            }
            catch (erro) {
                const mensagemDeErro = "Erro ao remover fragmento de filtro de escolas:\n";
                console.error(mensagemDeErro + erro);
            }
        },

        aoPressionarBotaoFiltrarEmpresa() {
            try {
                let filtro = this._retornaFiltroEmpresas();
                this._populaTabelaEmpresaComDados(filtro);
                this._formataElementosTabelaEmpresas();
            }
            catch (erro) {
                const mensagemDeErro = "Erro ao pressionar botão filtrar empresas:\n";
                console.error(mensagemDeErro + erro);
            }
        },

        aoPressionarBotaoFiltrarEscola() {
            try { 
                let filtro = this._retornaFiltroEscolas();
                this._populaTabelaEscolaComDados(filtro);
                this._formataElementosTabelaEscola();
            }
            catch (erro) {
                const mensagemDeErro = "Erro ao pressionar botão para filtrar Escolas:\n";
                console.error(mensagemDeErro + erro);
            }
        },
        _retornaFiltroEmpresas() {
            const nomePropriedadeSituacaoCadastralSelecioada = "/situacaoCadastralSelecionada";
            const nomePropriedadeNomeEmpresa = "/nomeEmpresa";
            const nomePropriedadeCnpjEmpresa = "/cnpjEmpresa";
            const nomePropriedadeCapitalSocialEmpresa = "/capitalSocialEmpresa";
            const nomePropriedadeDataAbertura = "/dataAbertura";
            const nomePropriedadeNaturezaJuridicaSelecionada = "/naturezaJuridicaSelecionada";
            const nomePropriedadeEstadoSelecionado = "/estadoSelecionado";
            
            try {
                let modelo = this.getView().getModel();
                return {
                    SituacaoCadastralFiltro: modelo.getProperty(nomePropriedadeSituacaoCadastralSelecioada),
                    RazaoSocialFiltro: modelo.getProperty(nomePropriedadeNomeEmpresa),
                    CnpjFiltro: modelo.getProperty(nomePropriedadeCnpjEmpresa),
                    CapitalSocialFiltro: modelo.getProperty(nomePropriedadeCapitalSocialEmpresa),
                    DataAberturaFiltro: modelo.getProperty(nomePropriedadeDataAbertura),
                    NaturezaJuridicaFiltro: modelo.getProperty(nomePropriedadeNaturezaJuridicaSelecionada),
                    EstadoFiltro: modelo.getProperty(nomePropriedadeEstadoSelecionado)
                }
            }
            catch (erro) {
                const mensagemDeErro = "Erro ao retornar valores do filtro empresas:\n";
                console.error(mensagemDeErro + erro);
            }
        },

        _retornaFiltroEscolas() {
            const nomePropriedadeNomeEscola = "/nomeEscola";
            const nomePropriedadeCodigoMec = "/codigoMec";
            const nomePropriedadeStatusAtividadeSelecionada = "/statusAtividadeSelecionada";
            const nomePropriedadeOrganizacaoAcademicaSelecioada = "/organizacaoAcademicaSelecionada";
            const nomePropriedadeEstadoSelecionado = "/estadoSelecionado";
            
            try {
                let modelo = this.getView().getModel();
                return {
                    NomeFiltro: modelo.getProperty(nomePropriedadeNomeEscola),
                    CodigoMecFiltro: modelo.getProperty(nomePropriedadeCodigoMec),
                    StatusAtividadeFiltro: modelo.getProperty(nomePropriedadeStatusAtividadeSelecionada),
                    OrganizacaoAcademicaFiltro: modelo.getProperty(nomePropriedadeOrganizacaoAcademicaSelecioada),
                    EstadoFiltro: modelo.getProperty(nomePropriedadeEstadoSelecionado)
                }
            }
            catch (erro) {
                const mensagemDeErro = "Erro ao retornar valores do filtro escolas:\n"
                console.error(mensagemDeErro + erro);
            }
        },

        _populaTabelaEmpresaComDados(filtro) {
            try {
                const DataRepository = this.getOwnerComponent().DataRepository;
                const tabela = this.byId(this.sIdTabela);
                const modelo = this.getView().getModel();

                tabela.removeAllColumns();

                DataRepository.obterTodasEmpresas(filtro)
                    .then(empresas => {
                        modelo.setProperty(this.sNomePropriedadeTabelaItems, empresas);
                    })
                    .catch(error => {
                        const sMensagemDeErro = "Erro ao obter Empresas:\n";
                        console.error(sMensagemDeErro, error);
                    });
            }
            catch (erro) {
                const mensagemDeErro = "Erro ao popular tabela Empresas com dados:\n";
                console.error(mensagemDeErro + erro);
            }
        },

        _formataElementosTabelaEmpresas() {
            const camposEmpresas = {
                nomeFantasia: "nome",
                cnpj: "CNPJ",
                situacaoCadastral: "Situação Cadastral",
                dataAbertura: "Data Abertura",
                naturezaJuridica: "Natureza Juridica",
                capitalSocial: "Capital Social",
                estado: "Estado"
            }

            const arrayChavesCamposEmpresas = Object.keys(camposEmpresas);
            const posicaoArrayEstado = 6;
            const posicaoArrayCapitalSocial = 5;
            const posicaoArrayNaturezaJuridica = 4;
            const posicaoArrayDataAbertura = 3;
            const posicaoArraySituacaoCadastral = 2;

            try {
                const tabela = this.byId(this.sIdTabela);
                tabela.removeAllColumns();


                Object.entries(camposEmpresas).forEach(([sCampo, sHeader]) => {
                    tabela.addColumn(new sap.m.Column({
                        header: new sap.m.Label({ text: sHeader })
                    }));
                });

                let view = this.getView();

                tabela.bindItems({
                    path: this.sNomePropriedadeTabelaItems,
                    template: new sap.m.ColumnListItem({
                        cells: Object.keys(camposEmpresas).map(campo => {

                            if (campo === arrayChavesCamposEmpresas[posicaoArrayEstado]) {
                                return new sap.m.Text({
                                    text: {
                                        path: campo,
                                        formatter: this.formatador.textoEstado
                                    }
                                });
                            }

                            if (campo === arrayChavesCamposEmpresas[posicaoArrayNaturezaJuridica]) {
                                return new sap.m.Text({
                                    text: {
                                        path: campo,
                                        formatter: function (naturezaJuridica) {
                                            return this.formatador.textoNaturezaJuridica(naturezaJuridica, view);
                                        }.bind(this)
                                    }
                                });
                            }

                            if (campo === arrayChavesCamposEmpresas[posicaoArraySituacaoCadastral]) {
                                return new sap.m.Text({
                                    text: {
                                        path: campo,
                                        formatter: function (situacaoCadastral) {
                                            return this.formatador.textoSituacaoCadastral(situacaoCadastral, view);
                                        }.bind(this)
                                    }
                                });
                            }

                            if (campo === arrayChavesCamposEmpresas[posicaoArrayCapitalSocial]) {
                                return new sap.m.Text({
                                    text: {
                                        path: campo,
                                        formatter: function (capitalSocial) {
                                            let oFormatadorFloat = NumberFormat.getFloatInstance(this.oOpcoesFormatadorDecimais);
                                            return oFormatadorFloat.format(capitalSocial);
                                        }.bind(this)
                                    }
                                })
                            }

                            if (campo === arrayChavesCamposEmpresas[posicaoArrayDataAbertura]) {
                                return new sap.m.Text({
                                    text: {
                                        path: campo,
                                        formatter: function (dataAbertura) {
                                            let oFormatadorData = DateFormat.getDateInstance(this.oOpcoesFormatadorData);
                                            return oFormatadorData.format(dataAbertura);
                                        }
                                    }
                                })
                            }
                            return new sap.m.Text({ text: "{" + campo + "}" });
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

        _populaTabelaEscolaComDados(filtro) {
            const DataRepository = this.getOwnerComponent().DataRepository;
            const model = this.getView().getModel();

            DataRepository.obterTodasEscolas(filtro)
                .then(aEscolas => {
                    model.setProperty(this.sNomePropriedadeTabelaItems, aEscolas);
                })
                .catch(oError => {
                    const sMensagemDeErro = "Erro ao obter Escolas:"
                    console.error(sMensagemDeErro, oError);
                });
        },

        _formataElementosTabelaEscola() {
            const tabela = this.byId(this.sIdTabela);

            tabela.removeAllColumns();

            const oCamposEscolas = {
                nome: "Nome",
                codigoMec: "Código MEC",
                statusAtividade: "Status Atividade",
                organizacaoAcademica: "Organização Acadêmica",
                estado: "Estado"
            };

            let oView = this.getView();

            Object.entries(oCamposEscolas).forEach(([sCampo, cabecalho]) => {
                tabela.addColumn(new sap.m.Column({
                    header: new sap.m.Label({ text: cabecalho })
                }));
            });

            tabela.bindItems({
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