using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Infra.Repositorio;

namespace Cod3rsGrowth.Testes;

public class RepositorioMock<T> : IRepositorio<T> where T : IEntidade
{
    public void Atualizar(T entidade)
    {
        var tabelaSingleton = TabelaSingleton<T>.Instance;
        var itemRemover = tabelaSingleton.Tabela.Find(x => x.Id == entidade.Id);

        if (itemRemover != null)
        {
            tabelaSingleton.Tabela.Remove(itemRemover);
            tabelaSingleton.Tabela.Add(entidade);
        }
    }

    public void Criar(T entidade)
    {
        var tabelaSingleton = TabelaSingleton<T>.Instance;

        tabelaSingleton.Tabela.Add(entidade);
    }

    public void Deletar(T entidade)
    {
        var tabelaSingleton = TabelaSingleton<T>.Instance;

        tabelaSingleton.Tabela.Remove(entidade);
    }
    public T ObterPorId(int Id)
    {
        var tabelaSingleton = TabelaSingleton<T>.Instance;
        var tabela = TabelaSingleton<T>.Instance;

        return tabela.Tabela.Find(x => x.Id == Id);
    }

    public List<T> ObterTodos()
    {
        var tabelaSingleton = TabelaSingleton<T>.Instance;
        
        return tabelaSingleton.Tabela;
    }
}