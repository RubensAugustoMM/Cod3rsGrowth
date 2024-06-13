using Cod3rsGrowth.Dominio.Modelos;

namespace Cod3rsGrowth.Testes;

public partial class TabelaSingleton
{
    private static TabelaSingleton _instance = new TabelaSingleton();
    private static object _singletonLock = new object();
    private TabelaSingleton()
    {

    }

    public static TabelaSingleton Instance
    {
        get
        {
            lock (_singletonLock)
            {
                return _instance;
            }
        }
    }

    public Lazy<List<Convenio>> Convenios = new Lazy<List<Convenio>>(() =>
    {
        return new List<Convenio>();
    });

    public Lazy<List<Empresa>> Empresas = new Lazy<List<Empresa>>(() =>
    {
        return new List<Empresa>();
    });

    public Lazy<List<Endereco>> Enderecos = new Lazy<List<Endereco>>(() =>
    {
        return new List<Endereco>();
    });

    public Lazy<List<Escola>> Escolas = new Lazy<List<Escola>>(() =>
    {
        return new List<Escola>();
    });
    public Lazy<List<Estado>> Estados = new Lazy<List<Estado>>(() =>
    {
        return new List<Estado>();
    });
}