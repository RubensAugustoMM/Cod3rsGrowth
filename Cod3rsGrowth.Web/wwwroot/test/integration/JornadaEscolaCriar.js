sap.ui.define([
    "sap/ui/test/opaQunit",
    "./paginas/App",
    "./paginas/CriarEditarEscolas"
], function (opaQunit, App, CriarEditarEscolas) {
    "use strict";

    QUnit.module("Criar Escola", () => {
        opaTest("A tela de criação de Escolas deve ser carregada",
            function (Given, When, Then) {
                Given.iInicializoMinhaAplicacao({
                    hash: "/#/Escolas/Criar"
                });
                Then.naPaginaDeCriacaoEscola
                    .aPaginaDeCriacaoDeEscolasDeveSerCarregadaCorretamente();
            });
        opaTest("O painel Escola deve ser carregado corretamente",
            function (Given, When, Then) {
                Then.naPaginaDeCriacaoEscola
                    .oPainelEscolaDeveSerCarregadoCorretamente();
            }
        );
        opaTest("O painel Endereco deve ser carregado corretamente",
            function (Given, When, Then) {
                Then.naPaginaDeCriacaoEscola
                    .oPainelEnderecoDeveSerCarregadoCorretamente();
            }
        );
        opaTest("Ao Clicar no botão voltar carregar página de listagem de Escolass",
            function (Given, When, Then) {
                When.naPaginaDeCriacaoEscola
                    .aoClicarNoBotaoVoltar();
                Then.naPaginaDeListagem
                    .aPaginaDeListagemDeEscolasFoiCarregadaCorretamente();
                Then.iTeardownMyAppFrame();
            }
        );
    });
})