using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Dominio.Filtros;
using LinqToDB;
using Cod3rsGrowth.Dominio.ObjetosTranferenciaDados;
using Cod3rsGrowth.Dominio;

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

    public int Criar(Escola escolaCriada)
    {
        return _contexto.InsertWithInt32Identity(escolaCriada);
    }

    public void Deletar(int id)
    {
        _contexto.Delete(id);
    }

    public EscolaEnderecoOtd ObterPorId(int Id)
    {
        IQueryable<EscolaEnderecoOtd> query = from escola in _contexto.TabelaEscolas
                                     where escola.Id == Id
                                     join endereco in _contexto.TabelaEnderecos on escola.IdEndereco equals endereco.Id
                                     select new EscolaEnderecoOtd
                                     {
                                        Id = escola.Id,
                                        StatusAtividade = escola.StatusAtividade, 
                                        Nome = escola.Nome,
                                        CodigoMec= escola.CodigoMec,
                                        Telefone = escola.Telefone,
                                        Email = escola.Email,
                                        InicioAtividade =escola.InicioAtividade,
                                        IdEndereco = escola.IdEndereco,
                                        CategoriaAdministrativa = escola.CategoriaAdministrativa,
                                        OrganizacaoAcademica = escola.OrganizacaoAcademica,
                                        Estado = endereco.Estado
                                     };

        return query.FirstOrDefault() ?? throw new Exception($"Nenhuma Escola com Id {Id} existe no contexto atual!\n");
    }

    public List<EscolaEnderecoOtd> ObterTodos(FiltroEscolaEnderecoOtd? filtroEscolaEnderecoOtd)
    {
        IQueryable<EscolaEnderecoOtd> query = from escola in _contexto.TabelaEscolas
                                     join endereco in _contexto.TabelaEnderecos on escola.IdEndereco equals endereco.Id
                                     select new EscolaEnderecoOtd
                                     {
                                        Id = escola.Id,
                                        StatusAtividade = escola.StatusAtividade, 
                                        Nome = escola.Nome,
                                        CodigoMec= escola.CodigoMec,
                                        Telefone = escola.Telefone,
                                        Email = escola.Email,
                                        InicioAtividade =escola.InicioAtividade,
                                        IdEndereco = escola.IdEndereco, 
                                        CategoriaAdministrativa = escola.CategoriaAdministrativa,
                                        OrganizacaoAcademica = escola.OrganizacaoAcademica,
                                        Estado = endereco.Estado
                                     };

        if (filtroEscolaEnderecoOtd != null)
        {
            if (filtroEscolaEnderecoOtd.StatusAtividadeFiltro != null)
                query = from escola in query
                        where escola.StatusAtividade == filtroEscolaEnderecoOtd.StatusAtividadeFiltro
                        select escola;

            if (filtroEscolaEnderecoOtd.CategoriaAdministrativaFiltro != null)
                query = from escola in query
                        where (escola.CategoriaAdministrativa == 
                            filtroEscolaEnderecoOtd.CategoriaAdministrativaFiltro)
                        select escola;

            if (filtroEscolaEnderecoOtd.OrganizacaoAcademicaFiltro != null)
                query = from escola in query
                        where (escola.OrganizacaoAcademica == 
                            filtroEscolaEnderecoOtd.OrganizacaoAcademicaFiltro)
                        select escola;

            if (filtroEscolaEnderecoOtd.EstadoFiltro != null)
                query = from escola in query
                        where (escola.Estado == 
                            filtroEscolaEnderecoOtd.EstadoFiltro)
                        select escola;

            if (filtroEscolaEnderecoOtd.InicioAtividadeFiltro != null)
            {
                if (filtroEscolaEnderecoOtd.MaiorOuIgualInicioAtividade == null)
                {
                    query = from escola in query
                            where escola.InicioAtividade == filtroEscolaEnderecoOtd.InicioAtividadeFiltro
                            select escola;
                }
                else if(filtroEscolaEnderecoOtd.MaiorOuIgualInicioAtividade.Value)
                {
                    query = from escola in query
                            where escola.InicioAtividade >= filtroEscolaEnderecoOtd.InicioAtividadeFiltro
                            select escola;
                }
                else
                {
                    query = from escola in query
                            where escola.InicioAtividade <= filtroEscolaEnderecoOtd.InicioAtividadeFiltro
                            select escola;
                }
            }

            if (filtroEscolaEnderecoOtd.NomeFiltro != null)
                query = from escola in query
                        where escola.Nome.Contains(filtroEscolaEnderecoOtd.NomeFiltro)
                        select escola;

            if (filtroEscolaEnderecoOtd.IdEnderecoFiltro != null)
                query = from escola in query
                        where escola.IdEndereco == filtroEscolaEnderecoOtd.IdEnderecoFiltro
                        select escola;

            if (filtroEscolaEnderecoOtd.CodigoMecFiltro != null)
                query = from escola in query
                        where escola.CodigoMec.Contains(filtroEscolaEnderecoOtd.CodigoMecFiltro)
                        select escola;
        }

        return query.ToList();
    }
}