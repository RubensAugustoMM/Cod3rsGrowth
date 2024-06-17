using System;

namespace Cod3rsGrowth.Dominio.Modelos;
public class Convenio 
{
    public int Id { get; set; }
    public int NumeroProcesso { get; set; }
    public string Objeto { get; set; }
    public decimal Valor { get; set; }
    public DateTime DataInicio { get; set; } = new();
    public DateTime? DataTermino { get; set; }
    public int IdEscola { get; set; }
    public int IdEmpresa { get; set; }
}