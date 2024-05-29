using Cod3rsGrowth.Dominio.Modelos;

namespace Cod3rsGrowth.Dominio.Interfaces;

public interface IRepositorioEscola
{
    List<Escola> ObterTodos();
    Escola ObterPorId(int Id);
    void Criar(Escola escolaCriada);
    void Atualizar(Escola escolaAtualizada);
    void Deletar(int Id);
}