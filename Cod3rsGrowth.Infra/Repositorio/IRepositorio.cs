namespace Cod3rsGrowth.Infra.Repositorio;

public interface Repositorio<T>
{
    IEnumerable<T> ObterTodos();
    T ObterPorId(int Id);
    void Criar(T entidade);
    void Atualizar(T etidade);
    void Deletar(T entidade);

}
