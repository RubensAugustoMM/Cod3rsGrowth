sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/ui/core/date/UI5Date",
	"ui5/cod3rsgrowth/modelos/Servicos/ServicoEscolas",
	"ui5/cod3rsgrowth/modelos/Servicos/ServicoEnderecos",
	"sap/ui/core/routing/History",
	"sap/m/MessageBox",
	"sap/ui/model/json/JSONModel"
], function (
	Controller,
	UI5Date,
	ServicoEscolas,
	ServicoEnderecos,
	History,
	MessageBox,
	JSONModel
) {
	"use strict";

	const NOME_ROTA_ESCOLA_EDITAR = "EscolaEditar";
	const NOME_MODELO_ENDERECO_ESCOLA = "EnderecoEscolaCriarEditar";
	const NOME_MODELO_ESCOLA = "EscolaCriarEditar";
	const NOME_MODELO_VALORES_PADRAO = "valoresPadrao";
	return Controller.extend("ui5.cod3rsgrowth.controller.CriarEditarEscolas", {
		_idEscolaAtualizar: 0,
		_idEnderecoAtualizar: 0,
		_rotaAtual: "",
		_nomeModeloI18n: "i18n",
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
			this._trataErros(i18nMensagemDeErro, () => {
				const i18nTituloEscolaCriar = "CriarEditarEscola.TituloCriar";
				let i18n = this.getOwnerComponent().getModel(this._nomeModeloI18n).getResourceBundle();
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
			var modeloEscola = new JSONModel(dadosEscola);
			this.getView().setModel(modeloEscola, NOME_MODELO_ESCOLA);
			const dadosEstado = {
				cep:undefined,
				estado:undefined,
				municipio:undefined,
				bairro:undefined,
				rua:undefined,
				numero:undefined,
				complemento:undefined
			}
			var modeloEstadoEscola = new JSONModel(dadosEstado);
			this.getView().setModel(modeloEstadoEscola, NOME_MODELO_ENDERECO_ESCOLA);
		},
		_aoCoincidirComRotaEscolaEditar: async function (oEvent) {
			const i18nMensagemDeErro = "CriarEditarEscolas.ErroCoincidirRotaEditar";
			const parametroNomeRota = "name";
			this._rotaAtual = oEvent.getParameter(parametroNomeRota);
			this._trataErros(i18nMensagemDeErro, async () => {
				const nomeArgumentosCaminhoEscola = "arguments";
				let idEscola = oEvent.getParameter(nomeArgumentosCaminhoEscola).caminhoEscola;
				let escola = await ServicoEscolas.obterEscolaPorId(idEscola);
				this._populaTelaComValoresEscolaEditar(escola);
				this._populaTelaComValoresEnderecoDaEscolaEditar(escola.idEndereco);
				const i18TituloEscolaEditar = "CriarEditarEscolas.TituloEditar";
				const i18n = this._retornaModeloI18n();
				this.byId(this._idCriarEditarEscolas).setTitle(i18n.getText(i18TituloEscolaEditar));
			});
		},
		_retornaValoresEscola() {
			let valoresEscola = this.getView().getModel(NOME_MODELO_ESCOLA).getData();
			valoresEscola.statusAtividade = valoresEscola.statusAtividade == 1 ? true : false;
			return valoresEscola;
		},
		_populaTelaComValoresEscolaEditar: async function (escola) {
			escola.statusAtividade = escola.statusAtividade ? 1 : 0;
			this._idEscolaAtualizar = escola.id;
			escola = new JSONModel(escola);
			this.getView().setModel(escola, NOME_MODELO_ESCOLA);
		},
		_populaTelaComValoresEnderecoDaEscolaEditar: async function (id) {
			let endereco = await ServicoEnderecos.obterEnderecoPorId(id);
			this._idEnderecoAtualizar = id;
			endereco = new JSONModel(endereco);
			this.getView().setModel(endereco, NOME_MODELO_ENDERECO_ESCOLA);
		},
		_retornaValoresEndereco() {
			return this.getView().getModel(NOME_MODELO_ENDERECO_ESCOLA).getData();
		},
		_mostraMensagemDeErro(mensagemDeErro, erro) {
			MessageBox.show(erro.message, {
				icon: MessageBox.Icon.ERROR,
				title: mensagemDeErro,
				actions: [MessageBox.Action.CLOSE]
			});
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
			this._trataErros(i18nMensagemDeErro, async () => {
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
				this._trataErros(i18nMensagemDeErro, async () => {
					const modelo = this.getView().getModel(NOME_MODELO_VALORES_PADRAO);
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
							textoErro += this._retornaTextoErro(respostaEndereco);
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
							textoErro += this._retornaTextoErro(respostaEscola);
						}
						if (respostaEscola != undefined &&
							respostaEscola.Status == status500) {
							textoErro += respostaEscola.Detail;
						}
						if (this._rotaAtual == "EscolaCriar"&&
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
			this._trataErros(i18nMensagemDeErro, () => {
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
		_retornaTextoErro(resposta) {
			let textoRetorno = "";
			const chavesErro = Object.keys(resposta.errors);
			chavesErro.forEach((erro => {
				textoRetorno += `${erro}:\n`;
				resposta.errors[erro].forEach((erro => {
					textoRetorno += erro + "\n";
				}));
			}));
			return textoRetorno;
		},
		_trataErros(nomeModeloTituloErro, funcao) {
			const modelo = this.getView().getModel();
			const nomePropriedadeOcupado = "/ocupado";
			modelo.setProperty(nomePropriedadeOcupado, true);
			let erroPego;
			return Promise.resolve(funcao())
				.catch(erro => {
					erroPego = erro;
				})
				.finally(() => {
					modelo.setProperty(nomePropriedadeOcupado, false)
					if (erroPego != null) {
						const i18n = this._retornaModeloI18n();
						const TituloErro = i18n.getText(nomeModeloTituloErro);
						this._mostraMensagemDeErro(TituloErro, erroPego);
					}
				});
		},
		_retornaModeloI18n() {
			return this.getOwnerComponent().getModel(this._nomeModeloI18n).getResourceBundle();
		}
	});
});