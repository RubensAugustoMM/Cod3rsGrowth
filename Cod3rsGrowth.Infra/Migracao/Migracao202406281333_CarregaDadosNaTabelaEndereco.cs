using FluentMigrator;

namespace Cod3rsGrowth.Infra;

[Migration(202406281333)]
public class Migracao202406281333_CarregaDadosNaTabelaEnderecos : Migration
{
    public override void Up()
    {
        Insert.IntoTable("Enderecos").Row(new
        {
            Numero = 13,
            Cep = "03965712",
            Municipio = "Goiania",
            Bairro = "Setor dos Funcionarios",
            Rua = "vv 8",
            Complemento = "Em frente ao cemiterio santana",
            Estado = 7
        });

        Insert.IntoTable("Enderecos").Row(new
        {
            Numero = 0,
            Cep = "65434712",
            Municipio = "Goiania",
            Bairro = "Setor dos Funcionarios",
            Rua = "150d",
            Estado = 7
        });

        Insert.IntoTable("Enderecos").Row(new
        {
            Numero = 2,
            Cep = "65754368",
            Municipio = "Goiania",
            Bairro = "Itatiaia",
            Rua = "Rua das Magnolias",
            Estado = 7
        });

        Insert.IntoTable("Enderecos").Row(new
        {
            Numero = 170,
            Cep = "47914678",
            Municipio = "Goiania",
            Bairro = "Balneareo Meia Ponte",
            Rua = "Avenida 02",
            Estado = 7
        });

        Insert.IntoTable("Enderecos").Row(new
        {
            Numero = 8,
            Cep = "65857913",
            Municipio = "Aparecida de Goiania",
            Bairro = "Garavelo",
            Rua = "Rua dos Buritis",
            Estado = 7
        });

        Insert.IntoTable("Enderecos").Row(new
        {
            Numero = 2,
            Cep = "06853476",
            Municipio = "Aparecida de Goiania",
            Bairro = "Setor Central",
            Rua = "Rodrigo Fontes",
            Estado = 7
        });

        Insert.IntoTable("Enderecos").Row(new
        {
            Numero = 17,
            Cep = "09876543",
            Municipio = "Rio de Janeiro",
            Bairro = "Meyer",
            Rua = "Presidente Jao Gourlart",
            Estado = 17
        });

        Insert.IntoTable("Enderecos").Row(new
        {
            Numero = 9,
            Cep = "96750012",
            Municipio = "Rio de Janeiro",
            Bairro = "Meyer",
            Rua = "Rua 022",
            Complemento = "Em frente ao campo de futebol",
            Estado = 17
        });

        Insert.IntoTable("Enderecos").Row(new
        {
            Numero = 100,
            Cep = "96759876",
            Municipio = "Cuiaba",
            Bairro = "Pedregal",
            Rua = "Rua 30",
            Estado = 9
        });

        Insert.IntoTable("Enderecos").Row(new
        {
            Numero = 100,
            Cep = "09835789",
            Municipio = "Aguas Claras",
            Bairro = "Aguas Claras Sul",
            Rua = "Rua 105",
            Estado = 26
        });
    }

    public override void Down()
    {
        Delete.FromTable("Enderecos").AllRows();
    }
}