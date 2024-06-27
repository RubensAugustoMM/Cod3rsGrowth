using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;
using LinqToDB;

namespace Cod3rsGrowth.Infra.Repositorios;

public class RepositorioEndereco : IRepositorioEndereco
{
    private readonly ContextoAplicacao _contexto;

    public RepositorioEndereco(ContextoAplicacao contexto)
    {
        _contexto = contexto;
    }

    public void Atualizar(Endereco endrecoAtualizado)
    {
        _contexto.Update(endrecoAtualizado);
    }

    public void Criar(Endereco enderecoCriado)
    {
        _contexto.Insert(enderecoCriado);
    }

    public void Deletar(int id)
    {
        _contexto.Delete(id);
    }

    public Endereco ObterPorId(int Id)
    {
        return _contexto.TabelaEnderecos.FirstOrDefault(c => c.Id == Id) ?? throw new Exception($"Nenhum Endereco com Id {Id} existe no contexto atual!\n");
    }

    public List<Endereco> ObterTodos(FiltroEndereco? filtroEndereco)
    {
        IQueryable<Endereco> query = from e in _contexto.TabelaEnderecos
                                     select e;

        if (filtroEndereco != null)
        {
            if (filtroEndereco.EstadoFiltro != null)
            {
                query = from e in query
                        where e.Estado == filtroEndereco.EstadoFiltro
                        select e;
            }

            if (filtroEndereco.MunicipioFiltro != null)
            {
                query = from e in query
                        where e.Municipio.Contains(filtroEndereco.MunicipioFiltro)
                        select e;
            }

            if (filtroEndereco.BairroFiltro != null)
            {
                query = from e in query
                        where e.Bairro.Contains(filtroEndereco.BairroFiltro)
                        select e;
            }


            if (filtroEndereco.CepFiltro != null)
            {
                query = from e in query
                        where e.Cep.Contains(filtroEndereco.CepFiltro)
                        select e;
            }
        }

        return query.ToList();
    }
}