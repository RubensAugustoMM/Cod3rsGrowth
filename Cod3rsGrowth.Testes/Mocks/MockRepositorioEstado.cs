using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Infra.Repositorios;

namespace Cod3rsGrowth.Testes.Mocks;

public class MockRepositorioEstado : IRepositorioEstado
{
    TabelaSingleton Tabelas = TabelaSingleton.Instance;

    public void Atualizar(Estado estadoAtualizado)
    {
        var estadoExistente = ObterPorId(estadoAtualizado.Id);

        estadoExistente.Nome = estadoAtualizado.Nome;
        estadoExistente.Sigla = estadoAtualizado.Sigla;
        estadoExistente.ListaEnderecos = estadoAtualizado.ListaEnderecos;
    }

    public void Criar(Estado estadoCriado)
    {
        Tabelas._estados.Value.Add(estadoCriado);
    }

    public void Deletar(Estado estadoDeletado)
    {
        Tabelas._estados.Value.Remove(estadoDeletado);
    }

    public Estado ObterPorId(int Id)
    {
        return Tabelas._estados.Value.FirstOrDefault(c => c.Id == Id) ?? throw new NullReferenceException();
    }

    public List<Estado> ObterTodos()
    {
        return Tabelas._estados.Value;
    }
}