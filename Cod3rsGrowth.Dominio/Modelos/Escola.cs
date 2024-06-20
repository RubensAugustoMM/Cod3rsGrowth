using LinqToDB.Mapping;
using Cod3rsGrowth.Dominio.Enums;

namespace Cod3rsGrowth.Dominio.Modelos;

[Table("Escolas")]
public class Escola
{
    [PrimaryKey, Identity]
    public int Id { get; set; }
    [Column("StatusAtividade"), NotNull]
    public bool StatusAtividade { get; set; }
    [Column("Nome"), NotNull]
    public string Nome { get; set; }
    [Column("CodigoMec"), NotNull]
    public string CodigoMec { get; set; }
    [Column("Telefone"), NotNull]
    public string Telefone { get; set; }
    [Column("Email"), NotNull]
    public string Email { get; set; }
    [Column("InicioAtividade")]
    public DateTime InicioAtividade { get; set; } = new();
    [Column("CategoriaAdministrativa"), NotNull]
    public CategoriaAdministrativaEnums CategoriaAdministrativa { get; set; }
    [Column("OrganizacaAcademica"), NotNull]
    public OrganizacaoAcademicaEnums OrganizacaoAcademica { get; set; }
    [Column("IdEndereco"), NotNull]
    public int IdEndereco { get; set; }
    [Association(ThisKey =nameof(IdEndereco), OtherKey =nameof(Endereco.Id))]
    public Endereco EndrecoReferente { get; set; }
    [NotColumn]
    public List<Convenio> ListaConvenios { get; set; } = new();
}