sap.ui.define([
    "sap/ui/test/opaQunit",
    "./paginas/App",
    "./paginas/CriarEditarEmpresas"
], function (opaQunit, App, CriarEditarEmpresas) {
    "use strict";

    QUnit.module("Editar Empresa", () => {
        opaTest("A tela de Edição de Empresas deve ser carregada",
            function (Given, When, Then) {
                Given.iInicializoMinhaAplicacao({
                    hash: "/#/Empresas/Criar"
                });
                Then.naPaginaDeCriacaoEdicaoEmpresa
                    .aPaginaDeCriacaoEdicaoDeEmpresasDeveSerCarregadaCorretamente();
            });
        opaTest("O painel Empresa deve ser carregado corretamente",
            function (Given, When, Then) {
                Then.naPaginaDeCriacaoEdicaoEmpresa
                    .oPainelEmpresaDeveSerCarregadoCorretamente();
            }
        );
        opaTest("O painel Endereco deve ser carregado corretamente",
            function (Given, When, Then) {
                Then.naPaginaDeCriacaoEdicaoEmpresa
                    .oPainelEnderecoDeveSerCarregadoCorretamente();
            }
        );
        opaTest("Ao Clicar no botão voltar carregar página de listagem de Empresas",
            function (Given, When, Then) {
                When.naPaginaDeCriacaoEdicaoEmpresa
                    .aoClicarNoBotaoVoltar();
                Then.naPaginaDeListagem
                    .aPaginaDeListagemDeEmpresasFoiCarregadaCorretamente();
                Then.iTeardownMyAppFrame();
            }
        );
    });
})