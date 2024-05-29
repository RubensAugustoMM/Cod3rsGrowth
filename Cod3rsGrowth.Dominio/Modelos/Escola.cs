using Cod3rsGrowth.Dominio.Enums;
using System;
using System.Data.Common;

namespace Cod3rsGrowth.Dominio.Modelos;
public class Escola
{
    public int Id { get; set; }
    public bool StatusAtividade { get;  set; }
    public string Nome { get; set; }
    public string CodigoMec { get; set; }
    public string Telefone { get; set; }
    public string Email { get; set; }
    public DateTime InicioAtividade { get; set; }
    public CategoriaAdministrativaEnums CategoriaAdministrativa { get; set; }
    public OrganizacaoAcademicaEnums OrganizacaoAcademica { get; set; }
    public int IdEndereco { get; set; }
    public List<Convenio> ListaConvenios { get; set; } = new();
}