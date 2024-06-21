using FluentMigrator;

namespace Cod3rsGrowth.Infra.Migracao;

[Migration(202406201850)]
public class Migracao202406201850_CriaTabelaEmpresas : Migration
{
    public override void Up()
    {
        Create.Table("Empresas").WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
            .WithColumn("Idade").AsInt32().NotNullable()
            .WithColumn("RazaoSocial").AsString().NotNullable()
            .WithColumn("NomeFantasia").AsString().NotNullable()
            .WithColumn("Cnpj").AsString().NotNullable()
            .WithColumn("SituacaoCadastral").AsBoolean().NotNullable()
            .WithColumn("DataSituacaoCadastral").AsDate().NotNullable()
            .WithColumn("DataAbertura").AsDateTime().NotNullable()
            .WithColumn("CapitalSocial").AsDecimal().NotNullable()
            .WithColumn("NaturezaJuridica").AsInt32().NotNullable()
            .WithColumn("Porte").AsInt32().NotNullable()
            .WithColumn("MatrizFilial").AsInt32().NotNullable()
            .WithColumn("IdEndereco").AsInt32().NotNullable();

        Create.ForeignKey("fk_Empresas_Enderecos").FromTable("Empresas").ForeignColumn("IdEndereco")
            .ToTable("Enderecos").PrimaryColumn("Id");
    }

    public override void Down()
    {
        Delete.ForeignKey("fk_Empresas_Enderecos");
        Delete.Table("Empresas"); 
    }
}