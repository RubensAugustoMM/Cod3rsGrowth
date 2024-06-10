using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Servico;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Cod3rsGrowth.Testes;

public class TestesServicoEndereco : TesteBase
{
    private readonly ServicoEndereco _servicoEndereco;
    private readonly TabelaSingleton _tabelas;
    private Endereco _enderecoEntrada = new()
    {
        Id = 0,
        Numero = 5,
        Cep = "72311089",
        Municipio = "Hidrolandia",
        Bairro = "Pedregal",
        Rua = "Rua das Magnolias",
        Complemento = "Em frente ao bretas",
        IdEstado = 0
    };
    private Estado _estadoEntrada = new()
    {
        Id = 0,
        Nome = "Goias",
        Sigla = "GO"
    };

    public TestesServicoEndereco()
    {
        _servicoEndereco = _serviceProvider.GetService<ServicoEndereco>() ?? throw new Exception("Objeto _serviceProvider retornou null apos nao encontrar ServicoEndereco!");
        _tabelas = TabelaSingleton.Instance;
    }

    [Fact]
    public void ao_ObterTodos_deve_retornar_lista_com_apenas_um_Endereco()
    {
        List<Endereco> ValorEsperado = new()
        {
            new Endereco()
            {
                Id = 0,
                Numero = 13,
                Cep = "11333666",
                Municipio = "Sao Bartolomeu",
                Bairro = "joao",
                Rua = "143",
                Complemento = "Perto da merceria do Galo",
                IdEstado = 1
            }
       };
        _tabelas.Enderecos.Value.Clear();
        _tabelas.Enderecos.Value.AddRange(ValorEsperado);

        var ValorRetornado = _servicoEndereco.ObterTodos();

        Assert.Equal(ValorEsperado.Count, ValorRetornado.Count);
    }

    [Fact]
    public void ao_ObterTodos_deve_retornar_lista_com_apenas_dois_Enderecos()
    {
        List<Endereco> ValorEsperado = new()
        {
            new Endereco()
            {
                Id = 0,
                Numero = 13,
                Cep = "11333666",
                Municipio = "Sao Bartolomeu",
                Bairro = "joao",
                Rua = "143",
                Complemento = "Perto da merceria do Galo",
                IdEstado = 1
            },
            new Endereco()
            {
                Id = 1,
                Numero = 11,
                Cep = "313341266",
                Municipio = "Sao Bartolomeu",
                Bairro = "Setor dos Operarios",
                Rua = "v57",
                Complemento = "Perto do terminal das bandeiras",
                IdEstado = 1
            }
       };
        _tabelas.Enderecos.Value.Clear();
        _tabelas.Enderecos.Value.AddRange(ValorEsperado);

        var ValorRetornado = _servicoEndereco.ObterTodos();

        Assert.Equal(ValorEsperado.Count, ValorRetornado.Count);
    }

