using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Servico;
using Cod3rsGrowth.Testes.Mocks;
using Cod3rsGrowth.Dominio.Interfaces;

namespace Cod3rsGrowth.Testes;

public static class ModuloInjetor
{
    static public void InjetaDependencias(ServiceCollection Servicos)
    {
        Servicos.AddScoped<IRepositorioConvenio,MockRepositorioConvenio>()
                .AddScoped<IRepositorioEmpresa,MockRepositorioEmpresa>()
                .AddScoped<IRepositorioEndereco,MockRepositorioEndereco>()
                .AddScoped<IRepositorioEscola,MockRepositorioEscola>()
                .AddScoped<IRepositorioEstado,MockRepositorioEstado>()
                .AddScoped<ServicoConvenio>()
                .AddScoped<ServicoEmpresa>()
                .AddScoped<ServicoEndereco>()
                .AddScoped<ServicoEscola>()
                .AddScoped<ServicoEstado>();
    }
}