using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Dominio.Filtros;
using LinqToDB;

namespace Cod3rsGrowth.Infra.Repositorios;

public class RepositorioEmpresa : IRepositorioEmpresa
{
    private readonly ContextoAplicacao _contexto;

    public RepositorioEmpresa(ContextoAplicacao contexto)
    {
        _contexto = contexto;
    }

    public void Atualizar(Empresa empresaAtualizada)
    {
        _contexto.Update(empresaAtualizada);
    }

    public void Criar(Empresa empresaCriada)
    {
        _contexto.Insert(empresaCriada);
    }

    public void Deletar(int id)
    {
        _contexto.Delete(id);
    }

    public Empresa ObterPorId(int Id)
    {
        return _contexto.TabelaEmpresas.FirstOrDefault(c => c.Id == Id) ?? throw new Exception($"Nenhuma Empresa com Id {Id} existe no contexto atual!\n");
    }

    public List<Empresa> ObterTodos(FiltroEmpresa? filtroEmpresa)
    {
        IQueryable<Empresa> query = from e in _contexto.TabelaEmpresas
                                    select e;

        if (filtroEmpresa != null)
        {
            if (filtroEmpresa.NaturezaJuridicaFiltro != null)
            {
                query = from e in query
                        where e.NaturezaJuridica == filtroEmpresa.NaturezaJuridicaFiltro
                        select e;
            }

            if (filtroEmpresa.PorteFiltro != null)
            {
                query = from e in query
                        where e.Porte == filtroEmpresa.PorteFiltro
                        select e;
            }

            if (filtroEmpresa.MatrizFilialFiltro != null)
            {
                query = from e in query
                        where e.MatrizFilial == filtroEmpresa.MatrizFilialFiltro
                        select e;
            }

            if (filtroEmpresa.DataSituacaoCadastralFiltro != null)
            {
                if (filtroEmpresa.MaiorOuIgualDataSituacaoCadastral == null)
                {
                    query = from e in query
                            where e.DataSituacaoCadastral == filtroEmpresa.DataSituacaoCadastralFiltro
                            select e;
                }
                else if(filtroEmpresa.MaiorOuIgualDataSituacaoCadastral.Value)
                {
                    query = from e in query
                            where e.DataSituacaoCadastral >= filtroEmpresa.DataSituacaoCadastralFiltro
                            select e;
                }
                else
                {
                    query = from e in query
                            where e.DataSituacaoCadastral <= filtroEmpresa.DataSituacaoCadastralFiltro
                            select e;
                }
            }

            if (filtroEmpresa.DataAberturaFiltro != null)
            {
                if (filtroEmpresa.MaiorOuIgualDataAbertura == null)
                {
                    query = from e in query
                            where e.DataAbertura == filtroEmpresa.DataAberturaFiltro
                            select e;
                }
                else if(filtroEmpresa.MaiorOuIgualDataAbertura.Value)
                {
                    query = from e in query
                            where e.DataAbertura >= filtroEmpresa.DataAberturaFiltro && filtroEmpresa.MaiorOuIgualDataAbertura.Value
                            select e;
                }
                else
                {
                    query = from e in query
                            where e.DataAbertura <= filtroEmpresa.DataAberturaFiltro
                            select e;
                }
            }

            if (filtroEmpresa.CapitalSocialFiltro != null)
            {
                if (filtroEmpresa.MaiorOuIgualCapitalSocial == null)
                {
                    query = from e in query
                            where e.CapitalSocial == filtroEmpresa.CapitalSocialFiltro
                            select e;
                }
                else if(filtroEmpresa.MaiorOuIgualCapitalSocial.Value)
                {
                    query = from e in query
                            where e.CapitalSocial >= filtroEmpresa.CapitalSocialFiltro
                            select e;
                }
                else
                {
                    query = from e in query
                            where e.CapitalSocial <= filtroEmpresa.CapitalSocialFiltro
                            select e;
                }
            }

            if (filtroEmpresa.IdadeFiltro != null)
            {
                if (filtroEmpresa.MaiorOuIgualIdade == null)
                {
                    query = from e in query
                            where e.Idade == filtroEmpresa.IdadeFiltro
                            select e;
                }
                else if(filtroEmpresa.MaiorOuIgualIdade.Value)
                {
                    query = from e in query
                            where e.Idade >= filtroEmpresa.IdadeFiltro
                            select e;
                }
                else
                {
                    query = from e in query
                            where e.Idade <= filtroEmpresa.IdadeFiltro
                            select e;
                }
            }

            if (filtroEmpresa.RazaoSocialFiltro != null)
            {
                query = from e in query
                        where e.RazaoSocial.Contains(filtroEmpresa.RazaoSocialFiltro)
                        select e;
            }

            if (filtroEmpresa.NomeFantasiaFiltro != null)
            {
                query = from e in query
                        where e.NomeFantasia.Contains(filtroEmpresa.NomeFantasiaFiltro)
                        select e;
            }

            if (filtroEmpresa.IdEnderecoFiltro != null)
            {
                query = from e in query
                        where e.IdEndereco == filtroEmpresa.IdEnderecoFiltro
                        select e;
            }

            if (filtroEmpresa.CnpjFiltro != null)
            {
                query = from e in query
                        where e.Cnpj.Contains(filtroEmpresa.CnpjFiltro)
                        select e;
            }
        }

        return query.ToList();
    }
}