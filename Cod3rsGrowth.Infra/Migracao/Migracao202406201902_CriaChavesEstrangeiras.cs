using FluentMigrator;

namespace Cod3rsGrowth.Infra;

[Migration(202406201902)]
public class Migracao202406201902_CriaChavesEstrangeiras : Migration
{
    public override void Up()
    {

        Create.ForeignKey("fk_Endereco_Estados").FromTable("Enderecos").ForeignColumn("IdEstado")
            .ToTable("Estados").PrimaryColumn("Id");

        Create.ForeignKey("fk_Escolas_Enderecos").FromTable("Escolas").ForeignColumn("IdEndereco")
            .ToTable("Enderecos").PrimaryColumn("Id");


        Create.ForeignKey("fk_Empresas_Enderecos").FromTable("Empresas").ForeignColumn("IdEndereco")
            .ToTable("Enderecos").PrimaryColumn("Id");

        Create.ForeignKey("fk_Convenios_Escolas").FromTable("Convenios").ForeignColumn("IdEscola")
            .ToTable("Escolas").PrimaryColumn("Id");

        Create.ForeignKey("fk_Convenios_Empresas").FromTable("Convenios").ForeignColumn("IdEmpresa")
            .ToTable("Empresas").PrimaryColumn("Id");
    }

    public override void Down()
    {
        Delete.ForeignKey("fk_Convenios_Empresas");
        Delete.ForeignKey("fk_COnvenios_Escolas");
        Delete.ForeignKey("fk_Escolas_Enderecos");
        Delete.ForeignKey("fk_Empresas_Enderecos");
        Delete.ForeignKey("fk_Endereco_Estados");
    }
}
