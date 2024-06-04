using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;

namespace Cod3rsGrowth.Servico;

public class ServicoConvenio : IRepositorioConvenio
{
    private readonly IRepositorioConvenio _repositorioConvenio;

    public ServicoConvenio(IRepositorioConvenio repositorioConvenio)
    {
        _repositorioConvenio = repositorioConvenio;
    }

    public void Atualizar(Convenio convenioAtualizado)
    {
        throw new NotImplementedException();
    }

    public void Criar(Convenio convenioCriado)
    {
        throw new NotImplementedException();
    }

    public void Deletar(int Id)
    {
        throw new NotImplementedException();
    }

    public Convenio ObterPorId(int Id)
    {
        throw new NotImplementedException();
    }

    public List<Convenio> ObterTodos()
    {
        return _repositorioConvenio.ObterTodos();
    }
}
