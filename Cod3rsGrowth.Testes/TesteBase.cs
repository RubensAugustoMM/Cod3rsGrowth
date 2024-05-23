using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

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