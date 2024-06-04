using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;

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
        Tabelas.Enderecos.Value.Add(enderecoCriado);
    }

    public void Deletar(int Id)
    {
        var EnderecoDeletado = ObterPorId(Id);

        Tabelas.Enderecos.Value.Remove(EnderecoDeletado);
    }

    public Endereco ObterPorId(int Id)
    {
        return Tabelas.Enderecos.Value.FirstOrDefault(c => c.Id == Id) ?? throw new Exception($"Nenhum Endereco com Id {Id} existe no contexto atual!\n");
    }

    public List<Endereco> ObterTodos()
    {
        return Tabelas.Enderecos.Value;
    }
}