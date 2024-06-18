using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Dominio.Modelos;

namespace Cod3rsGrowth.Dominio.Interfaces;

public interface IRepositorioEscola
{
    List<Escola> ObterTodos();
    List<Escola> ObterTodos(FiltroEscola filtroEscola);
    Escola ObterPorId(int Id);
    void Criar(Escola escolaCriada);
    void Atualizar(Escola escolaAtualizada);
    void Deletar(int id);
}