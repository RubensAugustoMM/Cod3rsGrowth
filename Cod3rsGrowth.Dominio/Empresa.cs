using System;

namespace Cod3rsGrowth.Dominio;
class Empresa
{
    public int IdEmpresa { get;  set; }
    public int Idade { get;  set; }
   public string RazaoSocial { get; set; }
    public string NomeFantasia { get; set; }
    public string Cnpj { get; set; }
    public bool SitucaoCadastral { get; set; }
    public DateTime DataSituacaoCadastral { get; set; }
    public DateTime DataAbertura { get; set; }
    public decimal CapitalSocial { get; set; }
    public NaturezaJuridica NaturezaJuridica { get; set; }
    public porte Porte { get; set; } 
    public matrizFilial MatrizFilial { get;  set; }
    public List<Convenio> Convenios { get; } = new();
}