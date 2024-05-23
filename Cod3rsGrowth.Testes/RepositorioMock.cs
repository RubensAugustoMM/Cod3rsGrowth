using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Infra.Repositorio;
using Microsoft.VisualBasic;

namespace Cod3rsGrowth.Testes;

public class RepositorioMock<T> : IRepositorio<T> where T : IEntidade
{
    TabelaSingleton Tabelas = TabelaSingleton.Instance;
    public void Atualizar(T entidade)
    {
        var ItemRemover = Tabelas.RetornaTabela<T>().Find(x => x.Id == entidade.Id);

        if (ItemRemover != null)
        {
            Tabelas.RetornaTabela<T>().Remove(ItemRemover);
            Tabelas.RetornaTabela<T>().Add(entidade);
        }
    }

    public void Criar(T entidade)
    {
        Tabelas.RetornaTabela<T>().Add(entidade);
    }

    public void Deletar(T entidade)
    {
        Tabelas.RetornaTabela<T>().Remove(entidade);
    }
    public T ObterPorId(int Id)
    { 
        return (T)Tabelas.RetornaTabela<T>().Find(x => x.Id == Id);
    }

    public List<T> ObterTodos()
    {
        return Tabelas.RetornaTabela<T>().Cast<T>().ToList();
    }
}