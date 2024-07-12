using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Infra.Migracao;
using Microsoft.Extensions.Hosting;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Servico.Validacoes;
using Cod3rsGrowth.Servico;
using Cod3rsGrowth.Infra.Repositorios;
using Cod3rsGrowth.Forms.Forms;
using Cod3rsGrowth.Infra;
using LinqToDB.AspNet;
using LinqToDB;
using LinqToDB.AspNet.Logging;
using System.Configuration;

namespace Cod3rsGrowth.Forms;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    { 
        /*
        ApplicationConfiguration.Initialize();
        var host = CriaHostBuilder().Build();
        var ServiceProvider = host.Services;
    
        Application.Run(ServiceProvider.GetRequiredService<TelaPrincipalForm>());
    */    
        using (var serviceProvider = CriaServicos()) 
            using (var escopo = serviceProvider.CreateScope())
        {
            AtualizaBancoDeDados(escopo.ServiceProvider);
        }
    }

    static IHostBuilder CriaHostBuilder()
    {
        String StringConexao = ConfigurationManager
                            .ConnectionStrings["ConvenioEscolaEmpresaBD"]
                            .ConnectionString;

        return Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                services
                .AddLinqToDBContext<ContextoAplicacao>((provider, options) =>
                options
                    .UseSqlServer(StringConexao)
                    .UseDefaultLogging(provider))
                .AddScoped<IRepositorioConvenio, RepositorioConvenio>()
                .AddScoped<IRepositorioEmpresa, RepositorioEmpresa>()
                .AddScoped<IRepositorioEndereco, RepositorioEndereco>()
                .AddScoped<IRepositorioEscola, RepositorioEscola>()
                .AddScoped<ValidadorConvenio>()
                .AddScoped<ValidadorEmpresa>()
                .AddScoped<ValidadorEndereco>()
                .AddScoped<ValidadorEscola>()
                .AddScoped<ServicoConvenio>()
                .AddScoped<ServicoEmpresa>()
                .AddScoped<ServicoEndereco>()
                .AddScoped<ServicoEscola>()
                .AddScoped<TelaEmpresaForm>()
                .AddScoped<TelaEscolaForm>()
                .AddScoped<TelaConvenioForm>()
                .AddScoped<TelaEnderecoForm>()
                .AddScoped<TelaPrincipalForm>();
            });
    }

    private static ServiceProvider CriaServicos()
    {
        String StringConexao = ConfigurationManager
                            .ConnectionStrings["ConvenioEscolaEmpresaBD"]
                            .ConnectionString;

        return new ServiceCollection()
        .AddFluentMigratorCore()
        .ConfigureRunner(rb => rb
                .AddSqlServer()
                .WithGlobalConnectionString(StringConexao)
                .ScanIn(typeof(Migracao202406201845_CriaTabelaEnderecos).Assembly).For.Migrations()
                .ScanIn(typeof(Migracao202406201848_CriaTabelaEscolas).Assembly).For.Migrations()
                .ScanIn(typeof(Migracao202406201850_CriaTabelaEmpresas).Assembly).For.Migrations()
                .ScanIn(typeof(Migracao202406201854_CriaTabelaConvenios).Assembly).For.Migrations())
            .AddLogging(Ib => Ib.AddFluentMigratorConsole())
            .BuildServiceProvider(false);
    }

    private static void AtualizaBancoDeDados(IServiceProvider serviceProvider)
    {
        var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

        runner.MigrateUp(202406281624);
    }
}