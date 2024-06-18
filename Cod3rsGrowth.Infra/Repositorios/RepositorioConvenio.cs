﻿using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;
using LinqToDB;

namespace Cod3rsGrowth.Infra.Repositorios;

public class RepositorioConvenio : IRepositorioConvenio
{
    public void Atualizar(Convenio convenioAtualizado)
    {
        throw new NotImplementedException();
    }

    public void Criar(Convenio convenioCriado)
    {
        throw new NotImplementedException();
    }

    public void Deletar(int id)
    {
        throw new NotImplementedException();
    }

    public Convenio ObterPorId(int Id)
    {
        throw new NotImplementedException();
    }

    public List<Convenio> ObterTodos(FiltroConvenio? filtroConvenio)
    {
        using (var contexto = new ContextoAplicacao())
        {
            IQueryable<Convenio> query;

            query = from c in contexto.TabelaConvenios
                    select c;

            if (filtroConvenio != null)
            {
                if (filtroConvenio.IdEscolaFiltro != null)
                    query = from c in query
                            where c.IdEscola == filtroConvenio.IdEscolaFiltro
                            select c;

                if (filtroConvenio.IdEscolaFiltro != null)
                    query = from c in query
                            where c.IdEmpresa == filtroConvenio.IdEmpresaFiltro
                            select c;

                if (filtroConvenio.DataInicioFiltro != null)
                {
                    if (filtroConvenio.MaiorOuIgualDataInicio == null)
                        query = from c in query
                                where c.DataInicio == filtroConvenio.DataInicioFiltro
                                select c;
                    else
                        query = from c in query
                                where c.DataInicio >= filtroConvenio.DataInicioFiltro && filtroConvenio.MaiorOuIgualDataInicio.Value ||
                                       c.DataInicio <= filtroConvenio.DataInicioFiltro && !filtroConvenio.MaiorOuIgualDataInicio.Value
                                select c;
                }

                if (filtroConvenio.ValorFiltro != null)
                {
                    if (filtroConvenio.MaiorOuIgualValor != null)
                        query = from c in query
                                where c.Valor == filtroConvenio.ValorFiltro
                                select c;
                    else
                        query = from c in query
                                where c.Valor >= filtroConvenio.ValorFiltro && filtroConvenio.MaiorOuIgualValor.Value ||
                                       c.Valor <= filtroConvenio.ValorFiltro && !filtroConvenio.MaiorOuIgualValor.Value
                                select c;
                }

                if (filtroConvenio.DataTerminoFiltro != null)
                {
                    if (filtroConvenio.MaiorOuIgualDataTermino == null)
                        query = from c in query
                                where c.DataTermino == filtroConvenio.DataTerminoFiltro
                                select c;
                    else
                        query = from c in query
                                where c.DataTermino >= filtroConvenio.DataTerminoFiltro && filtroConvenio.MaiorOuIgualDataTermino.Value ||
                                       c.DataTermino <= filtroConvenio.DataTerminoFiltro && !filtroConvenio.MaiorOuIgualDataTermino.Value
                                select c;
                }

                if (filtroConvenio.ObjetoFiltro != null)
                    query = from c in query
                            where c.Objeto.Contains(filtroConvenio.ObjetoFiltro)
                            select c;
            }

            return query.ToList();
        }
    }
}