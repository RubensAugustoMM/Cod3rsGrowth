using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;

namespace Cod3rsGrowth.Servico;

public class ServicoEmpresa : IRepositorioEmpresa
{
    private readonly IRepositorioEmpresa _repositorioEmpresa;

    public ServicoEmpresa(IRepositorioEmpresa repositorioEmpresa)
    {
        _repositorioEmpresa = repositorioEmpresa; 
    }

    public void Atualizar(Empresa empresaAtualizada)
    {
        throw new NotImplementedException();
    }

    public void Criar(Empresa empresaCriada)
    {
        throw new NotImplementedException();
    }

    public void Deletar(int Id)
    {
        throw new NotImplementedException();
    }

    public Empresa ObterPorId(int Id)
    {
        throw new NotImplementedException();
    }

    public List<Empresa> ObterTodos()
    {
        return _repositorioEmpresa.ObterTodos();
    }
}