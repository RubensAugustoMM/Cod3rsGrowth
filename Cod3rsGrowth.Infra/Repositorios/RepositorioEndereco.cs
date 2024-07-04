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

    public EnderecoOtd ObterPorId(int Id)
    {
        IQueryable<EnderecoOtd> query = from endereco in _contexto.TabelaEnderecos
                                     where endereco.Id == Id
                                     select new EnderecoOtd
                                     {
                                        Id = endereco.Id,
                                        Numero = endereco.Numero, 
                                        Cep = endereco.Cep,
                                        Municipio = endereco.Municipio,
                                        Bairro = endereco.Bairro,
                                        Rua = endereco.Rua,
                                        Complemento = endereco.Complemento,
                                        Estado = EnumExtencoes.RetornaDescricao(endereco.Estado)
                                     };

        return query.FirstOrDefault() ?? throw new Exception($"Nenhum Endereco com Id {Id} existe no contexto atual!\n"); 
    }

    public List<EnderecoOtd> ObterTodos(FiltroEnderecoOtd? filtroEnderecoOtd)
    {
        IQueryable<EnderecoOtd> query = from endereco in _contexto.TabelaEnderecos
                                     select new EnderecoOtd
                                     {
                                        Id = endereco.Id,
                                        Numero = endereco.Numero, 
                                        Cep = endereco.Cep,
                                        Municipio = endereco.Municipio,
                                        Bairro = endereco.Bairro,
                                        Rua = endereco.Rua,
                                        Complemento = endereco.Complemento,
                                        Estado = EnumExtencoes.RetornaDescricao(endereco.Estado)
                                     };

        if (filtroEnderecoOtd != null)
        {
            if (filtroEnderecoOtd.EstadoFiltro != null)
            {
                query = from estado in query
                        where (estado.Estado == 
                            EnumExtencoes.RetornaDescricao(filtroEnderecoOtd.EstadoFiltro))
                        select estado;
            }

            if (filtroEnderecoOtd.MunicipioFiltro != null)
            {
                query = from estado in query
                        where estado.Municipio.StartsWith(filtroEnderecoOtd.MunicipioFiltro)
                        select estado;
            }

            if (filtroEnderecoOtd.BairroFiltro != null)
            {
                query = from estado in query
                        where estado.Bairro.StartsWith(filtroEnderecoOtd.BairroFiltro)
                        select estado;
            }

            if (filtroEnderecoOtd.CepFiltro != null)
            {
                query = from estado in query
                        where estado.Cep.StartsWith(filtroEnderecoOtd.CepFiltro)
                        select estado;
            }
        }

        return query.ToList();
    }
}