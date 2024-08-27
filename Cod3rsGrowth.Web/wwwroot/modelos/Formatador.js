sap.ui.define([], () => {
	"use strict";

	return {
		_retornaModeloi18n(view) {
			return view.getModel("i18n").getResourceBundle();
		},
		textoEstado(numeroEstado) {
			switch (numeroEstado) {
				case 0:
					return "Acre-AC";
				case 1:
					return "Alagoas-AL";
				case 2:
					return "Amapa-AP";
				case 3:
					return "Amazonas-AM";
				case 4:
					return "Bahia-BA";
				case 5:
					return "Ceara-CE";
				case 6:
					return "Espirito Santo-ES";
				case 7:
					return "Goias-GO";
				case 8:
					return "Maranhao-MA";
				case 9:
					return "Mato Grosso-MT";
				case 10:
					return "Mato Grosso do Sul-MS";
				case 11:
					return "Minas Gerais-MG";
				case 12:
					return "Para-PA";
				case 13:
					return "Paraiba-PB";
				case 14:
					return "Parana-PR";
				case 15:
					return "Pernambuco-PE";
				case 16:
					return "Piaui-PI";
				case 17:
					return "Rio de Janeiro-RJ";
				case 18:
					return "Rio Grande do Norte-RN";
				case 19:
					return "Rio Grande do Sul-RS";
				case 20:
					return "Rondonia-RO";
				case 21:
					return "Roraima-RR";
				case 22:
					return "Santa Catarina-SC";
				case 23:
					return "São Paulo-SP";
				case 24:
					return "Sergipe-SE";
				case 25:
					return "Tocantins-TO";
				case 26:
					return "Distrito Federal-DF";
				default:
					return "";
			}
		},

		textoNaturezaJuridica(numeroNaturezaJuridica, view) {
			var oModeloi18n = view.getModel("i18n").getResourceBundle();

			switch (numeroNaturezaJuridica) {
				case 0:
					return  oModeloi18n.getText("Formatador.MicroempreendedorIndividual");
				case 1:
					return oModeloi18n.getText("Formatador.EmpresarioIndividual");
				case 2:
					return oModeloi18n.getText("Formatador.SociedadeEmpresariaLimitada");
				case 3:
					return oModeloi18n.getText("Formatador.SociedadeEmpresariaUnipessoalLimitada");
				case 4:
					return oModeloi18n.getText("Formatador.SociedadeSimplesPura");
				case 5:
					return oModeloi18n.getText("Formatador.SociedadeSimplesLimitada");
				case 6:
					return oModeloi18n.getText("Formatador.SociedadeAnonimaAberta");
				case 7:
					return oModeloi18n.getText("Formatador.SociedadeAnonimaFechada");
				default:
					return "";
			}
		},

		textoOrganizacaoAcademica(numeroOrganizacaoAcademica, view) {
			var oModeloi18n = view.getModel("i18n").getResourceBundle();

			switch (numeroOrganizacaoAcademica) {
				case 0:
					return oModeloi18n.getText("Formatador.Faculdade");
				case 1:
					return oModeloi18n.getText("Formatador.CentroUniversitario");
				case 2:
					return oModeloi18n.getText("Formatador.InstitutoFederal");
				case 3:
					return oModeloi18n.getText("Formatador.Universidade");
				case 4:
					return oModeloi18n.getText("Formatador.EscolaDoGoverno");
				default:
					return "";
			}
		},

		textoSituacaoCadastral(valorSituacaoCadastral, view) {
			var oModeloi18n = this._retornaModeloi18n(view);

			if (valorSituacaoCadastral)
			{
				return oModeloi18n.getText("Formatador.Ativa");
			}
			else
			{
				return oModeloi18n.getText("Formatador.Inativa");
			}
		}
	};
});