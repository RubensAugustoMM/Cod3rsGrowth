using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Servico.Validacoes;

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

    public bool Criar(Estado estadoCriado)
    {
        var EstadoValido = _validadorEstado.Validate(estadoCriado);

        if (EstadoValido.IsValid)
            _repositorioEstado.Criar(estadoCriado);

        return EstadoValido.IsValid;
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