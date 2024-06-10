using Cod3rsGrowth.Dominio.Modelos;

namespace Cod3rsGrowth.Dominio.Interfaces;

public interface IRepositorioEstado
{
    List<Estado> ObterTodos();
    Estado ObterPorId(int Id);
    void Criar(Estado estadoCriado);
    void Atualizar(Estado estadoAtualizado);
    void Deletar(int Id);
}