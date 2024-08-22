sap.ui.define([
    "sap/ui/test/opaQunit",
    "./paginas/App",
    "./paginas/Lista"
], function (opaQunit, App, Lista) {
    "use strict";

    QUnit.module("Lista Escolas", () => {
        opaTest("A tabela Escolas deve ser carregada com 5 colunas", function (Given, When, Then) {
            Given.iInicializoMinhaAplicacao({
                hash: "/#/Escolas"
            });

            When.naPaginaAPP.aoPressionarBotaoLateralEscolas();

            Then.naPaginaDeListagem.aTabelaEscolasDevePossuir5Colunas(5);
        });

        opaTest("Ao clicar no painel filtros, o fragmento de Escolas empresas deve ser carregado",
            function (Given, When, Then) {
                When.naPaginaDeListagem
                    .aoClicarNoPainelFiltros();
            
                Then.naPaginaDeListagem
                    .oFragmentDeFiltrosEscolasDeveSerCarregado();

            Then.iTeardownMyApp();
        });
    });
})