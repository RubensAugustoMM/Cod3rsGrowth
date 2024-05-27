using Cod3rsGrowth.Dominio.Modelos;

namespace Cod3rsGrowth.Infra.Repositorios;

public interface IRepositorioEstado
{
    List<Estado> ObterTodos();
    Estado ObterPorId(int Id);
    void Criar(Estado entidade);
    void Atualizar(Estado entidade);
    void Deletar(Estado entidade);
}