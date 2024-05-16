using System;
using System.ComponentModel;

namespace Cod3rsGrowth.Dominio;
public enum PorteEnum
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
