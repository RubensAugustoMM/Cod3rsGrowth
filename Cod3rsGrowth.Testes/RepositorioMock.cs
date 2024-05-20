using System.Net;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Infra.Repositorio;

namespace Cod3rsGrowth.Testes;

public class RepositorioMock<T> : ICod3rsGrowthRepositorio<T>
{
    Dictionary<long, T> Dados;

    public RepositorioMock()
    {
        Dados = new();
    }

    public void Atualizar(T entidade)
    {
        throw new NotImplementedException();
    }

    public void Criar(T entidade)
    {
        throw new NotImplementedException();
    }

    public void Deletar(T entidade)
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public T ObterPorId(int Id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<T> ObterTodos()
    {
        throw new NotImplementedException();
    }
}