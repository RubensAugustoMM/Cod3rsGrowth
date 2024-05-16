using System;

namespace Cod3rsGrowth.Dominio;
public class Estado
{
    public int IdEstado { get; private set; }
    public string Nome { get; private set; }
    public string Sigla { get; private set; }
    public List<Endereco> Enderecos { get; } = new(); 
}