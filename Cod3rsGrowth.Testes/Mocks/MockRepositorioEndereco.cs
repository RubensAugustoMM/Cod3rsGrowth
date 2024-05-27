using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Infra.Repositorios;

namespace Cod3rsGrowth.Testes.Mocks;

public class MockRepositorioEndereco : IRepositorioEndereco
{
    TabelaSingleton Tabelas = TabelaSingleton.Instance;

    public void Atualizar(Endereco entidade)
    {
        var objeto = Tabelas._enderecos.Value.Find(x => x.Id == entidade.Id);

        Tabelas._enderecos.Value.Remove(objeto);
        Tabelas._enderecos.Value.Add(entidade);
    }

    public void Criar(Endereco entidade)
    {
        Tabelas._enderecos.Value.Add(entidade);
    }

    public void Deletar(Endereco entidade)
    {
        Tabelas._enderecos.Value.Remove(entidade);
    }

    public Endereco ObterPorId(int Id)
    {
        return Tabelas._enderecos.Value.Find(x => x.Id == Id); 
    }

    public List<Endereco> ObterTodos()
    {
        return Tabelas._enderecos.Value;
    }
}