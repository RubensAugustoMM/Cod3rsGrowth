namespace Cod3rsGrowth.Dominio;

public class EnderecoOtd
{
    public int Id { get; set; }
    public int Numero { get; set; }
    public string Cep { get; set; }
    public string Municipio { get; set; }
    public string Bairro { get; set; }
    public string Rua { get; set; }
    public string? Complemento { get; set; }
    public string Estado { get; set; }
}