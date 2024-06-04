using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;

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
        Tabelas.Estados.Value.Add(estadoCriado);
    }

    public void Deletar(int id)
    {
        var EstadoDeletado = ObterPorId(id);

        Tabelas.Estados.Value.Remove(EstadoDeletado);
    }

    public Estado ObterPorId(int Id)
    {
        if (Id < 0)
            throw new ArgumentOutOfRangeException("Valor negativo informado ao metodo!\n");


        return Tabelas.Estados.Value.FirstOrDefault(c => c.Id == Id) ?? throw new Exception($"Nenhum Estado com Id {Id} existe no contexto atual!\n");
    }

    public List<Estado> ObterTodos()
    {
        return Tabelas.Estados.Value;
    }
}