using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Dominio.Modelos;

namespace Cod3rsGrowth.Dominio.Interfaces;

public interface IRepositorioEstado
{
    List<Estado> ObterTodos();
    List<Estado> ObterTodos(FiltroEstado filtroEstado);
    Estado ObterPorId(int Id);
    void Criar(Estado estadoCriado);
    void Atualizar(Estado estadoAtualizado);
    void Deletar(int id);
}