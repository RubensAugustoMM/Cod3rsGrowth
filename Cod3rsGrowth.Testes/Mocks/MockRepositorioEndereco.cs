using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Infra.Repositorios;

namespace Cod3rsGrowth.Testes.Mocks;

public class MockRepositorioEndereco : IRepositorioEndereco
{
    TabelaSingleton Tabelas = TabelaSingleton.Instance;

    public void Atualizar(Endereco enderecoAtualizado)
    {
        var enderecoExistente = ObterPorId(enderecoAtualizado.Id);

        enderecoExistente.Numero = enderecoAtualizado.Numero;
        enderecoExistente.Cep = enderecoAtualizado.Cep;
        enderecoExistente.Municipio = enderecoAtualizado.Municipio;
        enderecoExistente.Bairro = enderecoAtualizado.Bairro;
        enderecoExistente.Rua = enderecoAtualizado.Rua;
        enderecoExistente.Complemento = enderecoAtualizado.Complemento;
        enderecoExistente.IdEstado = enderecoAtualizado.IdEstado;
        enderecoExistente.ListaEscolas = enderecoAtualizado.ListaEscolas;
        enderecoExistente.ListaEmpresas = enderecoAtualizado.ListaEmpresas;
    }

    public void Criar(Endereco enderecoCriado)
    {
        Tabelas._enderecos.Value.Add(enderecoCriado);
    }

    public void Deletar(Endereco enderecoDeletado)
    {
        Tabelas._enderecos.Value.Remove(enderecoDeletado);
    }

    public Endereco ObterPorId(int Id)
    {
        return Tabelas._enderecos.Value.FirstOrDefault(c => c.Id == Id) ?? throw new NullReferenceException();
    }

    public List<Endereco> ObterTodos()
    {
        return Tabelas._enderecos.Value;
    }
}