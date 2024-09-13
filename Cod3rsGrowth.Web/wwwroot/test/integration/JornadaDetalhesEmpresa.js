sap.ui.define([
    "sap/ui/test/opaQunit",
    "./paginas/App",
    "./paginas/DetalhesEmpresa",
    "./paginas/Lista"
], function (opaQunit, App, DetalhesEmpresa, Lista) {
    "use strict";

    QUnit.module("Detalhes Empresa", () => {
        opaTest("A tela de Detalhes de empresa deve ser carregada",
            function (Given, When, Then) {
                Given.iInicializoMinhaAplicacao({
                    hash: "/#/"
                });
                When.naPaginaDeListagem
                    .aoClicarSobreUmaEmpresa();
                Then.naPaginaDeDetalhesEmpresa
                    .aPaginaDeDetalhesEmpresaDeveSerCarregadaCorretamente();
            });
        opaTest("O painel Empresa deve ser carregado corretamente",
            function (Given, When, Then) {
                Then.naPaginaDeDetalhesEmpresa
                    .oPainelEmpresasDeveSerCarregadoCorretamente();
            }
        );
        opaTest("O painel Endereco deve ser carregado corretamente",
            function (Given, When, Then) {
                Then.naPaginaDeDetalhesEmpresa
                    .oPainelEnderecoDeveSerCarregadoCorretamente();
            }
        );
        opaTest("Ao Clicar no botão voltar carregar página de listagem de empresas",
            function (Given, When, Then) {
                When.naPaginaDeDetalhesEmpresa
                    .aoClicarNoBotaoVoltar();
                Then.naPaginaDeListagem
                    .aPaginaDeListagemDeEmpresasFoiCarregadaCorretamente();
            }
        );
        opaTest("Ao clicar botão deletar a empresa deve ser deletada e voltar para a tela de litagem",
            function (Given, When, Then) {
                When.naPaginaDeListagem
                    .aoCliciarEmEmpresaOuEscolaTesteDeletar();
                When.naPaginaDeDetalhesEmpresa
                    .aoClicarNoBotaoDeletar();
                Then.naPaginaDeListagem
                    .aPaginaDeListagemDeEmpresasFoiCarregadaCorretamente();
                Then.iTeardownMyAppFrame();
            }
        )
    });
})