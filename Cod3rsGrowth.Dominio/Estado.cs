using System;


class Estado
{
    public int idEstado { get; private set; }
    public string Nome { get; private set; }
    public string Sigla { get; private set; }
    
    public List<Endereco> Enderecos { get; } = new(); 
}