using LinqToDB.Mapping;

namespace Cod3rsGrowth.Dominio.Modelos;

public class Estado 
{
    [PrimaryKey, Identity]
    public int Id { get; set; }
    [Column("Nome"), NotNull]
    public string Nome { get; set; }
    [Column("Sigla"), NotNull]
    public string Sigla { get; set; }
    [Column]
    public List<Endereco> ListaEnderecos { get; set; } = new();
}