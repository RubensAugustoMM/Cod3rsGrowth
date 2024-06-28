using Cod3rsGrowth.Dominio.Enums;
using FluentMigrator;

namespace Cod3rsGrowth.Infra;

[Migration(202406281612)]
public class Migracao202406281612_CarregaDadosNaTabelaEmpresa : Migration
{
    public override void Up()
    {
        Insert.IntoTable("Empresas").Row(new
        {
            Idade = 10,
            RazaoSocial = "TudoLimpo LTDA",
            NomeFantasia = "Tudo Limpo!",
            Cnpj = "11111111111111",
            SituacaoCadastral = true,
            DataSituacaoCadastral = new DateTime(2024,2,2),
            DataAbertura = new DateTime(2014, 2, 2),
            CapitalSocial = 100_000,
            NaturezaJuridica = 1,
            Porte = 2,
            MatrizFilial = 0,
            IdEndereco = 1
        });

        Insert.IntoTable("Empresas").Row(new
        {
            Idade = 4,
            RazaoSocial = "Monopólio Cursos Online LTDA",
            NomeFantasia = "Monopólio Cursos",
            Cnpj = "22222222222222",
            SituacaoCadastral = true,
            DataSituacaoCadastral = new DateTime(2024,2,2),
            DataAbertura = new DateTime(2020, 2, 2),
            CapitalSocial = 2_000_000_000_000,
            NaturezaJuridica = 7,
            Porte = 4,
            MatrizFilial = 1,
            IdEndereco = 2
        });

        Insert.IntoTable("Empresas").Row(new
        {
            Idade = 14,
            RazaoSocial = "Fast Tansportes LTDA",
            NomeFantasia = "Fast! Transportes",
            Cnpj = "33333333333333",
            SituacaoCadastral = true,
            DataSituacaoCadastral = new DateTime(2024,2,2),
            DataAbertura = new DateTime(2010, 2, 2),
            CapitalSocial = 2_000_000_000_000,
            NaturezaJuridica = 7,
            Porte = 4,
            MatrizFilial = 0,
            IdEndereco = 3
        });

        Insert.IntoTable("Empresas").Row(new
        {
            Idade = 2,
            RazaoSocial = "Juninho Construtora LTDA",
            NomeFantasia = "Juninho Construções",
            Cnpj = "44444444444444",
            SituacaoCadastral = true,
            DataSituacaoCadastral = new DateTime(2024,2,2),
            DataAbertura = new DateTime(2022, 2, 2),
            CapitalSocial = 1_000_000,
            NaturezaJuridica = 1,
            Porte = 3,
            MatrizFilial = 0,
            IdEndereco = 4
        });

        Insert.IntoTable("Empresas").Row(new
        {
            Idade = 25,
            RazaoSocial = "Gertran Materiais de Laboratório LTDA",
            NomeFantasia = "Gertran",
            Cnpj = "55555555555555",
            SituacaoCadastral = true,
            DataSituacaoCadastral = new DateTime(2024,2,2),
            DataAbertura = new DateTime(1999, 2, 2),
            CapitalSocial = 10_000_000_000_000,
            NaturezaJuridica = 6,
            Porte = 4,
            MatrizFilial = 1,
            IdEndereco = 5
        });
    }

    public override void Down()
    {
        Delete.FromTable("Empresas").Row(new { Cnpj = "11111111111111" });
        Delete.FromTable("Empresas").Row(new { Cnpj = "22222222222222" });
        Delete.FromTable("Empresas").Row(new { Cnpj = "33333333333333" });
        Delete.FromTable("Empresas").Row(new { Cnpj = "44444444444444" });
        Delete.FromTable("Empresas").Row(new { Cnpj = "55555555555555" });
    }
}