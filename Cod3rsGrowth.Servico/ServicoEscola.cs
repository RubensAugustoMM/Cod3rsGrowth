using System.Reflection.Metadata;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Servico.Validacoes;
using FluentValidation;

namespace Cod3rsGrowth.Servico;

public class ServicoEscola : IRepositorioEscola
{
    private readonly IRepositorioEscola _repositorioEscola;
    private readonly ValidadorEscola _validadorEscola;

    public ServicoEscola(IRepositorioEscola repositorioEscola, ValidadorEscola validadorEscola)
    {
        _repositorioEscola = repositorioEscola;
        _validadorEscola = validadorEscola;
    }

    public void Atualizar(Escola escolaAtualizada)
    {
        throw new NotImplementedException();
    }

    public void Criar(Escola escolaCriada)
    {
        _validadorEscola.ValidateAndThrow(escolaCriada);
        _repositorioEscola.Criar(escolaCriada);
    }

    public void Deletar(int Id)
    {
        throw new NotImplementedException();
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