sap.ui.define([
    "sap/ui/test/opaQunit",
    "./paginas/App",
    "./paginas/Lista",
    "./paginas/CriarEditarEmpresas",
    "./paginas/DetalhesEmpresa"
], function (opaQunit,
	App,
	Lista,
	CriarEditarEmpresas,
	DetalhesEmpresa) {
    "use strict";

    QUnit.module("Lista Empresas", () => {
        opaTest("A tabela Empresas deve ser carregada com 7 colunas", function (Given, When, Then) {
            Given.iInicializoMinhaAplicacao({
                hash: "/#/"
            });

            Then.naPaginaDeListagem.aTabelaEmpresasDevePossuir7Colunas(7);

        });

        opaTest("Ao clicar no painel filtros, o fragmento de filtros empresas deve ser carregado",
            function (Given, When, Then) {
                When.naPaginaDeListagem
                    .aoClicarNoPainelFiltros();

                Then.naPaginaDeListagem
                    .oFragmentDeFiltrosEmpresasDeveSerCarregado();
            });

        opaTest("A tela de criação de empresas deve ser carregada ao clicar o botão adicionar na tela de listagem de Empresas",
            function (Given, When, Then) {

                When.naPaginaDeListagem
                    .aoClicarBotaoCriarEmpresa();
                Then.naPaginaDeCriacaoEdicaoEmpresa
                    .aPaginaDeCriacaoEdicaoDeEmpresasDeveSerCarregadaCorretamente();
                When.naPaginaDeCriacaoEdicaoEmpresa
                    .aoClicarNoBotaoVoltar();
            });

        opaTest("A tela de criação de empresa deve ser carregada ao clicar o botão adicionar na tela de listagem de empresas",
            function (Given, When, Then) {

                When.naPaginaDeListagem
                    .aoClicarBotaoCriarEmpresa();
                Then.naPaginaDeCriacaoEdicaoEmpresa
                    .aPaginaDeCriacaoEdicaoDeEmpresasDeveSerCarregadaCorretamente();
                When.naPaginaDeCriacaoEdicaoEmpresa
                    .aoClicarNoBotaoVoltar();
            });

        opaTest("A tela de detalhes deve ser carregada ao clicar em um item da tabela",
            function (Given, When, Then) {

                When.naPaginaDeListagem
                    .aoClicarSobreUmaEmpresa();
                Then.naPaginaDeDetalhesEmpresa
                    .aPaginaDeDetalhesEmpresaDeveSerCarregadaCorretamente();
                Then.iTeardownMyAppFrame();

            }
        );
    });
})