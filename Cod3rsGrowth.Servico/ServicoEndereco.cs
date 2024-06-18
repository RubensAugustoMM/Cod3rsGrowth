using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Servico.Validacoes;
using FluentValidation;

namespace Cod3rsGrowth.Servico;

public class ServicoEndereco : IRepositorioEndereco
{
    private readonly IRepositorioEndereco _repositorioEndereco;
    private readonly ValidadorEndereco _validadorEndereco;

    public ServicoEndereco(IRepositorioEndereco repositorioEndereco, ValidadorEndereco validadorEndereco)
    {
        _repositorioEndereco = repositorioEndereco;
        _validadorEndereco = validadorEndereco;
    }

    public void Atualizar(Endereco enderecoAtualizado)
    {
        ObterPorId(enderecoAtualizado.Id);
        _validadorEndereco.ValidateAndThrow(enderecoAtualizado);
        _repositorioEndereco.Atualizar(enderecoAtualizado);
    }

    public void Criar(Endereco enderecoCriado)
    {
        _validadorEndereco.ValidateAndThrow(enderecoCriado);
        _repositorioEndereco.Criar(enderecoCriado);
    }

    public void Deletar(int Id)
    {
        var EnderecoDeletar = ObterPorId(Id);
        var ResultadoValidacao = _validadorEndereco.Validate(EnderecoDeletar, options => options.IncludeRuleSets("Deletar")); 

        if (!ResultadoValidacao.IsValid)
            throw new ValidationException(ResultadoValidacao.Errors.First().ErrorMessage);
        
        _repositorioEndereco.Deletar(Id);
    }

    public Endereco ObterPorId(int Id)
    {
        return _repositorioEndereco.ObterPorId(Id);
    }

    public List<Endereco> ObterTodos(FiltroEndereco? filtroEndereco)
    {
        return _repositorioEndereco.ObterTodos(filtroEndereco);
    }
}