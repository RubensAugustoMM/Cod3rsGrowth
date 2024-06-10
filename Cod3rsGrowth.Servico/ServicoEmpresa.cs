using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Servico.Validacoes;
using FluentValidation;

namespace Cod3rsGrowth.Servico;

public class ServicoEmpresa : IRepositorioEmpresa
{
    private readonly IRepositorioEmpresa _repositorioEmpresa;
    private readonly ValidadorEmpresa _validadorEmpresa;
    
    public ServicoEmpresa(IRepositorioEmpresa repositorioEmpresa,ValidadorEmpresa validadorEmpresa)
    {
        _repositorioEmpresa = repositorioEmpresa;
        _validadorEmpresa = validadorEmpresa;
    }

    public void Atualizar(Empresa empresaAtualizada)
    {
        throw new NotImplementedException();
    }

    public void Criar(Empresa empresaCriada)
    {
        try
        {
            _validadorEmpresa.ValidateAndThrow(empresaCriada);
            _repositorioEmpresa.Criar(empresaCriada);
        }
        catch(Exception excecao)
        {
            Console.WriteLine(excecao.GetType().FullName);
            Console.WriteLine(excecao.Message);
        }
    }

    public void Deletar(int Id)
    {
        throw new NotImplementedException();
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