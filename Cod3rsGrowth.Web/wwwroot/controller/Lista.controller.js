sap.ui.define([
    "sap/ui/core/Fragment",
    "sap/ui/core/format/NumberFormat",
    "sap/ca/ui/model/format/DateFormat",
    "ui5/cod3rsgrowth/modelos/Servicos/ServicoEmpresas",
    "ui5/cod3rsgrowth/modelos/Servicos/ServicoEscolas",
    "sap/ui/model/json/JSONModel",
    "ui5/cod3rsgrowth/controller/ControllerBase"
], (
    Fragment,
    NumberFormat,
    DateFormat,
    ServicoEmpresas,
    ServicoEscolas,
    JSONModel,
    ControllerBase
) => {
    "use strict";

    return ControllerBase.extend("ui5.cod3rsgrowth.controller.Lista", {
        _sIdLista: "lista",
        _idTabela: "tabela",
        _idPainelFiltro: "painelFiltros",
        _nomePropriedadePainelExpandido: "/painelExpandido",
        _nomePropriedadeTabelaItems: "/items",
        _rotaAtual: "",
        _opcoesFormatadorDecimais: {
            minIntegerDigits: 1,
            MaxIntegerDigits: 3,
            minFractionsDigits: 2,
            maxFractionDigits: 2,
            style: "short"
        },
        _opcoesFormatadorData: {
            pattern: 'yyyy-MM-ddTHH:mm:ss'
        },

        onInit() {
            const nomeRotaEmpresa = "Empresas";
            const nomeRotaEscolas = "Escolas";
            const roteador = this.getOwnerComponent().getRouter();
            roteador.getRoute(nomeRotaEmpresa).attachMatched(this._aoCoincidirComRotaEmpresas, this);
            roteador.getRoute(nomeRotaEscolas).attachMatched(this._aoCoincidirComRotaEscolas, this);
        },

        _aoCoincidirComRotaEmpresas: function (oEvent) {
            this._rotaAtual = oEvent.getParameter("name");
            const i18nTituloEmpresas = "Lista.TituloEmpresas";
            const i18nMensagemDeErro = "Lista.ErroRotaEmpresas";
            let i18n = this.modeloI18n();
            this.tratarErros(i18nMensagemDeErro, () => {
                let modelo = this.modeloPadrao();
                this.byId(this._sIdLista).setTitle(i18n.getText(i18nTituloEmpresas))
                modelo.setProperty(this._nomePropriedadePainelExpandido, false);

                this._removerFragmentoFiltroEmpresas();
                this._removerFragmentoFiltroEscolas();
                this._configurarModeloDoFiltroEmpresa();
                this._carregarFragmentoFiltroEmpresas();
                this._popularTabelaEmpresasComDados({});
                this._formatarElementosDaTabelaEmpresas();
            });
        },

        _aoCoincidirComRotaEscolas: function (oEvent) {
            this._rotaAtual = oEvent.getParameter("name");
            const i18nTituloEscolas = "Lista.TituloEsocolas";
            const i18nMensagemDeErro = "Lista.ErroRotaEscolas";
            let i18n = this.modeloI18n();
            this.tratarErros(i18nMensagemDeErro, () => {
                let modelo = this.modeloPadrao();
                this.byId(this._sIdLista).setTitle(i18n.getText(i18nTituloEscolas));
                modelo.setProperty(this._nomePropriedadePainelExpandido, false);

                this._removerFragmentoFiltroEmpresas();
                this._removerFragmentoFiltroEscolas();
                this._configurarModeloDoFiltroEscola();
                this._carregarFragmentoFiltroEscolas();
                this._popularTabelaEscolasComDados({});
                this._formatarElementosDaTabelaEscola();
            });
        },

        _carregarFragmentoFiltroEmpresas() {
            const nomeFragmentoFiltroEmpresas = "ui5.cod3rsgrowth.view.FiltroEmpresas";
            const i18nMensagemDeErro = "Lista.ErroCarregarFiltroEmpresas";
            this.tratarErros(i18nMensagemDeErro, () => {
                const view = this.getView();
                Fragment.load({
                    id: view.getId(),
                    name: nomeFragmentoFiltroEmpresas,
                    controller: this
                }).then((panel) => {
                    const mainToolbar = view.byId(this._idPainelFiltro);
                    mainToolbar.addContent(panel);
                });
            });
        },

        _removerFragmentoFiltroEmpresas() {
            const i18nMensagemDeErro = "Lista.ErroRemoveFiltroEmpresas";
            this.tratarErros(i18nMensagemDeErro, () => {
                const view = this.getView();
                const painelFiltro = this.byId(this._idPainelFiltro);
                const conteudoPainelFiltro = this.byId(view.getId() + "--filtroEmpresasFragment");

                if (conteudoPainelFiltro) {
                    painelFiltro.removeContent(conteudoPainelFiltro);
                    conteudoPainelFiltro.destroy();
                }
            });
        },

        _carregarFragmentoFiltroEscolas() {
            const nomeFragmentoFiltroEscolas = "ui5.cod3rsgrowth.view.FiltroEscolas";
            const i18nMensagemDeErro = "Lista.ErroCarregarFiltroEscolas";

            this.tratarErros(i18nMensagemDeErro, () => {
                const view = this.getView();
                Fragment.load({
                    id: view.getId(),
                    name: nomeFragmentoFiltroEscolas,
                    controller: this
                }).then((panel) => {
                    const mainToolbar = view.byId(this._idPainelFiltro);
                    mainToolbar.addContent(panel);
                });
            });
        },

        _removerFragmentoFiltroEscolas() {
            const i18nMensagemDeErro = "Lista.ErroRemoveFiltroEscolas";
            this.tratarErros(i18nMensagemDeErro, () => {
                const view = this.getView();
                const painelFiltro = this.byId(this._idPainelFiltro);
                const conteudoPainelFiltro = view.byId(view.getId() + "--filtroEscolasFragment");

                if (conteudoPainelFiltro) {
                    painelFiltro.removeContent(conteudoPainelFiltro);
                    conteudoPainelFiltro.destroy();
                }
            });
        },

        aoPressionarBotaoFiltrarEmpresa() {
            const i18nMensagemDeErro = "Lista.ErroPressionaBotaoFiltrarEmpresas";
            this.tratarErros(i18nMensagemDeErro, () => {
                let filtro = this._obterValoresDoFiltroEmpresasDaTela();
                this._popularTabelaEmpresasComDados(filtro);
                this._formatarElementosDaTabelaEmpresas();
            });
        },

        aoPressionarBotaoFiltrarEscola() {
            const i18nMensagemDeErro = "Lista.ErroPressionaBotaoFiltrarEscolas";
            this.tratarErros(i18nMensagemDeErro, () => {
                let filtro = this._obterValoresDoFiltroEscolasDaTela();
                this._popularTabelaEscolasComDados(filtro);
                this._formatarElementosDaTabelaEscola();
            });
        },
        _configurarModeloDoFiltroEmpresa() {
            let dadosFiltroEmpresa = {
                SituacaoCadastralFiltro: undefined,
                RazaoSocialFiltro: undefined,
                CnpjFiltro: undefined,
                CapitalSocialFiltro: undefined,
                DataAberturaFiltro: undefined,
                NaturezaJuridicaFiltro: undefined,
                EstadoFiltro: undefined
            }
            this._modeloFiltroEmpresa(new JSONModel(dadosFiltroEmpresa));
        },
        _obterValoresDoFiltroEmpresasDaTela() {
            return this._modeloFiltroEmpresa().getData();
        },
        _configurarModeloDoFiltroEscola() {
            let dadosFiltroEscola = {
                NomeFiltro: undefined,
                CodigoMecFiltro: undefined,
                StatusAtividadeFiltro: undefined,
                OrganizacaoAcademicaFiltro: undefined,
                EstadoFiltro: undefined
            };
            this._modeloFiltroEscola(new JSONModel(dadosFiltroEscola));
        },

        _obterValoresDoFiltroEscolasDaTela() {
            return this._modeloFiltroEscola().getData();
        },

        _popularTabelaEmpresasComDados(filtro) {
            const i18nMensagemDeErro = "Lista.ErroPopulaTabelaEmpresas";
            this.tratarErros(i18nMensagemDeErro, () => {
                const tabela = this.byId(this._idTabela);
                const modelo = this.modeloPadrao();
                tabela.removeAllColumns();

                ServicoEmpresas.obterTodasEmpresas(filtro)
                    .then(empresas => {
                        modelo.setProperty(this._nomePropriedadeTabelaItems, empresas);
                    })
                    .catch(erro => {
                        const i18nMensagemDeErro = "Lista.ErroPopulaTabelaEmpresasRequisicao";
                        const i18n = this.modeloI18n();
                        const mensagemDeErro = i18n.getText(i18nMensagemDeErro);
                        this.mostraMensagemDeErro(mensagemDeErro, erro);
                    });
            });
        },

        _formatarElementosDaTabelaEmpresas() {
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

            const i18nMensagemDeErro = "Lista.ErroFormataTabelaEmpresas";
            this.tratarErros(i18nMensagemDeErro, () => {
                const tabela = this.byId(this._idTabela);
                tabela.removeAllColumns();


                Object.entries(camposEmpresas).forEach(([campo, cabecalho]) => {
                    tabela.addColumn(new sap.m.Column({
                        header: new sap.m.Label({ text: cabecalho })
                    }));
                });
                let view = this.getView();

                tabela.bindItems({
                    path: this._nomePropriedadeTabelaItems,
                    template: new sap.m.ColumnListItem({
                        type: "DetailAndActive",
                        detailPress: (oEvent) => this._aoPressionarBotaoEditarEmpresa(oEvent),
                        press: (oEvent) => this._aoPressionarSobreItemEmpresa(oEvent),
                        cells: Object.keys(camposEmpresas).map(campo => {
                            if (campo === arrayChavesCamposEmpresas[posicaoArrayEstado]) {
                                return new sap.m.Text({
                                    text: {
                                        path: campo,
                                        formatter: (codigo) => this.obterTextoDoEstado(codigo)
                                    }
                                });
                            }

                            if (campo === arrayChavesCamposEmpresas[posicaoArrayNaturezaJuridica]) {
                                return new sap.m.Text({
                                    text: {
                                        path: campo,
                                        formatter: (codigo) => this.obterTextoDaNaturezaJuridica(codigo)
                                    }
                                });
                            }

                            if (campo === arrayChavesCamposEmpresas[posicaoArraySituacaoCadastral]) {
                                return new sap.m.Text({
                                    text: {
                                        path: campo,
                                        formatter: (codigo) => this.obterTextoDoHabilitado(codigo)
                                    }
                                });
                            }

                            if (campo === arrayChavesCamposEmpresas[posicaoArrayCapitalSocial]) {
                                return new sap.m.Text({
                                    text: {
                                        path: campo,
                                        formatter: (capitalSocial) => {
                                            let formatadorFloat = NumberFormat.getFloatInstance(this._opcoesFormatadorDecimais);
                                            return formatadorFloat.format(capitalSocial);
                                        }
                                    }
                                })
                            }

                            if (campo === arrayChavesCamposEmpresas[posicaoArrayDataAbertura]) {
                                return new sap.m.Text({
                                    text: {
                                        path: campo,
                                        formatter: (dataAbertura) => {
                                            let formatadorData = DateFormat.getDateInstance(this._opcoesFormatadorData);
                                            return formatadorData.format(dataAbertura);
                                        }
                                    }
                                })
                            }
                            return new sap.m.Text({ text: "{" + campo + "}" });
                        })
                    })
                })
            });
        },

        _popularTabelaEscolasComDados(filtro) {
            const i18nMensagemDeErro = "Lista.ErroPopulaTabelaEscolas";
            this.tratarErros(i18nMensagemDeErro, () => {
                const tabela = this.byId(this._idTabela);
                const modelo = this.modeloPadrao();

                tabela.removeAllColumns();

                ServicoEscolas.obterTodasEscolas(filtro)
                    .then(escolas => {
                        modelo.setProperty(this._nomePropriedadeTabelaItems, escolas);
                    })
                    .catch(erro => {
                        const i18nMensagemDeErro = "Lista.ErroPopulaTabelaEscolasRequisicao";
                        const i18n = this.modeloI18n();
                        const mensagemDeErro = i18n.getText(i18nMensagemDeErro);
                        this.mostraMensagemDeErro(mensagemDeErro, erro);
                    });
            });
        },

        _formatarElementosDaTabelaEscola() {
            const camposEscolas = {
                nome: "Nome",
                codigoMec: "Código MEC",
                statusAtividade: "Status Atividade",
                organizacaoAcademica: "Organização Acadêmica",
                estado: "Estado"
            };

            const i18nMensagemDeErro = "Lista.ErroFormataTabelaEscolas";
            this.tratarErros(i18nMensagemDeErro, () => {
                const tabela = this.byId(this._idTabela);

                tabela.removeAllColumns();
                let view = this.getView();

                Object.entries(camposEscolas).forEach(([campo, cabecalho]) => {
                    tabela.addColumn(new sap.m.Column({
                        header: new sap.m.Label({ text: cabecalho })
                    }));
                });

                tabela.bindItems({
                    path: this._nomePropriedadeTabelaItems,
                    template: new sap.m.ColumnListItem({
                        detailPress: (oEvent) => this._aoPressionarBotaoEditarEscola(oEvent),
                        press: (oEvent) => this._aoPressionarSobreItemEscola(oEvent),
                        type: "DetailAndActive",
                        cells: Object.keys(camposEscolas).map(campo => {
                            if (campo === "estado") {
                                return new sap.m.Text({
                                    text: {
                                        path: campo,
                                        formatter: (codigo) => this.obterTextoDoEstado(codigo)
                                    }
                                });
                            }

                            const posicaoArrayOrganizacaoAcademica = 3;
                            const arrayChavesCamposEscolas = Object.keys(camposEscolas);
                            if (campo === arrayChavesCamposEscolas[posicaoArrayOrganizacaoAcademica]) {
                                return new sap.m.Text({
                                    text: {
                                        path: campo,
                                        formatter: (codigo) => this.obterTextoDaOrganizacaoAcademica(codigo)
                                    }
                                });
                            }

                            const posicaoArrayStatusAtividade = 2;
                            if (campo === arrayChavesCamposEscolas[posicaoArrayStatusAtividade]) {
                                return new sap.m.Text({
                                    text: {
                                        path: campo,
                                        formatter: (codigo) => this.obterTextoDoHabilitado(codigo)
                                    }
                                });
                            }

                            return new sap.m.Text({ text: "{" + campo + "}" });
                        })
                    })
                })
            });
        },
        aoPressionarBotaoCriar() {
            if (this._rotaAtual === "Empresas") {
                const i18nMensagemDeErro = "Lista.ErroPressionaBotaoCriarEmpresa";
                this.tratarErros(i18nMensagemDeErro, () => {
                    const nomeRotaCriarEmpresas = "EmpresaCriar";
                    const roteador = this.getOwnerComponent().getRouter();
                    roteador.navTo(nomeRotaCriarEmpresas);
                });
            }
            else {
                const i18nMensagemDeErro = "Lista.ErroPressionaBotaoCriarEmpresa";
                this.tratarErros(i18nMensagemDeErro, () => {
                    const nomeRotaCriarEscolas = "EscolaCriar";
                    const roteador = this.getOwnerComponent().getRouter();
                    roteador.navTo(nomeRotaCriarEscolas);
                });
            }
        },
        _aoPressionarBotaoEditarEmpresa(oEvent) {
            const empresaEditar = oEvent.getSource()
                .getBindingContext().getObject();
            const i18nMensagemDeErro = "Lista.ErroPressionaBotaoEditarEmpresa";
            this.tratarErros(i18nMensagemDeErro, () => {
                const nomeRotaEditarEmpresa = "EmpresaEditar";
                const roteador = this.getOwnerComponent().getRouter();
                roteador.navTo(nomeRotaEditarEmpresa, {
                    caminhoEmpresa: window.encodeURIComponent(empresaEditar.id)
                });
            });
        },

        _aoPressionarBotaoEditarEscola(oEvent) {
            const escolaEditar = oEvent.getSource()
                .getBindingContext().getObject();
            const i18nMensagemDeErro = "Lista.ErroPressionaBotaoEditarEscola";
            this.tratarErros(i18nMensagemDeErro, () => {
                const nomeRotaEditarEscola = "EscolaEditar";
                const roteador = this.getOwnerComponent().getRouter();
                roteador.navTo(nomeRotaEditarEscola, {
                    caminhoEscola: window.encodeURIComponent(escolaEditar.id)
                });
            });
        },
        _modeloFiltroEmpresa: function (modelo) {
            const nomeModelo = "FiltroEmpresa";
            return this.modelo(nomeModelo, modelo);
        },
        _modeloFiltroEscola: function (modelo) {
            const nomeModelo = "FiltroEscola";
            return this.modelo(nomeModelo, modelo);
        },
        _aoPressionarSobreItemEscola(oEvent) {
            const escolaDetalhes = oEvent.getSource()
                .getBindingContext().getObject();
            const i18nMensagemDeErro = "Lista.ErroPressionaBotaoVisualizarEscola";
            this.tratarErros(i18nMensagemDeErro, () => {
                const nomeRotaDetalhesEscola = "EscolaDetalhes";
                const roteador = this.getOwnerComponent().getRouter();
                roteador.navTo(nomeRotaDetalhesEscola, {
                    caminhoEscola: window.encodeURIComponent(escolaDetalhes.id)
                });
            });
        },
        _aoPressionarSobreItemEmpresa(oEvent) {
            const escolaDetalhes = oEvent.getSource()
                .getBindingContext().getObject();
            const i18nMensagemDeErro = "Lista.ErroPressionaBotaoVisualizarEmpresa";
            this.tratarErros(i18nMensagemDeErro, () => {
                const nomeRotaDtalhesEmpresa = "EmpresaDetalhes";
                const roteador = this.getOwnerComponent().getRouter();
                roteador.navTo(nomeRotaDtalhesEmpresa, {
                    caminhoEmpresa: window.encodeURIComponent(escolaDetalhes.id)
                });
            });
        }
    });
});