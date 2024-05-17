using System;

namespace Cod3rsGrowth.Dominio.Modelos;
public class Escola
{
    public bool StatusAtividade { get;  private set; }
    public int IdEscola {get; private set;}
    public string Nome { get; private set; }
    public string CodigoMec {get; private set;}
    public string Telefone { get; private set; }
    public string Email { get; private set; }
    public DateTime InicioAtividade { get; private set; }
    public CategoriaAdministrativaEnum CategoriaAdministrativa { get; private set; }
    public OrganizacaoAcademicaEnum OrganizacaoAcademica { get; private set; }
    public int IdEndereco { get; private set; }
    public Endereco Endereco { get; set; }
    public List<Convenio> Convenios { get; } = new();
}