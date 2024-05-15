using System;

namespace Cod3rsGrowth.Dominio;
class Escola
{
    public bool StatusAtividade { get;  set; }
    public int IdEscola {get; set;}
    public string Nome { get; set; }
    public string CodigoMec {get; set;}
    public string Telefone { get; set; }
    public string Email { get; set; }
    public DateTime InicioAtividade { get; set; }
    public categoriaAdministrativa CategoriaAdministrativa { get; set; }
    public organizacaoAcademica OrganizacaoAcademica { get; set; }
    public int IdEndereco { get; set; }
    public Endereco Endereco { get; set; }
    public List<Convenio> Convenios { get; } = new();
}