using Cod3rsGrowth.Dominio.Interfaces;

namespace Cod3rsGrowth.Dominio.Modelos;
public class Estado : IEntidade 
{
    public int Id { get; set; }
    public string Nome { get; private set; }
    public string Sigla { get; private set; }
    public List<Endereco> Enderecos { get; } = new();
}