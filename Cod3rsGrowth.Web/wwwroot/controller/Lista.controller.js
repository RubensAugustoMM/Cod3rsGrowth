sap.ui.define([
    "sap/ui/core/mvc/Controller",
    "ui5/cod3rsgrowth/modelos/Formatador",
    "sap/ui/core/Fragment",
    "sap/ui/core/format/NumberFormat",
    "sap/ca/ui/model/format/DateFormat",
    "ui5/cod3rsgrowth/modelos/Servicos/ServicoEmpresas",
    "ui5/cod3rsgrowth/modelos/Servicos/ServicoEscolas",
    "sap/ui/model/json/JSONModel",
    "sap/m/MessageBox"
], (Controller,
    Formatador,
    Fragment,
    NumberFormat,
    DateFormat,
    ServicoEmpresas,
    ServicoEscolas,
    JSONModel,
    MessageBox) => {
    "use strict";

    return Controller.extend("ui5.cod3rsgrowth.controller.Lista", {

        _formatador: Formatador,
        _sIdLista: "lista",
        _idTabela: "tabela",
        _idPainelFiltro: "painelFiltros",
        _nomeModeloI18n: "i18n",
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
            let i18n = this._retornaModeloI18n();
            this._trataErros(i18nMensagemDeErro, () => {
                let modelo = this.getView().getModel();
                this.byId(this._sIdLista).setTitle(i18n.getText(i18nTituloEmpresas))
                modelo.setProperty(this._nomePropriedadePainelExpandido, false);

                this._removerFragmentoFiltroEmpresas();
                this._removerFragmentoFiltroEscolas();
                this._carregaFragmentoFiltroEmpresas();
                this._populaTabelaEmpresaComDados({});
                this._formataElementosTabelaEmpresas();
            });
        },

        _aoCoincidirComRotaEscolas: function (oEvent) {
            this._rotaAtual = oEvent.getParameter("name");
            const i18nTituloEscolas = "Lista.TituloEsocolas";
            const i18nMensagemDeErro = "Lista.ErroRotaEscolas";
            let i18n = this._retornaModeloI18n();

            this._trataErros(i18nMensagemDeErro, () => {
                let modelo = this.getView().getModel();
                this.byId(this._sIdLista).setTitle(i18n.getText(i18nTituloEscolas));
                modelo.setProperty(this._nomePropriedadePainelExpandido, false);

                this._removerFragmentoFiltroEmpresas();
                this._removerFragmentoFiltroEscolas();
                this._carregaFragmentoFiltroEscolas();
                this._populaTabelaEscolaComDados({});
                this._formataElementosTabelaEscola();
            });
        },

        _carregaFragmentoFiltroEmpresas() {
            const nomeFragmentoFiltroEmpresas = "ui5.cod3rsgrowth.view.FiltroEmpresas";
            const i18nMensagemDeErro = "Lista.ErroCarregarFiltroEmpresas";

            this._trataErros(i18nMensagemDeErro, () => {
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
            this._trataErros(i18nMensagemDeErro, () => {
                const view = this.getView();
                const painelFiltro = this.byId(this._idPainelFiltro);
                const conteudoPainelFiltro = this.byId(view.getId() + "--filtroEmpresasFragment");

                if (conteudoPainelFiltro) {
                    painelFiltro.removeContent(conteudoPainelFiltro);
                    conteudoPainelFiltro.destroy();
                }
            });
        },

        _carregaFragmentoFiltroEscolas() {
            const nomeFragmentoFiltroEscolas = "ui5.cod3rsgrowth.view.FiltroEscolas";
            const i18nMensagemDeErro = "Lista.ErroCarregarFiltroEscolas";

            this._trataErros(i18nMensagemDeErro, () => {
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
            this._trataErros(i18nMensagemDeErro, () => {
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
            this._trataErros(i18nMensagemDeErro, () => {
                let filtro = this._retornaFiltroEmpresas();
                this._populaTabelaEmpresaComDados(filtro);
                this._formataElementosTabelaEmpresas();
            });
        },

        aoPressionarBotaoFiltrarEscola() {
            const i18nMensagemDeErro = "Lista.ErroPressionaBotaoFiltrarEscolas";
            this._trataErros(i18nMensagemDeErro, () => {
                let filtro = this._retornaFiltroEscolas();
                this._populaTabelaEscolaComDados(filtro);
                this._formataElementosTabelaEscola();
            });
        },
        _retornaFiltroEmpresas() {
            const nomePropriedadeSituacaoCadastralSelecioada = "/situacaoCadastralSelecionada";
            const nomePropriedadeNomeEmpresa = "/nomeEmpresa";
            const nomePropriedadeCnpjEmpresa = "/cnpjEmpresa";
            const nomePropriedadeCapitalSocialEmpresa = "/capitalSocialEmpresa";
            const nomePropriedadeDataAbertura = "/dataAbertura";
            const nomePropriedadeNaturezaJuridicaSelecionada = "/naturezaJuridicaSelecionada";
            const nomePropriedadeEstadoSelecionado = "/estadoSelecionado";
            const modelo = this.getView().getModel();
            return {
                SituacaoCadastralFiltro: modelo.getProperty(nomePropriedadeSituacaoCadastralSelecioada),
                RazaoSocialFiltro: modelo.getProperty(nomePropriedadeNomeEmpresa),
                CnpjFiltro: modelo.getProperty(nomePropriedadeCnpjEmpresa),
                CapitalSocialFiltro: modelo.getProperty(nomePropriedadeCapitalSocialEmpresa),
                DataAberturaFiltro: modelo.getProperty(nomePropriedadeDataAbertura),
                NaturezaJuridicaFiltro: modelo.getProperty(nomePropriedadeNaturezaJuridicaSelecionada),
                EstadoFiltro: modelo.getProperty(nomePropriedadeEstadoSelecionado)
            }
        },

        _retornaFiltroEscolas() {
            const nomePropriedadeNomeEscola = "/nomeEscola";
            const nomePropriedadeCodigoMec = "/codigoMec";
            const nomePropriedadeStatusAtividadeSelecionada = "/statusAtividadeSelecionada";
            const nomePropriedadeOrganizacaoAcademicaSelecioada = "/organizacaoAcademicaSelecionada";
            const nomePropriedadeEstadoSelecionado = "/estadoSelecionado";
            let modelo = this.getView().getModel();
            return {
                NomeFiltro: modelo.getProperty(nomePropriedadeNomeEscola),
                CodigoMecFiltro: modelo.getProperty(nomePropriedadeCodigoMec),
                StatusAtividadeFiltro: modelo.getProperty(nomePropriedadeStatusAtividadeSelecionada),
                OrganizacaoAcademicaFiltro: modelo.getProperty(nomePropriedadeOrganizacaoAcademicaSelecioada),
                EstadoFiltro: modelo.getProperty(nomePropriedadeEstadoSelecionado)
            }
        },

        _populaTabelaEmpresaComDados(filtro) {
            const i18nMensagemDeErro = "Lista.ErroPopulaTabelaEmpresas";
            this._trataErros(i18nMensagemDeErro, () => {
                const tabela = this.byId(this._idTabela);
                const modelo = this.getView().getModel();

                tabela.removeAllColumns();

                ServicoEmpresas.obterTodasEmpresas(filtro)
                    .then(empresas => {
                        modelo.setProperty(this._nomePropriedadeTabelaItems, empresas);
                    })
                    .catch(erro => {
            
                        const i18nMensagemDeErro = "Lista.ErroPopulaTabelaEmpresasRequisicao";
                        const i18n = this._retornaModeloI18n();
                        const mensagemDeErro = i18n.getText(i18nMensagemDeErro);
                        this._mostraMensagemDeErro(mensagemDeErro, erro);
                    });
            });
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

            const i18nMensagemDeErro = "Lista.ErroFormataTabelaEmpresas";
            this._trataErros(i18nMensagemDeErro, () => {
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
                        cells: Object.keys(camposEmpresas).map(campo => {

                            if (campo === arrayChavesCamposEmpresas[posicaoArrayEstado]) {
                                return new sap.m.Text({
                                    text: {
                                        path: campo,
                                        formatter: this._formatador.textoEstado
                                    }
                                });
                            }

                            if (campo === arrayChavesCamposEmpresas[posicaoArrayNaturezaJuridica]) {
                                return new sap.m.Text({
                                    text: {
                                        path: campo,
                                        formatter: function (naturezaJuridica) {
                                            return this._formatador.textoNaturezaJuridica(naturezaJuridica, view);
                                        }.bind(this)
                                    }
                                });
                            }

                            if (campo === arrayChavesCamposEmpresas[posicaoArraySituacaoCadastral]) {
                                return new sap.m.Text({
                                    text: {
                                        path: campo,
                                        formatter: function (situacaoCadastral) {
                                            return this._formatador.textoSituacaoCadastral(situacaoCadastral, view);
                                        }.bind(this)
                                    }
                                });
                            }

                            if (campo === arrayChavesCamposEmpresas[posicaoArrayCapitalSocial]) {
                                return new sap.m.Text({
                                    text: {
                                        path: campo,
                                        formatter: function (capitalSocial) {
                                            let formatadorFloat = NumberFormat.getFloatInstance(this._opcoesFormatadorDecimais);
                                            return formatadorFloat.format(capitalSocial);
                                        }.bind(this)
                                    }
                                })
                            }

                            if (campo === arrayChavesCamposEmpresas[posicaoArrayDataAbertura]) {
                                return new sap.m.Text({
                                    text: {
                                        path: campo,
                                        formatter: function (dataAbertura) {
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

        _populaTabelaEscolaComDados(filtro) {
            const i18nMensagemDeErro = "Lista.ErroPopulaTabelaEscolas";
            this._trataErros(i18nMensagemDeErro, () => {
                const tabela = this.byId(this._idTabela);
                const modelo = this.getView().getModel();

                tabela.removeAllColumns();

                ServicoEscolas.obterTodasEscolas(filtro)
                    .then(escolas => {
                        modelo.setProperty(this._nomePropriedadeTabelaItems, escolas);
                    })
                    .catch(erro => {
                        const i18nMensagemDeErro = "Lista.ErroPopulaTabelaEscolasRequisicao";
                        const i18n = this._retornaModeloI18n();
                        const mensagemDeErro = i18n.getText(i18nMensagemDeErro);
                        this._mostraMensagemDeErro(mensagemDeErro, erro);
                    });
            });
        },

        _formataElementosTabelaEscola() {

            const camposEscolas = {
                nome: "Nome",
                codigoMec: "Código MEC",
                statusAtividade: "Status Atividade",
                organizacaoAcademica: "Organização Acadêmica",
                estado: "Estado"
            };


            const i18nMensagemDeErro = "Lista.ErroFormataTabelaEscolas";
            this._trataErros(i18nMensagemDeErro, () => {
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
                        cells: Object.keys(camposEscolas).map(campo => {
                            if (campo === "estado") {
                                return new sap.m.Text({
                                    text: {
                                        path: campo,
                                        formatter: this._formatador.textoEstado
                                    }
                                });
                            }

                            const posicaoArrayOrganizacaoAcademica = 3;
                            const arrayChavesCamposEscolas = Object.keys(camposEscolas);
                            if (campo === arrayChavesCamposEscolas[posicaoArrayOrganizacaoAcademica]) {
                                return new sap.m.Text({
                                    text: {
                                        path: campo,
                                        formatter: function (organizacaoAcademica) {
                                            return this._formatador.textoOrganizacaoAcademica(organizacaoAcademica, view);
                                        }.bind(this)
                                    }
                                });
                            }

                            const posicaoArrayStatusAtividade = 2;
                            if (campo === arrayChavesCamposEscolas[posicaoArrayStatusAtividade]) {
                                return new sap.m.Text({
                                    text: {
                                        path: campo,
                                        formatter: function (statusAtividade) {
                                            return this._formatador.textoSituacaoCadastral(statusAtividade, view);
                                        }.bind(this)
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
                this._trataErros(i18nMensagemDeErro, () => {
                    const nomeRotaCriarEmpresas = "EmpresaCriar";
                    const roteador = this.getOwnerComponent().getRouter();
                    roteador.navTo(nomeRotaCriarEmpresas);
                });
            }
            else {
                const i18nMensagemDeErro = "Lista.ErroPressionaBotaoCriarEmpresa";
                this._trataErros(i18nMensagemDeErro, () => {
                    const nomeRotaCriarEscolas = "EscolaCriar";
                    const roteador = this.getOwnerComponent().getRouter();
                    roteador.navTo(nomeRotaCriarEscolas);
                });
            }
        },
        _mostraMensagemDeErro(mensagemDeErro, erro) {
            console.error(mensagemDeErro + erro);
            MessageBox.show(erro, {
                icon: MessageBox.Icon.ERROR,
                title: mensagemDeErro,
                actions: [MessageBox.Action.CLOSE]
            });
        },
		_trataErros(nomeModeloTituloErro, funcao) {
			const modelo = this.getView().getModel();
			const nomePropriedadeOcupado = "/ocupado";
			modelo.setProperty(nomePropriedadeOcupado, true);
			let erroPego;
			return Promise.resolve(funcao())
				.catch(erro => {
					erroPego = erro;
				})
				.finally(() => {	
					modelo.setProperty(nomePropriedadeOcupado, false)
					if (erroPego != null) {
						const i18n = this._retornaModeloI18n();
						const TituloErro = i18n.getText(nomeModeloTituloErro);
						this._mostraMensagemDeErro(TituloErro, erroPego);
					}
				});
		},
        _retornaModeloI18n() {
            return this.getOwnerComponent().getModel(this._nomeModeloI18n).getResourceBundle();
        }
    });
});