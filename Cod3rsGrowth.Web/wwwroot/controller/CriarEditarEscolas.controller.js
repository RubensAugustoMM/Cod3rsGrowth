sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/ui/core/date/UI5Date",
	"ui5/cod3rsgrowth/modelos/Servicos/ServicoEscolas",
	"ui5/cod3rsgrowth/modelos/Servicos/ServicoEnderecos",
	"sap/ui/core/routing/History",
	"sap/m/MessageBox"
], function (
	Controller,
	UI5Date,
	ServicoEscolas,
	ServicoEnderecos,
	History,
	MessageBox
) {
	"use strict";

	const NOME_PROPRIEDADA_NOME = "/nomeEscolaEntrada";
	const NOME_PROPRIEDADE_CODIGO_MEC = "/codigoMecEscolaEntrada";
	const NOME_PROPRIEDADE_TELEFONE = "/telefoneEscolaEntrada";
	const NOME_PROPRIEDADE_EMAIL = "/emailEscolaEntrada";
	const NOME_PROPRIEDADE_CATEGORIA_ADMINISTRATIVA = "/categoriaAdministrativaSelecionada";
	const NOME_PROPRIEDADE_ORGANIZACAO_ACADEMICA = "/organizacaoAcademicaSelecionada";
	const NOME_PROPRIEDADE_STATUS_ATIVIDADE = "/statusAtividadeSelecionada";
	const NOME_PROPRIEDADE_INICIO_ATIVIDADE_SELECIONADA = "/dataInicioAtividadeSelecionada";
	const NOME_PROPRIEDADE_CEP_ESCOLA = "/cepEscolaEntrado";
	const NOME_PROPRIEDADE_ESTADO_ESCOLA = "/estadoSelecionadoEscola";
	const NOME_PROPRIEDADE_MUNICIPIO_ESCOLA = "/municipioEscolaEntrado";
	const NOME_PROPRIEDADE_BAIRRO_ESCOLA = "/bairroEscolaEntrado";
	const NOME_PROPRIEDADE_RUA_ESCOLA = "/ruaEscolaEntrado";
	const NOME_PROPRIEDADE_NUMERO_ESCOLA = "/numeroEscolaEntrado";
	const NOME_PROPRIEDADE_COMPLEMENTO_ESCOLA = "/complementoEscolaEntrado";
	return Controller.extend("ui5.cod3rsgrowth.controller.CriarEditarEscolas", {
		_rotaAtual: "",
		_nomeModeloI18n: "i18n",
		_idCriarEditarEscolas: "criarEditarEscolas",
		onInit() {
			const nomeRotaEscolaCirar = "EscolaCriar";
			const roteador = this.getOwnerComponent().getRouter();
			roteador.getRoute(nomeRotaEscolaCirar).attachMatched(this._aoCoincidirComRotaEscolaCriar, this);
		},
		_aoCoincidirComRotaEscolaCriar(oEvent) {
			const idDataInicioAtividadeDatePicker = "dataInicioAtividade";
			const i18nMensagemDeErro = "CriarEditarEscola.ErroAoCoincidirRotas";
			const parametroNomeRota = "name";
			this._trataErros(i18nMensagemDeErro, () => {
				this._rotaAtual = oEvent.getParameter(parametroNomeRota);
				const i18nTituloEscolaCriar = "CriarEditarEscola.TituloCriar";
				let i18n = this.getOwnerComponent().getModel(this._nomeModeloI18n).getResourceBundle();
				this.byId(this._idCriarEditarEscolas).setTitle(i18n.getText(i18nTituloEscolaCriar));
				let dataAtual = new Date();
				this.byId(idDataInicioAtividadeDatePicker).setMaxDate(
					UI5Date.getInstance(
						dataAtual.getFullYear(),
						dataAtual.getMonth(),
						dataAtual.getDate()
					)
				);
			});
		},
		_retornaValoresEscola() {
			const modelo = this.getView().getModel();
			return {
				statusAtividade: modelo.getProperty(NOME_PROPRIEDADE_STATUS_ATIVIDADE),
				nome: modelo.getProperty(NOME_PROPRIEDADA_NOME),
				codigoMec: String(modelo.getProperty(NOME_PROPRIEDADE_CODIGO_MEC)),
				telefone: String(modelo.getProperty(NOME_PROPRIEDADE_TELEFONE)),
				email: modelo.getProperty(NOME_PROPRIEDADE_EMAIL),
				inicioAtividade: modelo.getProperty(NOME_PROPRIEDADE_INICIO_ATIVIDADE_SELECIONADA),
				categoriaAdministrativa: modelo.getProperty(NOME_PROPRIEDADE_CATEGORIA_ADMINISTRATIVA),
				organizacaoAcademica: modelo.getProperty(NOME_PROPRIEDADE_ORGANIZACAO_ACADEMICA),
				idEndereco: 0
			}
		},
		_retornaValoresEndereco() {
			const modelo = this.getView().getModel();
			return {
				numero: modelo.getProperty(NOME_PROPRIEDADE_NUMERO_ESCOLA),
				cep: String(modelo.getProperty(NOME_PROPRIEDADE_CEP_ESCOLA)),
				municipio: modelo.getProperty(NOME_PROPRIEDADE_MUNICIPIO_ESCOLA),
				bairro: modelo.getProperty(NOME_PROPRIEDADE_BAIRRO_ESCOLA),
				rua: modelo.getProperty(NOME_PROPRIEDADE_RUA_ESCOLA),
				complemento: modelo.getProperty(NOME_PROPRIEDADE_COMPLEMENTO_ESCOLA),
				estado: modelo.getProperty(NOME_PROPRIEDADE_ESTADO_ESCOLA)
			}
		},
		_mostraMensagemDeErro(mensagemDeErro, erro) {
			console.error(mensagemDeErro + erro.message);
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
				if (this._rotaAtual == "EscolaCriar") {
					const nomeModelo = "valoresPadrao";
					const modelo = this.getView().getModel(nomeModelo);
					respostaEndereco = await ServicoEnderecos.criarEndereco(this._retornaValoresEndereco(), modelo);
					let escolaCriar = this._retornaValoresEscola();	
					escolaCriar.idEndereco = respostaEndereco.id;
					let respostaEscola = await ServicoEscolas.criarEscola(escolaCriar, modelo)	
					if (respostaEscola.Status != undefined ||
						respostaEndereco.Status != undefined) {	
						const status500 = 500;
						const status400 = 400;
						if (respostaEndereco.Status == undefined) {
							ServicoEnderecos.deletarEndereco(respostaEndereco.id);
						}
						if (respostaEscola.Status == status400) {
							textoErro += this._retornaTextoErro(respostaEscola);
						}
						if (respostaEscola.Status == status500) {
							textoErro += respostaEscola.Detail;
						}
						if (respostaEndereco.Status == status400) {
							textoErro += this._retornaTextoErro(respostaEndereco);
						}
						if (respostaEndereco.Status == status500) {
							textoErro += respostaEndereco.Detail;
						}
						throw new Error(textoErro);
					}
					this.aoPressionarBotaoDeNavegacao();
				}
			});
		},
		aoPressionarBotaoDeNavegacao() {
			const i18nMensagemDeErro = "CriarEditarEscola.ErroAoClicarBotaoDeNavegaca";
			this._trataErros(i18nMensagemDeErro, () => {
				const historico = History.getInstance();
				const hashAnterior = historico.getPreviousHash();
				const modelo = this.getView().getModel();
				modelo.setProperty(NOME_PROPRIEDADE_CODIGO_MEC, undefined);
				modelo.setProperty(NOME_PROPRIEDADE_TELEFONE, undefined);
				modelo.setProperty(NOME_PROPRIEDADE_EMAIL, undefined);
				modelo.setProperty(NOME_PROPRIEDADE_CATEGORIA_ADMINISTRATIVA, undefined);
				modelo.setProperty(NOME_PROPRIEDADA_NOME, undefined);
				modelo.setProperty(NOME_PROPRIEDADE_ORGANIZACAO_ACADEMICA, undefined);
				modelo.setProperty(NOME_PROPRIEDADE_STATUS_ATIVIDADE, undefined);
				modelo.setProperty(NOME_PROPRIEDADE_INICIO_ATIVIDADE_SELECIONADA, undefined);
				modelo.setProperty(NOME_PROPRIEDADE_CEP_ESCOLA, undefined);
				modelo.setProperty(NOME_PROPRIEDADE_ESTADO_ESCOLA, undefined);
				modelo.setProperty(NOME_PROPRIEDADE_BAIRRO_ESCOLA, undefined);
				modelo.setProperty(NOME_PROPRIEDADE_MUNICIPIO_ESCOLA, undefined);
				modelo.setProperty(NOME_PROPRIEDADE_RUA_ESCOLA, undefined);
				modelo.setProperty(NOME_PROPRIEDADE_NUMERO_ESCOLA, undefined);
				modelo.setProperty(NOME_PROPRIEDADE_COMPLEMENTO_ESCOLA, undefined);
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