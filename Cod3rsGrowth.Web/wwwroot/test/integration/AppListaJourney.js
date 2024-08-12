sap.ui.define([
    "sap/ui/test/opaQunit",
    "./paginas/App",
    "./paginas/Lista"
], function (opaTest, App, Lista) {
    "use strict";

    opaTest("Deve abrir a página de listagem de Escolas ao clicar em um item da lista lateral", function (Given, When, Then) {
        Given.iInicializoMinhaAplicacao();

        When.naPaginaAPP.iPressionaBotaoLateralEmpresa();

        Then.naPaginaDeListagem.iDeveMostarPaginaListagemEmpresas(); 
    });

    opaTest("Deve abrir a página de listagem de Escolas ao clicar em um item da lista lateral", function (Given, When, Then) {
        When.naPaginaAPP.iPressionaBotaoLateralEscolas();

        Then.naPaginaDeListagem.iDeveMostarPaginaListagemEscolas();
        
        Then.iTeardownMyApp();
    });
});