using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Dominio.Filtros;

namespace Cod3rsGrowth.Infra.Repositorios;

public class RepositorioEmpresa : IRepositorioEmpresa
{
    public void Atualizar(Empresa empresaAtualizada)
    {
        throw new NotImplementedException();
    }

    public void Criar(Empresa empresaCriada)
    {
        throw new NotImplementedException();
    }

    public void Deletar(int id)
    {
        throw new NotImplementedException();
    }

    public Empresa ObterPorId(int Id)
    {
        throw new NotImplementedException();
    }

    public List<Empresa> ObterTodos(FiltroEmpresa? filtroEmpresa)
    {
        using (var contexto = new ContextoAplicacao())
        {
            IQueryable<Empresa> query = from e in contexto.TabelaEmpresas
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
                    else
                    {
                        query = from e in query
                                where e.DataSituacaoCadastral >= filtroEmpresa.DataSituacaoCadastralFiltro && filtroEmpresa.MaiorOuIgualDataSituacaoCadastral.Value ||
                                      e.DataSituacaoCadastral <= filtroEmpresa.DataSituacaoCadastralFiltro && !filtroEmpresa.MaiorOuIgualDataSituacaoCadastral.Value
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
                    else
                    {
                        query = from e in query
                                where e.DataAbertura >= filtroEmpresa.DataAberturaFiltro && filtroEmpresa.MaiorOuIgualDataAbertura.Value ||
                                      e.DataAbertura <= filtroEmpresa.DataAberturaFiltro && !filtroEmpresa.MaiorOuIgualDataAbertura.Value
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
                    else
                    {
                        query = from e in query
                                where e.CapitalSocial >= filtroEmpresa.CapitalSocialFiltro && filtroEmpresa.MaiorOuIgualCapitalSocial.Value ||
                                      e.CapitalSocial <= filtroEmpresa.CapitalSocialFiltro && !filtroEmpresa.MaiorOuIgualCapitalSocial.Value
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
                    else
                    {
                        query = from e in query
                                where e.Idade >= filtroEmpresa.IdadeFiltro && filtroEmpresa.MaiorOuIgualIdade.Value ||
                                      e.Idade <= filtroEmpresa.IdadeFiltro && !filtroEmpresa.MaiorOuIgualIdade.Value
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
}