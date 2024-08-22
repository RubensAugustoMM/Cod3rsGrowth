sap.ui.define([
    "sap/ui/test/opaQunit",
    "./paginas/App",
    "./paginas/Lista"
], function (opaQunit, App, Lista) {
    "use strict";

    QUnit.module("Lista Empresas", () => {
        opaTest("A tabela Empresas deve ser carregada com 7 colunas", function (Given, When, Then) {
            Given.iInicializoMinhaAplicacao({
                hash: "/#/Empresas"
            });

            Then.naPaginaDeListagem.aTabelaEmpresasDevePossuir7Colunas(7);

        });

        opaTest("Ao clicar no painel filtros, o fragmento de filtros empresas deve ser carregado",
            function (Given, When, Then) {
                When.naPaginaDeListagem
                    .aoClicarNoPainelFiltros();

                Then.naPaginaDeListagem
                    .oFragmentDeFiltrosEmpresasDeveSerCarregado();

            Then.iTeardownMyApp();
            });
    });
})