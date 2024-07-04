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
    public string CategoriaAdministrativa { get; set; }
    public string OrganizacaoAcademica { get; set; }
    public int IdEndereco { get; set; }
    public string Estado { get; set; }
}