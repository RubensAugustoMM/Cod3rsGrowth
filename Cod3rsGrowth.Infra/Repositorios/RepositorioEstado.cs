using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;

namespace Cod3rsGrowth.Infra.Repositorios;

public class RepositorioEstado : IRepositorioEstado
{
    public void Atualizar(Estado estadoAtualizado)
    {
        throw new NotImplementedException();
    }

    public void Criar(Estado estadoCriado)
    {
        throw new NotImplementedException();
    }

    public void Deletar(int id)
    {
        throw new NotImplementedException();
    }

    public Estado ObterPorId(int Id)
    {
        throw new NotImplementedException();
    }

    public List<Estado> ObterTodos(string filtro)
    {
        using (var contexto = new ContextoAplicacao())
        {
            var query = from e in contexto.TabelaEstados
                        where e.Nome == filtro || e.Sigla == filtro
                        select e;

            return query.ToList();
        }
    }
}