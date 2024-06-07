using Cod3rsGrowth.Dominio.Enums;
using System;

namespace Cod3rsGrowth.Dominio.Modelos;
public class Empresa
{
    public int Id { get; set; }
    public int Idade { get; set; }
    public string RazaoSocial { get; set; }
    public string NomeFantasia { get; set; }
    public string Cnpj { get; set; }
    public bool SitucaoCadastral { get; set; }
    public DateTime DataSituacaoCadastral { get; set; } = new();
    public DateTime DataAbertura { get; set; } = new();
    public decimal CapitalSocial { get; set; }
    public NaturezaJuridicaEnums NaturezaJuridica { get; set; }
    public PorteEnums Porte { get; set; }
    public MatrizFilialEnums MatrizFilial { get; set; }
    public int IdEndereco { get; set; }
}