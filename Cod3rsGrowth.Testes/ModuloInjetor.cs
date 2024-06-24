using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Servico;
using Cod3rsGrowth.Testes.Mocks;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Servico.Validacoes;

namespace Cod3rsGrowth.Testes;

public static class ModuloInjetor
{
    static public void InjetaDependencias(ServiceCollection Servicos)
    {
        Servicos.AddScoped<IRepositorioConvenio,MockRepositorioConvenio>()
                .AddScoped<IRepositorioEmpresa,MockRepositorioEmpresa>()
                .AddScoped<IRepositorioEndereco,MockRepositorioEndereco>()
                .AddScoped<IRepositorioEscola,MockRepositorioEscola>()
                .AddScoped<ValidadorConvenio>()
                .AddScoped<ValidadorEmpresa>()
                .AddScoped<ValidadorEndereco>()
                .AddScoped<ValidadorEscola>()
                .AddScoped<ServicoConvenio>()
                .AddScoped<ServicoEmpresa>()
                .AddScoped<ServicoEndereco>()
                .AddScoped<ServicoEscola>();
    }
}