    [Theory]
    [InlineData(2)]
    [InlineData(-1)]
    public void ObterPorId_deve_lancar_Exception_quando_informado_Id_invalido_ou_inexistente(int idInformado)
    {
        List<Endereco> ListaDadosTeste = new()
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
        _tabelas.Enderecos.Value.AddRange(ListaDadosTeste);

        var excecaoObterPorId = Assert.Throws<Exception>(() => _servicoEndereco.ObterPorId(idInformado));

        Assert.Equal($"Nenhum Endereco com Id {idInformado} existe no contexto atual!\n", excecaoObterPorId.Message);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    public void ObterPorId_deve_retornar_Endereco_existente_quando_informado_id_valido(int idInformado)
    {
        List<Endereco> ListaDadosTeste = new()
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
        _tabelas.Enderecos.Value.AddRange(ListaDadosTeste);

        var ValorEsperado = ListaDadosTeste[idInformado];
        var ValorRetornado = _servicoEndereco.ObterPorId(idInformado);

        Assert.Equal(ValorEsperado.Id, ValorRetornado.Id);
        Assert.Equal(ValorEsperado.Numero, ValorRetornado.Numero);
        Assert.Equal(ValorEsperado.Cep, ValorRetornado.Cep);
        Assert.Equal(ValorEsperado.Municipio, ValorRetornado.Municipio);
        Assert.Equal(ValorEsperado.Bairro, ValorRetornado.Bairro);
        Assert.Equal(ValorEsperado.Rua, ValorRetornado.Rua);
        Assert.Equal(ValorEsperado.Complemento, ValorRetornado.Complemento);
        Assert.Equal(ValorEsperado.IdEstado, ValorRetornado.IdEstado);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(-2)]
    public void Criar_deve_retornar_False_repositorio_quando_informado_Endereco_com_Id_invalido(int idInformado)
    {
        var EnderecoEntrada = _enderecoEntrada;
        EnderecoEntrada.Id = idInformado;

        var EnderecoValido =  _servicoEndereco.Criar(EnderecoEntrada);

        Assert.False(EnderecoValido);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(-2)]
    public void Criar_deve_retornar_False_quando_informado_Endereco_com_Numero_negativo(int numeroInformado)
    {
        var EnderecoEntrada = _enderecoEntrada;
        EnderecoEntrada.Numero = numeroInformado;

        var EnderecoValido =  _servicoEndereco.Criar(EnderecoEntrada);

        Assert.False(EnderecoValido);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("         ")]
    [InlineData("4340089819")]
    [InlineData("123")]
    [InlineData("asdfghjk")]
    public void Criar_deve_retornar_False_repositorio_quando_informado_Endereco_com_Cep_invalido(string cepInformado)
    {
        var EnderecoEntrada = _enderecoEntrada;
        EnderecoEntrada.Cep = cepInformado;

        var EnderecoValido =  _servicoEndereco.Criar(EnderecoEntrada);

        Assert.False(EnderecoValido);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("         ")]
    public void Criar_deve_retornar_False_repositorio_quando_informado_Endereco_com_Municipio_invalido(string municipioInformado)
    {
        var EnderecoEntrada = _enderecoEntrada;
        EnderecoEntrada.Municipio = municipioInformado;

        var EnderecoValido =  _servicoEndereco.Criar(EnderecoEntrada);

        Assert.False(EnderecoValido);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("         ")]
    public void Criar_deve_retornar_False_repositorio_quando_informado_Endereco_com_Bairro_invalido(string bairroInformado)
    {
        var EnderecoEntrada = _enderecoEntrada;
        EnderecoEntrada.Bairro = bairroInformado;

        var EnderecoValido =  _servicoEndereco.Criar(EnderecoEntrada);

        Assert.False(EnderecoValido);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("         ")]
    public void Criar_deve_retornar_False_repositorio_quando_informado_Endereco_com_Rua_invalida(string ruaInformado)
    {
        var EnderecoEntrada = _enderecoEntrada;
        EnderecoEntrada.Rua = ruaInformado;

        var EnderecoValido =  _servicoEndereco.Criar(EnderecoEntrada);

        Assert.False(EnderecoValido);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(2)]
    public void Criar_deve_retornar_False_repositorio_quando_informado_Endereco_com_IdEstado_invalido_ou_inexistente(int idEstadoInformado)
    {
        var EnderecoEntrada = _enderecoEntrada;
        EnderecoEntrada.IdEstado = idEstadoInformado;

        var EnderecoValido =  _servicoEndereco.Criar(EnderecoEntrada);

        Assert.False(EnderecoValido);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void Criar_deve_retornar_True_repositorio_quando_informado_Endereco_com_Id_valido(int idInformado)
    {
        var EnderecoEntrada = _enderecoEntrada;
        EnderecoEntrada.Id = idInformado;

        var EnderecoValido =  _servicoEndereco.Criar(EnderecoEntrada);

        Assert.True(EnderecoValido);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void Criar_deve_retornar_True_quando_informado_Endereco_com_Numero_positivo(int numeroInformado)
    {
        var EnderecoEntrada = _enderecoEntrada;
        EnderecoEntrada.Numero = numeroInformado;

        var EnderecoValido =  _servicoEndereco.Criar(EnderecoEntrada);

        Assert.True(EnderecoValido);
    }

    [Theory]
    [InlineData("87654321")]
    [InlineData("12345678")]
    public void Criar_deve_retornar_True_repositorio_quando_informado_Endereco_com_Cep_valido(string cepInformado)
    {
        var EnderecoEntrada = _enderecoEntrada;
        EnderecoEntrada.Cep = cepInformado;

        var EnderecoValido =  _servicoEndereco.Criar(EnderecoEntrada);

        Assert.True(EnderecoValido);
    }

    [Theory]
    [InlineData("Goiania")]
    [InlineData("Rodrigo ferreira")]
    public void Criar_deve_retornar_True_repositorio_quando_informado_Endereco_com_Municipio_valido(string municipioInformado)
    {
        var EnderecoEntrada = _enderecoEntrada;
        EnderecoEntrada.Municipio = municipioInformado;

        var EnderecoValido =  _servicoEndereco.Criar(EnderecoEntrada);

        Assert.True(EnderecoValido);
    }

    [Theory]
    [InlineData("Itatiaia")]
    [InlineData("Asa Norte")]
    public void Criar_deve_retornar_True_repositorio_quando_informado_Endereco_com_Bairro_valido(string bairroInformado)
    {
        var EnderecoEntrada = _enderecoEntrada;
        EnderecoEntrada.Bairro = bairroInformado;

        var EnderecoValido =  _servicoEndereco.Criar(EnderecoEntrada);

        Assert.True(EnderecoValido);
    }

    [Theory]
    [InlineData("Avenida Perimetral Norte")]
    [InlineData("Rua vv8")]
    public void Criar_deve_retornar_True_repositorio_quando_informado_Endereco_com_Rua_valida(string ruaInformado)
    {
        var EnderecoEntrada = _enderecoEntrada;
        EnderecoEntrada.Rua = ruaInformado;

        var EnderecoValido =  _servicoEndereco.Criar(EnderecoEntrada);

        Assert.True(EnderecoValido);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void Criar_deve_retornar_True_repositorio_quando_informado_Endereco_com_IdEstado_valido_e_existente(int idEstadoInformado)
    {
        var EnderecoEntrada = _enderecoEntrada;
        var EstadoEntrada = _estadoEntrada; 
        EnderecoEntrada.IdEstado = idEstadoInformado;
        EstadoEntrada.Id = idEstadoInformado;
        _tabelas.Estados.Value.Add(EstadoEntrada);

        var EnderecoValido =  _servicoEndereco.Criar(EnderecoEntrada);

        Assert.True(EnderecoValido);
    }
}