using Microsoft.Extensions.DependencyInjection;
using Xunit.Microsoft.DependencyInjection;
using System;
using Microsoft.VisualBasic;
using System.Collections;

namespace Cod3rsGrowth.Testes;

public class ModuloInjetor
{
    private ServiceCollection _Servicos;

    public ModuloInjetor()
    {
        _Servicos = new ServiceCollection();
    }

    public ServiceProvider ConstroiServiceProvider()
    {
        return _Servicos.BuildServiceProvider();
    }

}