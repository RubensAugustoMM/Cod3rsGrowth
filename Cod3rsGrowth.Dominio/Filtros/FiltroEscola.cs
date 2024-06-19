using Cod3rsGrowth.Dominio.Enums;

namespace Cod3rsGrowth.Dominio.Filtros;

public class FiltroEscola
{
    public bool? StatusAtividadeFiltro { get; set; }
    public string? NomeFiltro { get; set; }
    public string? CodigoMecFiltro { get; set; }
    public bool? MaiorOuIgualInicioAtividade { get; set; }
    public DateTime? InicioAtividadeFiltro { get; set; }
    public CategoriaAdministrativaEnums? CategoriaAdministrativaFiltro { get; set; }
    public OrganizacaoAcademicaEnums? OrganizacaoAcademicaFiltro { get; set; }
    public int? IdEnderecoFiltro { get; set; }
}