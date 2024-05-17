using System;
using System.ComponentModel;

namespace Cod3rsGrowth.Dominio.Enum;
public enum CategoriaAdministrativaEnum
{ 
    [Description("Adiministração Municipal")]
    Municipal, 
    [Description("Adiministração Federal")] 
    Federal, 
    [Description("Adiministração Estadual")] 
    Estadual
}
