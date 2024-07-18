using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Dominio.Filtros;
using LinqToDB;
using Cod3rsGrowth.Dominio.ObjetosTranferenciaDados;

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
        empresaCriada.Id = _contexto.InsertWithInt32Identity(empresaCriada);  
    }

    public void Deletar(int id)
    {
        _contexto.TabelaEmpresas.Where(e => e.Id == id).Delete();
    }

    public EmpresaEnderecoOtd ObterPorId(int Id)
    {
        IQueryable<EmpresaEnderecoOtd> query = from empresa in _contexto.TabelaEmpresas
                                     where empresa.Id == Id
                                     join endereco in _contexto.TabelaEnderecos on empresa.IdEndereco equals endereco.Id
                                     select new EmpresaEnderecoOtd
                                     {
                                        Id = empresa.Id,
                                        RazaoSocial = empresa.RazaoSocial,
                                        NomeFantasia = empresa.NomeFantasia,
                                        Cnpj = empresa.Cnpj,
                                        SitucaoCadastral = empresa.SitucaoCadastral,
                                        DataSituacaoCadastral = empresa.DataSituacaoCadastral,
                                        Idade = empresa.Idade,
                                        DataAbertura = empresa.DataAbertura,
                                        CapitalSocial = empresa.CapitalSocial,
                                        NaturezaJuridica = empresa.NaturezaJuridica,
                                        Porte = empresa.Porte,
                                        MatrizFilial = empresa.MatrizFilial,
                                        IdEndereco = empresa.IdEndereco,
                                        Estado = endereco.Estado
                                     };

        return query.FirstOrDefault() ?? throw new Exception($"Nenhuma Empresa com Id {Id} existe no contexto atual!\n"); 
    }

    public List<EmpresaEnderecoOtd> ObterTodos(FiltroEmpresaEnderecoOtd? filtroEmpresaEnderecoOtd)
    {
        IQueryable<EmpresaEnderecoOtd> query = from empresa in _contexto.TabelaEmpresas
                                               join endereco in _contexto.TabelaEnderecos on empresa.IdEndereco equals endereco.Id
                                               select new EmpresaEnderecoOtd
                                               {
                                                   Id = empresa.Id,
                                                   RazaoSocial = empresa.RazaoSocial,
                                                   NomeFantasia = empresa.NomeFantasia,
                                                   Cnpj = empresa.Cnpj,
                                                   SitucaoCadastral = empresa.SitucaoCadastral,
                                                   DataSituacaoCadastral = empresa.DataSituacaoCadastral,
                                                   Idade = empresa.Idade,
                                                   DataAbertura = empresa.DataAbertura,
                                                   CapitalSocial = empresa.CapitalSocial,
                                                   NaturezaJuridica = empresa.NaturezaJuridica,
                                                   Porte = empresa.Porte,
                                                   MatrizFilial = empresa.MatrizFilial,
                                                   IdEndereco = empresa.IdEndereco,
                                                   Estado = endereco.Estado
                                               };

        if (filtroEmpresaEnderecoOtd != null)
        {
            if(filtroEmpresaEnderecoOtd.SitucaoCadastralFiltro != null)
            {
                query = from empresa in query
                        where empresa.SitucaoCadastral == filtroEmpresaEnderecoOtd.SitucaoCadastralFiltro
                        let naturezaJuridica = empresa.NaturezaJuridica
                        let porte = empresa.Porte
                        let matrizFilial = empresa.MatrizFilial
                        let estado = empresa.Estado
                        select new EmpresaEnderecoOtd
                        {
                            Id = empresa.Id,
                            RazaoSocial = empresa.RazaoSocial,
                            NomeFantasia = empresa.NomeFantasia,
                            Cnpj = empresa.Cnpj,
                            SitucaoCadastral = empresa.SitucaoCadastral,
                            DataSituacaoCadastral = empresa.DataSituacaoCadastral,
                            Idade = empresa.Idade,
                            DataAbertura = empresa.DataAbertura,
                            CapitalSocial = empresa.CapitalSocial,
                            NaturezaJuridica = naturezaJuridica,
                            Porte = porte,
                            MatrizFilial = matrizFilial,
                            IdEndereco = empresa.IdEndereco,
                            Estado = estado
                        };
            }

            if (filtroEmpresaEnderecoOtd.NaturezaJuridicaFiltro != null)
            {
                query = from empresa in query
                        where empresa.NaturezaJuridica == filtroEmpresaEnderecoOtd.NaturezaJuridicaFiltro
                        select empresa;
            }

            if (filtroEmpresaEnderecoOtd.PorteFiltro != null)
            {
                query = from empresa in query
                        where empresa.Porte == filtroEmpresaEnderecoOtd.PorteFiltro
                        select empresa;
            }

            if (filtroEmpresaEnderecoOtd.MatrizFilialFiltro != null)
            {
                query = from empresa in query
                        where empresa.MatrizFilial == filtroEmpresaEnderecoOtd.MatrizFilialFiltro
                        select empresa;
            }

            if (filtroEmpresaEnderecoOtd.EstadoFiltro != null)
            {
                query = from empresa in query
                        where empresa.Estado == filtroEmpresaEnderecoOtd.EstadoFiltro
                        select empresa;
            }

            if (filtroEmpresaEnderecoOtd.DataSituacaoCadastralFiltro != null)
            {
                if (filtroEmpresaEnderecoOtd.MaiorOuIgualDataSituacaoCadastral == null)
                {
                    query = from empresa in query
                            where empresa.DataSituacaoCadastral == filtroEmpresaEnderecoOtd.DataSituacaoCadastralFiltro
                            select empresa;
                }
                else if(filtroEmpresaEnderecoOtd.MaiorOuIgualDataSituacaoCadastral.Value)
                {
                    query = from empresa in query
                            where empresa.DataSituacaoCadastral >= filtroEmpresaEnderecoOtd.DataSituacaoCadastralFiltro
                            select empresa;
                }
                else
                {
                    query = from empresa in query
                            where empresa.DataSituacaoCadastral <= filtroEmpresaEnderecoOtd.DataSituacaoCadastralFiltro
                            select empresa;
                }
            }

            if (filtroEmpresaEnderecoOtd.DataAberturaFiltro != null)
            {
                if (filtroEmpresaEnderecoOtd.MaiorOuIgualDataAbertura == null)
                {
                    query = from empresa in query
                            where empresa.DataAbertura == filtroEmpresaEnderecoOtd.DataAberturaFiltro
                            select empresa;
                }
                else if(filtroEmpresaEnderecoOtd.MaiorOuIgualDataAbertura.Value)
                {
                    query = from empresa in query
                            where empresa.DataAbertura >= filtroEmpresaEnderecoOtd.DataAberturaFiltro && filtroEmpresaEnderecoOtd.MaiorOuIgualDataAbertura.Value
                            select empresa;
                }
                else
                {
                    query = from empresa in query
                            where empresa.DataAbertura <= filtroEmpresaEnderecoOtd.DataAberturaFiltro
                            select empresa;
                }
            }

            if (filtroEmpresaEnderecoOtd.CapitalSocialFiltro != null)
            {
                if (filtroEmpresaEnderecoOtd.MaiorOuIgualCapitalSocial == null)
                {
                    query = from empresa in query
                            where empresa.CapitalSocial == filtroEmpresaEnderecoOtd.CapitalSocialFiltro
                            select empresa;
                }
                else if(filtroEmpresaEnderecoOtd.MaiorOuIgualCapitalSocial.Value)
                {
                    query = from empresa in query
                            where empresa.CapitalSocial >= filtroEmpresaEnderecoOtd.CapitalSocialFiltro
                            select empresa;
                }
                else
                {
                    query = from empresa in query
                            where empresa.CapitalSocial <= filtroEmpresaEnderecoOtd.CapitalSocialFiltro
                            select empresa;
                }
            }

            if (filtroEmpresaEnderecoOtd.IdadeFiltro != null)
            {
                if (filtroEmpresaEnderecoOtd.MaiorOuIgualIdade == null)
                {
                    query = from empresa in query
                            where empresa.Idade == filtroEmpresaEnderecoOtd.IdadeFiltro
                            select empresa;
                }
                else if(filtroEmpresaEnderecoOtd.MaiorOuIgualIdade.Value)
                {
                    query = from empresa in query
                            where empresa.Idade >= filtroEmpresaEnderecoOtd.IdadeFiltro
                            select empresa;
                }
                else
                {
                    query = from empresa in query
                            where empresa.Idade <= filtroEmpresaEnderecoOtd.IdadeFiltro
                            select empresa;
                }
            }

            if (filtroEmpresaEnderecoOtd.RazaoSocialFiltro != null)
            {
                query = from empresa in query
                        where empresa.RazaoSocial.Contains(filtroEmpresaEnderecoOtd.RazaoSocialFiltro)
                        select empresa;
            }

            if (filtroEmpresaEnderecoOtd.NomeFantasiaFiltro != null)
            {
                query = from empresa in query
                        where empresa.NomeFantasia.Contains(filtroEmpresaEnderecoOtd.NomeFantasiaFiltro)
                        select empresa;
            }

            if (filtroEmpresaEnderecoOtd.IdEnderecoFiltro != null)
            {
                query = from empresa in query
                        where empresa.IdEndereco == filtroEmpresaEnderecoOtd.IdEnderecoFiltro
                        select empresa;
            }

            if (filtroEmpresaEnderecoOtd.CnpjFiltro != null)
            {
                query = from empresa in query
                        where empresa.Cnpj.Contains(filtroEmpresaEnderecoOtd.CnpjFiltro)
                        select empresa;
            }
        }

        return query.ToList();
    }
}