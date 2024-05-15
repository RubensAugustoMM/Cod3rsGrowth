using System;
using Cod3rsGrowth.Dominio;

class Escola
{
    public bool statusAtividade { get; private set; }

    public int idEscola {get; private set;}

    public string Nome { get; private set; }
    public string CodigoMec {get; private set;}
    public string Telefone { get; private set; }
    public string Email { get; private set; }
    public DateTime inicioAtividade { get; private set; }
    public categoriaAdministrativa categoriaAdministrativa { get; private set; }
    public organizacaoAcademica organizacaoAcademica { get; private set; }
    public int idEndereco { get; private set; }
    public Endereco Endereco { get; private set; }
}