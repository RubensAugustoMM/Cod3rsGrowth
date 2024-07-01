using FluentMigrator;

namespace Cod3rsGrowth.Infra.Migracao;

[Migration(202406201845)]
public class Migracao202406201845_CriaTabelaEnderecos : Migration
{
    public override void Up()
    {
        Create.Table("Enderecos").WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
            .WithColumn("Numero").AsInt32().NotNullable()
            .WithColumn("Cep").AsString().NotNullable()
            .WithColumn("Municipio").AsString().NotNullable()
            .WithColumn("Bairro").AsString().NotNullable()
            .WithColumn("Rua").AsString().NotNullable()
            .WithColumn("Complemento").AsString().Nullable()
            .WithColumn("Estado").AsInt32().NotNullable();
    }

    public override void Down()
    {
        Delete.Table("Enderecos");
    }
}