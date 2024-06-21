using Cod3rsGrowth.Dominio.Enums;
using LinqToDB.Mapping;

namespace Cod3rsGrowth.Dominio.Modelos;

[Table("Enderecos")]
public class Endereco
{
    [PrimaryKey, Identity]
    public int Id { get; set; }
    [Column("Numero"), NotNull]
    public int Numero { get; set; }
    [Column("Cep"), NotNull]
    public string Cep { get; set; }
    [Column("Municipio"), NotNull]
    public string Municipio { get; set; }
    [Column("Bairro"), NotNull]
    public string Bairro { get; set; }
    [Column("Rua"), NotNull]
    public string Rua { get; set; }
    [Column("Complemento")]
    public string? Complemento { get; set; }
    public EstadoEnums Estado { get; set; }
}