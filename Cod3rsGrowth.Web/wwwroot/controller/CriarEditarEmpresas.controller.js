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

	return Controller.extend("ui5.cod3rsgrowth.controller.CriarEditarEmpresas", {

		_nomePropriedadeCepEmpresa: "/cepEmpresaEntrado",
		_nomePropriedadeEstadoEmpresa: "/estadoSelecionadoEmpresa",
		_nomePropriedadeMunicipioEmpresa: "/municipioEmpresaEntrado",
		_nomePropriedadeBairroEmpresa: "/bairroEmpresaEntrado",
		_nomePropriedadeRuaEmpresa: "/ruaEmpresaEntrado",
		_nomePropriedadeNumeroEmpresa: "/numeroEmpresaEntrado",
		_nomePropriedadeComplementoEmpresa: "/complementoEmpresaEntrado",
		_nomePropriedadeRazaoSocialEmpresa: "/razaoSocialEmpresaEntrada",
		_nomePropriedadeNomeFantasiaEmpresa: "/nomeFantasiaEmpresaEntrada",
		_nomePropriedadeCnpjEmpresa: "/cnpjEmpresaEntrada",
		_nomePropriedadeCapitalSocialEmpresa: "/capitalSocialEmpresaEntrada",
		_nomePropriedadeNaturezaJuridicaEmpresa: "/naturezaJuridicaSelecionada",
		_nomePropriedadePorteEmpresa: "/porteSelecionado",
		_nomePropriedadeMatrizFilialEmpresa: "/matrizFilialSelecionado",
		_nomePropriedadeSituacaoCadastralEmpresa: "/situacaoCadastralSelecionado",
		_nomePropriedadeDataAberturaEmpresa: "/dataAberturaSelecionada",
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
			const modelo = this.getView().getModel();
			return {
				razaoSocial: modelo.getProperty(this._nomePropriedadeRazaoSocialEmpresa),
				nomeFantasia: modelo.getProperty(this._nomePropriedadeNomeFantasiaEmpresa),
				cnpj: String(modelo.getProperty(this._nomePropriedadeCnpjEmpresa)),
				situacaoCadastral: modelo.getProperty(this._nomePropriedadeSituacaoCadastralEmpresa),
				dataSituacaoCadastral: new Date(),
				dataAbertura: modelo.getProperty(this._nomePropriedadeDataAberturaEmpresa),
				naturezaJuridica: modelo.getProperty(this._nomePropriedadeNaturezaJuridicaEmpresa),
				porte: modelo.getProperty(this._nomePropriedadePorteEmpresa),
				matrizFilial: modelo.getProperty(this._nomePropriedadeMatrizFilialEmpresa),
				capitalSocial: modelo.getProperty(this._nomePropriedadeCapitalSocialEmpresa),
				idEndereco: 0
			}
		},
		_retornaValoresEndereco() {
			const modelo = this.getView().getModel();
			return {
				numero: String(modelo.getProperty(this._nomePropriedadeNumeroEmpresa)),
				cep: String(modelo.getProperty(this._nomePropriedadeCepEmpresa)),
				municipio: modelo.getProperty(this._nomePropriedadeMunicipioEmpresa),
				bairro: modelo.getProperty(this._nomePropriedadeBairroEmpresa),
				rua: modelo.getProperty(this._nomePropriedadeRuaEmpresa),
				complemento: modelo.getProperty(this._nomePropriedadeComplementoEmpresa),
				estado: modelo.getProperty(this._nomePropriedadeEstadoEmpresa)
			}
		},
		aoPressionarSalvar: async function () {
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
					respostaEndereco = await ServicoEnderecos.criarEndereco(this._retornaValoresEndereco());
					let empresaCriar = this._retornaValoresEmpresa();
					debugger;
					empresaCriar.idEndereco = respostaEndereco.id;
					let respostaEmpresa = await ServicoEmpresas.criarEmpresa(empresaCriar)
					debugger;
					if (!respostaEmpresa.ok && !respostaEndereco.ok &&
						respostaEmpresa.ok != undefined && respostaEndereco.ok != undefined ||
						respostaEmpresa.Status != undefined || respostaEndereco.Status != undefined) {
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
				modelo.setProperty(this._nomePropriedadeRazaoSocialEmpresa, undefined);
				modelo.setProperty(this._nomePropriedadeNomeFantasiaEmpresa, undefined);
				modelo.setProperty(this._nomePropriedadeCnpjEmpresa, undefined);
				modelo.setProperty(this._nomePropriedadeSituacaoCadastralEmpresa, undefined);
				modelo.setProperty(this._nomePropriedadeDataAberturaEmpresa, undefined);
				modelo.setProperty(this._nomePropriedadeNaturezaJuridicaEmpresa, undefined);
				modelo.setProperty(this._nomePropriedadePorteEmpresa, undefined);
				modelo.setProperty(this._nomePropriedadeMatrizFilialEmpresa, undefined);
				modelo.setProperty(this._nomePropriedadeCapitalSocialEmpresa, undefined);
				modelo.setProperty(this._nomePropriedadeNumeroEmpresa, undefined);
				modelo.setProperty(this._nomePropriedadeCepEmpresa, undefined);
				modelo.setProperty(this._nomePropriedadeMunicipioEmpresa, undefined);
				modelo.setProperty(this._nomePropriedadeBairroEmpresa, undefined);
				modelo.setProperty(this._nomePropriedadeRuaEmpresa, undefined);
				modelo.setProperty(this._nomePropriedadeComplementoEmpresa, undefined);
				modelo.setProperty(this._nomePropriedadeEstadoEmpresa, undefined);
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
			const modelo = this.getView().getModel();
			const nomePropriedadeOcupado = "/ocupado";
			modelo.setProperty(nomePropriedadeOcupado, true);
			return Promise.resolve(funcao())
				.catch(erro => {
					const i18n = this._retornaModeloI18n();
					const TituloErro = i18n.getText(nomeModeloTituloErro);
					this._mostraMensagemDeErro(TituloErro, erro);
				})
				.finally(() => {
					modelo.setProperty(nomePropriedadeOcupado, false)
				});
		},
		_retornaModeloI18n() {
			return this.getOwnerComponent().getModel(this._nomeModeloI18n).getResourceBundle();
		}
	});
});