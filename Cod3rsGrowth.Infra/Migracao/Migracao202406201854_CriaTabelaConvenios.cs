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
            .WithColumn("IdEscola").AsInt32().NotNullable()
            .WithColumn("IdEmpresa").AsInt32().NotNullable();

        Create.ForeignKey("fk_Convenios_Escolas").FromTable("Convenios").ForeignColumn("IdEscola")
            .ToTable("Escolas").PrimaryColumn("Id");

        Create.ForeignKey("fk_Convenios_Empresas").FromTable("Convenios").ForeignColumn("IdEmpresa")
            .ToTable("Empresas").PrimaryColumn("Id");
    }

    public override void Down()
    {
        Delete.ForeignKey("fk_Convenios_Escolas");
        Delete.ForeignKey("fk_Convenios_Empresas");
        Delete.Table("Convenios");
    }
}