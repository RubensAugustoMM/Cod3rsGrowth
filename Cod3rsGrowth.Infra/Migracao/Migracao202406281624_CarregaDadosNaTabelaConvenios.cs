using FluentMigrator;

namespace Cod3rsGrowth.Infra;

[Migration(202406281624)]
public class Migracao202406281624_CarregaDadosNaTabelaConvenios : Migration
{
    public override void Up()
    {
        Insert.IntoTable("Convenios").Row(new
        {
            NumeroProcesso = 1,
            Objeto = "Limpeza dos prédios",
            Valor = 2_000_000,
            DataInicio = new DateTime(2020, 2, 2),
            DataTermino = new DateTime(2024, 2, 2),
            IdEscola = 1,
            IdEmpresa = 2
        });
    }

    public override void Down()
    {
        Delete.FromTable("Convenios").AllRows();
    }
}
