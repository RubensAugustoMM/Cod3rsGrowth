using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Infra.Repositorio;

namespace Cod3rsGrowth.Testes;

public class RepositorioMock<T> : IRepositorio<T> where T : IEntidade
{
    Dictionary<int, T> Dados;

    public RepositorioMock()
    {
        Dados = new();
    }

    public void Atualizar(T entidade)
    {
        Dados.Remove(entidade.Id);
        Dados.Add(entidade.Id, entidade);
    }

    public void Criar(T entidade)
    {
        Dados.Add(entidade.Id, entidade);
    }

    public void Deletar(T entidade)
    {
        Dados.Remove(entidade.Id);
    }
    public T ObterPorId(int Id)
    {
        if (Dados.ContainsKey(Id))
            return Dados[Id];
        else
            return default(T);
    }

    public List<T> ObterTodos()
    {
        List<T> retorno = Dados.Select(dado => dado.Value).ToList();
        return retorno;
    }
}