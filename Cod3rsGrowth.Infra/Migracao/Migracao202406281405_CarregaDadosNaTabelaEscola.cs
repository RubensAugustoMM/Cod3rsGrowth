using FluentMigrator;

namespace Cod3rsGrowth.Infra;

[Migration(202406281405)]
public class Migracao202406281405_CarregaDadosNaTabelaEscola : Migration
{
    public override void Up()
    {
        Insert.IntoTable("Escolas").Row(new
        {
            StatusAtividade = true,
            Nome = "Escola Estadual Marechal Deodoro da Fonseca",
            CodigoMec = "12345678",
            Telefone = "123456789",
            Email = "MarechalDeodoro@gmail",
            InicioAtividade = new DateTime(1999, 02, 13),
            CategoriaAdministrativa = 2,
            OrganizacaoAcademica = 4,
            IdEndereco = 1
        });

        Insert.IntoTable("Escolas").Row(new
        {
            StatusAtividade = true,
            Nome = "Escola Estadual São tomel de Figueiredo",
            CodigoMec = "10679454",
            Telefone = "123456789",
            Email = "saoTomel@gmail",
            InicioAtividade = new DateTime(1999, 02, 13),
            CategoriaAdministrativa = 2,
            OrganizacaoAcademica = 4,
            IdEndereco = 2
        });

        Insert.IntoTable("Escolas").Row(new
        {
            StatusAtividade = true,
            Nome = "Universidade Federal de Goiás",
            CodigoMec = "20202020",
            Telefone = "123456789",
            Email = "proreitoria@ufg",
            InicioAtividade = new DateTime(1999, 02, 13),
            CategoriaAdministrativa = 0,
            OrganizacaoAcademica = 1,
            IdEndereco = 3
        });

        Insert.IntoTable("Escolas").Row(new
        {
            StatusAtividade = true,
            Nome = "Instituto Federal",
            CodigoMec = "40404040",
            Telefone = "123456789",
            Email = "institutoFederal@if",
            InicioAtividade = new DateTime(1999, 02, 13),
            CategoriaAdministrativa = 0,
            OrganizacaoAcademica = 2,
            IdEndereco = 4
        });

        Insert.IntoTable("Escolas").Row(new
        {
            StatusAtividade = true,
            Nome = "Escola Municipal Velcheminov",
            CodigoMec = "60606060",
            Telefone = "123456789",
            Email = "velcheminov@gmail",
            InicioAtividade = new DateTime(1999, 02, 13),
            CategoriaAdministrativa = 0,
            OrganizacaoAcademica = 4,
            IdEndereco = 5
        });

    }

    public override void Down()
    {
        Delete.FromTable("Escolas").Row(new { CodigoMec = "12345678" });
        Delete.FromTable("Escolas").Row(new { CodigoMec = "10679454" });
        Delete.FromTable("Escolas").Row(new { CodigoMec = "20202020" });
        Delete.FromTable("Escolas").Row(new { CodigoMec = "40404040" });
        Delete.FromTable("Escolas").Row(new { CodigoMec = "60606060" });
    }
}