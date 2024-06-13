using System.Reflection.Metadata;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Servico.Validacoes;
using FluentValidation;

namespace Cod3rsGrowth.Servico;

public class ServicoEscola : IRepositorioEscola
{
    private readonly IRepositorioEscola _repositorioEscola;
    private readonly IRepositorioConvenio _repositorioConvenio;
    private readonly IRepositorioEndereco _repositorioEndereco;
    private readonly ValidadorEscola _validadorEscola;

    public ServicoEscola(IRepositorioEscola repositorioEscola,IRepositorioConvenio repositorioConvenio, IRepositorioEndereco repositorioEndereco, ValidadorEscola validadorEscola)
    {
        _repositorioEscola = repositorioEscola;
        _repositorioConvenio = repositorioConvenio;
        _repositorioEndereco = repositorioEndereco;
        _validadorEscola = validadorEscola;
    }

    public void Atualizar(Escola escolaAtualizada)
    {
        ObterPorId(escolaAtualizada.Id);
        _validadorEscola.ValidateAndThrow(escolaAtualizada);
        _repositorioEscola.Atualizar(escolaAtualizada);
    }

    public void Criar(Escola escolaCriada)
    {
        _validadorEscola.ValidateAndThrow(escolaCriada);
        _repositorioEscola.Criar(escolaCriada);
    }

    public void Deletar(int id)
    {
        var EmpresaDeletar = ObterPorId(id);
        var ListaConvenios = _repositorioConvenio.ObterTodos();
        var Convenio = ListaConvenios.FirstOrDefault(convenio => convenio.IdEmpresa == id);

        if (Convenio != null)
            throw new Exception("Nao e possivel excluir Escola pois possui convenio ativo!");

        _repositorioEndereco.Deletar(EmpresaDeletar.IdEndereco);
        _repositorioEscola.Deletar(id);
    }

    public Escola ObterPorId(int Id)
    {
        return _repositorioEscola.ObterPorId(Id);
    }

    public List<Escola> ObterTodos()
    {
        return _repositorioEscola.ObterTodos();
    }
}