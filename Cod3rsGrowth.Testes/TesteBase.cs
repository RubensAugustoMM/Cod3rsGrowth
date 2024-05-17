using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Testes;

public class TesteBase : IDisposable
{
    protected ServiceProvider serviceProvider { get; set; }
   
    public TesteBase()
    {
        var ServiceCollection = new ServiceCollection();
    }
     
    public void Dispose()
    {
        serviceProvider.Dispose(); 
    }
}