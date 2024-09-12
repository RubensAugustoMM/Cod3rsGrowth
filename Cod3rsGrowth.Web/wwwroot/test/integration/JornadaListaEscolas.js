sap.ui.define([
    "sap/ui/test/opaQunit",
    "./paginas/App",
    "./paginas/Lista",
    "./paginas/CriarEditarEscolas",
    "./paginas/DetalhesEscola"
], function (opaQunit,
	App,
	Lista,
	CriarEditarEscolas,
	DetalhesEscola) {
    "use strict";

    QUnit.module("Lista Escolas", () => {
        opaTest("A tabela Escolas deve ser carregada com 5 colunas", function (Given, When, Then) {
            Given.iInicializoMinhaAplicacao({
                hash: "/#/Escolas"
            });

            When.naPaginaAPP.aoPressionarBotaoLateralEscolas();

            Then.naPaginaDeListagem.aTabelaEscolasDevePossuir5Colunas(5);
        });

        opaTest("Ao clicar no painel filtros, o fragmento de Escolas deve ser carregado",
            function (Given, When, Then) {
                When.naPaginaDeListagem
                    .aoClicarNoPainelFiltros();

                Then.naPaginaDeListagem
                    .oFragmentDeFiltrosEscolasDeveSerCarregado();
            });

        opaTest("A tela de criação de escolas deve ser carregada ao clicar o botão adicionar na tela de listagem de Escolas",
            function (Given, When, Then) {

                When.naPaginaDeListagem
                    .aoClicarBotaoCriarEscola();
                Then.naPaginaDeCriacaoEdicaoEscola
                    .aPaginaDeCriacaoEdicaoDeEscolasDeveSerCarregadaCorretamente();
                When.naPaginaDeCriacaoEdicaoEscola
                    .aoClicarNoBotaoVoltar();
            });
        opaTest("A tela de Detalhes de escolas deve ser carregada ao clicar sobre uma escola da tela de listagem",
            function (Given, When, Then) {
                When.naPaginaDeListagem
                    .aoClicarSobreUmaEscola();
                Then.naPaginaDeDetalhesEscola
                    .aPaginaDeDetalhesEscolaDeveSerCarregadaCorretamente();
                When.naPaginaDeDetalhesEscola
                    .aoClicarNoBotaoVoltar();
            })
        opaTest("A tela de Edição de escolas deve ser carregada ao clicar o botão editar na tela de listagem",
            function (Given, When, Then) {
                When.naPaginaDeListagem
                    .aoClicarBotaoEditarEscola();
                Then.naPaginaDeCriacaoEdicaoEscola
                    .aPaginaDeCriacaoEdicaoDeEscolasDeveSerCarregadaCorretamente();
                Then.iTeardownMyAppFrame();
            });
    });
})