namespace Cod3rsGrowth.Dominio.Filtros;

public class FiltroConvenio
{
    public string? ObjetoFiltro { get; set; }
    public bool? MaiorOuIgualValor { get; set; }
    public decimal? ValorFiltro { get; set; }
    public bool? MaiorOuIgualDataInicio { get; set; }
    public DateTime? DataInicioFiltro { get; set; }
    public bool? MaiorOuIgualDataTermino { get; set; }
    public DateTime? DataTerminoFiltro { get; set; }
    public int? IdEscolaFiltro { get; set; }
    public int? IdEmpresaFiltro { get; set; }
}