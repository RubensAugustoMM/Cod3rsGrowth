using FluentValidation;
using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Servico;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Cod3rsGrowth.Testes;

public class TestesServicoEscola : TesteBase
{
    private readonly ServicoEscola _servicoEscola;
    private readonly TabelaSingleton _tabelas;
    private readonly Escola _escolaEntrada = new()
    {

        Id = 0,
        StatusAtividade = true,
        Nome = "Escola Rodrigo",
        CodigoMec = "12345678",
        Telefone = "12355645",
        Email = "rodrigo@gmail.com",
        InicioAtividade = new DateTime(1234, 12, 3),
        CategoriaAdministrativa = CategoriaAdministrativaEnums.Estadual,
        OrganizacaoAcademica = OrganizacaoAcademicaEnums.EscolaGoverno,
        IdEndereco = 0,

    };
    private readonly Endereco _enderecoEntrada = new()
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
    public static TheoryData<DateTime> CasosInicioAtividadeInvalidos = new()
    {
        {new DateTime(3000,2,3)},
        {new DateTime(4000,1,1)}
    };

    public TestesServicoEscola()
    {
        _servicoEscola = _serviceProvider.GetService<ServicoEscola>() ?? throw new Exception("Objeto _serviceProvider retornou null apos nao encontrar ServicoEscola!");
        _tabelas = TabelaSingleton.Instance;
        _tabelas.Enderecos.Value.Add(_enderecoEntrada);
    }

    [Fact]
    public void ao_ObterTodos_deve_retornar_lista_com_apenas_uma_Escola()
    {
        List<Escola> ValorEsperado = new()
        {
            new Escola()
            {
                Id = 0,
                StatusAtividade = true,
                Nome = "Escola Rodrigo",
                CodigoMec = "12345678",
                Telefone = "12355645",
                Email = "rodrigo@gmail.com",
                InicioAtividade = new DateTime(1234,12,3),
                CategoriaAdministrativa = CategoriaAdministrativaEnums.Estadual,
                OrganizacaoAcademica = OrganizacaoAcademicaEnums.EscolaGoverno
            }
       };
        _tabelas.Escolas.Value.Clear();
        _tabelas.Escolas.Value.AddRange(ValorEsperado);

        var ValorRetornado = _servicoEscola.ObterTodos();

        Assert.Equal(ValorEsperado.Count, ValorRetornado.Count);
    }

    [Fact]
    public void ao_ObterTodos_deve_retornar_lista_com_apenas_duas_Escolas()
    {
        List<Escola> ValorEsperado = new()
        {
            new Escola()
            {
                Id = 0,
                StatusAtividade = true,
                Nome = "Escola Rodrigo",
                CodigoMec = "12345678",
                Telefone = "12355645",
                Email = "rodrigo@gmail.com",
                InicioAtividade = new DateTime(1234,12,3),
                CategoriaAdministrativa = CategoriaAdministrativaEnums.Estadual,
                OrganizacaoAcademica = OrganizacaoAcademicaEnums.EscolaGoverno
            },
            new Escola()
            {
                Id = 1,
                StatusAtividade = true,
                Nome = "Escola Enzo menezes",
                CodigoMec = "12345678",
                Telefone = "143454345",
                Email = "enz@gmail.com",
                InicioAtividade = new DateTime(1234,12,3),
                CategoriaAdministrativa = CategoriaAdministrativaEnums.Estadual,
                OrganizacaoAcademica = OrganizacaoAcademicaEnums.EscolaGoverno
            }
       };
        _tabelas.Escolas.Value.Clear();
        _tabelas.Escolas.Value.AddRange(ValorEsperado);

        var ValorRetornado = _servicoEscola.ObterTodos();

        Assert.Equal(ValorEsperado.Count, ValorRetornado.Count);
    }

