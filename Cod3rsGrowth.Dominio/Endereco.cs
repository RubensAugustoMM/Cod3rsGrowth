using System;


class Endereco 
{
    public int idEndereco { get; private set; }
    public int numero { get; private set; }
    public string Cep { get; private set; }
    public string Municipio { get; private set; }
    public string Bairro { get; private set; }
    public string Rua { get; private set; }
    public string? Complemento { get; private set; }

    public int idEstado { get; private set; }
    public Estado Estado { get; private set; }

    public List<Escola> Escolas { get; } = new();
    public List<Empresa> Empresas { get; } = new();

}