using Cod3rsGrowth.Dominio.Modelos;

namespace Cod3rsGrowth.Infra.Repositorios;

public interface IRepositorioEstado
{
    List<Estado> ObterTodos();
    Estado ObterPorId(int Id);
    void Criar(Estado estadoCriado);
    void Atualizar(Estado estadoAtualizado);
    void Deletar(int Id);
}