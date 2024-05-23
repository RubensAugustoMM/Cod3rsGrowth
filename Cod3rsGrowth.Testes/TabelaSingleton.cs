using System.Dynamic;
using System.Reflection;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;

namespace Cod3rsGrowth.Testes;

public class TabelaSingleton
{
    private readonly static TabelaSingleton _instance = new TabelaSingleton();
    private List<IEntidade> _convenios = new();
    private List<IEntidade> _empresas = new();
    private List<IEntidade> _enderecos = new();
    private List<IEntidade> _escolas = new();
    private List<IEntidade> _estados = new();

    private TabelaSingleton()
    {

    }

    public List<IEntidade> RetornaTabela<T>() where T : IEntidade
    {
        if (typeof(T) == typeof(Convenio))
            return _convenios;

        if (typeof(T) == typeof(Empresa))
            return _empresas;

        if (typeof(T) == typeof(Endereco))
            return _enderecos;

        if (typeof(T) == typeof(Escola))
            return _escolas;

        if (typeof(T) == typeof(Estado))
            return _estados;

        return null; 
    }

    public static TabelaSingleton Instance
    {
        get
        {
            return _instance;
        } 
    }
}