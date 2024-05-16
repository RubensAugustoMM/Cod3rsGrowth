using Xunit.Microsoft.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;
using System;

namespace Cod3rsGrowth.Testes;

public class TesteBase : IDisposable
{
    protected ServiceProvider serviceProvider { get; set; }
   
    public TesteBase()
    {
        var ModuloInjetor = new ModuloInjetor();
        serviceProvider = ModuloInjetor.ConstroiServiceProvider();
    }
     
    public void Dispose()
    {
        serviceProvider.Dispose(); 
    }

}
