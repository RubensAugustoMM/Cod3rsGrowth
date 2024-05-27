using Cod3rsGrowth.Dominio.Modelos;

namespace Cod3rsGrowth.Infra.Repositorios;

public interface IRepositorioEscola
{
    List<Escola> ObterTodos();
    Escola ObterPorId(int Id);
    void Criar(Escola escolaCriada);
    void Atualizar(Escola escolaAtualizada);
    void Deletar(Escola escolaDeletada);
}