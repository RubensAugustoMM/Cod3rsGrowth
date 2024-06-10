using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Servico.Validacoes;

namespace Cod3rsGrowth.Servico;

public class ServicoEndereco : IRepositorioEndereco
{
    private readonly IRepositorioEndereco _repositorioEndereco;
    private readonly ValidadorEndereco _validadorEndereco;

    public ServicoEndereco(IRepositorioEndereco repositorioEndereco, ValidadorEndereco validadorEndereco)
    {
        _repositorioEndereco = repositorioEndereco;
        _validadorEndereco = validadorEndereco;
    }

    public void Atualizar(Endereco endrecoAtualizado)
    {
        throw new NotImplementedException();
    }

    public bool Criar(Endereco enderecoCriado)
    {

        var resultadoValidacao = _validadorEndereco.Validate(enderecoCriado);

        if (resultadoValidacao.IsValid)
            _repositorioEndereco.Criar(enderecoCriado);
            
        return resultadoValidacao.IsValid;
    }

    public void Deletar(int Id)
    {
        throw new NotImplementedException();
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