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
        var ItemRemover = Tabelas.DicionarioTabelas[typeof(T)].Value.Find(x => x.Id == entidade.Id);

        if (ItemRemover != null)
        {
            Tabelas.DicionarioTabelas[typeof(T)].Value.Remove(ItemRemover);
            Tabelas.DicionarioTabelas[typeof(T)].Value.Add(entidade);
        }
    }

    public void Criar(T entidade)
    {
        Tabelas.DicionarioTabelas[typeof(T)].Value.Add(entidade);
    }

    public void Deletar(T entidade)
    {
        Tabelas.DicionarioTabelas[typeof(T)].Value.Remove(entidade);
    }
    public T ObterPorId(int Id)
    { 
        return (T)Tabelas.DicionarioTabelas[typeof(T)].Value.Find(x => x.Id == Id);
    }

    public List<T> ObterTodos()
    {
        return Tabelas.DicionarioTabelas[typeof(T)].Value.Cast<T>().ToList();
    }
}