using System.Dynamic;
using System.Reflection;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;

namespace Cod3rsGrowth.Testes;

public class TabelaSingleton
{
    private readonly static TabelaSingleton instance = new TabelaSingleton();
    private List<IEntidade> Convenios = new();
    private List<IEntidade> Empresas = new();
    private List<IEntidade> Enderecos = new();
    private List<IEntidade> Escolas = new();
    private List<IEntidade> Estados = new();

    private TabelaSingleton()
    {

    }

    public List<IEntidade> RetornaTabela<T>() where T : IEntidade
    {
        if (typeof(T) == typeof(Convenio))
            return Convenios;

        if (typeof(T) == typeof(Empresa))
            return Empresas;

        if (typeof(T) == typeof(Endereco))
            return Enderecos;

        if (typeof(T) == typeof(Escola))
            return Escolas;

        if (typeof(T) == typeof(Estado))
            return Estados;

        return null; 
    }

    public static TabelaSingleton Instance
    {
        get
        {
            return instance;
        } 
    }
}