using Cod3rsGrowth.Dominio.Modelos;

namespace Cod3rsGrowth.Infra.Repositorios;

public interface IRepositorioConvenio
{
    List<Empresa> ObterTodos();
    Empresa ObterPorId(int Id);
    void Criar(Empresa entidade);
    void Atualizar(Empresa entidade);
    void Deletar(Empresa entidade);
}