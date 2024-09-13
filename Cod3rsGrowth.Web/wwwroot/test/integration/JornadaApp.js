sap.ui.define([
    "sap/ui/test/opaQunit",
    "./paginas/App",
    "./paginas/Lista"
], function (opaQunit, App, Lista) {
    "use strict";

    QUnit.module("Lista", () => {
        opaTest("Deve abrir a página de listagem de Empresas ao clicar no botão empresas na página lateral", function (Given, When, Then) {
            Given.iInicializoMinhaAplicacao({
                hash: "/#/"
            });

            When.naPaginaAPP.aoPressionarBotaoLateralEmpresas();

            Then.naPaginaDeListagem.aPaginaDeListagemDeEmpresasFoiCarregadaCorretamente();
        });

        opaTest("Deve abrir a página de listagem de Escolas ao clicar em um item da lista lateral", function (Given, When, Then) {
            When.naPaginaAPP.aoPressionarBotaoLateralEscolas();

            Then.naPaginaDeListagem.aPaginaDeListagemDeEscolasFoiCarregadaCorretamente();

            Then.iTeardownMyAppFrame();
        });
    });
})