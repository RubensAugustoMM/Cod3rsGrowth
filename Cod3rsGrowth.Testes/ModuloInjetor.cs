using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Testes;

public static class ModuloInjetor
{
    static public ServiceProvider BuildServiceProvider(ServiceCollection Servicos)
    {
        return Servicos.BuildServiceProvider();
    }
}