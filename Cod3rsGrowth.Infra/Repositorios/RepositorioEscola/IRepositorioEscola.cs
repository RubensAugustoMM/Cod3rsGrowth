using Cod3rsGrowth.Dominio.Modelos;

namespace Cod3rsGrowth.Infra.Repositorios;

public interface IRepositorioEscola
{
    List<Escola> ObterTodos();
    Escola ObterPorId(int Id);
    void Criar(Escola entidade);
    void Atualizar(Escola entidade);
    void Deletar(Escola entidade);
}