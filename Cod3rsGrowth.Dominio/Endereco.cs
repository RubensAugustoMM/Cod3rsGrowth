using System;


namespace Cod3rsGrowth.Dominio;
public class Endereco 
{
    public int IdEndereco { get; set; }
    public int Numero { get; set; }
    public string Cep { get; set; }
    public string Municipio { get; set; }
    public string Bairro { get; set; }
    public string Rua { get; set; }
    public string? Complemento { get; set; }
    public int IdEstado { get; set; }
    public Estado Estado { get; private set; }
    public List<Escola> Escolas { get; } = new();
    public List<Empresa> Empresas { get; } = new();
}