using System.ComponentModel;
using Cod3rsGrowth.Dominio.Enums;

namespace Cod3rsGrowth.Dominio.Enums.Extencoes;

public static class EnumExtencoes
{
    public static string RetornaDescricao(this Enum valorEnum)
    {
        var campo = valorEnum.GetType().GetField(valorEnum.ToString());
        if (campo == null)
            return valorEnum.ToString();

        var atributos = campo.GetCustomAttributes(typeof(DescriptionAttribute), false);
        if (Attribute.GetCustomAttribute(campo, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
        {
            return attribute.Description;
        }

        return valorEnum.ToString();
    } 
}