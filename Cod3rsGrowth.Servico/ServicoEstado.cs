using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;

namespace Cod3rsGrowth.Servico;

public class ServicoEstado : IRepositorioEstado
{
    private readonly IRepositorioEstado _repositorioEstado;

    public ServicoEstado(IRepositorioEstado repositorioEstado)
    {
        _repositorioEstado = repositorioEstado;
    }

    public void Atualizar(Estado estadoAtualizado)
    {
        throw new NotImplementedException();
    }

    public void Criar(Estado estadoCriado)
    {
        throw new NotImplementedException();
    }

    public void Deletar(int Id)
    {
        throw new NotImplementedException();
    }

    public Estado ObterPorId(int Id)
    {
        throw new NotImplementedException();
    }

    public List<Estado> ObterTodos()
    {
        return _repositorioEstado.ObterTodos();
    }
}