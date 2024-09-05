sap.ui.define([
    "sap/ui/test/Opa5",
    "sap/ui/test/matchers/AggregationLengthEquals",
    "sap/ui/test/matchers/PropertyStrictEquals",
    "sap/ui/test/actions/Press"
], function (Opa5,
    AggregationLengthEquals,
    PropertyStrictEquals,
    Press) {
    "use strict";

    let viewName = ".TelasCriarEditar.CriarEditarEscolas";

    Opa5.createPageObjects({
        naPaginaDeCriacaoEscola: {
            actions: {
                aoClicarNoBotaoVoltar() {
                    return this.waitFor({
                        viewName: viewName,
                        controlType: "sap.m.Button",
                        matchers: new PropertyStrictEquals({
                            name: 'type',
                            value: 'Back'
                        }),
                        actions: new Press(),
                        errorMessage: "Não foi possível encontrar o botão de voltar"
                    });
                }
            },
            assertions: {
                aPaginaDeCriacaoDeEscolasDeveSerCarregadaCorretamente() {
                    return this.waitFor({
                        viewName: viewName,
                        controlType: "sap.m.Page",
                        id: "criarEditarEscolas",
                        success: function () {
                            Opa5.assert.ok(true, "A página de criação de Escolas foi carregada corretamente")
                        },
                        errorMessage: "A páginade criação de empresas não foi carregada corretamente"
                    });
                },
                oPainelEscolaDeveSerCarregadoCorretamente() {
                    return this.waitFor({
                        viewName: viewName,
                        controlType: "sap.m.Panel",
                        id: "painelEscola",
                        success: function () {
                            Opa5.assert.ok(true, "O painel Escola foi carregado corretamente.")
                        },
                        errorMessage: "O painel Escola não foi carregado corretamente "
                    });
                },
                oPainelEnderecoDeveSerCarregadoCorretamente() {
                    return this.waitFor({
                        viewName: viewName,
                        controlType: "sap.m.Panel",
                        id: "painelEndereco",
                        success: function () {
                            Opa5.assert.ok(true, "O painel Endereco foi carregado corretamente.")
                        },
                        errorMessage: "O painel Endereco não foi carregado corretamente "
                    });
                }
            }
        }
    });
});