using LinqToDB.Mapping;

namespace Cod3rsGrowth.Dominio.Modelos;

[Table("Convenios")]
public class Convenio
{
    [PrimaryKey, Identity]
    public int Id { get; set; }
    [Column("NumeroProcesso"), NotNull]
    public int NumeroProcesso { get; set; }
    [Column("Objeto"), NotNull]
    public string Objeto { get; set; }
    [Column("Valor"),NotNull]
    public decimal Valor { get; set; }
    [Column("DataInicio"), NotNull]
    public DateTime DataInicio { get; set; } = new();
    [Column("DataTermino")]
    public DateTime? DataTermino { get; set; }
    [Column("IdEscola"), NotNull]
    public int IdEscola { get; set; }
    [Column("IdEscola"), NotNull]
    public int IdEmpresa { get; set; }
}