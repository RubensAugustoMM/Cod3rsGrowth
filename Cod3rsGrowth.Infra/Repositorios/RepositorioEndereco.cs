using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;

namespace Cod3rsGrowth.Infra.Repositorios;

public class RepositorioEndereco : IRepositorioEndereco
{
    public void Atualizar(Endereco endrecoAtualizado)
    {
        throw new NotImplementedException();
    }

    public void Criar(Endereco enderecoCriado)
    {
        throw new NotImplementedException();
    }

    public void Deletar(int id)
    {
        throw new NotImplementedException();
    }

    public Endereco ObterPorId(int Id)
    {
        throw new NotImplementedException();
    }

    public List<Endereco> ObterTodos(FiltroEndereco? filtroEndereco)
    {
        using (var contexto = new ContextoAplicacao())
        {


            IQueryable<Endereco> query = from e in contexto.TabelaEnderecos
                                         select e;

            if (filtroEndereco != null)
            {
                if (filtroEndereco.IdEstadoFiltro != null)
                    query = from e in contexto.TabelaEnderecos
                            where e.IdEstado == filtroEndereco.IdEstadoFiltro
                            select e;

                if (filtroEndereco.MunicipioFiltro != null)
                    query = from e in contexto.TabelaEnderecos
                            where e.Municipio.Contains(filtroEndereco.MunicipioFiltro)
                            select e;

                if (filtroEndereco.BairroFiltro != null)
                    query = from e in contexto.TabelaEnderecos
                            where e.Bairro.Contains(filtroEndereco.BairroFiltro)
                            select e;

                if (filtroEndereco.RuaFiltro != null)
                    query = from e in contexto.TabelaEnderecos
                            where e.Rua.Contains(filtroEndereco.RuaFiltro)
                            select e;

                if (filtroEndereco.CepFiltro != null)
                    query = from e in contexto.TabelaEnderecos
                            where e.Cep.Contains(filtroEndereco.CepFiltro)
                            select e;
            }
            
            return query.ToList();
        }
    }
}