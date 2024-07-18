using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Dominio.ObjetosTranferenciaDados;
using LinqToDB;
using Microsoft.IdentityModel.Tokens;

namespace Cod3rsGrowth.Infra.Repositorios;

public class RepositorioConvenio : IRepositorioConvenio
{
    private readonly ContextoAplicacao _contexto;

    public RepositorioConvenio(ContextoAplicacao contexto)
    {
        _contexto = contexto;
    }

    public void Atualizar(Convenio convenioAtualizado)
    {
        _contexto.Update(convenioAtualizado);
    }

    public void Criar(Convenio convenioCriado)
    {
        convenioCriado.Id = _contexto.InsertWithInt32Identity(convenioCriado);
    }

    public void Deletar(int id)
    {
        _contexto.TabelaConvenios.Where(c => c.Id == id).Delete();
    }

    public ConvenioEscolaEmpresaOtd ObterPorId(int Id)
    {
        IQueryable<ConvenioEscolaEmpresaOtd> query = from convenio in _contexto.TabelaConvenios
                                     where convenio.Id == Id
                                     join escola in _contexto.TabelaEscolas on convenio.IdEscola equals escola.Id
                                     join empresa in _contexto.TabelaEmpresas on convenio.IdEmpresa equals empresa.Id
                                     select new ConvenioEscolaEmpresaOtd
                                     {
                                        Id = convenio.Id,
                                        NumeroProcesso = convenio.NumeroProcesso,
                                        Objeto = convenio.Objeto,
                                        Valor = convenio.Valor,
                                        DataInicio = convenio.DataInicio,
                                        DataTermino = convenio.DataTermino,
                                        IdEscola = convenio.IdEscola,
                                        NomeEscola = escola.Nome,
                                        IdEmpresa = convenio.IdEmpresa,
                                        RazaoSocialEmpresa = empresa.RazaoSocial 
                                     };

        return query.FirstOrDefault() ?? throw new Exception($"Nenhum Convenio com Id {Id} existe no contexto atual!\n"); 
    }

    public List<ConvenioEscolaEmpresaOtd> ObterTodos(FiltroConvenioEscolaEmpresaOtd? filtroConvenioEscolaEmpresaOtd)
    {
        IQueryable<ConvenioEscolaEmpresaOtd> query = from convenio in _contexto.TabelaConvenios
                                     join escola in _contexto.TabelaEscolas on convenio.IdEscola equals escola.Id
                                     join empresa in _contexto.TabelaEmpresas on convenio.IdEmpresa equals empresa.Id
                                     select new ConvenioEscolaEmpresaOtd
                                     {
                                        Id = convenio.Id,
                                        NumeroProcesso = convenio.NumeroProcesso,
                                        Objeto = convenio.Objeto,
                                        Valor = convenio.Valor,
                                        DataInicio = convenio.DataInicio,
                                        DataTermino = convenio.DataTermino,
                                        IdEscola = convenio.IdEscola,
                                        NomeEscola = escola.Nome,
                                        IdEmpresa = convenio.IdEmpresa,
                                        RazaoSocialEmpresa = empresa.RazaoSocial  
                                     };

        if (filtroConvenioEscolaEmpresaOtd != null)
        {
            if (filtroConvenioEscolaEmpresaOtd.IdEscolaFiltro != null)
            {
                query = from convenio in query
                        where convenio.IdEscola == filtroConvenioEscolaEmpresaOtd.IdEscolaFiltro
                        select convenio;
            }

            if(filtroConvenioEscolaEmpresaOtd.NomeEscolaFiltro != null)
            {
                query = from convenio in query
                        where convenio.NomeEscola.Contains(filtroConvenioEscolaEmpresaOtd.NomeEscolaFiltro)
                        select convenio;
            }

            if (filtroConvenioEscolaEmpresaOtd.IdEmpresaFiltro != null)
            {
                query = from c in query
                        where c.IdEmpresa == filtroConvenioEscolaEmpresaOtd.IdEmpresaFiltro
                        select c;
            }

            if(filtroConvenioEscolaEmpresaOtd.RazaoSocialEmpresaFiltro != null)
            {
                query = from convenio in query
                        where convenio.RazaoSocialEmpresa.Contains(filtroConvenioEscolaEmpresaOtd.RazaoSocialEmpresaFiltro)
                        select convenio;
            }

            if (filtroConvenioEscolaEmpresaOtd.DataInicioFiltro != null)
            {
                if (filtroConvenioEscolaEmpresaOtd.MaiorOuIgualDataInicio == null)
                {
                    query = from c in query
                            where c.DataInicio == filtroConvenioEscolaEmpresaOtd.DataInicioFiltro
                            select c;
                }
                else if(filtroConvenioEscolaEmpresaOtd.MaiorOuIgualDataInicio.Value)
                {
                    query = from c in query
                            where c.DataInicio >= filtroConvenioEscolaEmpresaOtd.DataInicioFiltro
                            select c;
                }
                else
                {
                    query = from c in query
                            where c.DataInicio <= filtroConvenioEscolaEmpresaOtd.DataInicioFiltro
                            select c;
                }
            }

            if (filtroConvenioEscolaEmpresaOtd.ValorFiltro != null)
            {
                if (filtroConvenioEscolaEmpresaOtd.MaiorOuIgualValor == null)
                {
                    query = from c in query
                            where c.Valor == filtroConvenioEscolaEmpresaOtd.ValorFiltro
                            select c;
                }
                else if(filtroConvenioEscolaEmpresaOtd.MaiorOuIgualValor.Value)
                {
                    query = from c in query
                            where c.Valor >= filtroConvenioEscolaEmpresaOtd.ValorFiltro
                            select c;
                }
                else
                {
                    query = from c in query
                            where c.Valor <= filtroConvenioEscolaEmpresaOtd.ValorFiltro
                            select c;
                }
            }

            if (filtroConvenioEscolaEmpresaOtd.DataTerminoFiltro != null)
            {
                if (filtroConvenioEscolaEmpresaOtd.MaiorOuIgualDataTermino == null)
                {
                    query = from c in query
                            where c.DataTermino == filtroConvenioEscolaEmpresaOtd.DataTerminoFiltro
                            select c;
                }
                else if(filtroConvenioEscolaEmpresaOtd.MaiorOuIgualDataTermino.Value)
                {
                    query = from c in query
                            where c.DataTermino >= filtroConvenioEscolaEmpresaOtd.DataTerminoFiltro
                            select c;
                }
                else
                {
                    query = from c in query
                            where c.DataTermino <= filtroConvenioEscolaEmpresaOtd.DataTerminoFiltro
                            select c;
                }
            }

            if (filtroConvenioEscolaEmpresaOtd.ObjetoFiltro != null)
            {
                query = from c in query
                        where c.Objeto.Contains(filtroConvenioEscolaEmpresaOtd.ObjetoFiltro)
                        select c;
            }
        }

        return query.ToList();
    }
}