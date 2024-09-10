sap.ui.define([
    "ui5/cod3rsgrowth/controller/ControllerBase",
    "ui5/cod3rsgrowth/modelos/Servicos/ServicoEscolas",
    "ui5/cod3rsgrowth/modelos/Servicos/ServicoEnderecos",
    "sap/ui/model/json/JSONModel",
    "ui5/cod3rsgrowth/modelos/Formatador"
], function(
	ControllerBase,
	ServicoEscolas,
	ServicoEnderecos,
	JSONModel,
	Formatador
) {
	"use strict";

	return ControllerBase.extend("ui5.cod3rsgrowth.controller.EscolaDetalhes", {
        formatador: Formatador,
        onInit() {
            formatador.modeloI18n= this.modeloI18n();
            const nomeRotaEscola = "EscolaDetalhes";
            const roteador = this.getOwnerComponent().getRouter(); 
            roteador.getRoute(nomeRotaEscola).attachMatched(this._aoCoincidirRotaDetalhesEscola, this);
        },
        _aoCoincidirRotaDetalhesEscola: function(oEvent) {
            const i18nMensagemDeErro = "CriarEditarEscolas.ErroCoincidirRota";
            const parametroNomeRota = "name";
            const nomeArgumentosCamingoEscola = "arguments";
            this.trataErros(i18nMensagemDeErro,async () => {
                const idEscola =
                    oEvent.getParameter(nomeArgumentosCamingoEscola).caminhoEscola;
                const escola = await ServicoEscolas.obterEscolaPorId(idEscola);
                this._populaTelaComValoresDaEscola(escola);
                this._populaTelaComValoresDoEnderecoEscola(escola.idEndereco); 
            });
        },
        _populaTelaComValoresDaEscola: async function(escola) {
            this._modeloEscola(new JSONModel(escola)); 
        },
        _populaTelaComValoresDoEnderecoEscola: async function(id) {
            let endereco = await ServicoEnderecos.obterEnderecoPorId(id);
            this._modeloEndereco(new JSONModel(endereco));
        },
        _modeloEscola(modelo) {
            const nomeModelo = "EscolaDetalhes";
            return this.modelo(nomeModelo, modelo);
        },
        _modeloEndereco(modelo) {
            const nomeModelo = "EnderecoEscolaDetalhes";
            return this.modelo(nomeModelo, modelo);
        }
    });
});