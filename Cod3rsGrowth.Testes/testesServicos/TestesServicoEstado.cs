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
        _servicoEstado = _serviceProvider.GetService<ServicoEstado>() ?? throw new Exception("Objeto _serviceProvider retornou null apos nao encontrar ServicoEstado!");
        _tabelas = TabelaSingleton.Instance;
    }

    [Fact]
    public void ao_ObterTodos_deve_retornar_lista_com_apenas_um_Estado()
    {
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

        var ValorRetornado = _servicoEstado.ObterTodos();

        Assert.Equal(ValorEsperado.Count, ValorRetornado.Count);
    }

    [Fact]
    public void ao_ObterTodos_deve_retornar_lista_com_apenas_dois_Estados()
    {
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
                Id = 1,
                Nome = "Rio de Janeiro",
                Sigla = "RJ"
            }
       };

        _tabelas.Estados.Value.Clear();
        _tabelas.Estados.Value.AddRange(ValorEsperado);

        var ValorRetornado = _servicoEstado.ObterTodos();

        Assert.Equal(ValorEsperado.Count, ValorRetornado.Count);
    }
}