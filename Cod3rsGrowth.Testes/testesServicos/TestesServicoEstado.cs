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

    [Fact]
    public void ObterPorId_deve_lancar_Exception_Nenhum_Estado_com_Id_6_existe_no_contexto_atual_quando_informado_Id_6_inexistente_no_contexto()
    {
        _tabelas.Convenios.Value.Clear();

        var excecaoObterPorId = Assert.Throws<Exception>(() => _servicoEstado.ObterPorId(6));
        Assert.Contains("Nenhum Estado com Id 6 existe no contexto atual!\n", excecaoObterPorId.Message);
    }

    [Fact]
    public void ObterPorId_deve_lancar_ArgumentOutOfRangeException_valor_negativo_informado_ao_metodo_quando_informado_valor_negativo()
    {
        _tabelas.Convenios.Value.Clear();

        var excecaoObterPorId = Assert.Throws<ArgumentOutOfRangeException>(() => _servicoEstado.ObterPorId(-1));
        Assert.Contains("Valor negativo informado ao metodo!\n", excecaoObterPorId.Message);
    }

    [Fact]
    public void ObterPorId_deve_retornar_Estado_com_id_0_quando_informado_0()
    {
        List<Estado> ListaArrange = new()
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
        _tabelas.Estados.Value.AddRange(ListaArrange);

        var ValorEsperado = ListaArrange.Find(x => x.Id == 0);

        var ValorRetornado = _servicoEstado.ObterPorId(0);

        Assert.Equal(ValorEsperado.Id, ValorRetornado.Id); 
        Assert.Equal(ValorEsperado.Nome, ValorRetornado.Nome);
        Assert.Equal(ValorEsperado.Sigla, ValorRetornado.Sigla);
    }

    [Fact]
    public void ObterPorId_deve_retornar_Estado_com_id_1_quando_informado_1()
    {
        List<Estado> ListaArrange = new()
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
        _tabelas.Estados.Value.AddRange(ListaArrange);

        var ValorEsperado = ListaArrange.Find(x => x.Id == 1);

        var ValorRetornado = _servicoEstado.ObterPorId(1);

        Assert.Equal(ValorEsperado.Id, ValorRetornado.Id); 
        Assert.Equal(ValorEsperado.Nome, ValorRetornado.Nome);
        Assert.Equal(ValorEsperado.Sigla, ValorRetornado.Sigla);
    }
}