using System;


namespace Cod3rsGrowth.Dominio.Modelos;
public class Endereco : ModeloBase 
{
    public int Numero { get; private set; }
    public string Cep { get; private set; }
    public string Municipio { get; private set; }
    public string Bairro { get; private set; }
    public string Rua { get; private set; }
    public string? Complemento { get; private set; }
    public int IdEstado { get; private set; }
    public Estado Estado { get; private set; }
    public List<Escola> Escolas { get; } = new();
    public List<Empresa> Empresas { get; } = new();
}