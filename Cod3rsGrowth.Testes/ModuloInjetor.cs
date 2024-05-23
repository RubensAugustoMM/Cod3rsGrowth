using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Servico;
using Cod3rsGrowth.Dominio.Modelos;
using System.Runtime.CompilerServices;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Infra.Repositorio;

namespace Cod3rsGrowth.Testes;

public static class ModuloInjetor
{
    static public void InjetaDependencias(ServiceCollection Servicos)
    {
        Servicos.AddScoped(typeof(IRepositorio<>))
                .AddScoped<ServicoConvenio>()
                .AddScoped<ServicoEmpresa>()
                .AddScoped<ServicoEndereco>()
                .AddScoped<ServicoEscola>()
                .AddScoped<ServicoEstado>();
    }
}