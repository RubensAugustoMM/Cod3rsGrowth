using Cod3rsGrowth.Dominio.Enums;
using LinqToDB.Mapping;

namespace Cod3rsGrowth.Dominio.Modelos;

[Table("Empresas")]
public class Empresa
{
    [PrimaryKey, Identity]
    public int Id { get; set; }
    [Column("Idade"), NotNull]
    public int Idade { get; set; }
    [Column("RazaoSocial"), NotNull]
    public string RazaoSocial { get; set; }
    [Column("NomeFantasia"), NotNull]
    public string NomeFantasia { get; set; }
    [Column("Cnpj"), NotNull]
    public string Cnpj { get; set; }
    [Column("SitaucaoCadastral"), NotNull]
    public bool SitucaoCadastral { get; set; }
    [Column("DataSituacaoCadastral"), NotNull]
    public DateTime DataSituacaoCadastral { get; set; } = new();
    [Column("DataAbertura"), NotNull]
    public DateTime DataAbertura { get; set; } = new();
    [Column("CaptalSocial"), NotNull]
    public decimal CapitalSocial { get; set; }
    [Column("NaturezaJuridica"), NotNull]
    public NaturezaJuridicaEnums NaturezaJuridica { get; set; }
    [Column("Porte"), NotNull]
    public PorteEnums Porte { get; set; }
    [Column("MatrizFilial"), NotNull]
    public MatrizFilialEnums MatrizFilial { get; set; }
    [Column("IdEndereco"), NotNull]
    public int IdEndereco { get; set; }
    [NotColumn]
    public List<Convenio> ListaConvenio { get; set; } = new();
}