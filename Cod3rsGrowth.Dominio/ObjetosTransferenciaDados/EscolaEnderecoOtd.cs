using Cod3rsGrowth.Dominio.Enums;

namespace Cod3rsGrowth.Dominio.ObjetosTranferenciaDados;

public class EscolaEnderecoOtd
{
    public int Id { get; set; }
    public bool StatusAtividade { get; set; }
    public string Nome { get; set; }
    public string CodigoMec { get; set; }
    public string Telefone { get; set; }
    public string Email { get; set; }
    public DateTime InicioAtividade { get; set; } = new();
    public CategoriaAdministrativaEnums CategoriaAdministrativa { get; set; }
    public OrganizacaoAcademicaEnums OrganizacaoAcademica { get; set; }
    public int IdEndereco { get; set; }
    public EstadoEnums Estado { get; set; }
}