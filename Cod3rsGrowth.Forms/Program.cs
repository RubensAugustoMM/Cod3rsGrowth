using System;
using FluentMigrator.Runner;
using FluentMigrator.Runner.Initialization;
using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Infra.Migracao;

namespace Cod3rsGrowth.Forms
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            //ApplicationConfiguration.Initialize();
            //Application.Run(new Form1());

            using (var serviceProvider = CriaServicos())
            using (var scope = serviceProvider.CreateScope())
            {
                UpdateDatabase(scope.ServiceProvider);
            }
        }

        private static ServiceProvider CriaServicos()
        {
            return new ServiceCollection()
                .AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    .AddSqlServer()
                    .WithGlobalConnectionString("Data Source=ConvenioEscolaEmpresaBD")
                    .ScanIn(typeof(Migracao20240620_CriaTodasTabelasDoBancoDeDados).Assembly).For.Migrations())
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                .BuildServiceProvider(false);
        }

        private static void UpdateDatabase(IServiceProvider serviceProvider)
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

            runner.MigrateUp();
        }
    }
}