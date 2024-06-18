using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Servico.Validacoes;
using FluentValidation;

namespace Cod3rsGrowth.Servico;

public class ServicoConvenio : IRepositorioConvenio
{
    private readonly IRepositorioConvenio _repositorioConvenio;
    private readonly ValidadorConvenio _validadorConvenio;

    public ServicoConvenio(IRepositorioConvenio repositorioConvenio, ValidadorConvenio validadorConvenio)
    {
        _repositorioConvenio = repositorioConvenio;
        _validadorConvenio = validadorConvenio;
    }

    public void Atualizar(Convenio convenioAtualizado)
    {
        ObterPorId(convenioAtualizado.Id);
        _validadorConvenio.ValidateAndThrow(convenioAtualizado);
        _repositorioConvenio.Atualizar(convenioAtualizado);
    }

    public void Criar(Convenio convenioCriado)
    {
        _validadorConvenio.ValidateAndThrow(convenioCriado);
        _repositorioConvenio.Criar(convenioCriado);
    }

    public void Deletar(int id)
    {
        _repositorioConvenio.Deletar(id);
    }

    public Convenio ObterPorId(int Id)
    {
        return _repositorioConvenio.ObterPorId(Id);
    }

    public List<Convenio> ObterTodos(FiltroConvenio? filtroConvenio)
    {
        return _repositorioConvenio.ObterTodos(filtroConvenio);
    }
}
