namespace Cod3rsGrowth.Dominio.Modelos;
public class Estado 
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Sigla { get; set; }
    public List<Endereco> ListaEnderecos { get; set; } = new();
}