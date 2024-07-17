namespace Cod3rsGrowth.Dominio.Filtros;

public class FiltroConvenioEscolaEmpresaOtd
{
    public string? ObjetoFiltro { get; set; }
    public bool? MaiorOuIgualValor { get; set; }
    public decimal? ValorFiltro { get; set; }
    public bool? MaiorOuIgualDataInicio { get; set; }
    public DateTime? DataInicioFiltro { get; set; }
    public bool? MaiorOuIgualDataTermino { get; set; }
    public DateTime? DataTerminoFiltro { get; set; }
    public int? IdEscolaFiltro { get; set; }
    public string? NomeEscolaFiltro { get; set; }
    public int? IdEmpresaFiltro { get; set; }
    public string? RazaoSocialEmpresaFiltro { get; set; }
}