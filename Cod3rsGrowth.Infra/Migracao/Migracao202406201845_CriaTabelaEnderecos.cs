﻿using FluentMigrator;

namespace Cod3rsGrowth.Infra;

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
            .WithColumn("Complemento").AsString()
            .WithColumn("IdEstado").AsInt32().NotNullable();

        Create.ForeignKey("fk_Endereco_Estados").FromTable("Enderecos").ForeignColumn("IdEstado")
            .ToTable("Estados").PrimaryColumn("Id");
    }

    public override void Down()
    {
        Delete.Table("Enderecos");
    }
}