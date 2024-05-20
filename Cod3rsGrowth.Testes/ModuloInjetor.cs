using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Servico;
using Cod3rsGrowth.Dominio.Modelos;

namespace Cod3rsGrowth.Testes;

public static class ModuloInjetor
{
    static public void InjetaDependencias(ServiceCollection Servicos)
    {
        Servicos.AddScoped<ServicoConvenio>()
                .AddScoped<ServicoEmpresa>()
                .AddScoped<ServicoEndereco>()
                .AddScoped<ServicoEscola>()
                .AddScoped<ServicoEstado>()
                .AddSingleton<RepositorioMock<Convenio>>()
                .AddSingleton<RepositorioMock<Empresa>>()
                .AddSingleton<RepositorioMock<Endereco>>()
                .AddSingleton<RepositorioMock<Escola>>()
                .AddSingleton<RepositorioMock<Estado>>();

    }
}