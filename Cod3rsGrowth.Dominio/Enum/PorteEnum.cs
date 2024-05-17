using System.ComponentModel;
using System;

namespace Cod3rsGrowth.Dominio.Enum;
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
