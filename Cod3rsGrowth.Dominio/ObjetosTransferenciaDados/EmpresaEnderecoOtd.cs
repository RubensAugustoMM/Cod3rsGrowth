namespace Cod3rsGrowth.Dominio.ObjetosTranferenciaDados;

public class EmpresaEnderecoOtd
{ 
    public int Id { get; set; }
    public string RazaoSocial { get; set; }
    public string NomeFantasia { get; set; }
    public string Cnpj { get; set; }
    public bool SitucaoCadastral { get; set; }
    public DateTime DataSituacaoCadastral { get; set; } = new();
    public int Idade { get; set; }
    public DateTime DataAbertura { get; set; } = new();
    public string NaturezaJuridica { get; set; }
    public string Porte { get; set; }
    public string MatrizFilial { get; set; }
    public decimal CapitalSocial { get; set; }
    public int IdEndereco { get; set; }
    public string Estado { get; set; }
}