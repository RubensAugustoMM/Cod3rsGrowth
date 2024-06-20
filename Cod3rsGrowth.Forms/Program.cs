using System;
using FluentMigrator.Runner;
using FluentMigrator.Runner.Initialization;
using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Infra.Migracao;
using Microsoft.VisualBasic.ApplicationServices;
using static LinqToDB.Common.Configuration;
using System.Drawing;
using Cod3rsGrowth.Infra;

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
                AtualizaBancoDeDados(scope.ServiceProvider);
            }
        }

        private static ServiceProvider CriaServicos()
        {
            return new ServiceCollection()
            .AddFluentMigratorCore()
            .ConfigureRunner(rb => rb
            .AddSqlServer()
                    .WithGlobalConnectionString("Data Source = DESKTOP-DAA9S87\\SQLEXPRESS; Initial Catalog=Cod3rsGrowth; User ID=sa; Password=sap@123; Encrypt=False; TrustServerCertificate=True")
                    .ScanIn(typeof(Migracao202406201841_CriaTabelaEstados).Assembly).For.Migrations())
                .AddLogging(Ib => Ib.AddFluentMigratorConsole())
                .BuildServiceProvider(false);
        }

        private static void AtualizaBancoDeDados(IServiceProvider serviceProvider)
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

            runner.Down(new Migracao202406201841_CriaTabelaEstados());
        }
    }
}