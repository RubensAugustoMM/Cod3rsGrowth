using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Testes;

public class ModuloInjetor
{
    private ServiceCollection _Servicos;

    public ModuloInjetor()
    {
        _Servicos = new ServiceCollection();
    }

    public ServiceProvider ServiceProvider()
    {
        return _Servicos.BuildServiceProvider();
    }
}