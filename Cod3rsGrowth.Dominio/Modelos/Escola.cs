using Cod3rsGrowth.Dominio.Enums;
using LinqToDB.Mapping;

namespace Cod3rsGrowth.Dominio.Modelos;

[Table("TabelaEscolas")]
public class Escola
{
    [PrimaryKey, Identity]
    public int Id { get; set; }
    [Column("StatusAtividade"), NotNull]
    public bool StatusAtividade { get; set; }
    [Column("nome"),NotNull]
    public string Nome { get; set; }
    [Column("CodigoMec"),NotNull]
    public string CodigoMec { get; set; }
    [Column("Telefone"),NotNull]
    public string Telefone { get; set; }
    [Column("Email"),NotNull]
    public string Email { get; set; }
    [Column("InicioAtividade"),NotNull]
    public DateTime InicioAtividade { get; set; } = new();
    [Column("CategoriaAdministrativa"),NotNull]
    public CategoriaAdministrativaEnums CategoriaAdministrativa { get; set; }
    [Column("OrganizacaoAcademica"),NotNull]
    public OrganizacaoAcademicaEnums OrganizacaoAcademica { get; set; }
    [Column]
    public int IdEndereco { get; set; }
    public List<Convenio> ListaConvenios { get; set; } = new();
}