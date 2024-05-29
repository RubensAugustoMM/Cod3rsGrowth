using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Servico;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Cod3rsGrowth.Testes;

public class TestesServicoEndereco : TesteBase
{
    private readonly ServicoEndereco _servicoEndereco;
    private readonly TabelaSingleton _tabelas;
    public TestesServicoEndereco()
    {
        _servicoEndereco = _serviceProvider.GetService<ServicoEndereco>();
        _tabelas = TabelaSingleton.Instance;
    }

    [Fact]
    public void ObterTodos_ListaVazia_ListaVazia()
    {
        //arrange
        _tabelas.Enderecos.Value.Clear();
        var ValorEsperado = _tabelas.Enderecos.Value;

        //act
        var ValorRetornado = _servicoEndereco.ObterTodos();

        //assert
        Assert.Equal(ValorEsperado.Count, ValorRetornado.Count);
    }

    [Fact]
    public void ObterTodos_ListaUmElemento_listaUmElemento()
    {
        //arrage
        List<Endereco> ValorEsperado = new()
        {
            new Endereco()
            {
                Id = 0,
                Numero = 13,
                Cep = "113336666",
                Municipio = "Sao Bartolomeu",
                Bairro = "joao",
                Rua = "143",
                Complemento = "Perto da merceria do Galo",
                IdEstado = 20
            }
       };
        _tabelas.Enderecos.Value.Clear();
        _tabelas.Enderecos.Value.AddRange(ValorEsperado);

        //act
        var ValorRetornado = _servicoEndereco.ObterTodos();

        //assert
        Assert.Equal(ValorEsperado.Count, ValorRetornado.Count);
    }

    [Fact]
    public void ObterTodos_ListaDoisElemento_listaDoisElemento()
    {
        //arrage
        List<Endereco> ValorEsperado = new()
        {
            new Endereco()
            {
                Id = 0,
                Numero = 13,
                Cep = "113336666",
                Municipio = "Sao Bartolomeu",
                Bairro = "joao",
                Rua = "143",
                Complemento = "Perto da merceria do Galo",
                IdEstado = 20
            },
            new Endereco()
            {
                Id = 1,
                Numero = 11,
                Cep = "3133412666",
                Municipio = "Sao Bartolomeu",
                Bairro = "Setor dos Operarios",
                Rua = "v57",
                Complemento = "Perto do terminal das bandeiras",
                IdEstado = 20
            }
       };

        _tabelas.Enderecos.Value.Clear();
        _tabelas.Enderecos.Value.AddRange(ValorEsperado);

        //act
        var ValorRetornado = _servicoEndereco.ObterTodos();

        //assert
        Assert.Equal(ValorEsperado.Count, ValorRetornado.Count);
    }
}