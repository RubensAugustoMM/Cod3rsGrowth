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
	const NOME_ROTA_ESCOLA_CRIAR = "EscolaCriar";
	const NOME_ROTA_ESCOLA_EDITAR = "EscolaEditar";
	return ControllerBase.extend("ui5.cod3rsgrowth.controller.CriarEditarEscolas", {
		_idEscolaAtualizar: 0,
		_idEnderecoAtualizar: 0,
		_rotaAtual: "",
		_idCriarEditarEscolas: "criarEditarEscolas",
		onInit() {
			const roteador = this.getOwnerComponent().getRouter();
			roteador.getRoute(NOME_ROTA_ESCOLA_CRIAR).attachMatched(this._aoCoincidirComRotaEscolaCriar, this);
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
			this._configurarModeloEscolaDaTela();
			this._configuraModeloEnderecoDaTela();
			const i18nMensagemDeErro = "CriarEditarEscola.ErroAoCoincidirRotas";
			const parametroNomeRota = "name";
			this._rotaAtual = oEvent.getParameter(parametroNomeRota);
			this.tratarErros(i18nMensagemDeErro, () => {
				const i18nTituloEscolaCriar = "CriarEditarEscola.TituloCriar";
				let i18n = this.modeloI18n();
				this.byId(this._idCriarEditarEscolas).setTitle(i18n.getText(i18nTituloEscolaCriar));
			});
		},
		_configuraModeloEnderecoDaTela() {
			const dadosEstado = {
				cep: undefined,
				estado: undefined,
				municipio: undefined,
				bairro: undefined,
				rua: undefined,
				numero: undefined,
				complemento: undefined
			}
			this.modeloEndereco(new JSONModel(dadosEstado));
		},
		_configurarModeloEscolaDaTela() {
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
			this.modeloEscola(new JSONModel(dadosEscola))
		},
		_aoCoincidirComRotaEscolaEditar: async function (oEvent) {
			const i18nMensagemDeErro = "CriarEditarEscolas.ErroCoincidirRotaEditar";
			const parametroNomeRota = "name";
			this._rotaAtual = oEvent.getParameter(parametroNomeRota);
			this.tratarErros(i18nMensagemDeErro, async () => {
				const nomeArgumentosCaminhoEscola = "arguments";
				let idEscola = oEvent.getParameter(nomeArgumentosCaminhoEscola).caminhoEscola;
				let escola = await ServicoEscolas.obterEscolaPorId(idEscola);
				this._popularTelaComValoresDaEscolaEditar(escola);
				this._popularTelaComValoresDoEnderecoDaEscolaEditar(escola.idEndereco);
				const i18TituloEscolaEditar = "CriarEditarEscolas.TituloEditar";
				const i18n = this.modeloI18n();
				this.byId(this._idCriarEditarEscolas).setTitle(i18n.getText(i18TituloEscolaEditar));
			});
		},
		_obterValoresEscolaDaTela() {
			let valoresEscola = this.modeloEscola(undefined).getData();
			const valorHabilitado = 1;
			valoresEscola.statusAtividade = valoresEscola.statusAtividade == valorHabilitado ? true : false;
			return valoresEscola;
		},
		_popularTelaComValoresDaEscolaEditar: async function (escola) {
			escola.statusAtividade = escola.statusAtividade ? 1 : 0;
			this._idEscolaAtualizar = escola.id;
			this.modeloEscola(new JSONModel(escola));
		},
		_popularTelaComValoresDoEnderecoDaEscolaEditar: async function (id) {
			let endereco = await ServicoEnderecos.obterEnderecoPorId(id);
			this._idEnderecoAtualizar = id;
			this.modeloEndereco(new JSONModel(endereco));
		},
		_obterValoresEnderecoDaTela() {
			return this.modeloEndereco().getData();
		},
		/*
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
			this.tratarErros(i18nMensagemDeErro, async () => {
				let respostaEndereco;
				let respostaEscola;
				let textoErro = "";
				let i18nMensagemDeErro;
				const modelo = this.modeloValoresPadrao(undefined);
				let valoresEndereco = this._obterValoresEnderecoDaTela();
				let valoresEscola = this._obterValoresEscolaDaTela();
				if (this._rotaAtual == "EscolaCriar") {
					respostaEndereco = await ServicoEnderecos.criarEndereco(this._obterValoresEnderecoDaTela(), modelo);
					escolaCriar.idEndereco = respostaEndereco.id;
					respostaEscola = await ServicoEscolas.criarEscola(escolaCriar, modelo)
				}
				else {
					respostaEndereco = this._obterValoresEnderecoDaTela();
					respostaEndereco.id = this._idEnderecoAtualizar;
					respostaEndereco = await ServicoEnderecos.editarEndereco(respostaEndereco);
					let escolaEditar = this._obterValoresEscolaDaTela();
					escolaEditar.id = this._idEscolaAtualizar;
					escolaEditar.idEndereco = this._idEnderecoAtualizar;
					respostaEscola = await ServicoEscolas.editarEscola(escolaEditar);
				}
				const status500 = 500;
				const status400 = 400;
				if (respostaEndereco != undefined) {
					if (respostaEndereco.status != undefined &&
						respostaEndereco.status == status400) {
						textoErro += this.formatarMensagemDeErro(respostaEndereco);
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
						textoErro += this.formatarMensagemDeErro(respostaEscola);
					}
					if (respostaEscola != undefined &&
						respostaEscola.Status == status500) {
						textoErro += respostaEscola.Detail;
					}
					if (this._rotaAtual == "EscolaCriar" &&
						respostaEscola.ok == undefined &&
						respostaEndereco != undefined &&
						respostaEndereco.Status == undefined) {
						ServicoEnderecos.deletarEndereco(respostaEndereco.id);
					}
					if (respostaEscola.Status != undefined ||
						respostaEscola.status != undefined
					) {
						throw new Error(textoErro);
					}
				}

				this.aoPressionarBotaoDeNavegacao();
			});
		},
		*/
		aoPressionarSalvar: async function () {
			let i18nMensagemDeErro;
			if (this._rotaAtual == NOME_ROTA_ESCOLA_CRIAR) {
				i18nMensagemDeErro = "CriarEditarEscola.ErroAoTentarCriarEscola";
			}
			else {
				i18nMensagemDeErro = "CriarEditarEscola.ErroTentarEditarEscola";
			}
			i18nMensagemDeErro = "CriarEditarEscola.ErroTentarEditarEscola";
			this.tratarErros(i18nMensagemDeErro, async () => {
				const modeloValoresPadrao = this.modeloValoresPadrao();
				const valorNumericoPadrao = modeloValoresPadrao.getData().valorNumericoPadrao;

				let endereco = this._obterValoresEnderecoDaTela();
				endereco.id = this._idEnderecoAtualizar;
				let respostaEndereco;
				let respostaEscola;
				if (this._rotaAtual == NOME_ROTA_ESCOLA_EDITAR) {
					respostaEndereco = await ServicoEnderecos.editarEndereco(endereco);
				}
				else {
					respostaEndereco = await ServicoEnderecos.criarEndereco(endereco, modeloValoresPadrao);
				}
				
				let escola = this._obterValoresEscolaDaTela();
				escola.id = this._idEscolaAtualizar;
				escola.idEndereco = respostaEndereco.id ?? valorNumericoPadrao;
				if (this._rotaAtual == NOME_ROTA_ESCOLA_EDITAR) {
					respostaEscola = await ServicoEscolas.editarEscola(escola);
				}
				else {
					respostaEscola = ServicoEscolas.criarEscola(escola, modeloValoresPadrao);
				}

				this._analisarRespostaDoFetch(respostaEndereco, respostaEscola);
				this.aoPressionarBotaoDeNavegacao();
			});
		},
		_analisarRespostaDoFetch(respostaEndereco, respostaEscola) {
			let textoErro = "";
			const status500 = 500;
			const status400 = 400;
			if (respostaEndereco != undefined) {
				if (respostaEndereco.status != undefined &&
					respostaEndereco.status == status400
				) {
					textoErro += this.formatarMensagemDeErro(respostaEndereco);
				}
				if (respostaEndereco.Status != undefined &&
					respostaEndereco.Status == status500) {
					textoErro += respostaEndereco.Detail;
				}

				if (respostaEscola != undefined) {
					if (this._rotaAtual == NOME_ROTA_ESCOLA_CRIAR &&
						textoErro != "") {
						ServicoEnderecos.deletarEndereco(respostaEndereco.id);
					}
					if (respostaEscola.status != undefined &&
						respostaEscola.status == status400) {
						textoErro += this.formatarMensagemDeErro(respostaEscola);
					}
					if (respostaEndereco.Statis != undefined &&
						respostaEscola.Status == status500) {
						textoErro += respostaEscola.Detail;
					}
				}
				if (textoErro != "") {
					throw new Error(textoErro);
				}
			}
		},

		aoPressionarBotaoDeNavegacao() {
			const i18nMensagemDeErro = "CriarEditarEscola.ErroAoClicarBotaoDeNavegaca";
			this.tratarErros(i18nMensagemDeErro, () => {
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
		}
	});
});