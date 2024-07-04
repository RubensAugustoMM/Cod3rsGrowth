using Cod3rsGrowth.Dominio.Enums;

namespace Cod3rsGrowth.Dominio.Filtros;

public class FiltroEnderecoOtd
{
    public int? NumeroFiltro { get; set; }
    public string? CepFiltro { get; set; }
    public string? MunicipioFiltro { get; set; }
    public string? BairroFiltro { get; set; }
    public EstadoEnums? EstadoFiltro { get; set; }
}