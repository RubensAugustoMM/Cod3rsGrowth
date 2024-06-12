using FluentValidation;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Servico;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Cod3rsGrowth.Testes;

public class TestesServicoEndereco : TesteBase
{
    private readonly ServicoEndereco _servicoEndereco;
    private TabelaSingleton _tabelas;

    public TestesServicoEndereco()
    {
        _servicoEndereco = _serviceProvider.GetService<ServicoEndereco>() ?? throw new Exception("Objeto _serviceProvider retornou null apos nao encontrar ServicoEndereco!");
        _tabelas = TabelaSingleton.Instance;

        _tabelas.Enderecos.Value.Clear();
        _tabelas.Estados.Value.Clear();
        _tabelas.Estados.Value.Add(CriaNovoEstadoTeste());
    }

    private Endereco CriaNovoEnderecoTeste()
    {
        Endereco NovoEndereco = new()
        {
            Id = 0,
            Numero = 5,
            Cep = "72311089",
            Municipio = "Hidrolandia",
            Bairro = "Pedregal",
            Rua = "Rua das Magnolias",
            Complemento = "Em frente ao bretas",
            IdEstado = 1
        };

        return NovoEndereco;
    }

    private Estado CriaNovoEstadoTeste()
    {
        Estado NovoEstado = new()
        {
            Id = 1,
            Nome = "Goias",
            Sigla = "GO"
        };

        return NovoEstado;
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
    public void Criar_deve_retornar_ValidationException_quando_informado_Endereco_com_Id_negativo(int idInformado)
    {
        var EnderecoEntrada = CriaNovoEnderecoTeste();
        var ValorEsperado = "Id deve ser um valor maior ou igual a zero!";
        EnderecoEntrada.Id = idInformado;

        var excecao = Assert.Throws<ValidationException>(() => _servicoEndereco.Criar(EnderecoEntrada));

        Assert.Equal(ValorEsperado, excecao.Errors.First().ErrorMessage);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(-2)]
    public void Criar_deve_retornar_ValidationException_quando_informado_Endereco_com_Numero_negativo(int numeroInformado)
    {
        var EnderecoEntrada = CriaNovoEnderecoTeste();
        var ValorEsperado = "Numero deve ser um valor maior ou igual a zero!";
        EnderecoEntrada.Numero = numeroInformado;

        var excecao = Assert.Throws<ValidationException>(() => _servicoEndereco.Criar(EnderecoEntrada));

        Assert.Equal(ValorEsperado, excecao.Errors.First().ErrorMessage);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("         ")]
    public void Criar_deve_retornar_ValidationException_quando_informado_Endereco_com_Cep_vazio(string cepInformado)
    {
        var EnderecoEntrada = CriaNovoEnderecoTeste();
        var ValorEsperado = "Cep nao pode ter valor nulo ou formado por caracteres de espaco!";
        EnderecoEntrada.Cep = cepInformado;

        var excecao = Assert.Throws<ValidationException>(() => _servicoEndereco.Criar(EnderecoEntrada));

        Assert.Equal(ValorEsperado, excecao.Errors.First().ErrorMessage);
    }

    [Theory]
    [InlineData("4340089819")]
    [InlineData("123")]
    public void Criar_deve_retornar_ValidationException_quando_informado_Endereco_com_Cep_com_tamanho_diferente_que_8(string cepInformado)
    {
        var EnderecoEntrada = CriaNovoEnderecoTeste();
        var ValorEsperado = "Cep Length menor ou maior que 8 characteres!";
        EnderecoEntrada.Cep = cepInformado;

        var excecao = Assert.Throws<ValidationException>(() => _servicoEndereco.Criar(EnderecoEntrada));

        Assert.Equal(ValorEsperado, excecao.Errors.First().ErrorMessage);
    }

    [Theory]
    [InlineData("asdfghjk")]
    [InlineData("1234hvjo")]
    public void Criar_deve_retornar_ValidationException_quando_informado_Endereco_com_Cep_contendo_letras_ou_outros_simbolos(string cepInformado)
    {
        var EnderecoEntrada = CriaNovoEnderecoTeste();
        var ValorEsperado = "Cep e formado somente por numeros!";
        EnderecoEntrada.Cep = cepInformado;

        var excecao = Assert.Throws<ValidationException>(() => _servicoEndereco.Criar(EnderecoEntrada));

        Assert.Equal(ValorEsperado, excecao.Errors.First().ErrorMessage);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("         ")]
    public void Criar_deve_retornar_ValidationException_quando_informado_Endereco_com_Municipio_vazio(string municipioInformado)
    {
        var EnderecoEntrada = CriaNovoEnderecoTeste();
        var ValorEsperado = "Municipio nao pode ter valor nulo ou formado por caracteres de espaco!";
        EnderecoEntrada.Municipio = municipioInformado;

        var excecao = Assert.Throws<ValidationException>(() => _servicoEndereco.Criar(EnderecoEntrada));

        Assert.Equal(ValorEsperado, excecao.Errors.First().ErrorMessage);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("         ")]
    public void Criar_deve_retornar_ValidationException_quando_informado_Endereco_com_Bairro_vazio(string bairroInformado)
    {
        var EnderecoEntrada = CriaNovoEnderecoTeste();
        var ValorEsperado = "Bairro nao pode ter valor nulo ou formado por caracteres de espaco!";
        EnderecoEntrada.Bairro = bairroInformado;

        var excecao = Assert.Throws<ValidationException>(() => _servicoEndereco.Criar(EnderecoEntrada));

        Assert.Equal(ValorEsperado, excecao.Errors.First().ErrorMessage);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("         ")]
    public void Criar_deve_retornar_ValidationException_quando_informado_Endereco_com_Rua_invalida(string ruaInformado)
    {
        var EnderecoEntrada = CriaNovoEnderecoTeste();
        var ValorEsperado = "Rua nao pode ter valor nulo ou formado por caracteres de espaco!";
        EnderecoEntrada.Rua = ruaInformado;

        var excecao = Assert.Throws<ValidationException>(() => _servicoEndereco.Criar(EnderecoEntrada));

        Assert.Equal(ValorEsperado, excecao.Errors.First().ErrorMessage);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(-2)]
    public void Criar_deve_retornar_ValidationException_quando_informado_Endereco_com_IdEstado_negativo(int idEstadoInformado)
    {
        var EnderecoEntrada = CriaNovoEnderecoTeste();
        var ValorEsperado = "Id Estado deve ser um valor maior ou igual a zero!";
        EnderecoEntrada.IdEstado = idEstadoInformado;

        var excecao = Assert.Throws<ValidationException>(() => _servicoEndereco.Criar(EnderecoEntrada));

        Assert.Equal(ValorEsperado, excecao.Errors.First().ErrorMessage);
    }

    [Theory]
    [InlineData(4)]
    [InlineData(5)]
    public void Criar_deve_retornar_ValidationException_quando_informado_Endereco_com_IdEstado_inexistente(int idEstadoInformado)
    {
        var EnderecoEntrada = CriaNovoEnderecoTeste();
        var ValorEsperado = "Id Estado deve ser referente a um estado existente!";
        EnderecoEntrada.IdEstado = idEstadoInformado;

        var excecao = Assert.Throws<ValidationException>(() => _servicoEndereco.Criar(EnderecoEntrada));

        Assert.Equal(ValorEsperado, excecao.Errors.First().ErrorMessage);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void Criar_deve_adicionar_Endereco_no_repositorio_quando_informado_Endereco_com_Id_positivo(int idInformado)
    {
        var EnderecoEntrada = CriaNovoEnderecoTeste();
        EnderecoEntrada.Id = idInformado;

        _servicoEndereco.Criar(EnderecoEntrada);
        var ValorRetornado = _tabelas.Enderecos.Value.FirstOrDefault(EnderecoEntrada);

        Assert.NotNull(ValorRetornado);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void Criar_deve_adicionar_Endereco_no_repositorio_quando_informado_Endereco_com_Numero_positivo(int numeroInformado)
    {
        var EnderecoEntrada = CriaNovoEnderecoTeste();
        EnderecoEntrada.Numero = numeroInformado;

        _servicoEndereco.Criar(EnderecoEntrada);
        var ValorRetornado = _tabelas.Enderecos.Value.FirstOrDefault(EnderecoEntrada);

        Assert.NotNull(ValorRetornado);
    }

    [Theory]
    [InlineData("87654321")]
    [InlineData("12345678")]
    public void Criar_deve_adicionar_Endereco_no_repositorio_quando_informado_Endereco_com_Cep_valido(string cepInformado)
    {
        var EnderecoEntrada = CriaNovoEnderecoTeste();
        EnderecoEntrada.Cep = cepInformado;

        _servicoEndereco.Criar(EnderecoEntrada);
        var ValorRetornado = _tabelas.Enderecos.Value.FirstOrDefault(EnderecoEntrada);

        Assert.NotNull(ValorRetornado);
    }

    [Theory]
    [InlineData("Goiania")]
    [InlineData("Rodrigo ferreira")]
    public void Criar_deve_adicionar_Endereco_no_repositorio_quando_informado_Endereco_com_Municipio_valido(string municipioInformado)
    {
        var EnderecoEntrada = CriaNovoEnderecoTeste();
        EnderecoEntrada.Municipio = municipioInformado;

        _servicoEndereco.Criar(EnderecoEntrada);
        var ValorRetornado = _tabelas.Enderecos.Value.FirstOrDefault(EnderecoEntrada);

        Assert.NotNull(ValorRetornado);
    }

    [Theory]
    [InlineData("Itatiaia")]
    [InlineData("Asa Norte")]
    public void Criar_deve_adicionar_Endereco_no_repositorio_quando_informado_Endereco_com_Bairro_valido(string bairroInformado)
    {
        var EnderecoEntrada = CriaNovoEnderecoTeste();
        EnderecoEntrada.Bairro = bairroInformado;

        _servicoEndereco.Criar(EnderecoEntrada);
        var ValorRetornado = _tabelas.Enderecos.Value.FirstOrDefault(EnderecoEntrada);

        Assert.NotNull(ValorRetornado);
    }

    [Theory]
    [InlineData("Avenida Perimetral Norte")]
    [InlineData("Rua vv8")]
    public void Criar_deve_adicionar_Endereco_no_repositorio_quando_informado_Endereco_com_Rua_valida(string ruaInformado)
    {
        var EnderecoEntrada = CriaNovoEnderecoTeste();
        EnderecoEntrada.Rua = ruaInformado;

        _servicoEndereco.Criar(EnderecoEntrada);
        var ValorRetornado = _tabelas.Enderecos.Value.FirstOrDefault(EnderecoEntrada);

        Assert.NotNull(ValorRetornado);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void Criar_deve_adicionar_Endereco_no_repositorio_quando_informado_Endereco_com_IdEstado_valido_e_existente(int idEstadoInformado)
    {
        var EnderecoEntrada = CriaNovoEnderecoTeste();
        var EstadoEntrada = CriaNovoEstadoTeste();
        EnderecoEntrada.IdEstado = idEstadoInformado;
        EstadoEntrada.Id = idEstadoInformado;
        _tabelas.Estados.Value.Add(EstadoEntrada);

        _servicoEndereco.Criar(EnderecoEntrada);
        var ValorRetornado = _tabelas.Enderecos.Value.FirstOrDefault(EnderecoEntrada);

        Assert.NotNull(ValorRetornado);
    }

    [Theory]
    [InlineData(20)]
    [InlineData(30)]
    public void Atualizar_deve_retornar_Exception_quando_informado_Endereco_com_Id_inexistente(int idInformado)
    {
        var EnderecoEntrada = CriaNovoEnderecoTeste();
        EnderecoEntrada.Id = idInformado;

        var excecao = Assert.Throws<Exception>(() => _servicoEndereco.Atualizar(EnderecoEntrada));

        Assert.Equal($"Nenhum Endereco com Id {idInformado} existe no contexto atual!\n", excecao.Message);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("   ")]
    public void Atualizar_deve_retornar_ValidationException_quando_informado_Endereco_invalido(string municipioInformado)
    {
        var EnderecoEntrada = CriaNovoEnderecoTeste();
        EnderecoEntrada.Municipio = municipioInformado;
        _tabelas.Enderecos.Value.Add(EnderecoEntrada);

        var excecao = Assert.Throws<ValidationException>(() => _servicoEndereco.Atualizar(EnderecoEntrada));

        Assert.Equal("Municipio nao pode ter valor nulo ou formado por caracteres de espaco!", excecao.Errors.First().ErrorMessage);
    }

    [Theory]
    [InlineData("municipio2", 23, "Bairro1")]
    [InlineData("Rodrigos", 2, "Bairro3")]
    public void Atualizar_deve_alterar_parametros_de_Endereco_existente_quando_informado_Endereco_valido(string municipioInformado, int numeroInformado, string bairroInformado)
    {
        var EnderecoEntrada = CriaNovoEnderecoTeste();
        var EnderecoAtualizar = CriaNovoEnderecoTeste();
        EnderecoEntrada.Municipio = municipioInformado;
        EnderecoEntrada.Numero = numeroInformado;
        EnderecoEntrada.Bairro = bairroInformado;
        _tabelas.Enderecos.Value.Add(EnderecoAtualizar);

        _servicoEndereco.Atualizar(EnderecoEntrada);
        var ValorRetornado = _tabelas.Enderecos.Value.FirstOrDefault(endereco => endereco.Id == EnderecoEntrada.Id);

        Assert.Equal(municipioInformado, ValorRetornado.Municipio);
        Assert.Equal(numeroInformado, ValorRetornado.Numero);
        Assert.Equal(bairroInformado, ValorRetornado.Bairro);
    }
}