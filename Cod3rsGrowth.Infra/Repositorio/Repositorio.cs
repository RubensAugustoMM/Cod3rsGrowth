

using Cod3rsGrowth.Dominio.Interfaces;

namespace Cod3rsGrowth.Infra.Repositorio;

public class Cod3rsGrowth<T> : IRepositorio<T> where T : IEntidade
{
    public void Atualizar(T etidade)
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

    public T ObterPorId(int Id)
    {
        throw new NotImplementedException();
    }

    public List<T> ObterTodos()
    {
        throw new NotImplementedException();
    }
}