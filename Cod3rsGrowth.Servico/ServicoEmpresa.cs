using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Servico.Validacoes;
using FluentValidation;

namespace Cod3rsGrowth.Servico;

public class ServicoEmpresa : IRepositorioEmpresa
{
    private readonly IRepositorioEmpresa _repositorioEmpresa;
    private readonly IRepositorioConvenio _repositorioConvenio;
    private readonly IRepositorioEndereco _repositorioEndereco;
    private readonly ValidadorEmpresa _validadorEmpresa;
    
    public ServicoEmpresa(IRepositorioEmpresa repositorioEmpresa,IRepositorioConvenio repositorioConvenio, IRepositorioEndereco repositorioEndereco,ValidadorEmpresa validadorEmpresa)
    {
        _repositorioEmpresa = repositorioEmpresa;
        _repositorioConvenio = repositorioConvenio;
        _repositorioEndereco = repositorioEndereco;
        _validadorEmpresa = validadorEmpresa;
    }

    public void Atualizar(Empresa empresaAtualizada)
    {
        ObterPorId(empresaAtualizada.Id);
        _validadorEmpresa.ValidateAndThrow(empresaAtualizada);
        _repositorioEmpresa.Atualizar(empresaAtualizada);
    }

    public void Criar(Empresa empresaCriada)
    {
        _validadorEmpresa.ValidateAndThrow(empresaCriada);
        _repositorioEmpresa.Criar(empresaCriada);
    }

    public void Deletar(int id)
    {
        var EmpresaDeletar = ObterPorId(id);
        var ListaConvenios = _repositorioConvenio.ObterTodos();
        var Convenio = ListaConvenios.FirstOrDefault(convenio => convenio.IdEmpresa == id);

        if (Convenio != null)
            throw new Exception("Nao e possivel excluir empresa pois possui convenio ativo!");

        _repositorioEndereco.Deletar(EmpresaDeletar.IdEndereco);
        _repositorioEmpresa.Deletar(id);
    }

    public Empresa ObterPorId(int Id)
    {
        return _repositorioEmpresa.ObterPorId(Id);
    }

    public List<Empresa> ObterTodos()
    {
        return _repositorioEmpresa.ObterTodos();
    }
}