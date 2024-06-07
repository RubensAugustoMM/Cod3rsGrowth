using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Servico.Validacoes;

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
        throw new NotImplementedException();
    }

    public bool Criar(Convenio convenioCriado)
    {
        var resultadoValidacao = _validadorConvenio.Validate(convenioCriado);

        if (resultadoValidacao.IsValid)
            _repositorioConvenio.Criar(convenioCriado);

        return resultadoValidacao.IsValid;
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
