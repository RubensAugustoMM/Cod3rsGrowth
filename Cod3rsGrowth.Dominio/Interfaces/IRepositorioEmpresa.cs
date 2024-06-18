using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Dominio.Modelos;

namespace Cod3rsGrowth.Dominio.Interfaces;

public interface IRepositorioEmpresa
{
    List<Empresa> ObterTodos(FiltroEmpresa? FiltroEmpresa);
    Empresa ObterPorId(int Id);
    void Criar(Empresa empresaCriada);
    void Atualizar(Empresa empresaAtualizada);
    void Deletar(int id);
}