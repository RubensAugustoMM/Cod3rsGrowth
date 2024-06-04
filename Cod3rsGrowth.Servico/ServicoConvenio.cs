using System.Linq.Expressions;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Servico.Validacoes;
using FluentValidation;

namespace Cod3rsGrowth.Servico;

public class ServicoConvenio : IRepositorioConvenio
{
    private readonly IRepositorioConvenio _repositorioConvenio;
    private ValidadorConvenio _validadorConvenio = new();

    public ServicoConvenio(IRepositorioConvenio repositorioConvenio)
    {
        _repositorioConvenio = repositorioConvenio;
    }

    public void Atualizar(Convenio convenioAtualizado)
    {
        throw new NotImplementedException();
    }

    public void Criar(Convenio convenioCriado)
    {
        _validadorConvenio.ValidateAndThrow(convenioCriado);
    }

    public void Deletar(int Id)
    {
        throw new NotImplementedException();
    }

    public Convenio ObterPorId(int Id)
    {
        return _repositorioConvenio.ObterPorId(Id);
    }

    public List<Convenio> ObterTodos()
    {
        return _repositorioConvenio.ObterTodos();
    }
}
