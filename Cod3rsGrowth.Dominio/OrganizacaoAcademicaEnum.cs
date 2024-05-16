using System;
using System.ComponentModel;

namespace Cod3rsGrowth.Dominio;
public enum OrganizacaoAcademicaEnum 
{ 
    [Description("Faculdade")] 
    Faculdade, 
    [Description("Centro Universitario")]  
    CentroUniversitario, 
    [Description("Instituto Federal")]  
    InstitutoFederal,  
    [Description("Universidade")] 
    Universidade,
    [Description("Escola do Governo")]
    EscolaGoverno
}
