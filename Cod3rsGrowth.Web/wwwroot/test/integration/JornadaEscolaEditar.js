sap.ui.define([
    "sap/ui/test/opaQunit",
    "./paginas/App",
    "./paginas/CriarEditarEscolas"
], function (opaQunit, App, CriarEditarEscolas) {
    "use strict";

    QUnit.module("Editar Escola", () => {
        opaTest("A tela de Edição de Escolas deve ser carregada",
            function (Given, When, Then) {
                Given.iInicializoMinhaAplicacao({
                    hash: "/#/Escolas/Criar"
                });
                Then.naPaginaDeCriacaoEdicaoEscola
                    .aPaginaDeCriacaoEdicaoDeEscolasDeveSerCarregadaCorretamente();
            });
        opaTest("O painel Escola deve ser carregado corretamente",
            function (Given, When, Then) {
                Then.naPaginaDeCriacaoEdicaoEscola
                    .oPainelEscolaDeveSerCarregadoCorretamente();
            }
        );
        opaTest("O painel Endereco deve ser carregado corretamente",
            function (Given, When, Then) {
                Then.naPaginaDeCriacaoEdicaoEscola
                    .oPainelEnderecoDeveSerCarregadoCorretamente();
            }
        );
        opaTest("Ao Clicar no botão voltar carregar página de listagem de Escolas",
            function (Given, When, Then) {
                When.naPaginaDeCriacaoEdicaoEscola
                    .aoClicarNoBotaoVoltar();
                Then.naPaginaDeListagem
                    .aPaginaDeListagemDeEscolasFoiCarregadaCorretamente();
                Then.iTeardownMyAppFrame();
            }
        );
    });
})