using FluentValidation;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Servico;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Cod3rsGrowth.Dominio.Enums;


namespace Cod3rsGrowth.Testes;

public class TestesServicoEndereco : TesteBase
{
    private readonly ServicoEndereco _servicoEndereco;
    private TabelaSingleton _tabelas;

    public TestesServicoEndereco()
    {
        _servicoEndereco = _serviceProvider.GetService<ServicoEndereco>() ?? throw new Exception("Objeto _serviceProvider retornou null apos nao encontrar ServicoEndereco!");

        _tabelas = TabelaSingleton.Instance;  
        _tabelas.Estados.Value.Add(CriaNovoEstadoTeste());
    }

    private Endereco CriaNovoEnderecoTeste()
    {
        Endereco NovoEndereco = new()
        {
            Id = 30,
            Numero = 5,
            Cep = "72311089",
            Municipio = "Hidrolandia",
            Bairro = "Pedregal",
            Rua = "Rua das Magnolias",
            Complemento = "Em frente ao bretas",
            IdEstado = 30
        };

        return NovoEndereco;
    }

    private Estado CriaNovoEstadoTeste()
    {
        Estado NovoEstado = new()
        {
            Id = 30,
            Nome = "Goias",
            Sigla = "GO"
        };

        return NovoEstado;
    }

    [Fact]
    public void ao_ObterTodos_deve_retornar_lista_nao_vazia()
    {
        var ValorRetornado = _servicoEndereco.ObterTodos(null);

        Assert.NotNull(ValorRetornado);
    }

    [Theory]
    [InlineData(110)]
    [InlineData(-1)]
    public void ObterPorId_deve_lancar_Exception_quando_informado_Id_invalido_ou_inexistente(int idInformado)
    {
        var excecaoObterPorId = Assert.Throws<Exception>(() => _servicoEndereco.ObterPorId(idInformado));

        Assert.Equal($"Nenhum Endereco com Id {idInformado} existe no contexto atual!\n", excecaoObterPorId.Message);
    }

    [Theory]
    [InlineData(101)]
    [InlineData(102)]
    public void ObterPorId_deve_retornar_Endereco_existente_quando_informado_id_valido(int idInformado)
    {
        var ValorEsperado = CriaNovoEnderecoTeste();
        ValorEsperado.Id = idInformado;
        _tabelas.Enderecos.Value.Add(ValorEsperado);

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
    [InlineData(201)]
    [InlineData(202)]
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
    [InlineData(100)]
    [InlineData(200)]
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

    [Theory]
    [InlineData(-300)]
    [InlineData(505)]
    public void Deletar_deve_lancar_Exception_quando_informado_Id_invalido_ou_inexistente(int idInformado)
    {
        var EnderecoEntrada = CriaNovoEnderecoTeste();
        EnderecoEntrada.Id = idInformado;

        var excecaoObterPorId = Assert.Throws<Exception>(() => _servicoEndereco.Deletar(EnderecoEntrada.Id));

        Assert.Equal($"Nenhum Endereco com Id {idInformado} existe no contexto atual!\n", excecaoObterPorId.Message);
    }

    [Fact]
    public void Deletar_deve_lancar_ValidationException_quando_informado_Endereco_com_Empresa_existente()
    {
        var EnderecoEntrada = CriaNovoEnderecoTeste();
        EnderecoEntrada.Id = 501;
        Empresa EmpresaEntrada = new()
        {
            Id = 506,
            Idade = 1,
            RazaoSocial = "Fast! transportes LTDA",
            NomeFantasia = "Fast! transportes",
            Cnpj = "12345678901234",
            SitucaoCadastral = true,
            DataSituacaoCadastral = new DateTime(2024, 12, 03),
            DataAbertura = new DateTime(2023, 12, 03),
            CapitalSocial = 123124124,
            NaturezaJuridica = NaturezaJuridicaEnums.EmpresarioIndividual,
            Porte = PorteEnums.EmpresaPequenoPorte,
            MatrizFilial = MatrizFilialEnums.Matriz,
            IdEndereco = EnderecoEntrada.Id
        };
        _tabelas.Enderecos.Value.Add(EnderecoEntrada);
        _tabelas.Empresas.Value.Add(EmpresaEntrada);

        var excecao = Assert.Throws<ValidationException>(() => _servicoEndereco.Deletar(EnderecoEntrada.Id));
    
        Assert.Equal("Nao e possivel excluir Endereco relacionado a Empresa existente!", excecao.Message);
    }

    [Fact]
    public void Deletar_deve_lancar_ValidationException_quando_informado_Endereco_com_Escola_existente()
    {
        var EnderecoEntrada = CriaNovoEnderecoTeste();
        EnderecoEntrada.Id = 503;
        Escola EscolaEntrada = new()
        {
            Id = 506,
            StatusAtividade = true,
            Nome = "Escola Rodrigo",
            CodigoMec = "12345678",
            Telefone = "12355645",
            Email = "rodrigo@gmail.com",
            InicioAtividade = new DateTime(1234, 12, 3),
            CategoriaAdministrativa = CategoriaAdministrativaEnums.Estadual,
            OrganizacaoAcademica = OrganizacaoAcademicaEnums.EscolaGoverno,
            IdEndereco = EnderecoEntrada.Id
        };
        _tabelas.Enderecos.Value.Add(EnderecoEntrada);
        _tabelas.Escolas.Value.Add(EscolaEntrada);

        var excecao = Assert.Throws<ValidationException>(() => _servicoEndereco.Deletar(EnderecoEntrada.Id));
    
        Assert.Equal("Nao e possivel excluir Endereco relacionado a Escola existente!", excecao.Message);
    }


    [Theory]
    [InlineData(501)]
    [InlineData(502)]
    public void Deletar_deve_remover_Endereco_do_repositorio_quando_informado_Id_de_Endereco_a_remover(int idInformado)
    {
        var EnderecoEntrada = CriaNovoEnderecoTeste();
        EnderecoEntrada.Id = idInformado;
        _tabelas.Enderecos.Value.Add(EnderecoEntrada);

        _servicoEndereco.Deletar(EnderecoEntrada.Id);
        var ValorRetorno = _tabelas.Convenios.Value.FirstOrDefault(c => c.Id == idInformado);

        Assert.Null(ValorRetorno);
    }
}