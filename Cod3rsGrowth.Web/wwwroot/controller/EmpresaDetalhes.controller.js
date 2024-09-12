sap.ui.define([
    "ui5/cod3rsgrowth/controller/ControllerBase",
    "ui5/cod3rsgrowth/modelos/Servicos/ServicoEmpresas",
    "ui5/cod3rsgrowth/modelos/Servicos/ServicoEnderecos",
    "sap/ui/model/json/JSONModel",
    "sap/ui/core/format/DateFormat"
], function (
    ControllerBase,
    ServicoEmpresas,
    ServicoEnderecos,
    JSONModel,
    DateFormat,
) {
    "use strict";

    return ControllerBase.extend("ui5.cod3rsgrowth.controller.EmpresaDetalhes", {
        onInit() {
            const nomeRotaEscola = "EmpresaDetalhes";
            const roteador = this.getOwnerComponent().getRouter();
            roteador.getRoute(nomeRotaEscola).attachMatched(this._aoCoincidirRotaDetalhesEscola, this);
        },
        _aoCoincidirRotaDetalhesEscola: function (oEvent) {
            const i18nMensagemDeErro = "CriarEditarEmpresa.ErroCoincidirRota";
            const nomeArgumentosCamingoEmpresa = "arguments";
            this.trataErros(i18nMensagemDeErro, async () => {
                const idEmpresa =
                    oEvent.getParameter(nomeArgumentosCamingoEmpresa).caminhoEmpresa;
                const empresa = await ServicoEmpresas.obterEmpresaPorId(idEmpresa);
                this._populaTelaComValoresDaEmpresa(empresa);
                this._populaTelaComValoresDoEnderecoEmpresa(empresa.idEndereco);
            });
        },
        _populaTelaComValoresDaEmpresa: async function (empresa) {
            empresa.naturezaJuridica =
                this.textoNaturezaJuridica(empresa.naturezaJuridica);
            empresa.situacaoCadastral =
                this.textoHabilitado(empresa.situacaoCadastral);
            empresa.matrizFilial =
                this.textoMatrizFilial(empresa.matrizFilial);
            empresa.porte =
                this.textoPorte(empresa.porte);
            let formatadorData = DateFormat.getDateInstance({
                pattern: "dd/mm/yyyy"
            });
            empresa.dataAbertura =
                formatadorData.format(new Date(empresa.dataAbertura));
            empresa.dataSituacaoCadastral =
                formatadorData.format(new Date(empresa.dataSituacaoCadastral));
            this._modeloEmpresa(new JSONModel(empresa));
        },
        _populaTelaComValoresDoEnderecoEmpresa: async function (id) {
            let endereco = await ServicoEnderecos.obterEnderecoPorId(id);
            endereco.estado =
                this.textoEstado(endereco.estado);
            this._modeloEndereco(new JSONModel(endereco));
        },
        aoPressionarBotaoDeNavegacao() {
            let i18nMensagemDeErro = "TelaEmpresasDetalhes.ErroAoClicarBotaoNavegacao";
            this.trataErros(i18nMensagemDeErro, () => {
                const roteador = this.getOwnerComponent().getRouter();
                const nomeRotaEmpresas = "Empresas";
                roteador.navTo(nomeRotaEmpresas, {}, {}, true);
            })
        },
        _modeloEmpresa(modelo) {
            const nomeModelo = "EmpresaDetalhes";
            return this.modelo(nomeModelo, modelo);
        },
        _modeloEndereco(modelo) {
            const nomeModelo = "EnderecoEmpresaDetalhes";
            return this.modelo(nomeModelo, modelo);
        }
    });
});