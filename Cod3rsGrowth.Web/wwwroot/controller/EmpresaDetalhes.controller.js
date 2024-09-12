sap.ui.define([
    "ui5/cod3rsgrowth/controller/ControllerBase",
    "ui5/cod3rsgrowth/modelos/Servicos/ServicoEmpresas",
    "ui5/cod3rsgrowth/modelos/Servicos/ServicoEnderecos",
    "sap/ui/model/json/JSONModel",
    "sap/ui/core/format/DateFormat",
    "ui5/cod3rsgrowth/modelos/Repositorios/RepositorioEmpresas",
    "ui5/cod3rsgrowth/modelos/Repositorios/RepositorioEnderecos"
], function (
    ControllerBase,
    ServicoEmpresas,
    ServicoEnderecos,
    JSONModel,
    DateFormat,
    RepositorioEmpresas,
    RepositorioEnderecos,
) {
    "use strict";

    return ControllerBase.extend("ui5.cod3rsgrowth.controller.EmpresaDetalhes", {
        _idEmpresa: 0,
        _idEndereco: 0,
        onInit() {
            const nomeRotaEscola = "EmpresaDetalhes";
            const roteador = this.getOwnerComponent().getRouter();
            roteador.getRoute(nomeRotaEscola).attachMatched(this._aoCoincidirRotaDetalhesEscola, this);
        },
        _aoCoincidirRotaDetalhesEscola: function (oEvent) {
            const i18nMensagemDeErro = "CriarEditarEmpresa.ErroCoincidirRota";
            const nomeArgumentosCamingoEmpresa = "arguments";
            this.tratarErros(i18nMensagemDeErro, async () => {
                const idEmpresa =
                    oEvent.getParameter(nomeArgumentosCamingoEmpresa).caminhoEmpresa;
                const empresa = await ServicoEmpresas.obterEmpresaPorId(idEmpresa);
                this._idEmpresa = idEmpresa;
                this._idEndereco = empresa.idEndereco;
                this._popularTelaComValoresDaEmpresa(empresa);
                this._popularTelaComValoresDoEnderecoEmpresa(empresa.idEndereco);
            });
        },
        _popularTelaComValoresDaEmpresa: async function (empresa) {
            empresa.naturezaJuridica =
                this.obterTextoDaNaturezaJuridica(empresa.naturezaJuridica);
            empresa.situacaoCadastral =
                this.obterTextoDoHabilitado(empresa.situacaoCadastral);
            empresa.matrizFilial =
                this.obterTextoDaMatrizFilial(empresa.matrizFilial);
            empresa.porte =
                this.obterTextoDoPorte(empresa.porte);
            let formatadorData = DateFormat.getDateInstance({
                pattern: "dd/mm/yyyy"
            });
            empresa.dataAbertura =
                formatadorData.format(new Date(empresa.dataAbertura));
            empresa.dataSituacaoCadastral =
                formatadorData.format(new Date(empresa.dataSituacaoCadastral));
            this.modeloEmpresa(new JSONModel(empresa));
        },
        _popularTelaComValoresDoEnderecoEmpresa: async function (id) {
            let endereco = await ServicoEnderecos.obterEnderecoPorId(id);
            endereco.estado =
                this.obterTextoDoEstado(endereco.estado);
            this.modeloEndereco(new JSONModel(endereco));
        },
        aoPressionarBotaoDeNavegacao() {
            let i18nMensagemDeErro = "TelaEmpresasDetalhes.ErroAoClicarBotaoNavegacao";
            this.tratarErros(i18nMensagemDeErro, () => {
                const roteador = this.getOwnerComponent().getRouter();
                const nomeRotaEmpresas = "Empresas";
                roteador.navTo(nomeRotaEmpresas, {}, {}, true);
            });
        },
        aoPressionarDeletar() {
            let i18nMensagemDeErro = "TelaEmpresasDetalhes.ErroAoClicarBotaoDeletar";
            this.tratarErros(i18nMensagemDeErro, async () => {
                let resposta = await RepositorioEmpresas.deletarEmpresa(this._idEmpresa);
                if (resposta != undefined) {
                    throw new Error(resposta.Detail);
                }
                resposta = await RepositorioEnderecos.deletarEndereco(this._idEndereco);
                if (resposta != undefined) {
                    throw new Error(resposta.Detail);
                }
                this.aoPressionarBotaoDeNavegacao();
            });
        }
    });
});