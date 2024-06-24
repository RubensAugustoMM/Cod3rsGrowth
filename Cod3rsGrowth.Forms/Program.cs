using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Infra.Migracao;
using Microsoft.Extensions.Hosting;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Servico.Validacoes;
using Cod3rsGrowth.Servico;
using Cod3rsGrowth.Infra.Repositorios;
using Cod3rsGrowth.Forms.Forms;

namespace Cod3rsGrowth.Forms;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        var host = CriaHostBuilder().Build();
        var ServiceProvider = host.Services;

        Application.Run(ServiceProvider.GetRequiredService<TelaPrincipalForm>());
    }

    static IHostBuilder CriaHostBuilder()
    {
        return Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                services.AddScoped<IRepositorioConvenio, RepositorioConvenio>()
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
                .AddScoped<TelaPrincipalForm>();
            });
    }

    private static ServiceProvider CriaServicos()
    {
        return new ServiceCollection()
        .AddFluentMigratorCore()
        .ConfigureRunner(rb => rb
                .AddSqlServer()
                .WithGlobalConnectionString("Data Source = DESKTOP-DAA9S87\\SQLEXPRESS; Initial Catalog=Cod3rsGrowth; User ID=sa; Password=sap@123; Encrypt=False; TrustServerCertificate=True")
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

        runner.MigrateUp();
    }
}