sap.ui.define([
    "ui5/cod3rsgrowth/controller/ControllerBase",
    "ui5/cod3rsgrowth/modelos/Servicos/ServicoEscolas",
    "ui5/cod3rsgrowth/modelos/Servicos/ServicoEnderecos",
    "sap/ui/model/json/JSONModel",
    "sap/ui/core/format/DateFormat"
], function (
    ControllerBase,
    ServicoEscolas,
    ServicoEnderecos,
    JSONModel,
    DateFormat,
) {
    "use strict";

    return ControllerBase.extend("ui5.cod3rsgrowth.controller.EscolaDetalhes", {
        onInit() {
            const nomeRotaEscola = "EscolaDetalhes";
            const roteador = this.getOwnerComponent().getRouter();
            roteador.getRoute(nomeRotaEscola).attachMatched(this._aoCoincidirRotaDetalhesEscola, this);
        },
        _aoCoincidirRotaDetalhesEscola: function (oEvent) {
            const i18nMensagemDeErro = "CriarEditarEscolas.ErroCoincidirRota";
            const nomeArgumentosCamingoEscola = "arguments";
            this.trataErros(i18nMensagemDeErro, async () => {
                const idEscola =
                    oEvent.getParameter(nomeArgumentosCamingoEscola).caminhoEscola;
                const escola = await ServicoEscolas.obterEscolaPorId(idEscola);
                this._populaTelaComValoresDaEscola(escola);
                this._populaTelaComValoresDoEnderecoEscola(escola.idEndereco);
            });
        },
        _populaTelaComValoresDaEscola: async function (escola) {
            escola.organizacaoAcademica =
                this.obterTextoDaOrganizacaoAcademica(escola.organizacaoAcademica);
            escola.categoriaAdministrativa =
                this.obterTextoDaCategoriaAdministrativa(escola.categoriaAdministrativa);
            let formatadorData = DateFormat.getDateInstance({
                pattern: "dd/mm/yyyy"
            });
            escola.inicioAtividade =
                formatadorData.format(new Date(escola.inicioAtividade));
            this._modeloEscola(new JSONModel(escola));
        },
        _populaTelaComValoresDoEnderecoEscola: async function (id) {
            let endereco = await ServicoEnderecos.obterEnderecoPorId(id);
            endereco.estado =
                this.obterTextoDoEstado(endereco.estado);
            this._modeloEndereco(new JSONModel(endereco));
        },
        aoPressionarBotaoDeNavegacao() {
            let i18nMensagemDeErro = "TelaEscolaDetalhes.ErroAoClicarBotaoNavegacao";
            this.trataErros(i18nMensagemDeErro, () => {
                const roteador = this.getOwnerComponent().getRouter();
                const nomeRotaDeEscolas = "Escolas";
                roteador.navTo(nomeRotaDeEscolas, {}, {}, true);
            })
        },
        _modeloEscola(modelo) {
            const nomeModelo = "escola";
            return this.modelo(nomeModelo, modelo);
        },
        _modeloEndereco(modelo) {
            const nomeModelo = "endereco";
            return this.modelo(nomeModelo, modelo);
        }
    });
});