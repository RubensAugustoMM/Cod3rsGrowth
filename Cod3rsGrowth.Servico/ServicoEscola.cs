using Cod3rsGrowth.Dominio;
using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Dominio.ObjetosTranferenciaDados;
using Cod3rsGrowth.Servico.Validacoes;
using FluentValidation;

namespace Cod3rsGrowth.Servico;

public class ServicoEscola : IRepositorioEscola
{
    private readonly IRepositorioEscola _repositorioEscola;
    private readonly IRepositorioEndereco _repositorioEndereco;
    private readonly ValidadorEscola _validadorEscola;

    public ServicoEscola(IRepositorioEscola repositorioEscola, IRepositorioEndereco repositorioEndereco, ValidadorEscola validadorEscola)
    {
        _repositorioEscola = repositorioEscola;
        _repositorioEndereco = repositorioEndereco;
        _validadorEscola = validadorEscola;
    }

    public void Atualizar(Escola escolaAtualizada)
    {
        ObterPorId(escolaAtualizada.Id);
        _validadorEscola.ValidateAndThrow(escolaAtualizada);
        _repositorioEscola.Atualizar(escolaAtualizada);
    }

    public void Criar(Escola escolaCriada)
    {
        _validadorEscola.ValidateAndThrow(escolaCriada);
        _repositorioEscola.Criar(escolaCriada);
    }

    public void Deletar(int id)
    {
        var EscolaEnderecoOtdDeletar = ObterPorId(id);
        Escola EscolaDeletar = new()
        {
            Id = EscolaEnderecoOtdDeletar.Id,
            StatusAtividade = EscolaEnderecoOtdDeletar.StatusAtividade,
            Nome = EscolaEnderecoOtdDeletar.Nome,
            CodigoMec = EscolaEnderecoOtdDeletar.CodigoMec,
            Telefone = EscolaEnderecoOtdDeletar.Telefone,
            Email = EscolaEnderecoOtdDeletar.Email,
            InicioAtividade = EscolaEnderecoOtdDeletar.InicioAtividade,
            CategoriaAdministrativa = EscolaEnderecoOtdDeletar.CategoriaAdministrativa,
            OrganizacaoAcademica = EscolaEnderecoOtdDeletar.OrganizacaoAcademica,
            IdEndereco = EscolaEnderecoOtdDeletar.IdEndereco
        };

        var ResultadoValidacao = _validadorEscola.Validate(EscolaDeletar, options => options.IncludeRuleSets("Deletar"));

        if (!ResultadoValidacao.IsValid)
            throw new ValidationException(ResultadoValidacao.Errors.First().ErrorMessage);
        
        _repositorioEndereco.Deletar(EscolaDeletar.IdEndereco);
        _repositorioEscola.Deletar(id);
    }

    public EscolaEnderecoOtd ObterPorId(int Id)
    {
        return _repositorioEscola.ObterPorId(Id);
    }

    public List<EscolaEnderecoOtd> ObterTodos(FiltroEscolaEnderecoOtd? filtroEscolaEnderecoOtd)
    {
        return _repositorioEscola.ObterTodos(filtroEscolaEnderecoOtd);
    }
}