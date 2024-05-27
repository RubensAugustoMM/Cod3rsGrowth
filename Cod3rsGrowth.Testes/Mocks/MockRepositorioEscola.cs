using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Infra.Repositorios;

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
        escolaExistente.ListaConvenios = escolaAtualizada.ListaConvenios;
    }

    public void Criar(Escola escolaCriada)
    {
        Tabelas._escolas.Value.Add(escolaCriada);
    }

    public void Deletar(Escola escolaDeletada)
    {
        Tabelas._escolas.Value.Remove(escolaDeletada);
    }

    public Escola ObterPorId(int Id)
    {
        return Tabelas._escolas.Value.FirstOrDefault(c => c.Id == Id) ?? throw new NullReferenceException();
    }

    public List<Escola> ObterTodos()
    {
        return Tabelas._escolas.Value;
    }
}