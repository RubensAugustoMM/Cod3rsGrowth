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
            List<Empresa> query = new();

            if (filtroEmpresa == null)
            {
                query = (from e in contexto.TabelaEmpresas
                         select e)
                        .ToList();

                return query;
            }

            if (filtroEmpresa.NaturezaJuridicaFiltro != null)
                query = (from e in contexto.TabelaEmpresas
                         where e.NaturezaJuridica == filtroEmpresa.NaturezaJuridicaFiltro
                         select e)
                        .ToList();                           

            if (filtroEmpresa.PorteFiltro != null)
                query = (from e in contexto.TabelaEmpresas
                         where e.Porte == filtroEmpresa.PorteFiltro
                         select e)
                        .ToList();                           

            if (filtroEmpresa.MatrizFilialFiltro != null)
                query = (from e in contexto.TabelaEmpresas
                         where e.MatrizFilial == filtroEmpresa.MatrizFilialFiltro
                         select e)
                        .ToList();                           

            if (filtroEmpresa.DataSituacaoCadastralFiltro != null)
            {
                if (filtroEmpresa.MaiorOuIgualDataSituacaoCadastral == null)
                    query = (from e in contexto.TabelaEmpresas
                             where e.DataSituacaoCadastral == filtroEmpresa.DataSituacaoCadastralFiltro
                             select e)
                             .ToList();
                else
                    query = (from e in contexto.TabelaEmpresas
                             where e.DataSituacaoCadastral >= filtroEmpresa.DataSituacaoCadastralFiltro && filtroEmpresa.MaiorOuIgualDataSituacaoCadastral.Value ||
                                   e.DataSituacaoCadastral <= filtroEmpresa.DataSituacaoCadastralFiltro && !filtroEmpresa.MaiorOuIgualDataSituacaoCadastral.Value
                             select e)
                             .ToList();
            }

            if (filtroEmpresa.DataAberturaFiltro != null)
            {
                if (filtroEmpresa.MaiorOuIgualDataAbertura == null)
                    query = (from e in contexto.TabelaEmpresas
                             where e.DataAbertura == filtroEmpresa.DataAberturaFiltro
                             select e)
                             .ToList();
                else
                    query = (from e in contexto.TabelaEmpresas
                             where e.DataAbertura >= filtroEmpresa.DataAberturaFiltro && filtroEmpresa.MaiorOuIgualDataAbertura.Value ||
                                   e.DataAbertura <= filtroEmpresa.DataAberturaFiltro && !filtroEmpresa.MaiorOuIgualDataAbertura.Value
                             select e)
                             .ToList();
            }

            if (filtroEmpresa.CapitalSocialFiltro != null)
            {
                if (filtroEmpresa.CapitalSocialFiltro == null)
                    query = (from e in contexto.TabelaEmpresas
                             where e.CapitalSocial == filtroEmpresa.CapitalSocialFiltro
                             select e)
                             .ToList();
                else
                    query = (from e in contexto.TabelaEmpresas
                             where e.CapitalSocial >= filtroEmpresa.CapitalSocialFiltro && filtroEmpresa.MaiorOuIgualCapitalSocial.Value ||
                                   e.CapitalSocial <= filtroEmpresa.CapitalSocialFiltro && !filtroEmpresa.MaiorOuIgualCapitalSocial.Value
                             select e)
                             .ToList();
            }

            if (filtroEmpresa.IdadeFiltro != null)
            {
                if (filtroEmpresa.MaiorOuIgualIdade == null)
                    query = (from e in contexto.TabelaEmpresas
                             where e.Idade == filtroEmpresa.IdadeFiltro
                             select e)
                             .ToList();
                else
                    query = (from e in contexto.TabelaEmpresas
                             where e.Idade >= filtroEmpresa.IdadeFiltro && filtroEmpresa.MaiorOuIgualIdade.Value ||
                                   e.Idade <= filtroEmpresa.IdadeFiltro && !filtroEmpresa.MaiorOuIgualIdade.Value
                             select e)
                             .ToList();
            }

            if (filtroEmpresa.RazaoSocialFiltro != null)
                query = (from e in contexto.TabelaEmpresas
                         where e.RazaoSocial.Contains(filtroEmpresa.RazaoSocialFiltro)
                         select e)
                        .ToList();

            if (filtroEmpresa.NomeFantasiaFiltro != null)
                query = (from e in contexto.TabelaEmpresas
                         where e.NomeFantasia.Contains(filtroEmpresa.NomeFantasiaFiltro)
                         select e)
                        .ToList();

             if (filtroEmpresa.IdEnderecoFiltro != null)
                query = (from e in contexto.TabelaEmpresas
                         where e.IdEndereco == filtroEmpresa.IdEnderecoFiltro
                         select e)
                        .ToList();                           

            if (filtroEmpresa.CnpjFiltro != null)
                query = (from e in contexto.TabelaEmpresas
                         where e.Cnpj.Contains(filtroEmpresa.CnpjFiltro)
                         select e)
                        .ToList();

            return query;
        }
    }

}