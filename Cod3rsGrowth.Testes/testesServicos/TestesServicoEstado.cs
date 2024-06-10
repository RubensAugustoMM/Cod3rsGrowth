using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Servico;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Cod3rsGrowth.Testes;

public class TestesServicoEstado : TesteBase
{
    private readonly ServicoEstado _servicoEstado;
    private readonly TabelaSingleton _tabelas;
    private readonly Estado _estadoEntrada = new()
    {
        Id = 0,
        Nome = "Goias",
        Sigla = "GO"
    };
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

    [Theory]
    [InlineData(2)]
    [InlineData(-1)]
    public void ObterPorId_deve_lancar_Exception_quando_informado_Id_invalido_ou_inexistente(int idInformado)
    {
        List<Estado> ListaDadosTeste = new()
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
        _tabelas.Estados.Value.AddRange(ListaDadosTeste);

        var excecaoObterPorId = Assert.Throws<Exception>(() => _servicoEstado.ObterPorId(idInformado));

        Assert.Equal($"Nenhum Estado com Id {idInformado} existe no contexto atual!\n", excecaoObterPorId.Message);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    public void ObterPorId_deve_retornar_Estado_existente_quando_informado_id_valido(int idInformado)
    {
        List<Estado> ListaDadosTeste = new()
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
        _tabelas.Estados.Value.AddRange(ListaDadosTeste);

        var ValorEsperado = ListaDadosTeste[idInformado];
        var ValorRetornado = _servicoEstado.ObterPorId(idInformado);

        Assert.Equal(ValorEsperado.Id, ValorRetornado.Id);
        Assert.Equal(ValorEsperado.Nome, ValorRetornado.Nome);
        Assert.Equal(ValorEsperado.Sigla, ValorRetornado.Sigla);
    }
    /*
    [Theory]
    [InlineData(-1)]
    [InlineData(-2)]
    public void Criar_deve_retornar_False_quando_informado_Estado_com_Id_negativo(int idInformado)
    {
        var EstadoEntrada = _estadoEntrada;
        EstadoEntrada.Id = idInformado;

        var EstadoValido =  _servicoEstado.Criar(EstadoEntrada);

        Assert.False(EstadoValido);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("    ")]
    public void Criar_deve_retornar_False_quando_informado_Estado_com_Nome_invalido(string nomeInformado)
    {
        var EstadoEntrada = _estadoEntrada;
        EstadoEntrada.Nome = nomeInformado;

        var EstadoValido =  _servicoEstado.Criar(EstadoEntrada);

        Assert.False(EstadoValido);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("    ")]
    [InlineData("goa")]
    public void Criar_deve_retornar_False_quando_informado_Estado_com_Sigla_invalida(string siglaInformado)
    {
        var EstadoEntrada = _estadoEntrada;
        EstadoEntrada.Sigla = siglaInformado;

        var EstadoValido =  _servicoEstado.Criar(EstadoEntrada);

        Assert.False(EstadoValido);
    }

    [Fact]
    public void Criar_deve_retornar_False_quando_informado_Estado_com_ListaEnderecos_null()
    {
        var EstadoEntrada = _estadoEntrada;
        EstadoEntrada.ListaEnderecos = null;

        var EstadoValido =  _servicoEstado.Criar(EstadoEntrada);

        Assert.False(EstadoValido);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void Criar_deve_retornar_True_quando_informado_Estado_com_Id_positivo(int idInformado)
    {
        var EstadoEntrada = _estadoEntrada;
        EstadoEntrada.Id = idInformado;

        var EstadoValido =  _servicoEstado.Criar(EstadoEntrada);

        Assert.True(EstadoValido);
    }

    [Theory]
    [InlineData("Goias")]
    [InlineData("Mato Grosso")]
    public void Criar_deve_retornar_True_quando_informado_Estado_com_Nome_valido(string nomeInformado)
    {
        var EstadoEntrada = _estadoEntrada;
        EstadoEntrada.Nome = nomeInformado;

        var EstadoValido =  _servicoEstado.Criar(EstadoEntrada);

        Assert.True(EstadoValido);
    }

    [Theory]
    [InlineData("RJ")]
    [InlineData("SP")]
    public void Criar_deve_retornar_True_quando_informado_Estado_com_Sigla_valida(string siglaInformado)
    {
        var EstadoEntrada = _estadoEntrada;
        EstadoEntrada.Sigla = siglaInformado;

        var EstadoValido =  _servicoEstado.Criar(EstadoEntrada);

        Assert.True(EstadoValido);
    }

    [Fact]
    public void Criar_deve_retornar_True_quando_informado_Estado_com_ListaEnderecos_Existente()
    {
        var EstadoEntrada = _estadoEntrada;

        var EstadoValido =  _servicoEstado.Criar(EstadoEntrada);

        Assert.True(EstadoValido);
    }
    */
}