using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;

namespace Cod3rsGrowth.Testes.Mocks;

public class MockRepositorioEscola : IRepositorioEscola
{
    TabelaSingleton Tabelas = TabelaSingleton.Instance;

    public void Atualizar(Escola escolaAtualizada)
    {
        var escolaExistente = ObterPorId(escolaAtualizada.Id);

        escolaExistente.StatusAtividade = escolaAtualizada.StatusAtividade;
        escolaExistente.Nome = escolaAtualizada.Nome;
        escolaExistente.CodigoMec = escolaAtualizada.CodigoMec;
        escolaExistente.Telefone = escolaAtualizada.Telefone;
        escolaExistente.Email = escolaAtualizada.Email;
        escolaExistente.InicioAtividade = escolaAtualizada.InicioAtividade;
        escolaExistente.CategoriaAdministrativa = escolaAtualizada.CategoriaAdministrativa;
        escolaExistente.OrganizacaoAcademica = escolaAtualizada.OrganizacaoAcademica;
        escolaExistente.IdEndereco = escolaAtualizada.IdEndereco;
    }

    public void Criar(Escola escolaCriada)
    {
        Tabelas.Escolas.Value.Add(escolaCriada);
    }

    public void Deletar(int id)
    {
        Tabelas.Escolas.Value.Remove(ObterPorId(id));
    }

    public Escola ObterPorId(int Id)
    {
        return Tabelas.Escolas.Value.FirstOrDefault(c => c.Id == Id) ?? throw new Exception($"Nenhuma Escola com Id {Id} existe no contexto atual!\n");
    }

    public List<Escola> ObterTodos(FiltroEscola? filtroEscola)
    {
        return Tabelas.Escolas.Value;
    }
}