using System;
using Cod3rsGrowth.Dominio.Interfaces;

namespace Cod3rsGrowth.Dominio.Modelos;
public class Convenio : IEntidade 
{
    public int Id { get; set; }
    public int NumeroProcesso { get; set; }
    public string Objeto { get; set; }
    public double Valor { get; set; } 
    public DateTime DataInicio { get; set;}
    public DateTime? DataTermino { get; set; }
    public int IdEscola { get; set; }
    public Escola Escola { get; set; } 
    public int IdEmpresa { get; set; }
    public Empresa Empresa { get; set; }
}