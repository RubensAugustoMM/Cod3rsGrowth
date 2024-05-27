using Cod3rsGrowth.Dominio.Modelos;

namespace Cod3rsGrowth.Testes;

public partial class TabelaSingleton
{
    private readonly static TabelaSingleton _instance = new TabelaSingleton();

    private TabelaSingleton()
    {

    }

    public static TabelaSingleton Instance
    {
        get
        {
            return _instance;
        }
    }
    public Lazy<List<Convenio>> _convenios = new Lazy<List<Convenio>>(() =>
    {
        return new List<Convenio>();
    });

    public Lazy<List<Empresa>> _empresas = new Lazy<List<Empresa>>(() =>
    {
        return new List<Empresa>();
    });

    public Lazy<List<Endereco>> _enderecos = new Lazy<List<Endereco>>(() =>
    {
        return new List<Endereco>();
    });

    public Lazy<List<Escola>> _escolas = new Lazy<List<Escola>>(() =>
    {
        return new List<Escola>();
    });
    public Lazy<List<Estado>> _estados = new Lazy<List<Estado>>(() =>
    {
        return new List<Estado>();
    });
}