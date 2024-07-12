using Cod3rsGrowth.Dominio;
using Cod3rsGrowth.Dominio.Enums;
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

    public void Criar(ref Endereco enderecoCriado)
    {
        try
        {
            _validadorEndereco.ValidateAndThrow(enderecoCriado);
            _repositorioEndereco.Criar(ref enderecoCriado);
        }
        catch(Exception)
        {
            throw;
        }
    }

    public void Deletar(int Id)
    {
        var EnderecoOtdDeletar = ObterPorId(Id);
        Endereco EnderecoDeletar = new()
        {
            Id = EnderecoOtdDeletar.Id,
            Numero = EnderecoOtdDeletar.Numero,
            Cep = EnderecoOtdDeletar.Cep,
            Municipio = EnderecoOtdDeletar.Municipio,
            Bairro = EnderecoOtdDeletar.Bairro,
            Rua = EnderecoOtdDeletar.Rua,
            Complemento = EnderecoOtdDeletar.Complemento,
            Estado = EnderecoOtdDeletar.Estado
        };

        var ResultadoValidacao = _validadorEndereco.Validate(EnderecoDeletar, options => options.IncludeRuleSets("Deletar")); 

        if (!ResultadoValidacao.IsValid)
            throw new ValidationException(ResultadoValidacao.Errors.First().ErrorMessage);
        
        _repositorioEndereco.Deletar(Id);
    }

    public Endereco ObterPorId(int Id)
    {
        return _repositorioEndereco.ObterPorId(Id);
    }

    public List<Endereco> ObterTodos(FiltroEndereco? filtroEnderecoOtd)
    {
        return _repositorioEndereco.ObterTodos(filtroEnderecoOtd);
    }
}