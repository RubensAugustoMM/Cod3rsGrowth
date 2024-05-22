using System.Dynamic;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;

namespace Cod3rsGrowth.Testes;

public class TabelaSingleton<T> where T : IEntidade
{
    private static readonly TabelaSingleton<T> instance = new TabelaSingleton<T>();
    public List<object> Tabela = new();

    private TabelaSingleton()
    {

    }

    public static TabelaSingleton<T> Instance
    {
        get
        {
            return instance;
        }
    }
}