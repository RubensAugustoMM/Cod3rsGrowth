using System.Reflection.Metadata;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;

namespace Cod3rsGrowth.Servico;

public class ServicoEscola : IRepositorioEscola
{
    private readonly IRepositorioEscola _repositorioEscola;

    public ServicoEscola(IRepositorioEscola repositorioEscola)
    {
        _repositorioEscola = repositorioEscola;
    }

    public void Atualizar(Escola escolaAtualizada)
    {
        throw new NotImplementedException();
    }

    public bool Criar(Escola escolaCriada)
    {
        throw new NotImplementedException();
    }

    public void Deletar(int Id)
    {
        throw new NotImplementedException();
    }

    public Escola ObterPorId(int Id)
    {
        return _repositorioEscola.ObterPorId(Id);
    }

    public List<Escola> ObterTodos()
    {
        return _repositorioEscola.ObterTodos();
    }
}