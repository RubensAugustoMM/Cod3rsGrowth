using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Dominio.Filtros;

namespace Cod3rsGrowth.Infra.Repositorios;

public class RepositorioEscola : IRepositorioEscola
{
    public void Atualizar(Escola escolaAtualizada)
    {
        throw new NotImplementedException();
    }

    public void Criar(Escola escolaCriada)
    {
        throw new NotImplementedException();
    }

    public void Deletar(int id)
    {
        throw new NotImplementedException();
    }

    public Escola ObterPorId(int Id)
    {
        throw new NotImplementedException();
    }

    public List<Escola> ObterTodos()
    {
        using (var contexto = new ContextoAplicacao())
        {
            var query = from e in contexto.TabelaEscolas
                        select e;

            return query.ToList();
        }
    }

    public List<Escola> ObterTodos(FiltroEscola? filtroEscola)
    {
        using (var contexto = new ContextoAplicacao())
        {
            List<Escola> query = new();

            if (filtroEscola == null)
                return ObterTodos();

            if (filtroEscola.StatusAtividadeFiltro != null)
                query = (from e in contexto.TabelaEscolas
                         where e.StatusAtividade == filtroEscola.StatusAtividadeFiltro
                         select e)
                        .ToList();

            if (filtroEscola.CategoriaAdministrativaFiltro != null)
                query = (from e in contexto.TabelaEscolas
                         where e.CategoriaAdministrativa == filtroEscola.CategoriaAdministrativaFiltro
                         select e)
                        .ToList();
 
            if (filtroEscola.CategoriaAdministrativaFiltro != null)
                query = (from e in contexto.TabelaEscolas
                         where e.CategoriaAdministrativa == filtroEscola.CategoriaAdministrativaFiltro
                         select e)
                        .ToList();                           

            if (filtroEscola.InicioAtividadeFiltro != null)
            {
                if (filtroEscola.InicioAtividadeFiltro == null)
                    query = (from e in contexto.TabelaEscolas
                             where e.InicioAtividade == filtroEscola.InicioAtividadeFiltro
                             select e)
                             .ToList();
                else
                    query = (from e in contexto.TabelaEscolas
                             where e.InicioAtividade >= filtroEscola.InicioAtividadeFiltro && filtroEscola.MaiorOuIgualInicioAtividade.Value ||
                                   e.InicioAtividade <= filtroEscola.InicioAtividadeFiltro && !filtroEscola.MaiorOuIgualInicioAtividade.Value
                             select e)
                             .ToList();
            }

            if (filtroEscola.NomeFiltro != null)
                query = (from e in contexto.TabelaEscolas
                         where e.Nome.Contains(filtroEscola.NomeFiltro)
                         select e)
                        .ToList();

             if (filtroEscola.IdEnderecoFiltro != null)
                query = (from e in contexto.TabelaEscolas
                         where e.IdEndereco == filtroEscola.IdEnderecoFiltro
                         select e)
                        .ToList();         

            if (filtroEscola.CodigoMecFiltro != null)
                query = (from e in contexto.TabelaEscolas
                         where e.CodigoMec.Contains(filtroEscola.CodigoMecFiltro)
                         select e)
                        .ToList();                  

            return query;
        }
    }


}