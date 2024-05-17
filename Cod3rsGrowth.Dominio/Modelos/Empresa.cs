using System;

namespace Cod3rsGrowth.Dominio.Modelos;
public class Empresa
{
    public int IdEmpresa { get; private set; }
    public int Idade { get; private set; }
    public string RazaoSocial { get; private set; }
    public string NomeFantasia { get; private set; }
    public string Cnpj { get; private set; }
    public bool SitucaoCadastral { get; private set; }
    public DateTime DataSituacaoCadastral { get; private set; }
    public DateTime DataAbertura { get; private set; }
    public decimal CapitalSocial { get; private set; }
    public NaturezaJuridicaEnum NaturezaJuridica { get; private set; }
    public PorteEnum Porte { get; private set; }
    public MatrizFilialEnum MatrizFilial { get; private set; }
    public List<Convenio> Convenios { get; } = new();
}