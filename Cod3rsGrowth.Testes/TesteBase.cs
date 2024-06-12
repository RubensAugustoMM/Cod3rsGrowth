using Microsoft.Extensions.DependencyInjection;
using Xunit;

[assembly: CollectionBehavior(DisableTestParallelization = true)]
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