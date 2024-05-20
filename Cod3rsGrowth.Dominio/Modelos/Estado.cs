namespace Cod3rsGrowth.Dominio.Modelos;
public class Estado : ModeloBase
{
    public string Nome { get; private set; }
    public string Sigla { get; private set; }
    public List<Endereco> Enderecos { get; } = new();
}