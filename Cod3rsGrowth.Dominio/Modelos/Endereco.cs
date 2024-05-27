using System;


namespace Cod3rsGrowth.Dominio.Modelos;
public class Endereco
{
    public int Id { get; set; }
    public int Numero { get; set; }
    public string Cep { get; set; }
    public string Municipio { get; set; }
    public string Bairro { get; set; }
    public string Rua { get; set; }
    public string? Complemento { get; set; }
    public int IdEstado { get; set; }
    public List<Escola> ListaEscolas { get; set; } = new();
    public List<Empresa> ListaEmpresas { get; set; } = new();
}