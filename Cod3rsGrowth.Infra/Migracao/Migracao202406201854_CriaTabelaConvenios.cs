using FluentMigrator;

namespace Cod3rsGrowth.Infra.Migracao;

[Migration(202406201854)]
public class Migracao202406201854_CriaTabelaConvenios : Migration
{
    public override void Up()
    {
        Create.Table("Convenios").WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
            .WithColumn("NumeroProcesso").AsInt32().NotNullable()
            .WithColumn("Objeto").AsString().NotNullable()
            .WithColumn("Valor").AsDecimal().NotNullable()
            .WithColumn("DataInicio").AsDateTime().NotNullable()
            .WithColumn("DataTermino").AsDateTime()
            .WithColumn("IdEscola").AsInt32().ForeignKey("Escolas", "Id").NotNullable()
            .WithColumn("IdEmpresa").AsInt32().ForeignKey("Empresas", "Id").NotNullable();
    }

    public override void Down()
    {
        Delete.Table("Convenios");
    }
}