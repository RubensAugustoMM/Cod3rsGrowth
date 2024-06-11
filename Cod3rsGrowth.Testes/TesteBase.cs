using System.ComponentModel;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Testes;

public class TesteBase : IDisposable
{
    protected ServiceProvider _serviceProvider { get; set; }
    protected TabelaSingleton _tabelas;

    public TesteBase() 
    {
        var ServiceCollection = new ServiceCollection();
        ModuloInjetor.InjetaDependencias(ServiceCollection);
        _serviceProvider = ServiceCollection.BuildServiceProvider();
        _tabelas = TabelaSingleton.Instance;

        _tabelas.Convenios.Value.Clear();
        _tabelas.Empresas.Value.Clear();
        _tabelas.Enderecos.Value.Clear();
        _tabelas.Escolas.Value.Clear();
        _tabelas.Estados.Value.Clear();

    }
  
    public void Dispose()
    {
        _serviceProvider.Dispose();
    }
}