using Cod3rsGrowth.Dominio.Modelos;

namespace Cod3rsGrowth.Infra.Repositorios;

public interface IRepositorioEmpresa
{
    List<Empresa> ObterTodos();
    Empresa ObterPorId(int Id);
    void Criar(Empresa entidade);
    void Atualizar(Empresa entidade);
    void Deletar(Empresa entidade);
}