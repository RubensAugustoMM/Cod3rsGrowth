using Cod3rsGrowth.Dominio.Interfaces;

namespace Cod3rsGrowth.Infra.Repositorio;
public interface IRepositorio<T> where T : IEntidade
{
    List<T> ObterTodos();
    T ObterPorId(int Id);
    void Criar(T entidade);
    void Atualizar(T etidade);
    void Deletar(T entidade);
}