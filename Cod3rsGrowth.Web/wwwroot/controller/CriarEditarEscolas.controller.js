sap.ui.define([
	"sap/ui/core/date/UI5Date",
	"ui5/cod3rsgrowth/modelos/Servicos/ServicoEscolas",
	"ui5/cod3rsgrowth/modelos/Servicos/ServicoEnderecos",
	"sap/ui/core/routing/History",
	"sap/m/MessageBox",
	"sap/ui/model/json/JSONModel",
	"ui5/cod3rsgrowth/controller/ControllerBase"
], function (
	UI5Date,
	ServicoEscolas,
	ServicoEnderecos,
	History,
	MessageBox,
	JSONModel,
	ControllerBase
) {
	"use strict";

	const NOME_ROTA_ESCOLA_EDITAR = "EscolaEditar";
	return ControllerBase.extend("ui5.cod3rsgrowth.controller.CriarEditarEscolas", {
		_idEscolaAtualizar: 0,
		_idEnderecoAtualizar: 0,
		_rotaAtual: "",
		_idCriarEditarEscolas: "criarEditarEscolas",
		onInit() {
			const nomeRotaEscolaCirar = "EscolaCriar";
			const roteador = this.getOwnerComponent().getRouter();
			roteador.getRoute(nomeRotaEscolaCirar).attachMatched(this._aoCoincidirComRotaEscolaCriar, this);
			roteador.getRoute(NOME_ROTA_ESCOLA_EDITAR).attachMatched(this._aoCoincidirComRotaEscolaEditar, this);
			const idDataInicioAtividade = "dataInicioAtividade";
			let dataAtual = new Date();
			this.byId(idDataInicioAtividade).setMaxDate(
				UI5Date.getInstance(
					dataAtual.getFullYear(),
					dataAtual.getMonth(),
					dataAtual.getDay()));
		},
		_aoCoincidirComRotaEscolaCriar(oEvent) {
			this._configuraModeloDeDadosDaTela();
			const i18nMensagemDeErro = "CriarEditarEscola.ErroAoCoincidirRotas";
			const parametroNomeRota = "name";
			this._rotaAtual = oEvent.getParameter(parametroNomeRota);
			this.trataErros(i18nMensagemDeErro, () => {
				const i18nTituloEscolaCriar = "CriarEditarEscola.TituloCriar";
				let i18n = this.modeloI18n();
				this.byId(this._idCriarEditarEscolas).setTitle(i18n.getText(i18nTituloEscolaCriar));
			});
		},
		_configuraModeloDeDadosDaTela() {
			debugger;
			const dadosEscola = {
				statusAtividade: undefined,
				nome: undefined,
				codigoMec: undefined,
				telefone: undefined,
				email: undefined,
				inicioAtividade: undefined,
				categoriaAdministrativa: undefined,
				organizacaoAcademica: undefined
			}
			this._modeloEscola(new JSONModel(dadosEscola))
			const dadosEstado = {
				cep:undefined,
				estado:undefined,
				municipio:undefined,
				bairro:undefined,
				rua:undefined,
				numero:undefined,
				complemento:undefined
			}
				this._modeloEnderecoEscola(new JSONModel(dadosEstado));
		},
		_aoCoincidirComRotaEscolaEditar: async function (oEvent) {
			const i18nMensagemDeErro = "CriarEditarEscolas.ErroCoincidirRotaEditar";
			const parametroNomeRota = "name";
			this._rotaAtual = oEvent.getParameter(parametroNomeRota);
			this.trataErros(i18nMensagemDeErro, async () => {
				const nomeArgumentosCaminhoEscola = "arguments";
				let idEscola = oEvent.getParameter(nomeArgumentosCaminhoEscola).caminhoEscola;
				let escola = await ServicoEscolas.obterEscolaPorId(idEscola);
				this._populaTelaComValoresEscolaEditar(escola);
				this._populaTelaComValoresEnderecoDaEscolaEditar(escola.idEndereco);
				const i18TituloEscolaEditar = "CriarEditarEscolas.TituloEditar";
				const i18n = this.modeloI18n();
				this.byId(this._idCriarEditarEscolas).setTitle(i18n.getText(i18TituloEscolaEditar));
			});
		},
		_retornaValoresEscola() {
			let valoresEscola = this._modeloEscola(undefined).getData();
			valoresEscola.statusAtividade = valoresEscola.statusAtividade == 1 ? true : false;
			return valoresEscola;
		},
		_populaTelaComValoresEscolaEditar: async function (escola) {
			escola.statusAtividade = escola.statusAtividade ? 1 : 0;
			this._idEscolaAtualizar = escola.id;
			this._modeloEscola(new JSONModel(escola));
		},
		_populaTelaComValoresEnderecoDaEscolaEditar: async function (id) {
			let endereco = await ServicoEnderecos.obterEnderecoPorId(id);
			this._idEnderecoAtualizar = id;
			this._modeloEnderecoEscola(new JSONModel(endereco));
		},
		_retornaValoresEndereco() {
			return this._modeloEnderecoEscola().getData();
		},
		aoPressionarSalvar: async function () {
			let respostaEndereco;
			let textoErro = "";
			let i18nMensagemDeErro;
			if (this._rotaAtual == "EscolaCriar") {
				i18nMensagemDeErro = "CriarEditarEscola.ErroAoTentarCriarEscola";
			}
			else {
				i18nMensagemDeErro = "CriarEditarEscola.ErroTentarEditarEscola";
			}
			this.trataErros(i18nMensagemDeErro, async () => {
				let respostaEndereco;
				let respostaEscola;
				let textoErro = "";
				let i18nMensagemDeErro;
				if (this._rotaAtual == "EscolaCriar") {
					i18nMensagemDeErro = "CriarEditarEscolas.ErroAoTentarCriarEscolas";
				}
				else {
					i18nMensagemDeErro = "CriarEditarEscolas.ErroAoTentarEditarEscolas";
				}
				this.trataErros(i18nMensagemDeErro, async () => {
					const modelo = this.modeloValoresPadrao(undefined);
					if (this._rotaAtual == "EscolaCriar") {
						respostaEndereco = await ServicoEnderecos.criarEndereco(this._retornaValoresEndereco(), modelo);
						let escolaCriar = this._retornaValoresEscola();
						escolaCriar.idEndereco = respostaEndereco.id;
						respostaEscola = await ServicoEscolas.criarEscola(escolaCriar, modelo)
					}
					else {
						respostaEndereco = this._retornaValoresEndereco();
						respostaEndereco.id = this._idEnderecoAtualizar;
						respostaEndereco = await ServicoEnderecos.editarEndereco(respostaEndereco);
						let escolaEditar = this._retornaValoresEscola();
						escolaEditar.id = this._idEscolaAtualizar;
						escolaEditar.idEndereco = this._idEnderecoAtualizar;
						respostaEscola = await ServicoEscolas.editarEscola(escolaEditar);
					}
					const status500 = 500;
					const status400 = 400;
					if (respostaEndereco != undefined) {
						if (respostaEndereco.status != undefined &&
							respostaEndereco.status == status400) {
							textoErro += this.retornaTextoErro(respostaEndereco);
						}
						if (respostaEndereco.Status != undefined &&
							respostaEndereco.Status == status500) {
							textoErro += respostaEndereco.Detail;
						}
						if (respostaEndereco.ok != undefined && !respostaEndereco.ok ||
							respostaEndereco.status != undefined
						) {
							throw new Error(textoErro);
						}
					}
					if (respostaEscola != undefined) {
						if (respostaEscola != undefined &&
							respostaEscola.status == status400) {
							textoErro += this.retornaTextoErro(respostaEscola);
						}
						if (respostaEscola != undefined &&
							respostaEscola.Status == status500) {
							textoErro += respostaEscola.Detail;
						}
						if (this._rotaAtual == "EscolaCriar"&&
							respostaEscola.ok == undefined &&
							respostaEndereco != undefined &&
							respostaEndereco.Status == undefined) {
							ServicoEnderecos.deletarEndereco(respostaEndereco.id);
						}
						if (respostaEscola.Status != undefined||
							respostaEscola.status != undefined
						) {
							throw new Error(textoErro);
						}
					}

					this.aoPressionarBotaoDeNavegacao();
				});
			});
		},
		aoPressionarBotaoDeNavegacao() {
			const i18nMensagemDeErro = "CriarEditarEscola.ErroAoClicarBotaoDeNavegaca";
			this.trataErros(i18nMensagemDeErro, () => {
				const historico = History.getInstance();
				const hashAnterior = historico.getPreviousHash();
				if (hashAnterior != undefined) {
					window.history.go(-1);
				}
				else {
					const roteador = this.getOwnerComponent().getRouter();
					const nomeRotaEscolas = "Escolas";
					roteador.navTo(nomeRotaEscolas, {}, {}, true);
				}
			})
		},
		_modeloEscola: function (modelo) {
			const nomeModelo = "EscolaCriarEditar";
			return this.modelo(nomeModelo, modelo);
		},
		_modeloEnderecoEscola: function (modelo) {
			const nomeModelo= "EnderecoEscolaCriarEditar";
			return this.modelo(nomeModelo, modelo);
		}
	});
});