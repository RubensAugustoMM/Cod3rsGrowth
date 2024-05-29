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
        escolaExistente.ListaConvenios = escolaAtualizada.ListaConvenios;
    }

    public void Criar(Escola escolaCriada)
    {
        Tabelas.Escolas.Value.Add(escolaCriada);
    }

    public void Deletar(int Id)
    {
        var EscolaDeletada = ObterPorId(Id);

        Tabelas.Escolas.Value.Remove(EscolaDeletada);
    }

    public Escola ObterPorId(int Id)
    {
        return Tabelas.Escolas.Value.FirstOrDefault(c => c.Id == Id) ?? throw new Exception("Nenhuma Escola possui Id correspondente ao fornecido\n");
    }

    public List<Escola> ObterTodos()
    {
        return Tabelas.Escolas.Value;
    }
}