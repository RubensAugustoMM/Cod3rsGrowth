using System.Dynamic;

class Convenio
{
    public int idConvenio { get; private set; } 
    public int numeroProcesso { get; private set; }
    public string Objeto { get; private set; }
    public double valor { get; set; } 

    public DateTime dataInicio { get; private set;}
    public DateTime? dataTermino { get; private set; }

    public int idEscola { get; private set; }
    public Escola Escola { get; private set; } 
    public int idEmpresa { get; private set; }
    public Empresa Empresa { get; private set; }

    public List<Convenio> Convenios { get; } = new();

}