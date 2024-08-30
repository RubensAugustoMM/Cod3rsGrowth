sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/ui/core/routing/History",
	"ui5/cod3rsgrowth/modelos/Servicos/ServicoEmpresas",
	"sap/m/MessageBox",
	"sap/viz/ui5/types/layout/Stack",
	"ui5/cod3rsgrowth/modelos/Servicos/ServicoEnderecos"
], function (
	Controller,
	History,
	ServicoEmpresas,
	MessageBox,
	Stack,
	ServicoEnderecos
) {
	"use strict";

	return Controller.extend("ui5.cod3rsgrowth.controller.CriarEditarEmpresas", {
		_rotaAtual: "",
		_nomeModeloI18n: "i18n",
		_idCriarEditarEmpresas: "criarEditarEmpresas",
		onInit() {
			const nomeRotaEmpresaCriar = "EmpresaCriar";
			try {
				const roteador = this.getOwnerComponent().getRouter();

				roteador.getRoute(nomeRotaEmpresaCriar).attachMatched(this._aoCoincidirComRotaEmpresaCriar, this);
			}
			catch (erro) {
				const i18nMensagemDeErro = "CriarEditarEmpresas.ErroIniciarTela";
				const i18n = this.getOwnerComponent().getModel(this._nomeModeloI18n).getResourceBundle();
				const mensagemDeErro = i18n.getText(i18nMensagemDeErro);
				this._mostraMensagemDeErro(mensagemDeErro, erro);
			}
		},
		_aoCoincidirComRotaEmpresaCriar(oEvent) {
			try {
				const parametroNomeRota = "name";
				this._rotaAtual = oEvent.getParameter(parametroNomeRota);
				const i18TituloEmpresaCriar = "CriarEditarEmpresas.TituloCriar";
				let i18n = this.getOwnerComponent().getModel(this._nomeModeloI18n).getResourceBundle();
				this.byId(this._idCriarEditarEmpresas).setTitle(i18n.getText(i18TituloEmpresaCriar));
			}
			catch (erro) {
				const i18nMensagemDeErro = "CriarEditarEmpresas.ErroCoincidirRotaCriar";
				const i18n = this.getOwnerComponent().getModel(this._nomeModeloI18n).getResourceBundle();
				const mensagemDeErro = i18n.getText(i18nMensagemDeErro);
				this._mostraMensagemDeErro(mensagemDeErro, erro);
			}
		},
		_retornaValoresEmpresa() {
			const nomePropriedadeRazaoSocialEmpresa = "/razaoSocialEmpresaEntrada";
			const nomePropriedadeNomeFantasiaEmpresa = "/nomeFantasiaEmpresaEntrada";
			const nomePropriedadeCnpjEmpresa = "/cnpjEmpresaEntrada";
			const nomePropriedadeCapitalSocialEmpresa = "/capitalSocialEmpresaEntrada";
			const nomePropriedadeNaturezaJuridicaEmpresa = "/naturezaJuridicaSelecionada";
			const nomePropriedadePorteEmpresa = "/porteSelecionado";
			const nomePropriedadeMatrizFilialEmpresa = "/matrizFilialSelecionado";
			const nomePropriedadeSituacaoCadastralEmpresa = "/situacaoCadastralSelecionado";
			const nomePropriedadeDataAberturaEmpresa = "/dataAberturaSelecionada";

			try {
				const modelo = this.getView().getModel();
				return {
					razaoSocial: modelo.getProperty(nomePropriedadeRazaoSocialEmpresa),
					nomeFantasia: modelo.getProperty(nomePropriedadeNomeFantasiaEmpresa),
					cnpj: modelo.getProperty(nomePropriedadeCnpjEmpresa).toString(),
					situacaoCadastral: modelo.getProperty(nomePropriedadeSituacaoCadastralEmpresa),
					dataSituacaoCadastral: new Date(),
					dataAbertura: modelo.getProperty(nomePropriedadeDataAberturaEmpresa),
					naturezaJuridica: modelo.getProperty(nomePropriedadeNaturezaJuridicaEmpresa),
					porte: modelo.getProperty(nomePropriedadePorteEmpresa),
					matrizFilial: modelo.getProperty(nomePropriedadeMatrizFilialEmpresa),
					capitalSocial: modelo.getProperty(nomePropriedadeCapitalSocialEmpresa),
					idEndereco: 0
				}
			}
			catch (erro) {
				const i18nMensagemDeErro = "CriarEditarEmpresas.ErroRecebeDadosTela";
				const i18n = this.getOwnerComponent().getModel(this._nomeModeloI18n).getResourceBundle();
				const mensagemDeErro = i18n.getText(i18nMensagemDeErro);
				this._mostraMensagemDeErro(mensagemDeErro, erro);
			}
		},
		_retornaValoresEndereco() {
			const nomePropriedadeCepEmpresa = "/cepEmpresaEntrado";
			const nomePropriedadeEstadoEmpresa = "/estadoSelecionadoEmpresa";
			const nomePropriedadeMunicipioEmpresa = "/municipioEmpresaEntrado";
			const nomePropriedadeBairroEmpresa = "/bairroEmpresaEntrado";
			const nomePropriedadeRuaEmpresa = "/ruaEmpresaEntrado";
			const nomePropriedadeNumeroEmpresa = "/numeroEmpresaEntrado";
			const nomePropriedadeComplementoEmpresa = "/complementoEmpresaEntrado";
			try {
				const modelo = this.getView().getModel();
				return {
					numero: modelo.getProperty(nomePropriedadeNumeroEmpresa),
					cep: modelo.getProperty(nomePropriedadeCepEmpresa),
					municipio: modelo.getProperty(nomePropriedadeMunicipioEmpresa),
					bairro: modelo.getProperty(nomePropriedadeBairroEmpresa),
					rua: modelo.getProperty(nomePropriedadeRuaEmpresa),
					complemento: modelo.getProperty(nomePropriedadeComplementoEmpresa),
					estado: modelo.getProperty(nomePropriedadeEstadoEmpresa)
				}
			}
			catch (erro) {
				const i18nMensagemDeErro = "CriarEditarEmpresas.ErroRecebeDadosTela";
				const i18n = this.getOwnerComponent().getModel(this._nomeModeloI18n).getResourceBundle();
				const mensagemDeErro = i18n.getText(i18nMensagemDeErro);
				this._mostraMensagemDeErro(mensagemDeErro, erro);
			}
		},
		aoPressionarSalvar: async function () {
			let respostaEndereco;
			let textoErro = "";
			try {
				if (this._rotaAtual == "EmpresaCriar") {
					respostaEndereco = await ServicoEnderecos.criarEndereco(this._retornaValoresEndereco());
					let empresaCriar = this._retornaValoresEmpresa();
					debugger;
					empresaCriar.idEndereco = respostaEndereco.id;
					let respostaEmpresa = await ServicoEmpresas.criarEmpresa(empresaCriar)
					debugger;
					if (!respostaEmpresa.ok &&  !respostaEndereco.ok &&
						respostaEmpresa.ok != undefined && respostaEndereco.ok != undefined ||
						respostaEmpresa.Status != undefined || respostaEndereco.Status !=undefined) {
						debugger;
						const status500 = 500;
						const status400 = 400;
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
			} catch (erro) {
				let i18nMensagemDeErro;
				if (this._rotaAtual == "EmpresaCriar") {
					i18nMensagemDeErro = "CriarEditarEmpresas.ErroAoTentarCriarEmpresa";
				}
				else {
					i18nMensagemDeErro = "CriarEditarEmpresas.ErroTentarEditarEmpresa";
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
				roteador.navTo("Empresas", {}, {}, true);
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