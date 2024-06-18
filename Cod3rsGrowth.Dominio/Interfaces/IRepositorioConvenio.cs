using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Dominio.Modelos;

namespace Cod3rsGrowth.Dominio.Interfaces;

public interface IRepositorioConvenio
{
    List<Convenio> ObterTodos(FiltroConvenio filtroConvenio);
    Convenio ObterPorId(int Id);
    void Criar(Convenio convenioCriado);
    void Atualizar(Convenio convenioAtualizado);
    void Deletar(int id);
}