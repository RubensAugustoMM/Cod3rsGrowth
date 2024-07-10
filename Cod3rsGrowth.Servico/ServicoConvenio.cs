using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Dominio.ObjetosTranferenciaDados;
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

    public int Criar(Convenio convenioCriado)
    {
        _validadorConvenio.ValidateAndThrow(convenioCriado);
        return _repositorioConvenio.Criar(convenioCriado);
    }

    public void Deletar(int id)
    {
        _repositorioConvenio.Deletar(id);
    }

    public ConvenioEscolaEmpresaOtd ObterPorId(int Id)
    {
        return _repositorioConvenio.ObterPorId(Id);
    }

    public List<ConvenioEscolaEmpresaOtd> ObterTodos(FiltroConvenioEscolaEmpresaOtd? filtroConvenioEscolaEmpresaOtd)
    {
        return _repositorioConvenio.ObterTodos(filtroConvenioEscolaEmpresaOtd);
    }
}