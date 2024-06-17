using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;

namespace Cod3rsGrowth.Infra.Repositorios;

public class RepositorioEscola : IRepositorioEscola
{
    public void Atualizar(Escola escolaAtualizada)
    {
        throw new NotImplementedException();
    }

    public void Criar(Escola escolaCriada)
    {
        throw new NotImplementedException();
    }

    public void Deletar(int id)
    {
        throw new NotImplementedException();
    }

    public Escola ObterPorId(int Id)
    {
        throw new NotImplementedException();
    }

    public List<Escola> ObterTodos(string filtro)
    {
        using (var contexto = new ContextoAplicacao())
        {
            if (string.IsNullOrWhiteSpace(filtro))
                return contexto.TabelaEscolas.ToList();

            var query = from e in contexto.TabelaEscolas
                        where e.Nome == filtro
                        select e;

            return query.ToList();
        }
    }
}