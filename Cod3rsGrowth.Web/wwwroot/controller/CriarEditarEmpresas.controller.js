sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/ui/core/routing/History",
	"ui5/cod3rsgrowth/modelos/Servicos/ServicoEmpresas",
	"sap/viz/ui5/types/layout/Stack",
	"ui5/cod3rsgrowth/modelos/Servicos/ServicoEnderecos",
	"sap/ui/core/date/UI5Date",
	"sap/m/MessageBox"
], function (
	Controller,
	History,
	ServicoEmpresas,
	Stack,
	ServicoEnderecos,
	UI5Date,
	MessageBox
) {
	"use strict";

	const NOME_PROPRIEDADE_ESTADO_EMPRESA = "/estadoSelecionadoEmpresa";
	const NOME_PROPRIEDADE_MUNICIPIO_EMPRESA = "/municipioEmpresaEntrado";
	const NOME_PROPRIEDADE_BAIRRO_EMPRESA = "/bairroEmpresaEntrado";
	const NOME_PROPRIEDADE_RUA_EMPRESA = "/ruaEmpresaEntrado";
	const NOME_PROPRIEDADE_NUMERO_EMPRESA = "/numeroEmpresaEntrado";
	const NOME_PROPRIEDADE_COMPLEMENTO_EMPRESA = "/complementoEmpresaEntrado";
	const NOME_PROPRIEDADE_RAZAO_SOCIAL_EMPRESA = "/razaoSocialEmpresaEntrada";
	const NOME_PROPRIEDADE_CEP_EMPRESA = "/cepEmpresaEntrado";
	const NOME_PROPRIEDADE_NOME_FANTASIA_EMPRESA = "/nomeFantasiaEmpresaEntrada";
	const NOME_PROPRIEDADE_CNPJ_EMPRESA = "/cnpjEmpresaEntrada";
	const NOME_PROPRIEDADE_CAPITAL_SOCIAL_EMPRESA = "/capitalSocialEmpresaEntrada";
	const NOME_PROPRIEDADE_NATUREZA_JURIDICA_EMPRESA = "/naturezaJuridicaSelecionada";
	const NOME_PROPRIEDADE_PORTE_EMPRESA = "/porteSelecionado";
	const NOME_PROPRIEDADE_MATRIZ_FILIAL_EMPRESA = "/matrizFilialSelecionado";
	const NOME_PROPRIEDADE_SITUACAO_CADASTRAL_EMPRESA = "/situacaoCadastralSelecionado";
	const NOME_PROPRIEDADE_DATA_ABERTURA_EMPRESA = "/dataAberturaSelecionada";
	return Controller.extend("ui5.cod3rsgrowth.controller.CriarEditarEmpresas", {
		_rotaAtual: "",
		_nomeModeloI18n: "i18n",
		_idCriarEditarEmpresas: "criarEditarEmpresas",
		onInit() {
			const nomeRotaEmpresaCriar = "EmpresaCriar";
			const roteador = this.getOwnerComponent().getRouter();
			roteador.getRoute(nomeRotaEmpresaCriar).attachMatched(this._aoCoincidirComRotaEmpresaCriar, this);
			const idDataAberturaDatePicker = "dataAberturaDatePicker";
			let dataAtual = new Date();
			this.byId(idDataAberturaDatePicker).setMaxDate(
				UI5Date.getInstance(
					dataAtual.getFullYear(),
					dataAtual.getMonth(),
					dataAtual.getDay()));
		},
		_aoCoincidirComRotaEmpresaCriar(oEvent) {
			const i18nMensagemDeErro = "CriarEditarEmpresas.ErroCoincidirRotaCriar";
			const parametroNomeRota = "name";
			this._rotaAtual = oEvent.getParameter(parametroNomeRota);
			this._trataErros(i18nMensagemDeErro, () => {
				const i18TituloEmpresaCriar = "CriarEditarEmpresas.TituloCriar";
				const i18n = this._retornaModeloI18n();
				this.byId(this._idCriarEditarEmpresas).setTitle(i18n.getText(i18TituloEmpresaCriar));
			});
		},
		_retornaValoresEmpresa() {
			debugger;
			const modelo = this.getView().getModel();
			return {
				razaoSocial: modelo.getProperty(NOME_PROPRIEDADE_RAZAO_SOCIAL_EMPRESA),
				nomeFantasia: modelo.getProperty(NOME_PROPRIEDADE_NOME_FANTASIA_EMPRESA),
				cnpj: String(modelo.getProperty(NOME_PROPRIEDADE_CNPJ_EMPRESA)),
				situacaoCadastral: modelo.getProperty(NOME_PROPRIEDADE_SITUACAO_CADASTRAL_EMPRESA),
				dataSituacaoCadastral: new Date(),
				dataAbertura: modelo.getProperty(NOME_PROPRIEDADE_DATA_ABERTURA_EMPRESA),
				naturezaJuridica: modelo.getProperty(NOME_PROPRIEDADE_NATUREZA_JURIDICA_EMPRESA),
				porte: modelo.getProperty(NOME_PROPRIEDADE_PORTE_EMPRESA),
				matrizFilial: modelo.getProperty(NOME_PROPRIEDADE_MATRIZ_FILIAL_EMPRESA),
				capitalSocial: modelo.getProperty(NOME_PROPRIEDADE_CAPITAL_SOCIAL_EMPRESA),
				idEndereco: 0
			}
		},
		_retornaValoresEndereco() {
			debugger;
			const modelo = this.getView().getModel();
			return {
				numero: String(modelo.getProperty(NOME_PROPRIEDADE_NUMERO_EMPRESA)),
				cep: String(modelo.getProperty(NOME_PROPRIEDADE_CEP_EMPRESA)),
				municipio: modelo.getProperty(NOME_PROPRIEDADE_MUNICIPIO_EMPRESA),
				bairro: modelo.getProperty(NOME_PROPRIEDADE_BAIRRO_EMPRESA),
				rua: modelo.getProperty(NOME_PROPRIEDADE_RUA_EMPRESA),
				complemento: modelo.getProperty(NOME_PROPRIEDADE_COMPLEMENTO_EMPRESA),
				estado: modelo.getProperty(NOME_PROPRIEDADE_ESTADO_EMPRESA)
			}
		},
		aoPressionarSalvar: async function () {
			debugger;
			let respostaEndereco;
			let textoErro = "";
			let i18nMensagemDeErro;
			if (this._rotaAtual == "EmpresaCriar") {
				i18nMensagemDeErro = "CriarEditarEmpresas.ErroAoTentarCriarEmpresa";
			}
			else {
				i18nMensagemDeErro = "CriarEditarEmpresas.ErroTentarEditarEmpresa";
			}
			this._trataErros(i18nMensagemDeErro, async () => {
				if (this._rotaAtual == "EmpresaCriar") {
					debugger;
					const nomeModelo = "valoresPadrao";
					const modelo = this.getView().getModel(nomeModelo);
					respostaEndereco = await ServicoEnderecos.criarEndereco(this._retornaValoresEndereco(), modelo);
					let empresaCriar = this._retornaValoresEmpresa();
					debugger;
					empresaCriar.idEndereco = respostaEndereco.id;
					let respostaEmpresa = await ServicoEmpresas.criarEmpresa(empresaCriar, modelo);
					debugger;
					if (respostaEmpresa.Status != undefined ||
						respostaEndereco.Status != undefined) {
						debugger;
						const status500 = 500;
						const status400 = 400;
						if (respostaEndereco.Status == undefined) {
							ServicoEnderecos.deletarEndereco(respostaEndereco.id);
						}
						if (respostaEmpresa.Status == status400) {
							textoErro += this._retornaTextoErro(respostaEmpresa);
						}
						if (respostaEmpresa.Status == status500) {
							textoErro += respostaEmpresa.Detail;
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
			let i18nMensagemDeErro = "CriarEditarEmpresas.ErroAoClicarBotaoNavegacao";
			this._trataErros(i18nMensagemDeErro, () => {
				const historico = History.getInstance();
				const hashAnterior = historico.getPreviousHash();
				const modelo = this.getView().getModel();
				modelo.setProperty(NOME_PROPRIEDADE_NOME_FANTASIA_EMPRESA, undefined);
				modelo.setProperty(NOME_PROPRIEDADE_DATA_ABERTURA_EMPRESA, undefined);
				modelo.setProperty(NOME_PROPRIEDADE_NATUREZA_JURIDICA_EMPRESA, undefined);
				modelo.setProperty(NOME_PROPRIEDADE_PORTE_EMPRESA, undefined);
				modelo.setProperty(NOME_PROPRIEDADE_SITUACAO_CADASTRAL_EMPRESA, undefined);
				modelo.setProperty(NOME_PROPRIEDADE_CNPJ_EMPRESA, undefined);
				modelo.setProperty(NOME_PROPRIEDADE_RAZAO_SOCIAL_EMPRESA, undefined);
				modelo.setProperty(NOME_PROPRIEDADE_MATRIZ_FILIAL_EMPRESA, undefined);
				modelo.setProperty(NOME_PROPRIEDADE_CAPITAL_SOCIAL_EMPRESA, undefined);
				modelo.setProperty(NOME_PROPRIEDADE_NUMERO_EMPRESA, undefined);
				modelo.setProperty(NOME_PROPRIEDADE_CEP_EMPRESA, undefined);
				modelo.setProperty(NOME_PROPRIEDADE_MUNICIPIO_EMPRESA, undefined);
				modelo.setProperty(NOME_PROPRIEDADE_BAIRRO_EMPRESA, undefined);
				modelo.setProperty(NOME_PROPRIEDADE_RUA_EMPRESA, undefined);
				modelo.setProperty(NOME_PROPRIEDADE_COMPLEMENTO_EMPRESA, undefined);
				modelo.setProperty(NOME_PROPRIEDADE_ESTADO_EMPRESA, undefined);
				if (hashAnterior != undefined) {
					window.history.go(-1);
				}
				else {
					const roteador = this.getOwnerComponent().getRouter();
					const nomeRotaEmpresas = "Empresas";
					roteador.navTo(nomeRotaEmpresas, {}, {}, true);
				}
			})
		},
		_mostraMensagemDeErro(mensagemDeErro, erro) {
			debugger;
			console.error(mensagemDeErro + erro.message);
			MessageBox.show(erro.message, {
				icon: MessageBox.Icon.ERROR,
				title: mensagemDeErro,
				actions: [MessageBox.Action.CLOSE]
			});
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
			debugger;
			const modelo = this.getView().getModel();
			const nomePropriedadeOcupado = "/ocupado";
			modelo.setProperty(nomePropriedadeOcupado, true);
			let erroPego;
			return Promise.resolve(funcao())
				.catch(erro => {
					erroPego = erro;
				})
				.finally(() => {
					debugger;
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