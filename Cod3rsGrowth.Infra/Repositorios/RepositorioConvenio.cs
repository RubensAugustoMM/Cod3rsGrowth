using Cod3rsGrowth.Dominio.Filtros;
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
            List<Convenio> query = new();

            if (filtroConvenio == null)
            {
                query = (from c in contexto.TabelaConvenios
                         select c)
                        .ToList();

                return query;
            }

            if (filtroConvenio.IdEscolaFiltro != null)
                query = (from c in contexto.TabelaConvenios
                             where c.IdEscola == filtroConvenio.IdEscolaFiltro
                             select c)
                             .ToList();

            if(filtroConvenio.IdEscolaFiltro != null)
                query = (from c in contexto.TabelaConvenios
                             where c.IdEmpresa == filtroConvenio.IdEmpresaFiltro
                             select c)
                             .ToList();
 
            if (filtroConvenio.DataInicioFiltro != null)
            {
                if (filtroConvenio.MaiorOuIgualDataInicio == null)
                    query = (from c in contexto.TabelaConvenios
                             where c.DataInicio == filtroConvenio.DataInicioFiltro
                             select c)
                             .ToList();
                else
                    query = (from c in contexto.TabelaConvenios
                             where c.DataInicio >= filtroConvenio.DataInicioFiltro && filtroConvenio.MaiorOuIgualDataInicio.Value ||
                                   c.DataInicio <= filtroConvenio.DataInicioFiltro && !filtroConvenio.MaiorOuIgualDataInicio.Value
                             select c)
                             .ToList();
            }

            if (filtroConvenio.ValorFiltro != null)
            {
                if (filtroConvenio.MaiorOuIgualValor != null)
                    query = (from c in contexto.TabelaConvenios
                             where c.Valor == filtroConvenio.ValorFiltro
                             select c)
                             .ToList();
                else
                    query = (from c in contexto.TabelaConvenios
                             where c.Valor >= filtroConvenio.ValorFiltro && filtroConvenio.MaiorOuIgualValor.Value ||
                                   c.Valor <= filtroConvenio.ValorFiltro && !filtroConvenio.MaiorOuIgualValor.Value
                             select c)
                             .ToList();
            }

            if (filtroConvenio.DataTerminoFiltro != null)
            {
                if (filtroConvenio.MaiorOuIgualDataTermino == null)
                    query = (from c in contexto.TabelaConvenios
                             where c.DataTermino == filtroConvenio.DataTerminoFiltro
                             select c)
                             .ToList();
                else
                    query = (from c in contexto.TabelaConvenios
                             where c.DataTermino >= filtroConvenio.DataTerminoFiltro && filtroConvenio.MaiorOuIgualDataTermino.Value ||
                                   c.DataTermino <= filtroConvenio.DataTerminoFiltro && !filtroConvenio.MaiorOuIgualDataTermino.Value
                             select c)
                             .ToList();
            }
 
            if (filtroConvenio.ObjetoFiltro != null)
                query = (from c in contexto.TabelaConvenios
                         where c.Objeto.Contains(filtroConvenio.ObjetoFiltro)
                         select c)
                        .ToList();
                         
            return query;
        }
    }
}