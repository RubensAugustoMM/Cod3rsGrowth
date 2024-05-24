using System.Dynamic;
using System.Reflection;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;

namespace Cod3rsGrowth.Testes;

public class TabelaSingleton
{
    private readonly static TabelaSingleton _instance = new TabelaSingleton();

    public Lazy<List<IEntidade>> _convenios = new Lazy<List<IEntidade>>(() => 
    {
        return new List<IEntidade>();
    });

    public Lazy<List<IEntidade>> _empresas = new Lazy<List<IEntidade>>(() => 
    {
        return new List<IEntidade>();
    });

    public Lazy<List<IEntidade>> _enderecos = new Lazy<List<IEntidade>>(() => 
    {
        return new List<IEntidade>();
    });

    public Lazy<List<IEntidade>> _escolas = new Lazy<List<IEntidade>>(() => 
    {
        return new List<IEntidade>();
    });
    public Lazy<List<IEntidade>> _estados = new Lazy<List<IEntidade>>(() => 
    {
        return new List<IEntidade>();
    });
    
    public Dictionary<Type, Lazy<List<IEntidade>>> DicionarioTabelas = new();

    private TabelaSingleton()
    {
        DicionarioTabelas.Add(typeof(Convenio), _convenios);
        DicionarioTabelas.Add(typeof(Empresa), _empresas);
        DicionarioTabelas.Add(typeof(Endereco), _enderecos);
        DicionarioTabelas.Add(typeof(Escola), _escolas);
        DicionarioTabelas.Add(typeof(Estado), _estados);
    }

    public static TabelaSingleton Instance
    {
        get
        {
            return _instance;
        } 
    }
}