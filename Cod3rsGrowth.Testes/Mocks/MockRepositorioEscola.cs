using Cod3rsGrowth.Dominio;
using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Dominio.ObjetosTranferenciaDados;

namespace Cod3rsGrowth.Testes.Mocks;

public class MockRepositorioEscola : IRepositorioEscola
{
    TabelaSingleton Tabelas = TabelaSingleton.Instance;

    public void Atualizar(Escola escolaAtualizada)
    {
        var escolaExistente = ObterPorIdModelo(escolaAtualizada.Id);

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
        Tabelas.Escolas.Value.Remove(ObterPorIdModelo(id));
    }

    public EscolaEnderecoOtd ObterPorId(int id)
    {
        var EscolaRetornada = ObterPorIdModelo(id);
        var EnderecoRetornado = Tabelas.Enderecos.Value.FirstOrDefault(e => e.Id == EscolaRetornada.IdEndereco) ?? throw new Exception($"Nenhum Endereco com Id {EscolaRetornada.IdEndereco} existe no contexto atual!\n");
        
        var EscolaEnderecoOtdRetornado = new EscolaEnderecoOtd()
        {
            Id = EscolaRetornada.Id,
            StatusAtividade = EscolaRetornada.StatusAtividade,
            Nome = EscolaRetornada.Nome,
            CodigoMec = EscolaRetornada.CodigoMec,
            Telefone = EscolaRetornada.Telefone,
            Email = EscolaRetornada.Email,
            InicioAtividade = EscolaRetornada.InicioAtividade,
            CategoriaAdministrativa = EnumExtencoes.RetornaDescricao(EscolaRetornada.CategoriaAdministrativa),
            OrganizacaoAcademica = EnumExtencoes.RetornaDescricao(EscolaRetornada.OrganizacaoAcademica),
            IdEndereco = EscolaRetornada.IdEndereco,
            Estado = EnumExtencoes.RetornaDescricao(EnderecoRetornado.Estado)

        };

        return EscolaEnderecoOtdRetornado;
    }

    public List<EscolaEnderecoOtd> ObterTodos(FiltroEscolaEnderecoOtd? filtroEscolaEnderecoOtd)
    {
        var ListaEscolas = Tabelas.Escolas.Value;
        List<EscolaEnderecoOtd> ListaEscolaEnderecoOtd = new();

        foreach (var escola in ListaEscolas)
        {
            var EnderecoRetornado = Tabelas.Enderecos.Value.FirstOrDefault(e => e.Id == escola.IdEndereco) ?? throw new Exception($"Nenhum Endereco com Id {escola.IdEndereco} existe no contexto atual!\n");

            ListaEscolaEnderecoOtd.Add(new EscolaEnderecoOtd()
            {
                Id = escola.Id,
                StatusAtividade = escola.StatusAtividade,
                Nome = escola.Nome,
                CodigoMec = escola.CodigoMec,
                Telefone = escola.Telefone,
                Email = escola.Email,
                InicioAtividade = escola.InicioAtividade,
                CategoriaAdministrativa = EnumExtencoes.RetornaDescricao(escola.CategoriaAdministrativa),
                OrganizacaoAcademica = EnumExtencoes.RetornaDescricao(escola.OrganizacaoAcademica),
                IdEndereco = escola.IdEndereco,
                Estado = EnumExtencoes.RetornaDescricao(EnderecoRetornado.Estado)
            });
        }

        return ListaEscolaEnderecoOtd;
    }

    private Escola ObterPorIdModelo(int id)
    {
        return Tabelas.Escolas.Value.FirstOrDefault(c => c.Id == id) ?? throw new Exception($"Nenhuma Escola com Id {id} existe no contexto atual!\n");
    }
}