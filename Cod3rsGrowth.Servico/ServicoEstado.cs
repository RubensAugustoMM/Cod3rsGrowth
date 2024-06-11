using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Servico.Validacoes;
using FluentValidation;

namespace Cod3rsGrowth.Servico;

public class ServicoEstado : IRepositorioEstado
{
    private readonly IRepositorioEstado _repositorioEstado;
    private readonly ValidadorEstado _validadorEstado;

    public ServicoEstado(IRepositorioEstado repositorioEstado, ValidadorEstado validadorEstado)
    {
        _repositorioEstado = repositorioEstado;
        _validadorEstado = validadorEstado;
    }

    public void Atualizar(Estado estadoAtualizado)
    {
        throw new NotImplementedException();
    }

    public void Criar(Estado estadoCriado)
    {
        _validadorEstado.ValidateAndThrow(estadoCriado);
        _repositorioEstado.Criar(estadoCriado);
    }

    public void Deletar(int Id)
    {
        throw new NotImplementedException();
    }

    public Estado ObterPorId(int Id)
    {
        return _repositorioEstado.ObterPorId(Id);
    }

    public List<Estado> ObterTodos()
    {
        return _repositorioEstado.ObterTodos();
    }
}