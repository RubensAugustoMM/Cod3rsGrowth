using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;

namespace Cod3rsGrowth.Servico;

public class ServicoEndereco : IRepositorioEndereco
{
    private readonly IRepositorioEndereco _repositorioEndereco;

    public ServicoEndereco(IRepositorioEndereco repositorioEndereco)
    {
        _repositorioEndereco = repositorioEndereco; 
    }

    public void Atualizar(Endereco endrecoAtualizado)
    {
        throw new NotImplementedException();
    }

    public void Criar(Endereco enderecoCriado)
    {
        throw new NotImplementedException();
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