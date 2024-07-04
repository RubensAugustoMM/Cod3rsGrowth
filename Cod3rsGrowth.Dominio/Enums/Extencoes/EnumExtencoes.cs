using System.ComponentModel;
using Cod3rsGrowth.Dominio.Enums;

namespace Cod3rsGrowth.Dominio;

public static class EnumExtencoes
{
    public static string RetornaDescricao(this Enum valorEnum)
    {
        var campo = valorEnum.GetType().GetField(valorEnum.ToString());
        if (campo == null)
            return valorEnum.ToString();

        var atributos = campo.GetCustomAttributes(typeof(DescriptionAttribute), false);
        if(Attribute.GetCustomAttribute(campo,typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
        {
            return attribute.Description;
        }

        return valorEnum.ToString();
    }

    public static TEnum RetornaEnum<TEnum>(this string descricaoEnum) where TEnum: struct, Enum
    {
        var descricaoEnumCorte = descricaoEnum.Trim(' ', '-');
        TEnum ValorEnum;

        if(Enum.TryParse<TEnum>(descricaoEnumCorte, out ValorEnum))
        {
            return ValorEnum;
        }

        return ValorEnum;
    }

    public static List<string> RetornaListaDescricoesEnums<TEnum>() where TEnum : struct, Enum
    {
        var ArrayEnum = Enum.GetValues<TEnum>();
        List<string> DescricoesEnum = new();

        foreach (var e in ArrayEnum)
        {
            DescricoesEnum.Add(RetornaDescricao(e));
        }

        return DescricoesEnum;
    }
}