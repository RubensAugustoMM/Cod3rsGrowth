using System;
using Cod3rsGrowth.Dominio.Interfaces;

namespace Cod3rsGrowth.Dominio.Modelos;
public class Convenio : IEntidade 
{
    public int Id { get; set; }
    public int NumeroProcesso { get; private set; }
    public string Objeto { get; private set; }
    public double Valor { get; private set; } 
    public DateTime DataInicio { get; private set;}
    public DateTime? DataTermino { get; private set; }
    public int IdEscola { get; private set; }
    public Escola Escola { get; private set; } 
    public int IdEmpresa { get; private set; }
    public Empresa Empresa { get; private set; }
}