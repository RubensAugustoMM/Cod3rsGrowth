sap.ui.define([
    "sap/ui/test/Opa5",
    "sap/ui/test/matchers/AggregationLengthEquals",
    "sap/ui/test/actions/Press"
], function (Opa5,
    AggregationLengthEquals,
    Press) {
    "use strict";

    let viewName = ".Lista";

    Opa5.createPageObjects({
        naPaginaDeListagem: {
            actions: {
                aoClicarBotaoCriarEmpresa: function (){
                    return this.waitFor({
                        viewName: viewName,
                        controlType: "sap.m.Button",
                        id: "botaoCriar",
                        actions: new Press(),
                        errorMessage: "Não foi possível encontrar o botão criar empresa."
                    });
                },
                aoClicarBotaoCriarEscola: function (){
                    return this.waitFor({
                        viewName: viewName,
                        controlType: "sap.m.Button",
                        id: "botaoCriar",
                        actions: new Press(),
                        errorMessage: "Não foi possível encontrar o botão criar escola."
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