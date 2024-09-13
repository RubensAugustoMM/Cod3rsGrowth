using Cod3rsGrowth.Dominio.Enums;

namespace Cod3rsGrowth.Dominio.ObjetosTranferenciaDados;

public class EmpresaEnderecoOtd
{ 
    public int Id { get; set; }
    public string RazaoSocial { get; set; }
    public string NomeFantasia { get; set; }
    public string Cnpj { get; set; }
    public bool SituacaoCadastral { get; set; }
    public DateTime DataSituacaoCadastral { get; set; } = new();
    public int Idade { get; set; }
    public DateTime DataAbertura { get; set; } = new();
    public NaturezaJuridicaEnums NaturezaJuridica { get; set; }
    public PorteEnums Porte { get; set; }
    public MatrizFilialEnums MatrizFilial { get; set; }
    public decimal CapitalSocial { get; set; }
    public int IdEndereco { get; set; }
    public EstadoEnums Estado { get; set; }
}