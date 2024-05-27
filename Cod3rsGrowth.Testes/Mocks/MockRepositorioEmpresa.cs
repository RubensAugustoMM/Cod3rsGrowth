using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Infra.Repositorios;

namespace Cod3rsGrowth.Testes.Mocks;

public class MockRepositorioEmpresa : IRepositorioEmpresa
{
    TabelaSingleton Tabelas = TabelaSingleton.Instance;

    public void Atualizar(Empresa entidade)
    {
        var objeto = Tabelas._empresas.Value.Find(x => x.Id == entidade.Id);

        Tabelas._empresas.Value.Remove(objeto);
        Tabelas._empresas.Value.Add(entidade);
    }

    public void Criar(Empresa entidade)
    {
        Tabelas._empresas.Value.Add(entidade);
    }

    public void Deletar(Empresa entidade)
    {
        Tabelas._empresas.Value.Remove(entidade);
    }

    public Empresa ObterPorId(int Id)
    {
        return Tabelas._empresas.Value.Find(x => x.Id == Id); 
    }

    public List<Empresa> ObterTodos()
    {
        return Tabelas._empresas.Value;
    }
}