    [Theory]
    [InlineData(2)]
    [InlineData(-1)]
    public void ObterPorId_deve_lancar_Exception_quando_informado_Id_invalido_ou_inexistente(int idInformado)
    {
        List<Escola> ListaDadosTeste = new()
        {
            new Escola()
            {
                Id = 0,
                StatusAtividade = true,
                Nome = "Escola Rodrigo",
                CodigoMec = "12345678",
                Telefone = "12355645",
                Email = "rodrigo@gmail.com",
                InicioAtividade = new DateTime(1234,12,3),
                CategoriaAdministrativa = CategoriaAdministrativaEnums.Estadual,
                OrganizacaoAcademica = OrganizacaoAcademicaEnums.EscolaGoverno
            },
            new Escola()
            {
                Id = 1,
                StatusAtividade = true,
                Nome = "Escola Enzo menezes",
                CodigoMec = "12345678",
                Telefone = "143454345",
                Email = "enz@gmail.com",
                InicioAtividade = new DateTime(1234,12,3),
                CategoriaAdministrativa = CategoriaAdministrativaEnums.Estadual,
                OrganizacaoAcademica = OrganizacaoAcademicaEnums.EscolaGoverno
            }
       };
        _tabelas.Escolas.Value.Clear();
        _tabelas.Escolas.Value.AddRange(ListaDadosTeste);

        var excecaoObterPorId = Assert.Throws<Exception>(() => _servicoEscola.ObterPorId(idInformado));

        Assert.Equal($"Nenhuma Escola com Id {idInformado} existe no contexto atual!\n", excecaoObterPorId.Message);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    public void ObterPorId_deve_retornar_Escola_existente_quando_informado_id_valido(int idInformado)
    {
        List<Escola> ListaDadosTeste = new()
        {
            new Escola()
            {
                Id = 0,
                StatusAtividade = true,
                Nome = "Escola Rodrigo",
                CodigoMec = "12345678",
                Telefone = "12355645",
                Email = "rodrigo@gmail.com",
                InicioAtividade = new DateTime(1234,12,3),
                CategoriaAdministrativa = CategoriaAdministrativaEnums.Estadual,
                OrganizacaoAcademica = OrganizacaoAcademicaEnums.EscolaGoverno
            },
            new Escola()
            {
                Id = 1,
                StatusAtividade = true,
                Nome = "Escola Enzo menezes",
                CodigoMec = "12345678",
                Telefone = "143454345",
                Email = "enz@gmail.com",
                InicioAtividade = new DateTime(1234,12,3),
                CategoriaAdministrativa = CategoriaAdministrativaEnums.Estadual,
                OrganizacaoAcademica = OrganizacaoAcademicaEnums.EscolaGoverno
            }
       };
        _tabelas.Escolas.Value.Clear();
        _tabelas.Escolas.Value.AddRange(ListaDadosTeste);

        var ValorEsperado = ListaDadosTeste[idInformado];
        var ValorRetornado = _servicoEscola.ObterPorId(idInformado);

        Assert.Equal(ValorEsperado.Id, ValorRetornado.Id);
        Assert.Equal(ValorEsperado.StatusAtividade, ValorRetornado.StatusAtividade);
        Assert.Equal(ValorEsperado.CodigoMec, ValorRetornado.CodigoMec);
        Assert.Equal(ValorEsperado.Telefone, ValorRetornado.Telefone);
        Assert.Equal(ValorEsperado.Email, ValorRetornado.Email);
        Assert.Equal(ValorEsperado.InicioAtividade.Date, ValorRetornado.InicioAtividade.Date);
        Assert.Equal(ValorEsperado.CategoriaAdministrativa, ValorRetornado.CategoriaAdministrativa);
        Assert.Equal(ValorEsperado.OrganizacaoAcademica, ValorRetornado.OrganizacaoAcademica);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(-2)]
    public void Criar_deve_retornar_ValidationException_quando_informado_Escola_com_Id_negativo(int idInformado)
    {
        var EscolaEntrada = _escolaEntrada;
        var ValorEsperado = "Id deve ser um valor maior ou igual a zero!";
        EscolaEntrada.Id = idInformado;

        var excecao = Assert.Throws<ValidationException>(() => _servicoEscola.Criar(EscolaEntrada));

        Assert.Equal(ValorEsperado, excecao.Errors.First().ErrorMessage );
    }

    [Theory]
    [InlineData(null)]
    [InlineData("     ")]
    public void Criar_deve_retornar_ValidationException_quando_informado_Escola_com_Nome_vazio(string nomeInformado)
    {
        var EscolaEntrada = _escolaEntrada;
        var ValorEsperado = "Nome nao pode ter valor nulo ou formado por caracteres de espaco!";
        EscolaEntrada.Nome = nomeInformado;

        var excecao = Assert.Throws<ValidationException>(() => _servicoEscola.Criar(EscolaEntrada));

        Assert.Equal(ValorEsperado, excecao.Errors.First().ErrorMessage );
    }

    [Theory]
    [InlineData(null)]
    [InlineData("     ")]
    public void Criar_deve_retornar_ValidatioException_quando_informado_Escola_com_CodigoMec_vazio(string codigoMecInformado)
    {
        var EscolaEntrada = _escolaEntrada;
        var ValorEsperado = "Codigo Mec nao pode ter valor nulo ou formado por caracteres de espaco!";
        EscolaEntrada.CodigoMec = codigoMecInformado;

        var excecao = Assert.Throws<ValidationException>(() => _servicoEscola.Criar(EscolaEntrada));

        Assert.Equal(ValorEsperado, excecao.Errors.First().ErrorMessage );
    }

    [Theory]
    [InlineData("123")]
    [InlineData("123456789")]
    public void Criar_deve_retornar_ValidationException_quando_informado_Escola_com_CodigoMec_com_tamanho_diferente_que_8(string codigoMecInformado)
    {
        var EscolaEntrada = _escolaEntrada;
        var ValorEsperado = "Codigo Mec Length menor ou maior que 8 characteres!";
        EscolaEntrada.CodigoMec = codigoMecInformado;

        var excecao = Assert.Throws<ValidationException>(() => _servicoEscola.Criar(EscolaEntrada));

        Assert.Equal(ValorEsperado, excecao.Errors.First().ErrorMessage);
    }

    [Theory]
    [InlineData("abcdefgh")]
    [InlineData("1234abcd")]
    public void Criar_deve_retornar_ValidationException_quando_informado_Escola_com_CodigoMec_com_letras_ou_outros_simbolos(string codigoMecInformado)
    {
        var EscolaEntrada = _escolaEntrada;
        var ValorEsperado = "Codigo Mec e formado somente por numeros!";
        EscolaEntrada.CodigoMec = codigoMecInformado;

        var excecao = Assert.Throws<ValidationException>(() => _servicoEscola.Criar(EscolaEntrada));

        Assert.Equal(ValorEsperado, excecao.Errors.First().ErrorMessage);
    }
    
    [Theory]
    [InlineData(null)]
    [InlineData("     ")]
    public void Criar_deve_retornar_ValidationException_quando_informado_Escola_com_Telefone_vazio(string telefoneInformado)
    {
        var EscolaEntrada = _escolaEntrada;
        var ValorEsperado = "Telefone nao pode ter valor nulo ou formado por caracteres de espaco!";
        EscolaEntrada.Telefone = telefoneInformado;

        var excecao = Assert.Throws<ValidationException>(() => _servicoEscola.Criar(EscolaEntrada));

        Assert.Equal(ValorEsperado, excecao.Errors.First().ErrorMessage);
    }

    [Theory]
    [InlineData("abcdefgh")]
    [InlineData("31ds45fdgjidj")]
    public void Criar_deve_retornar_ValidationException_quando_informado_Escola_com_Telefone_com_letras_ou_outros_simbolos(string telefoneInformado)
    {
        var EscolaEntrada = _escolaEntrada;
        var ValorEsperado = "Telefone e formado somente por numeros!";
        EscolaEntrada.Telefone = telefoneInformado;

        var excecao = Assert.Throws<ValidationException>(() => _servicoEscola.Criar(EscolaEntrada));

        Assert.Equal(ValorEsperado, excecao.Errors.First().ErrorMessage);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("     ")]
    public void Criar_deve_retornar_ValidationException_quando_informado_Escola_com_Email_vazio(string emailInformado)
    {
        var EscolaEntrada = _escolaEntrada;
        var ValorEsperado = "Email nao pode ter valor nulo ou formado por caracteres de espaco!";
        EscolaEntrada.Email = emailInformado;

        var excecao = Assert.Throws<ValidationException>(() => _servicoEscola.Criar(EscolaEntrada));

        Assert.Equal(ValorEsperado, excecao.Errors.First().ErrorMessage);
    }

    [Theory]
    [InlineData("Escola Rodrigo")]
    [InlineData("Helena")]
    public void Criar_deve_retornar_ValidationException_quando_informado_Escola_com_Email_invalido(string emailInformado)
    {
        var EscolaEntrada = _escolaEntrada;
        var ValorEsperado = "A string inserida nao e um Email valido!";
        EscolaEntrada.Email = emailInformado;

        var excecao = Assert.Throws<ValidationException>(() => _servicoEscola.Criar(EscolaEntrada));

        Assert.Equal(ValorEsperado, excecao.Errors.First().ErrorMessage);
    }


    [Theory, MemberData(nameof(CasosInicioAtividadeInvalidos))]
    public void Criar_deve_retornar_ValidationException_quando_informado_Escola_com_InicioAtividade_invalido(DateTime inicioAtividadeInformado)
    {
        var EscolaEntrada = _escolaEntrada;
        var ValorEsperado = "Inicio Atividade nao pode ser maior ou igual a data atual";
        EscolaEntrada.InicioAtividade = inicioAtividadeInformado; 

        var excecao = Assert.Throws<ValidationException>(() => _servicoEscola.Criar(EscolaEntrada));

        Assert.Equal(ValorEsperado, excecao.Errors.First().ErrorMessage);
    }
    
    [Theory]
    [InlineData(-1)]
    [InlineData(30)]
    public void Criar_deve_retornar_ValidationException_quando_informado_Escola_com_CategoriaAdministrativa_invalida(int categoriaAdministrativaInformada)
    {
        var EscolaEntrada = _escolaEntrada;
        var ValorEsperado = "Valor de Categoria Administrativa fora do Enum!";
        EscolaEntrada.CategoriaAdministrativa = (CategoriaAdministrativaEnums)categoriaAdministrativaInformada;

        var excecao = Assert.Throws<ValidationException>(() => _servicoEscola.Criar(EscolaEntrada));

        Assert.Equal(ValorEsperado, excecao.Errors.First().ErrorMessage);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(30)]
    public void Criar_deve_retornar_ValidationException_quando_informado_Escola_com_OrganizacaoAcademica_invalida(int organizacaoAcademicaInformada)
    {
        var EscolaEntrada = _escolaEntrada;
        var ValorEsperado = "Valor de Organizacao Academica fora do Enum!";
        EscolaEntrada.OrganizacaoAcademica = (OrganizacaoAcademicaEnums)organizacaoAcademicaInformada;

        var excecao = Assert.Throws<ValidationException>(() => _servicoEscola.Criar(EscolaEntrada));

        Assert.Equal(ValorEsperado, excecao.Errors.First().ErrorMessage);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(-2)]
    public void Criar_deve_retornar_ValidationException_quando_informado_Escola_com_IdEndereco_negativo(int idEnderecoInformada)
    {
        var EscolaEntrada = _escolaEntrada;
        var ValorEsperado = "Id Endereco deve ser um valor maior ou igual a zero!";
        EscolaEntrada.IdEndereco = idEnderecoInformada;

        var excecao = Assert.Throws<ValidationException>(() => _servicoEscola.Criar(EscolaEntrada));

        Assert.Equal(ValorEsperado, excecao.Errors.First().ErrorMessage);
    }

    [Theory]
    [InlineData(30)]
    [InlineData(20)]
    public void Criar_deve_retornar_ValidationException_quando_informado_Escola_com_IdEndereco_inexistente(int idEnderecoInformada)
    {
        var EscolaEntrada = _escolaEntrada;
        var ValorEsperado = "Id Endereco deve ser referente a uma endereco existente!";
        EscolaEntrada.IdEndereco = idEnderecoInformada;

        var excecao = Assert.Throws<ValidationException>(() => _servicoEscola.Criar(EscolaEntrada));

        Assert.Equal(ValorEsperado, excecao.Errors.First().ErrorMessage);
    }

    [Fact]
    public void Criar_deve_retornar_ValidationException_quando_informado_Escola_com_ListaConvenios_nula()
    {
        var EscolaEntrada = _escolaEntrada;
        var EnderecoEntrada = _enderecoEntrada;
        var ValorEsperado = "Lista Convenios nao pode ser um valor nulo!";
        EscolaEntrada.ListaConvenios = null;
        _tabelas.Enderecos.Value.Clear();
        _tabelas.Enderecos.Value.Add(EnderecoEntrada);

        var excecao = Assert.Throws<ValidationException>(() => _servicoEscola.Criar(EscolaEntrada));

        Assert.Equal(ValorEsperado, excecao.Errors.First().ErrorMessage);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void Criar_deve_adicionar_Escola_no_repositorio_quando_informado_Escola_com_Id_positivo(int idInformado)
    {
        var EscolaEntrada = _escolaEntrada;
        EscolaEntrada.Id = idInformado;

        _servicoEscola.Criar(EscolaEntrada);
        var ValorRetornado = _tabelas.Escolas.Value.FirstOrDefault(EscolaEntrada);

        Assert.NotNull(ValorRetornado);
    }

    [Theory]
    [InlineData("Escola Rodrigo")]
    [InlineData("valido")]
    public void Criar_deve_adicionar_Escola_no_repositorio_quando_informado_Escola_com_Nome_valido(string nomeInformado)
    {
        var EscolaEntrada = _escolaEntrada;
        EscolaEntrada.Nome = nomeInformado;

        _servicoEscola.Criar(EscolaEntrada);
        var ValorRetornado = _tabelas.Escolas.Value.FirstOrDefault(EscolaEntrada);

        Assert.NotNull(ValorRetornado);
    }

    [Theory]
    [InlineData("87654321")]
    [InlineData("12345678")]
    public void Criar_deve_adicionar_Escola_no_repositorio_quando_informado_Escola_com_CodigoMec_valido(string nomeInformado)
    {
        var EscolaEntrada = _escolaEntrada;
        EscolaEntrada.Nome = nomeInformado;

        _servicoEscola.Criar(EscolaEntrada);
        var ValorRetornado = _tabelas.Escolas.Value.FirstOrDefault(EscolaEntrada);

        Assert.NotNull(ValorRetornado);
    }

    [Theory]
    [InlineData("9987212345")]
    [InlineData("1234567899")]
    public void Criar_deve_adicionar_Escola_no_repositorio_quando_informado_Escola_com_Telefone_valido(string telefoneInformado)
    {
        var EscolaEntrada = _escolaEntrada;
        EscolaEntrada.Telefone = telefoneInformado;

        _servicoEscola.Criar(EscolaEntrada);
        var ValorRetornado = _tabelas.Escolas.Value.FirstOrDefault(EscolaEntrada);

        Assert.NotNull(ValorRetornado);
    }

    [Theory]
    [InlineData("Engenharia@urbs")]
    [InlineData("Escola@Rodrigo")]
    public void Criar_deve_adicionar_Escola_no_repositorio_quando_informado_Escola_com_Email_valido(string emailInformado)
    {
        var EscolaEntrada = _escolaEntrada;
        EscolaEntrada.Email = emailInformado;

        _servicoEscola.Criar(EscolaEntrada);
        var ValorRetornado = _tabelas.Escolas.Value.FirstOrDefault(EscolaEntrada);

        Assert.NotNull(ValorRetornado);
    }

    [Fact]
    public void Criar_deve_adicionar_Escola_no_repositorio_quando_informado_Escola_com_InicioAtividade_valido()
    {
        var EscolaEntrada = _escolaEntrada;

        _servicoEscola.Criar(EscolaEntrada);
        var ValorRetornado = _tabelas.Escolas.Value.FirstOrDefault(EscolaEntrada);

        Assert.NotNull(ValorRetornado);
    }
    
    [Theory]
    [InlineData(CategoriaAdministrativaEnums.Estadual)]
    [InlineData(CategoriaAdministrativaEnums.Federal)]
    public void Criar_deve_adicionar_Escola_no_repositorio_quando_informado_Escola_com_CategoriaAdministrativa_valida(CategoriaAdministrativaEnums categoriaAdministrativaInformada)
    {
        var EscolaEntrada = _escolaEntrada;
        EscolaEntrada.CategoriaAdministrativa = categoriaAdministrativaInformada;

        _servicoEscola.Criar(EscolaEntrada);
        var ValorRetornado = _tabelas.Escolas.Value.FirstOrDefault(EscolaEntrada);

        Assert.NotNull(ValorRetornado);
    }

    [Theory]
    [InlineData(OrganizacaoAcademicaEnums.CentroUniversitario)]
    [InlineData(OrganizacaoAcademicaEnums.Faculdade)]
    public void Criar_deve_adicionar_Escola_no_repositorio_quando_informado_Escola_com_OrganizacaoAcademica_valida(OrganizacaoAcademicaEnums organizacaoAcademicaInformada)
    {
        var EscolaEntrada = _escolaEntrada;
        EscolaEntrada.OrganizacaoAcademica = organizacaoAcademicaInformada;

        _servicoEscola.Criar(EscolaEntrada);
        var ValorRetornado = _tabelas.Escolas.Value.FirstOrDefault(EscolaEntrada);

        Assert.NotNull(ValorRetornado);
    }

    [Theory]
    [InlineData(3)]
    [InlineData(6)]
    public void Criar_deve_adicionar_Escola_no_repositorio_quando_informado_Escola_com_IdEndereco_valido_ou_existente(int idEnderecoInformada)
    {
        var EscolaEntrada = _escolaEntrada;
        var EnderecoEntrada = _enderecoEntrada;
        EscolaEntrada.IdEndereco = idEnderecoInformada;
        EnderecoEntrada.Id = idEnderecoInformada;
        _tabelas.Enderecos.Value.Add(EnderecoEntrada);

        _servicoEscola.Criar(EscolaEntrada);
        var ValorRetornado = _tabelas.Escolas.Value.FirstOrDefault(EscolaEntrada);

        Assert.NotNull(ValorRetornado);
    }

    [Fact]
    public void Criar_deve_adicionar_Escola_no_repositorio_quando_informado_Escola_com_ListaConvenios_existente()
    {
        var EscolaEntrada = _escolaEntrada;

        _servicoEscola.Criar(EscolaEntrada);
        var ValorRetornado = _tabelas.Escolas.Value.FirstOrDefault(EscolaEntrada);

        Assert.NotNull(ValorRetornado);
    }
}