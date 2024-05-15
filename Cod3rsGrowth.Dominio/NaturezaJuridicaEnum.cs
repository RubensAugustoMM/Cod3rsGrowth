using System;
using System.ComponentModel;

namespace Cod3rsGrowth.Dominio;
public enum NaturezaJuridicaEnum
{
    [Description("Microempreendedor Individual")]
    MicroempreendedorIndividual,
    [Description("Empresario Individual")]
    EmpresarioIndividual,
    [Description("Sociedade Empresaria Limitada")]
    SociedadeEmpresariaLimitada,
    [Description("Sociedade Empresaria Unipessoal Limitada")]
    SociedadeEmpresariaUnipessoalLimitada,
    [Description("Sociedade Simples Pura")]
    SociedadeSimplesPura,
    [Description("Sociedade Simples Limitada")]
    SociedadeSimplesLimitada,
    [Description("Sociedade Anonima Aberta")]
    SociedadeAnonimaAberta,
    [Description("Sociedade Anonima Fechada")]
    SociedadeAnonimaFechada
}
