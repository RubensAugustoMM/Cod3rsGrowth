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

    public List<Convenio> ObterTodos(string filtro)
    {
        using (var contexto = new ContextoAplicacao())
        {
            var query = from c in contexto.TabelaConvenios
                        where c.Objeto == filtro
                        select c;

            return query.ToList();
        }
    }
}