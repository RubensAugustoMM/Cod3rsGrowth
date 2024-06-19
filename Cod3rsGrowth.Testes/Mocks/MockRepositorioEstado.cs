using Cod3rsGrowth.Dominio.Filtros;
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
        Tabelas.Estados.Value.Remove(ObterPorId(id));
    }

    public Estado ObterPorId(int Id)
    {
        return Tabelas.Estados.Value.FirstOrDefault(c => c.Id == Id) ?? throw new Exception($"Nenhum Estado com Id {Id} existe no contexto atual!\n");
    }

    public List<Estado> ObterTodos(FiltroEstado? filtroEstado)
    {
        return Tabelas.Estados.Value;
    }
}