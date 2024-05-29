using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Servico;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Cod3rsGrowth.Testes;

public class TestesServicoEstado : TesteBase
{
    private readonly ServicoEstado _servicoEstado;
    private readonly TabelaSingleton _tabelas;
    public TestesServicoEstado()
    {
        _servicoEstado = _serviceProvider.GetService<ServicoEstado>();
        _tabelas = TabelaSingleton.Instance;
    }

    [Fact]
    public void ObterTodos_ListaVazia_ListaVazia()
    {
        //arrange
        _tabelas.Estados.Value.Clear();
        var ValorEsperado = _tabelas.Estados.Value;

        //act
        var ValorRetornado = _servicoEstado.ObterTodos();

        //assert
        Assert.Equal(ValorEsperado.Count, ValorRetornado.Count);
    }

    [Fact]
    public void ObterTodos_ListaUmElemento_listaUmElemento()
    {
        //arrage
        List<Estado> ValorEsperado = new()
        {
            new Estado()
            {
                Id = 0,
                Nome = "Goias",
                Sigla = "GO"
            }
       };
        _tabelas.Estados.Value.Clear();
        _tabelas.Estados.Value.AddRange(ValorEsperado);

        //act
        var ValorRetornado = _servicoEstado.ObterTodos();

        //assert
        Assert.Equal(ValorEsperado.Count, ValorRetornado.Count);
    }

    [Fact]
    public void ObterTodos_ListaDoisElemento_listaDoisElemento()
    {
        //arrage
        List<Estado> ValorEsperado = new()
        {
            new Estado()
            {
                Id = 0,
                Nome = "Goias",
                Sigla = "GO"
            },
            new Estado()
            {
                Id = 0,
                Nome = "Rio de Janeiro",
                Sigla = "RJ"
            }
       };

        _tabelas.Estados.Value.Clear();
        _tabelas.Estados.Value.AddRange(ValorEsperado);

        //act
        var ValorRetornado = _servicoEstado.ObterTodos();

        //assert
        Assert.Equal(ValorEsperado.Count, ValorRetornado.Count);
    }
}