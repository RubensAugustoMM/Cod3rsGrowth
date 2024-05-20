namespace Cod3rsGrowth.Infra.Repositorio;

public interface ICod3rsGrowthRepositorio<T>
{
    IEnumerable<T> ObterTodos();
    T ObterPorId(int Id);
    void Criar(T entidade);
    void Atualizar(T etidade);
    void Deletar(T entidade);

}
