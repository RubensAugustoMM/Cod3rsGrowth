using Cod3rsGrowth.Dominio;
using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;

namespace Cod3rsGrowth.Testes.Mocks;

public class MockRepositorioEndereco : IRepositorioEndereco
{
    TabelaSingleton Tabelas = TabelaSingleton.Instance;

    public void Atualizar(Endereco enderecoAtualizado)
    {
        var enderecoExistente =  Tabelas.Enderecos.Value.FirstOrDefault(c => c.Id == enderecoAtualizado.Id) ?? throw new Exception($"Nenhum Endereco com Id {enderecoAtualizado.Id} existe no contexto atual!\n");

        enderecoExistente.Numero = enderecoAtualizado.Numero;
        enderecoExistente.Cep = enderecoAtualizado.Cep;
        enderecoExistente.Municipio = enderecoAtualizado.Municipio;
        enderecoExistente.Bairro = enderecoAtualizado.Bairro;
        enderecoExistente.Rua = enderecoAtualizado.Rua;
        enderecoExistente.Complemento = enderecoAtualizado.Complemento;
        enderecoExistente.Estado = enderecoAtualizado.Estado;
    }

    public void Criar(Endereco enderecoCriado)
    {
        Tabelas.Enderecos.Value.Add(enderecoCriado);
    }

    public void Deletar(int id)
    {
        Tabelas.Enderecos.Value.Remove(ObterPorIdModelo(id));
    }

    public EnderecoOtd ObterPorId(int id)
    {
        var EnderecoRetornado = ObterPorIdModelo(id);

        var EnderecoOtdRetornado = new EnderecoOtd()
        {
            Id = EnderecoRetornado.Id,
            Numero = EnderecoRetornado.Numero,
            Cep = EnderecoRetornado.Cep,
            Municipio = EnderecoRetornado.Municipio,
            Bairro = EnderecoRetornado.Bairro,
            Rua = EnderecoRetornado.Rua,
            Complemento = EnderecoRetornado.Complemento,
            Estado = EnumExtencoes.RetornaDescricao(EnderecoRetornado.Estado)
        };

        return EnderecoOtdRetornado;
    }

    public List<EnderecoOtd> ObterTodos(FiltroEndereco? filtroEnderecoOtd)
    {
        var ListaEnderecos = Tabelas.Enderecos.Value;
        List<EnderecoOtd> ListaEnderecoOtd = new();

        foreach (var endereco in ListaEnderecos)
        {
            ListaEnderecoOtd.Add(new EnderecoOtd()
            {
            Id = endereco.Id,
            Numero = endereco.Numero,
            Cep = endereco.Cep,
            Municipio = endereco.Municipio,
            Bairro = endereco.Bairro,
            Rua = endereco.Rua,
            Complemento = endereco.Complemento,
            Estado = EnumExtencoes.RetornaDescricao(endereco.Estado)
            });
        }

        return ListaEnderecoOtd;
    }

    private Endereco ObterPorIdModelo(int id)
    {
        return Tabelas.Enderecos.Value.FirstOrDefault(c => c.Id == id) ?? throw new Exception($"Nenhum Endereco com Id {id} existe no contexto atual!\n");
    }
}