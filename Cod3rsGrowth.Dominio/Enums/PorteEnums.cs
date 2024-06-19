using System.ComponentModel;

namespace Cod3rsGrowth.Dominio.Enums;
public enum PorteEnums
{
    [Description("Microempreendedor Individual")]
    MicroeempreendedorIndividual,
    [Description("Micro Empresa")]
    Microempresa,
    [Description("Empresa de Pequeno Porte")]
    EmpresaPequenoPorte,
    [Description("Media Empresa")]
    MediaEmpresa,
    [Description("Grande Empresa")]
    GrandeEmpresa
}