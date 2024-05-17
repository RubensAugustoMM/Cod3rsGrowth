using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Testes;

public class TesteBase : IDisposable
{
    protected ServiceProvider serviceProvider { get; set; }
   
    public TesteBase()
    {
        var ModuloInjetor = new ModuloInjetor();
        serviceProvider = ModuloInjetor.ServiceProvider();
    }
     
    public void Dispose()
    {
        serviceProvider.Dispose(); 
    }
}