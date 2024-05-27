using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Infra.Repositorios;

namespace Cod3rsGrowth.Testes.Mocks;

public class MockRepositorioEstado : IRepositorioEstado
{
    TabelaSingleton Tabelas = TabelaSingleton.Instance;

    public void Atualizar(Estado entidade)
    {
        var objeto = Tabelas._estados.Value.Find(x => x.Id == entidade.Id);

        Tabelas._estados.Value.Remove(objeto);
        Tabelas._estados.Value.Add(entidade);
    }

    public void Criar(Estado entidade)
    {
        Tabelas._estados.Value.Add(entidade);
    }

    public void Deletar(Estado entidade)
    {
        Tabelas._estados.Value.Remove(entidade);
    }

    public Estado ObterPorId(int Id)
    {
        return Tabelas._estados.Value.Find(x => x.Id == Id); 
    }

    public List<Estado> ObterTodos()
    {
        return Tabelas._estados.Value;
    }
}