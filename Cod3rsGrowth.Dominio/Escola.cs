using System;

namespace Cod3rsGrowth.Dominio;
class Escola
{
    public bool StatusAtividade { get; private set; }
    public int IdEscola {get; private set;}
    public string Nome { get; private set; }
    public string CodigoMec {get; private set;}
    public string Telefone { get; private set; }
    public string Email { get; private set; }
    public DateTime InicioAtividade { get; private set; }
    public categoriaAdministrativa CategoriaAdministrativa { get; private set; }
    public organizacaoAcademica OrganizacaoAcademica { get; private set; }
    public int IdEndereco { get; private set; }
    public Endereco Endereco { get; private set; }
    public List<Convenio> Convenios { get; } = new();
}