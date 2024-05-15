using System;

namespace Cod3rsGrowth.Dominio;
class Estado
{
    public int IdEstado { get; set; }
    public string Nome { get; set; }
    public string Sigla { get; set; }
    public List<Endereco> Enderecos { get; } = new(); 
}