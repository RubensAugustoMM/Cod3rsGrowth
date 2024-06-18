using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Dominio.Filtros;

namespace Cod3rsGrowth.Infra.Repositorios;

public class RepositorioEstado : IRepositorioEstado
{
    public void Atualizar(Estado estadoAtualizado)
    {
        throw new NotImplementedException();
    }

    public void Criar(Estado estadoCriado)
    {
        throw new NotImplementedException();
    }

    public void Deletar(int id)
    {
        throw new NotImplementedException();
    }

    public Estado ObterPorId(int Id)
    {
        throw new NotImplementedException();
    }

    public List<Estado> ObterTodos(FiltroEstado? filtroEstado)
    {
        using (var contexto = new ContextoAplicacao())
        {
            List<Estado> query = new();

            if (filtroEstado == null)
            {
                query = (from c in contexto.TabelaEstados
                         select c)
                        .ToList();

                return query;
            }

            if (filtroEstado.NomeFiltro != null)
                query = (from c in contexto.TabelaEstados
                         where c.Nome.Contains(filtroEstado.NomeFiltro)
                         select c)
                        .ToList();
  
            if (filtroEstado.SiglaFiltro != null)
                query = (from c in contexto.TabelaEstados
                         where c.Sigla.Contains(filtroEstado.SiglaFiltro)
                         select c)
                        .ToList();
                                                
            return query;
        }
    }
}