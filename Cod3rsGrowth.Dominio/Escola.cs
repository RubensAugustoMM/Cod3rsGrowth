using System;
using System.ComponentModel;

namespace Cod3rsGrowth.Dominio;
public class Escola
{
    public bool StatusAtividade { get;  set; }
    public int IdEscola {get; set;}
    public string Nome { get; set; }
    public string CodigoMec {get; set;}
    public string Telefone { get; set; }
    public string Email { get; set; }
    public DateTime InicioAtividade { get; set; }
    public CategoriaAdministrativaEnum CategoriaAdministrativa { get; set; }
    public OrganizacaoAcademicaEnum OrganizacaoAcademica { get; set; }
    public int IdEndereco { get; set; }
    public Endereco Endereco { get; set; }
    public List<Convenio> Convenios { get; } = new();
}