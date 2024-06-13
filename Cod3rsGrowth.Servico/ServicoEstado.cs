using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Servico.Validacoes;
using FluentValidation;

namespace Cod3rsGrowth.Servico;

public class ServicoEstado : IRepositorioEstado
{
    private readonly IRepositorioEstado _repositorioEstado;
    private readonly IRepositorioEndereco _repositorioEndereco;
    private readonly ValidadorEstado _validadorEstado;

    public ServicoEstado(IRepositorioEstado repositorioEstado,IRepositorioEndereco repositorioEndereco, ValidadorEstado validadorEstado)
    {
        _repositorioEstado = repositorioEstado;
        _repositorioEndereco = repositorioEndereco;
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
        var ListaEnderecos = _repositorioEndereco.ObterTodos();
        var Endereco = ListaEnderecos.FirstOrDefault(endereco => endereco.IdEstado == Id);

        if (Endereco != null)
            throw new Exception("Nao e possivel excluir Estado relacionado a Endereco existente!");

        _repositorioEstado.Deletar(Id);
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