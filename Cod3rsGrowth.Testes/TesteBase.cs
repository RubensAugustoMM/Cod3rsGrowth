using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Testes;

public class TesteBase : IDisposable
{
    protected ServiceProvider ServiceProvider { get; set; }
   
    public TesteBase()
    {
        var ServiceCollection = new ServiceCollection();
        ModuloInjetor.InjetaDependencias(ServiceCollection);
        ServiceProvider = ServiceCollection.BuildServiceProvider();
    }
     
    public void Dispose()
    {
        ServiceProvider.Dispose(); 
    }
}