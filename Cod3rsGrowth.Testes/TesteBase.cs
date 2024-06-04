using System.ComponentModel;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Testes;

public class TesteBase : IDisposable
{
    protected ServiceProvider _serviceProvider { get; set; }

    public TesteBase() 
    {
        var ServiceCollection = new ServiceCollection();
        ModuloInjetor.InjetaDependencias(ServiceCollection);
        _serviceProvider = ServiceCollection.BuildServiceProvider();
    }
  
    public void Dispose()
    {
        _serviceProvider.Dispose();
    }
}