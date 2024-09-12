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

    let viewName = ".TelasDetalhes.EmpresaDetalhes";

    Opa5.createPageObjects({
        naPaginaDeDetalhesEmpresa: {
            actions: {
                aoClicarNoBotaoVoltar: function() {
                    return this.waitFor({
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
                aPaginaDeDetalhesEmpresaDeveSerCarregadaCorretamente:function() {
                    return this.waitFor({
                        viewName: viewName,
                        controlType: "sap.m.Page",
                        id: "idPaginaDetalhesEmpresa",
                        success: function () {
                            Opa5.assert.ok(true, "A página de detalhes empresa foi carregada corretamente")
                        },
                        errorMessage: "A páginade detalhes empresa não foi carregada corretamente"
                    });
                },
                oPainelEmpresasDeveSerCarregadoCorretamente: function() {
                    return this.waitFor({
                        viewName: viewName,
                        controlType: "sap.m.Panel",
                        id: "painelEmpresa",
                        success: function () {
                            Opa5.assert.ok(true, "O painel Empresa foi carregado corretamente.")
                        },
                        errorMessage: "O painel Empresa não foi carregado corretamente "
                    });
                },
                oPainelEnderecoDeveSerCarregadoCorretamente: function() {
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