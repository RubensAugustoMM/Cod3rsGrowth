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

    public void Atualizar(Endereco endrecoAtualizado)
    {
        throw new NotImplementedException();
    }

    public void Criar(Endereco enderecoCriado)
    {
        _validadorEndereco.ValidateAndThrow(enderecoCriado);
        _repositorioEndereco.Criar(enderecoCriado);
    }

    public void Deletar(int Id)
    {
        throw new NotImplementedException();
    }

    public Endereco ObterPorId(int Id)
    {
        return _repositorioEndereco.ObterPorId(Id);
    }

    public List<Endereco> ObterTodos()
    {
        return _repositorioEndereco.ObterTodos();
    }
}