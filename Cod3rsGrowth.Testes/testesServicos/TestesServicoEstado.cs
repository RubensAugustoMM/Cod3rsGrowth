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
    public void ObterTodos_DeveRetornar_Lista_Com_Um_Elemento_QuandoInformado_Lista_Com_Um_Elemento()
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
    public void ObterTodos_DeveRetornar_Lista_Com_Dois_Elemento_QuandoInformado_Lista_Com_Dois_Elemento()
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
                Id = 0,
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