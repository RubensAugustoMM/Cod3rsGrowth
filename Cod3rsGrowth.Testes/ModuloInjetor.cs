using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Dominio.Servicos;

namespace Cod3rsGrowth.Testes;

public static class ModuloInjetor
{
    static public void InjetaDependencias(ServiceCollection Servicos)
    {
        Servicos.AddScoped<IServicoConvenio, ServicoConvenio>()
                .AddScoped<IServicoEmpresa, ServicoEmpresa>()
                .AddScoped<IServicoEndereco, ServicoEndereco>()
                .AddScoped<IServicoEscola, ServicoEscola>()
                .AddScoped<IServicoEstado, ServicoEstado>();
    }
}