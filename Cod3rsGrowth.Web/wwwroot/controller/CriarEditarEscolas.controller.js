sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/ui/core/date/UI5Date",
	"ui5/cod3rsgrowth/modelos/Servicos/ServicoEscolas",
	"ui5/cod3rsgrowth/modelos/Servicos/ServicoEnderecos",
	"sap/ui/core/routing/History",
	"sap/m/MessageBox"
], function(
	Controller,
	UI5Date,
	ServicoEscolas,
	ServicoEnderecos,
	History,
	MessageBox
) {
	"use strict";

	return Controller.extend("ui5.cod3rsgrowth.controller.CriarEditarEscolas", {
		_rotaAtual: "",
		_nomeModeloI18n: "i18n",
		_idCriarEditarEscolas: "criarEditarEscolas",
		onInit() { 
			const nomeRotaEscolaCirar = "EscolaCriar";
			try {
				const roteador = this.getOwnerComponent().getRouter();
				roteador.getRoute(nomeRotaEscolaCirar).attachMatched(this._aoCoincidirComRotaEscolaCriar, this);
			}
			catch (erro) {	
				const i18nMensagemDeErro = "CriarEditarEscola.ErroAoInicializarTela";
				const i18n = this.getOwnerComponent().getModel(this._nomeModeloI18n).getResourceBundle();
				const mensagemDeErro = i18n.getText(i18nMensagemDeErro);
				this._mostraMensagemDeErro(mensagemDeErro, erro);
			}
		},
		_aoCoincidirComRotaEscolaCriar(oEvent) {
			try {
				const idDataInicioAtividadeDatePicker = "dataInicioAtividade";
				const parametroNomeRota = "name";
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
			}
			catch(erro)
			{
				const i18nMensagemDeErro = "CriarEditarEscola.ErroAoCoincidirRotaCriar"
				const i18n = this.getOwnerComponent().getModel(this._nomeModeloI18n).getResourceBundle();
				const mensagemDeErro = i18n.getText(i18nMensagemDeErro);
				this._mostraMensagemDeErro(mensagemDeErro, erro);
			}
		},
		_retornaValoresEscola() {
			const nomePropriedadeNome = "/nomeEscolaEntrada";
			const nomePropriedadeCodigoMec = "/codigoMecEscolaEntrada";
			const nomePropriedadeTelefone = "/telefoneEscolaEntrada";
			const nomePropriedadeEmail = "/emailEscolaEntrada";
			const nomePropriedadeCategoriaAdministrativa = "/categoriaAdministrativaSelecionada";
			const nomePropriedadeOrganizacaoAcademica = "/organizacaoAcademicaSelecionada";
			const nomePropriedadeStatusAtividade = "/statusAtividadeSelecionada";
			const nomePropriedadeInicioAtividadeSelecionada = "/dataInicioAtividadeSelecionada"; 

			try {
				const modelo = this.getView().getModel();
				return {
					statusAtividade: modelo.getProperty(nomePropriedadeStatusAtividade),
					nome: modelo.getProperty(nomePropriedadeNome),
					codigoMec: modelo.getProperty(nomePropriedadeCodigoMec),
					telefone: modelo.getProperty(nomePropriedadeTelefone),
					email: modelo.getProperty(nomePropriedadeEmail),
					inicioAtividade: modelo.getProperty(nomePropriedadeInicioAtividadeSelecionada),
					categoriaAdministrativa: modelo.getProperty(nomePropriedadeCategoriaAdministrativa),
					organizacaoAcademica: modelo.getProperty(nomePropriedadeOrganizacaoAcademica),
					idEndereco: 0
				}
			}
			catch (erro) {
				const i18nMensagemDeErro = "CriarEditarEscola.ErroRecebeDadosTela"
				const i18n = this.getOwnerComponent().getModel(this._nomeModeloI18n).getResourceBundle();
				const mensagemDeErro = i18n.getText(i18nMensagemDeErro);
				this._mostraMensagemDeErro(mensagemDeErro, erro);
			}
		},
		_retornaValoresEndereco() {
			const nomePropriedadeCepEscola = "/cepEscolaEntrado";
			const nomePropriedadeEstadoEscola = "/estadoSelecionadoEscola";
			const nomePropriedadeMunicipioEscola = "/municipioEscolaEntrado";
			const nomePropriedadeBairroEscola = "/bairroEscolaEntrado";
			const nomePropriedadeRuaEscola = "/ruaEscolaEntrado";
			const nomePropriedadeNumeroEscola = "/numeroEscolaEntrado";
			const nomePropriedadeComplementoEscola = "/complementoEscolaEntrado";
			try {
				const modelo = this.getView().getModel();
				return {
					numero: modelo.getProperty(nomePropriedadeNumeroEscola),
					cep: modelo.getProperty(nomePropriedadeCepEscola),
					municipio: modelo.getProperty(nomePropriedadeMunicipioEscola),
					bairro: modelo.getProperty(nomePropriedadeBairroEscola),
					rua: modelo.getProperty(nomePropriedadeRuaEscola),
					complemento: modelo.getProperty(nomePropriedadeComplementoEscola),
					estado: modelo.getProperty(nomePropriedadeEstadoEscola)
				}
			}
			catch (erro) {
				const i18nMensagemDeErro = "CriarEditarEscola.ErroRecebeDadosTela";
				const i18n = this.getOwnerComponent().getModel(this._nomeModeloI18n).getResourceBundle();
				const mensagemDeErro = i18n.getText(i18nMensagemDeErro);
				this._mostraMensagemDeErro(mensagemDeErro, erro);
			}
		},
		_retornaValoresEndereco() {
			const nomePropriedadeCepEscola = "/cepEscolaEntrado";
			const nomePropriedadeEstadoEscola = "/estadoSelecionadoEscola";
			const nomePropriedadeMunicipioEscola = "/municipioEscolaEntrado";
			const nomePropriedadeBairroEscola = "/bairroEscolaEntrado";
			const nomePropriedadeRuaEscola = "/ruaEscolaEntrado";
			const nomePropriedadeNumeroEscola = "/numeroEscolaEntrado";
			const nomePropriedadeComplementoEscola = "/complementoEscolaEntrado";
			try {
				const modelo = this.getView().getModel();
				return {
					numero: modelo.getProperty(nomePropriedadeNumeroEscola),
					cep: modelo.getProperty(nomePropriedadeCepEscola),
					municipio: modelo.getProperty(nomePropriedadeMunicipioEscola),
					bairro: modelo.getProperty(nomePropriedadeBairroEscola),
					rua: modelo.getProperty(nomePropriedadeRuaEscola),
					complemento: modelo.getProperty(nomePropriedadeComplementoEscola),
					estado: modelo.getProperty(nomePropriedadeEstadoEscola)
				}
			}
			catch (erro) {
				const i18nMensagemDeErro = "CriarEditarEscolas.ErroRecebeDadosTela";
				const i18n = this.getOwnerComponent().getModel(this._nomeModeloI18n).getResourceBundle();
				const mensagemDeErro = i18n.getText(i18nMensagemDeErro);
				this._mostraMensagemDeErro(mensagemDeErro, erro);
			}
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
		aoPressionarSalvar: async function () {
			let respostaEndereco;
			let textoErro = "";
			try {
				if (this._rotaAtual == "EscolaCriar") {
					respostaEndereco = await ServicoEnderecos.criarEndereco(this._retornaValoresEndereco());
					let empresaCriar = this._retornaValoresEscola();
					debugger;
					empresaCriar.idEndereco = respostaEndereco.id;
					let respostaEscola = await ServicoEscolas.criarEscola(empresaCriar)
					debugger;
					if (!respostaEscola.ok && !respostaEndereco.ok &&
						respostaEscola.ok != undefined && respostaEndereco.ok != undefined ||
						respostaEscola.Status != undefined || respostaEndereco.Status != undefined) {
						debugger;
						const status500 = 500;
						const status400 = 400;
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
			} catch (erro) {
				let i18nMensagemDeErro;
				if (this._rotaAtual == "EscolaCriar") {
					i18nMensagemDeErro = "CriarEditarEscola.ErroAoTentarCriarEscola";
				}
				else {
					i18nMensagemDeErro = "CriarEditarEscola.ErroTentarEditarEscola";
				}
				const i18n = this.getOwnerComponent().getModel(this._nomeModeloI18n).getResourceBundle();
				const mensagemDeErro = i18n.getText(i18nMensagemDeErro);
				this._mostraMensagemDeErro(mensagemDeErro, erro);
			}
		},

		aoPressionarBotaoDeNavegacao() {
			const historico = History.getInstance();
			const hashAnterior = historico.getPreviousHash();

			if (hashAnterior != undefined) {
				window.history.go(-1);
			}
			else {
				const roteador = this.getOwnerComponent().getRouter();
				roteador.navTo("Escolas", {}, {}, true);
			}
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
		}
	});
});