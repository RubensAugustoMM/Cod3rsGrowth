using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Dominio.Filtros;
using LinqToDB;

namespace Cod3rsGrowth.Infra.Repositorios;

public class RepositorioEstado : IRepositorioEstado
{
    public void Atualizar(Estado estadoAtualizado)
    {
        using (var contexto = new ContextoAplicacao())
        {
            contexto.Update(estadoAtualizado);
        }
    }

    public void Criar(Estado estadoCriado)
    {
        using (var contexto = new ContextoAplicacao())
        {
            contexto.Insert(estadoCriado);
        }
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
            IQueryable<Estado> query = from c in contexto.TabelaEstados
                                       select c;

            if (filtroEstado != null)
            {
                if (filtroEstado.NomeFiltro != null)
                {
                    query = from c in query
                            where c.Nome.Contains(filtroEstado.NomeFiltro)
                            select c;
                }

                if (filtroEstado.SiglaFiltro != null)
                {
                    query = from c in contexto.TabelaEstados
                            where c.Sigla.Contains(filtroEstado.SiglaFiltro)
                            select c;
                }
            }

            return query.ToList();
        }
    }
}