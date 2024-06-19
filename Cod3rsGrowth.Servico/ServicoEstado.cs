using Cod3rsGrowth.Dominio.Filtros;
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
        ObterPorId(estadoAtualizado.Id);
        _validadorEstado.ValidateAndThrow(estadoAtualizado);
        _repositorioEstado.Atualizar(estadoAtualizado);
    }

    public void Criar(Estado estadoCriado)
    {
        _validadorEstado.ValidateAndThrow(estadoCriado);
        _repositorioEstado.Criar(estadoCriado);
    }

    public void Deletar(int Id)
    {
        var EstadoDeletar = _repositorioEstado.ObterPorId(Id);
        var ResultadoValidacao = _validadorEstado.Validate(EstadoDeletar, options => options.IncludeRuleSets("Deletar"));

        if (!ResultadoValidacao.IsValid)
            throw new ValidationException(ResultadoValidacao.Errors.First().ErrorMessage);
        
        _repositorioEstado.Deletar(Id);
    }

    public Estado ObterPorId(int Id)
    {
        return _repositorioEstado.ObterPorId(Id);
    }

    public List<Estado> ObterTodos(FiltroEstado filtroEstado)
    {
        return _repositorioEstado.ObterTodos(filtroEstado);
    }
}