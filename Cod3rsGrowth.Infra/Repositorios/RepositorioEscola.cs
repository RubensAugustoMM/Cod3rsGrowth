using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Dominio.Filtros;
using LinqToDB;

namespace Cod3rsGrowth.Infra.Repositorios;

public class RepositorioEscola : IRepositorioEscola
{
    private readonly ContextoAplicacao _contexto;

    public RepositorioEscola(ContextoAplicacao contexto)
    {
        _contexto = contexto;
    }

    public void Atualizar(Escola escolaAtualizada)
    {
        _contexto.Update(escolaAtualizada);
    }

    public void Criar(Escola escolaCriada)
    {
        _contexto.Insert(escolaCriada);
    }

    public void Deletar(int id)
    {
        _contexto.Delete(id);
    }

    public Escola ObterPorId(int Id)
    {
        return _contexto.TabelaEscolas.FirstOrDefault(c => c.Id == Id) ?? throw new Exception($"Nenhuma Escola com Id {Id} existe no contexto atual!\n");
    }

    public List<Escola> ObterTodos(FiltroEscola? filtroEscola)
    {
        IQueryable<Escola> query = from e in _contexto.TabelaEscolas
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
                {
                    query = from e in query
                            where e.InicioAtividade == filtroEscola.InicioAtividadeFiltro
                            select e;
                }
                else if(filtroEscola.MaiorOuIgualInicioAtividade.Value)
                {
                    query = from e in query
                            where e.InicioAtividade >= filtroEscola.InicioAtividadeFiltro
                            select e;
                }
                else
                {
                    query = from e in query
                            where e.InicioAtividade <= filtroEscola.InicioAtividadeFiltro
                            select e;
                }
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