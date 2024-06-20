using FluentMigrator;

namespace Cod3rsGrowth.Infra.Migracao;

[Migration(202406201609)]
public class Migracao202406201751_CriaTodasTabelasDoBancoDeDados : Migration
{
    public override void Up()
    {
        CriaTabelaEstados();
        CriaTabelaEnderecos();
        CriaTabelaEscolas();
        CriaTabelaEmpresas();
        CriaTabelaConvenios();
    }

    public override void Down()
    {
        Delete.Table("Convenios");
        Delete.ForeignKey("fk_Convenios_Escolas");
        Delete.ForeignKey("fk_Convenios_Empresas");

        Delete.Table("Emperesas");
        Delete.ForeignKey("fk_Empresas_Enderecos");

        Delete.Table("Enderecos");
        Delete.ForeignKey("fk_Endereco_Estado");

        Delete.Table("Escolas");
        Delete.ForeignKey("fk_Escolas_Enderecos");

        Delete.Table("Estados");
    }
    
    private void CriaTabelaConvenios() 
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

    private void CriaTabelaEmpresas()
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

    private void CriaTabelaEnderecos()
    {
        Create.Table("Enderecos").WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
            .WithColumn("Numero").AsInt32().NotNullable()
            .WithColumn("Cep").AsString().NotNullable()
            .WithColumn("Municipio").AsString().NotNullable()
            .WithColumn("Bairro").AsString().NotNullable()
            .WithColumn("Rua").AsString().NotNullable()
            .WithColumn("Complemento").AsString()
            .WithColumn("IdEstado").AsInt32().NotNullable();

        Create.ForeignKey("fk_Endereco_Estado").FromTable("Enderecos").ForeignColumn("IdEstado")
            .ToTable("Estados").PrimaryColumn("Id");
    }

    private void CriaTabelaEscolas()
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
            .WithColumn("IdEndereco").AsInt32().NotNullable();

        Create.ForeignKey("fk_Escolas_Enderecos").FromTable("Escolas").ForeignColumn("IdEndereco")
            .ToTable("Enderecos").PrimaryColumn("Id");
    }

    private void CriaTabelaEstados()
    {
        Create.Table("Estados").WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
            .WithColumn("Nome").AsString().NotNullable()
            .WithColumn("Sigla").AsString().NotNullable();
    }
}