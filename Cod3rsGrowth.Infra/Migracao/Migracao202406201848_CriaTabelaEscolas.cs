using FluentMigrator;

namespace Cod3rsGrowth.Infra.Migracao;

[Migration(202406201848)]
public class Migracao202406201848_CriaTabelaEscolas : Migration
{
    public override void Up()
    {
        Create.Table("Escolas").WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
            .WithColumn("StatusAtividade").AsBoolean().NotNullable()
            .WithColumn("Nome").AsString().NotNullable()
            .WithColumn("CodigoMec").AsString().NotNullable()
            .WithColumn("Telefone").AsString().NotNullable()
            .WithColumn("Email").AsString().NotNullable()
            .WithColumn("InicioAtividade").AsDateTime().NotNullable()
            .WithColumn("CategoriaAdministrativa").AsInt32().NotNullable()
            .WithColumn("OrganizacaoAcademica").AsInt32().NotNullable()
            .WithColumn("IdEndereco").AsInt32().ForeignKey("Enderecos", "Id").OnDelete(System.Data.Rule.Cascade).NotNullable();
    }

    public override void Down()
    {
        Delete.ForeignKey()
            .FromTable("Escolas").ForeignColumn("IdEndereco")
            .ToTable("Enderecos").PrimaryColumn("Id");

        Delete.Table("Escolas");
    }
}