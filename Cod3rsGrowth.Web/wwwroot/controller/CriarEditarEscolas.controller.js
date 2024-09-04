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

	return Controller.extend("ui5.cod3rsgrowth.controller.CriarEditarEscolas", {

		_nomePropriedadeNome: "/nomeEscolaEntrada",
		_nomePropriedadeCodigoMec: "/codigoMecEscolaEntrada",
		_nomePropriedadeTelefone: "/telefoneEscolaEntrada",
		_nomePropriedadeEmail: "/emailEscolaEntrada",
		_nomePropriedadeCategoriaAdministrativa: "/categoriaAdministrativaSelecionada",
		_nomePropriedadeOrganizacaoAcademica: "/organizacaoAcademicaSelecionada",
		_nomePropriedadeStatusAtividade: "/statusAtividadeSelecionada",
		_nomePropriedadeInicioAtividadeSelecionada: "/dataInicioAtividadeSelecionada",
		_nomePropriedadeCepEscola: "/cepEscolaEntrado",
		_nomePropriedadeEstadoEscola: "/estadoSelecionadoEscola",
		_nomePropriedadeMunicipioEscola: "/municipioEscolaEntrado",
		_nomePropriedadeBairroEscola: "/bairroEscolaEntrado",
		_nomePropriedadeRuaEscola: "/ruaEscolaEntrado",
		_nomePropriedadeNumeroEscola: "/numeroEscolaEntrado",
		_nomePropriedadeComplementoEscola: "/complementoEscolaEntrado",
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
		},
		_retornaValoresEscola() {
			const modelo = this.getView().getModel();
			return {
				statusAtividade: modelo.getProperty(this._nomePropriedadeStatusAtividade),
				nome: modelo.getProperty(this._nomePropriedadeNome),
				codigoMec: String(modelo.getProperty(this._nomePropriedadeCodigoMec)),
				telefone: String(modelo.getProperty(this._nomePropriedadeTelefone)),
				email: modelo.getProperty(this._nomePropriedadeEmail),
				inicioAtividade: modelo.getProperty(this._nomePropriedadeInicioAtividadeSelecionada),
				categoriaAdministrativa: modelo.getProperty(this._nomePropriedadeCategoriaAdministrativa),
				organizacaoAcademica: modelo.getProperty(this._nomePropriedadeOrganizacaoAcademica),
				idEndereco: 0
			}
		},
		_retornaValoresEndereco() {
			const modelo = this.getView().getModel();
			return {
				numero: modelo.getProperty(this._nomePropriedadeNumeroEscola),
				cep: String(modelo.getProperty(this._nomePropriedadeCepEscola)),
				municipio: modelo.getProperty(this._nomePropriedadeMunicipioEscola),
				bairro: modelo.getProperty(this._nomePropriedadeBairroEscola),
				rua: modelo.getProperty(this._nomePropriedadeRuaEscola),
				complemento: modelo.getProperty(this._nomePropriedadeComplementoEscola),
				estado: modelo.getProperty(this._nomePropriedadeEstadoEscola)
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
			const modelo = this.getView().getModel();
			modelo.setProperty(this._nomePropriedadeNome, undefined);
			modelo.setProperty(this._nomePropriedadeCodigoMec, undefined);
			modelo.setProperty(this._nomePropriedadeTelefone, undefined);
			modelo.setProperty(this._nomePropriedadeEmail, undefined);
			modelo.setProperty(this._nomePropriedadeCategoriaAdministrativa, undefined);
			modelo.setProperty(this._nomePropriedadeOrganizacaoAcademica, undefined);
			modelo.setProperty(this._nomePropriedadeStatusAtividade, undefined);
			modelo.setProperty(this._nomePropriedadeInicioAtividadeSelecionada, undefined);
			modelo.setProperty(this._nomePropriedadeCepEscola, undefined);
			modelo.setProperty(this._nomePropriedadeEstadoEscola, undefined);
			modelo.setProperty(this._nomePropriedadeBairroEscola, undefined);
			modelo.setProperty(this._nomePropriedadeMunicipioEscola, undefined);
			modelo.setProperty(this._nomePropriedadeRuaEscola, undefined);
			modelo.setProperty(this._nomePropriedadeNumeroEscola, undefined);
			modelo.setProperty(this._nomePropriedadeComplementoEscola, undefined);
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