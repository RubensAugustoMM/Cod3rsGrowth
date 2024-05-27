using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Infra.Repositorios;
using Microsoft.VisualBasic;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace Cod3rsGrowth.Testes.Mocks;

public class MockRepositorioConvenio : IRepositorioConvenio
{
    TabelaSingleton Tabelas = TabelaSingleton.Instance;

    public void Atualizar(Empresa entidade)
    {
        var objeto = Tabelas._convenios.Value.Find(x => x.Id == entidade.Id);

        Tabelas._convenios.Value.Remove(objeto);
        Tabelas._convenios.Value.Add(entidade);
    }

    public void Criar(Empresa entidade)
    {
        Tabelas._convenios.Value.Add(entidade);
    }

    public void Deletar(Empresa entidade)
    {
        Tabelas._convenios.Value.Remove(entidade);
    }

    public Empresa ObterPorId(int Id)
    {
        return Tabelas._convenios.Value.Find(x => x.Id == Id); 
    }

    public List<Empresa> ObterTodos()
    {
        return Tabelas._convenios.Value;
    }
}