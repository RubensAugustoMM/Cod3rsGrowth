using LinqToDB.Mapping;

namespace Cod3rsGrowth.Dominio.Modelos;

[Table("TabelaEstados")]
public class Estado 
{
    [PrimaryKey, Identity]
    public int Id { get; set; }
    [Column("Nome"), NotNull]
    public string Nome { get; set; }
    [Column("Sigla"), NotNull]
    public string Sigla { get; set; }
    public List<Endereco> ListaEnderecos { get; set; } = new();
}