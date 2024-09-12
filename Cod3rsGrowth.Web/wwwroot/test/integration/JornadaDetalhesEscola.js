sap.ui.define([
    "sap/ui/test/opaQunit",
    "./paginas/App",
    "./paginas/DetalhesEscola",
    "./paginas/Lista"
], function (opaQunit, App,DetalhesEscola , Lista) {
    "use strict";

    QUnit.module("Detalhes Escola", () => {
        opaTest("A tela de Detalhes de escola deve ser carregada",
            function (Given, When, Then) {
                Given.iInicializoMinhaAplicacao({
                    hash: "/#/Escolas/"
                });
                When.naPaginaDeListagem
                    .aoClicarSobreUmaEscola();
                Then.naPaginaDeDetalhesEscola
                    .aPaginaDeDetalhesEscolaDeveSerCarregadaCorretamente();
            });
        opaTest("O painel Escola deve ser carregado corretamente",
            function (Given, When, Then) {
                Then.naPaginaDeDetalhesEscola
                    .oPainelEscolasDeveSerCarregadoCorretamente();
            }
        );
        opaTest("O painel Endereco deve ser carregado corretamente",
            function (Given, When, Then) {
                Then.naPaginaDeDetalhesEscola
                    .oPainelEnderecoDeveSerCarregadoCorretamente();
            }
        );
        opaTest("Ao Clicar no botão voltar carregar página de listagem de escolas",
            function (Given, When, Then) {
                When.naPaginaDeDetalhesEscola
                    .aoClicarNoBotaoVoltar();
                Then.naPaginaDeListagem
                    .aPaginaDeListagemDeEscolasFoiCarregadaCorretamente();
                Then.iTeardownMyAppFrame();
            }
        );
    });
})