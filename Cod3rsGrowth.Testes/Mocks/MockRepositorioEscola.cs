using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Infra.Repositorios;

namespace Cod3rsGrowth.Testes.Mocks;

public class MockRepositorioEscola : IRepositorioEscola
{
    TabelaSingleton Tabelas = TabelaSingleton.Instance;

    public void Atualizar(Escola entidade)
    {
        var objeto = Tabelas._escolas.Value.Find(x => x.Id == entidade.Id);

        Tabelas._escolas.Value.Remove(objeto);
        Tabelas._escolas.Value.Add(entidade);
    }

    public void Criar(Escola entidade)
    {
        Tabelas._escolas.Value.Add(entidade);
    }

    public void Deletar(Escola entidade)
    {
        Tabelas._escolas.Value.Remove(entidade);
    }

    public Escola ObterPorId(int Id)
    {
        return Tabelas._escolas.Value.Find(x => x.Id == Id); 
    }

    public List<Escola> ObterTodos()
    {
        return Tabelas._escolas.Value;
    }
}