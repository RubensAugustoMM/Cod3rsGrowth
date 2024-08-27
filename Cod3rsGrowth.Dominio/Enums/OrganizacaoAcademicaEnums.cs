using System.ComponentModel;

namespace Cod3rsGrowth.Dominio.Enums;
public enum OrganizacaoAcademicaEnums 
{ 
    [Description("Faculdade")] 
    Faculdade, 
    [Description("Centro Universitário")]  
    CentroUniversitario, 
    [Description("Instituto Federal")]  
    InstitutoFederal,  
    [Description("Universidade")] 
    Universidade,
    [Description("Escola do Governo")]
    EscolaGoverno
}