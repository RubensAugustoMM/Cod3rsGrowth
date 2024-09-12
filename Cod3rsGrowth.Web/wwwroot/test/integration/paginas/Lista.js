sap.ui.define([
    "sap/ui/test/Opa5",
    "sap/ui/test/matchers/AggregationLengthEquals",
    "sap/ui/test/actions/Press",
    "sap/ui/test/matchers/PropertyStrictEquals"
], function (Opa5,
	AggregationLengthEquals,
	Press,
	PropertyStrictEquals) {
    "use strict";

    let viewName = ".Lista";

    Opa5.createPageObjects({
        naPaginaDeListagem: {
            actions: {
                aoClicarSobreUmaEmpresa: function () {
                    return this.waitFor({
                        viewName: viewName,
                        controlType: "sap.m.ColumnListItem",
                        actions: new Press(),
                        errorMessage: "não foi possível encontrar uma empresa para clicar na tabela"
                    })  
                },
                aoClicarBotaoCriarEmpresa: function () {
                    return this.waitFor({
                        viewName: viewName,
                        controlType: "sap.m.Button",
                        id: "botaoCriar",
                        actions: new Press(),
                        errorMessage: "Não foi possível encontrar o botão criar empresa."
                    });
                },
                aoClicarBotaoEditarEmpresa: function () {
                    return this.waitFor({
                        viewName: viewName,
                        controlType: "sap.m.Button",
                        matchers: new PropertyStrictEquals({
                            name: "icon",
                            value: "sap-icon://edit"
                        }),
                        actions: new Press(),
                        errorMessage: "Não foi possível encontrar o botão Editar empresa."
                    });
                },
                aoClicarBotaoCriarEscola: function () {
                    return this.waitFor({
                        viewName: viewName,
                        controlType: "sap.m.Button",
                        id: "botaoCriar",
                        actions: new Press(),
                        errorMessage: "Não foi possível encontrar o botão criar escola."
                    });
                },
                aoClicarBotaoEditarEscola: function () {
                    return this.waitFor({
                        viewName: viewName,
                        controlType: "sap.m.Button",
                        matchers: new PropertyStrictEquals({
                            name: "icon",
                            value: "sap-icon://edit"
                        }),
                        actions: new Press(),
                        errorMessage: "Não foi possível encontrar o botão Editar escola."
                    });
                },
                aoClicarNoPainelFiltros: function () {
                    return this.waitFor({
                        viewName: viewName,
                        controlType: "sap.m.Panel",
                        id: "painelFiltros",
                        actions: function (painelFiltros) {
                            painelFiltros.expanded = true
                            painelFiltros.setProperty("expanded", true);
                        },
                        errorMessage: "Não foi possivel encontrar o painel de filtros"
                    });
                }
            },
            assertions: {
                aPaginaDeListagemDeEmpresasFoiCarregadaCorretamente: function () {
                    return this.waitFor({
                        viewName: viewName,
                        controlType: "sap.m.Page",
                        id: "lista",
                        matchers: new sap.ui.test.matchers.PropertyStrictEquals({ name: "title", value: "Empresas" }),
                        success: function () {
                            Opa5.assert.ok(true, "A página de listagem de empresas foi exibida.");
                        },
                        errorMessage: "A página de listagem de empresas não foi exibida."
                    });
                },
                aPaginaDeListagemDeEscolasFoiCarregadaCorretamente: function () {
                    return this.waitFor({
                        viewName: viewName,
                        controlType: "sap.m.Page",
                        id: "lista",
                        matchers: new sap.ui.test.matchers.PropertyStrictEquals({ name: "title", value: "Escolas" }),
                        success: function () {
                            Opa5.assert.ok(true, "A página de listagem de Escolas foi exibida.");
                        },
                        errorMessage: "A página de listagem de Escolas não foi exibida."
                    });
                },
                aTabelaDevePossuirAQuantidadeDeColunasInformada: function (Quantidade) {
                    return this.waitFor({
                        viewName: viewName,
                        controlType: "sap.m.Table",
                        id: "tabela",
                        matchers: new AggregationLengthEquals({
                            name: 'columns',
                            length: Quantidade
                        }),
                        success: () => {
                            Opa5.assert.ok(true, "A tabela possui a quantidade informada")
                        },
                        errorMessage: "A Tabela não possui a quantidade de colunas informada"
                    })
                },
                aTabelaEscolasDevePossuir5Colunas: function () {
                    this.aTabelaDevePossuirAQuantidadeDeColunasInformada(5);
                },
                aTabelaEmpresasDevePossuir7Colunas: function () {
                    this.aTabelaDevePossuirAQuantidadeDeColunasInformada(7);
                },
                oFragmentDeFiltrosEmpresasDeveSerCarregado: function () {
                    return this.waitFor({
                        viewName: viewName,
                        controlType: "sap.m.Panel",
                        id: "filtroEmpresasFragment",
                        success: () => {
                            Opa5.assert.ok(true, "O fragmento FiltroEmpresas foi carregado com sucess")
                        },
                        errorMessage: "O fragmento FiltroEmpresas não foi carregado com sucesso"
                    })
                },

                oFragmentDeFiltrosEscolasDeveSerCarregado: function () {
                    return this.waitFor({
                        viewName: viewName,
                        controlType: "sap.m.Panel",
                        id: "filtroEscolasFragment",
                        success: () => {
                            Opa5.assert.ok(true, "O fragmento FiltroEmpresas foi carregado com sucesso")
                        },
                        errorMessage: "O fragmento FiltroEmpresas não foi carregado com sucesso"
                    })
                }
            }
        }
    });
});