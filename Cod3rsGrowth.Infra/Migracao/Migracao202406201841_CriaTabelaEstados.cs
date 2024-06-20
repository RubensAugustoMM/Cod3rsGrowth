using FluentMigrator;

namespace Cod3rsGrowth.Infra.Migracao;

[Migration(202406201841)]
public class Migracao202406201841_CriaTabelaEstados : Migration
{
    public override void Up()
    {
        Create.Table("Estados").WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
            .WithColumn("Nome").AsString().NotNullable()
            .WithColumn("Sigla").AsString().NotNullable();
    }

    public override void Down()
    {
        Delete.Table("Estados");
    }
}