using Cod3rsGrowth.Dominio.Enums;

namespace Cod3rsGrowth.Dominio.Filtros;

public class FiltroEmpresaEnderecoOtd
{
    public bool? MaiorOuIgualIdade { get; set; }
    public int? IdadeFiltro { get; set; }
    public string? RazaoSocialFiltro { get; set; }
    public string? NomeFantasiaFiltro { get; set; }
    public string? CnpjFiltro { get; set; }
    public bool? SitucaoCadastralFiltro { get; set; }
    public bool? MaiorOuIgualDataSituacaoCadastral { get; set; }
    public DateTime? DataSituacaoCadastralFiltro { get; set; }
    public bool? MaiorOuIgualDataAbertura { get; set; }
    public DateTime? DataAberturaFiltro { get; set; }
    public bool? MaiorOuIgualCapitalSocial { get; set; }
    public decimal? CapitalSocialFiltro { get; set; }
    public NaturezaJuridicaEnums? NaturezaJuridicaFiltro { get; set; }
    public PorteEnums? PorteFiltro { get; set; }
    public MatrizFilialEnums? MatrizFilialFiltro { get; set; }
    public int? IdEnderecoFiltro { get; set; }
    public EstadoEnums? EstadoFiltro { get; set; }
}