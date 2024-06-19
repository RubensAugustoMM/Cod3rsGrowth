using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Dominio.Filtros;
using LinqToDB;

namespace Cod3rsGrowth.Infra.Repositorios;

public class RepositorioEscola : IRepositorioEscola
{
    public void Atualizar(Escola escolaAtualizada)
    {
        using (var contexto = new ContextoAplicacao())
        {
            contexto.Update(escolaAtualizada);
        }
    }

    public void Criar(Escola escolaCriada)
    {
        using (var contexto = new ContextoAplicacao())
        {
            contexto.Insert(escolaCriada);
        }
    }

    public void Deletar(int id)
    {
        throw new NotImplementedException();
    }

    public Escola ObterPorId(int Id)
    {
        throw new NotImplementedException();
    }

    public List<Escola> ObterTodos(FiltroEscola? filtroEscola)
    {
        using (var contexto = new ContextoAplicacao())
        {
            IQueryable<Escola> query = from e in contexto.TabelaEscolas
                                       select e;

            if (filtroEscola != null)
            {
                if (filtroEscola.StatusAtividadeFiltro != null)
                    query = from e in query
                            where e.StatusAtividade == filtroEscola.StatusAtividadeFiltro
                            select e;

                if (filtroEscola.CategoriaAdministrativaFiltro != null)
                    query = from e in query
                            where e.CategoriaAdministrativa == filtroEscola.CategoriaAdministrativaFiltro
                            select e;

                if (filtroEscola.CategoriaAdministrativaFiltro != null)
                    query = from e in query
                            where e.CategoriaAdministrativa == filtroEscola.CategoriaAdministrativaFiltro
                            select e;

                if (filtroEscola.InicioAtividadeFiltro != null)
                {
                    if (filtroEscola.MaiorOuIgualInicioAtividade == null)
                        query = from e in query
                                where e.InicioAtividade == filtroEscola.InicioAtividadeFiltro
                                select e;
                    else
                        query = from e in query
                                where e.InicioAtividade >= filtroEscola.InicioAtividadeFiltro && filtroEscola.MaiorOuIgualInicioAtividade.Value ||
                                      e.InicioAtividade <= filtroEscola.InicioAtividadeFiltro && !filtroEscola.MaiorOuIgualInicioAtividade.Value
                                select e;
                }

                if (filtroEscola.NomeFiltro != null)
                    query = from e in query
                            where e.Nome.Contains(filtroEscola.NomeFiltro)
                            select e;

                if (filtroEscola.IdEnderecoFiltro != null)
                    query = from e in query
                            where e.IdEndereco == filtroEscola.IdEnderecoFiltro
                            select e;

                if (filtroEscola.CodigoMecFiltro != null)
                    query = from e in query
                            where e.CodigoMec.Contains(filtroEscola.CodigoMecFiltro)
                            select e;
            }
            
            return query.ToList();
        }
    }
}