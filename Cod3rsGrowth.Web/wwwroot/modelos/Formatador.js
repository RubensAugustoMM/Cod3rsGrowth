sap.ui.define([], () => {
	"use strict";
		let modeloI18n = undefined;
		return {
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

			textoNaturezaJuridica(numeroNaturezaJuridica) {
				switch (numeroNaturezaJuridica) {
					case 0:
						return modeloI18n.getText("Formatador.MicroempreendedorIndividual");
					case 1:
						return modeloI18n.getText("Formatador.EmpresarioIndividual");
					case 2:
						return modeloI18n.getText("Formatador.SociedadeEmpresariaLimitada");
					case 3:
						return modeloI18n.getText("Formatador.SociedadeEmpresariaUnipessoalLimitada");
					case 4:
						return modeloI18n.getText("Formatador.SociedadeSimplesPura");
					case 5:
						return modeloI18n.getText("Formatador.SociedadeSimplesLimitada");
					case 6:
						return modeloI18n.getText("Formatador.SociedadeAnonimaAberta");
					case 7:
						return modeloI18n.getText("Formatador.SociedadeAnonimaFechada");
					default:
						return "";
				}
			},

			textoOrganizacaoAcademica(numeroOrganizacaoAcademica) {
				switch (numeroOrganizacaoAcademica) {
					case 0:
						return modeloI18n.getText("Formatador.Faculdade");
					case 1:
						return modeloI18n.getText("Formatador.CentroUniversitario");
					case 2:
						return modeloI18n.getText("Formatador.InstitutoFederal");
					case 3:
						return modeloI18n.getText("Formatador.Universidade");
					case 4:
						return modeloI18n.getText("Formatador.EscolaDoGoverno");
					default:
						return "";
				}
			},

			textoSituacaoCadastral(valorSituacaoCadastral) {
				if (valorSituacaoCadastral) {
					return modeloI18n.getText("Formatador.Ativa");
				}
				else {
					return modeloI18n.getText("Formatador.Inativa");
				}
			},
			textoCategoriaAdministrativao() {
				
			}
		};
});