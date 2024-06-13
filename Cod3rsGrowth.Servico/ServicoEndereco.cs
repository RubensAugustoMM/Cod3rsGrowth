using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Servico.Validacoes;
using FluentValidation;

namespace Cod3rsGrowth.Servico;

public class ServicoEndereco : IRepositorioEndereco
{
    private readonly IRepositorioEndereco _repositorioEndereco;
    private readonly IRepositorioEmpresa _repositorioEmpresa;
    private readonly IRepositorioEscola _repositorioEscola;
    private readonly ValidadorEndereco _validadorEndereco;

    public ServicoEndereco(IRepositorioEndereco repositorioEndereco,IRepositorioEmpresa repositorioEmpresa,IRepositorioEscola repositorioEscola, ValidadorEndereco validadorEndereco)
    {
        _repositorioEndereco = repositorioEndereco;
        _repositorioEmpresa = repositorioEmpresa;
        _repositorioEscola = repositorioEscola;
        _validadorEndereco = validadorEndereco;
    }

    public void Atualizar(Endereco enderecoAtualizado)
    {
        ObterPorId(enderecoAtualizado.Id);
        _validadorEndereco.ValidateAndThrow(enderecoAtualizado);
        _repositorioEndereco.Atualizar(enderecoAtualizado);
    }

    public void Criar(Endereco enderecoCriado)
    {
        _validadorEndereco.ValidateAndThrow(enderecoCriado);
        _repositorioEndereco.Criar(enderecoCriado);
    }

    public void Deletar(int Id)
    {
        var ListaEscolas = _repositorioEscola.ObterTodos();
        var ListaEmpresas = _repositorioEmpresa.ObterTodos();
        var Escola = ListaEscolas.FirstOrDefault(escola => escola.IdEndereco == Id);
        var Empresa = ListaEmpresas.FirstOrDefault(empresa => empresa.IdEndereco == Id);

        if (Escola != null)
            throw new Exception("Nao e possivel excluir Endereco relacionado a Escola existente!");
        if (Empresa != null)
            throw new Exception("Nao e possivel excluir Endereco relacionado a Empresa existente!");

        _repositorioEndereco.Deletar(Id);
    }

    public Endereco ObterPorId(int Id)
    {
        return _repositorioEndereco.ObterPorId(Id);
    }

    public List<Endereco> ObterTodos()
    {
        return _repositorioEndereco.ObterTodos();
    }
}