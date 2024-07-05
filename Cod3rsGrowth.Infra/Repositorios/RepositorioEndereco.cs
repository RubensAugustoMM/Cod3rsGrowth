using Cod3rsGrowth.Dominio;
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
        IQueryable<Endereco> query = from endereco in _contexto.TabelaEnderecos
                                     where endereco.Id == Id
                                     select endereco;

        return query.FirstOrDefault() ?? throw new Exception($"Nenhum Endereco com Id {Id} existe no contexto atual!\n"); 
    }

    public List<Endereco> ObterTodos(FiltroEndereco? filtroEndereco)
    {
        IQueryable<Endereco> query = from endereco in _contexto.TabelaEnderecos
                                     select endereco;

        if (filtroEndereco != null)
        {
            if (filtroEndereco.EstadoFiltro != null)
            {
                query = from estado in query
                        where estado.Estado == filtroEndereco.EstadoFiltro
                        select estado;
            }

            if (filtroEndereco.MunicipioFiltro != null)
            {
                query = from estado in query
                        where estado.Municipio.StartsWith(filtroEndereco.MunicipioFiltro)
                        select estado;
            }

            if (filtroEndereco.BairroFiltro != null)
            {
                query = from estado in query
                        where estado.Bairro.StartsWith(filtroEndereco.BairroFiltro)
                        select estado;
            }

            if (filtroEndereco.CepFiltro != null)
            {
                query = from estado in query
                        where estado.Cep.StartsWith(filtroEndereco.CepFiltro)
                        select estado;
            }
        }

        return query.ToList();
    }
}