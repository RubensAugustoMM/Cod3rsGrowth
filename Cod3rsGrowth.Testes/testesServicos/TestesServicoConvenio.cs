using FluentValidation;
using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Servico;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Cod3rsGrowth.Testes;

public class TestesServicoConvenio : TesteBase
{
    private readonly ServicoConvenio _servicoConvenio;

    public TestesServicoConvenio()
    {
        _servicoConvenio = _serviceProvider.GetService<ServicoConvenio>() ?? throw new Exception("Objeto _serviceProvider retornou null apos nao encontrar ServicoConvenio!");
    }

    private void ReiniciaRepositoriosDeTeste()
    {
        _tabelas.Convenios.Value.Clear();
        _tabelas.Escolas.Value.Clear();
        _tabelas.Escolas.Value.Add(CriaNovaEscolaTeste());
        _tabelas.Empresas.Value.Clear();
        _tabelas.Empresas.Value.Add(CriaNovaEmpresaTeste());
    }

    private Convenio CriaNovoConvenioTeste()
    {
        Convenio ConvenioRetornar = new()
        {
            Id = 0,
            NumeroProcesso = 123,
            Objeto = "objeto",
            Valor = 2.0M,
            DataInicio = new DateTime(1900, 2, 3),
            IdEscola = 1,
            IdEmpresa = 1
        };

        return ConvenioRetornar;
    }

    private Empresa CriaNovaEmpresaTeste()
    {
        Empresa empresaNova = new()
        {
            Id = 1,
            Idade = 3,
            RazaoSocial = "Carlinhos Ferragens LTDA",
            NomeFantasia = "Carlinhos Ferragens",
            Cnpj = "11122233344",
            SitucaoCadastral = true,
            DataSituacaoCadastral = new DateTime(1000, 12, 03),
            DataAbertura = new DateTime(1000, 12, 03),
            CapitalSocial = 13,
            NaturezaJuridica = NaturezaJuridicaEnums.EmpresarioIndividual,
            Porte = PorteEnums.EmpresaPequenoPorte,
            MatrizFilial = MatrizFilialEnums.Matriz
        };

        return empresaNova;
    }

    private Escola CriaNovaEscolaTeste()
    {
        Escola NovaEscola = new()
        {
            Id = 1,
            StatusAtividade = true,
            Nome = "Escola Rodrigo",
            CodigoMec = "3415",
            Telefone = "12355645",
            Email = "rodrigo@gmail.com",
            InicioAtividade = new DateTime(1234, 12, 3),
            CategoriaAdministrativa = CategoriaAdministrativaEnums.Estadual,
            OrganizacaoAcademica = OrganizacaoAcademicaEnums.EscolaGoverno

        };

        return NovaEscola;
    }

    [Fact]
    public void ao_ObterTodos_deve_retornar_lista_com_apenas_um_Convenio()
    {
        ReiniciaRepositoriosDeTeste();
        List<Convenio> ValorEsperado = new()
        {
            new Convenio()
            {
                Id = 0,
                NumeroProcesso = 123,
                Objeto = "convenio convenio",
                Valor = 2.00M,
                DataInicio =  new DateTime(1917,01,30),
                IdEscola = 3,
                IdEmpresa = 12
            }
       };
        _tabelas.Convenios.Value.AddRange(ValorEsperado);

        var ValorRetornado = _servicoConvenio.ObterTodos();

        Assert.Equal(ValorEsperado.Count, ValorRetornado.Count);
    }

    [Fact]
    public void ao_ObterTodos_deve_retornar_lista_com_apenas_dois_Convenios()
    {
        ReiniciaRepositoriosDeTeste();
        List<Convenio> ValorEsperado = new()
        {
            new Convenio()
            {
                Id = 0,
                NumeroProcesso = 123,
                Objeto = "convenio convenio",
                Valor = 2.00M,
                DataInicio =  new DateTime(1917,01,30),
                IdEscola = 3,
                IdEmpresa = 12
            },
            new Convenio()
            {
                Id = 1,
                NumeroProcesso = 314,
                Objeto = "Curso Empreendedorismo - vendendo bolo de pote",
                Valor = 500_000_000.00M,
                DataInicio = new(2024,01,01),
                IdEmpresa = 4,
                IdEscola = 12
            }
       };
        _tabelas.Convenios.Value.Clear();
        _tabelas.Convenios.Value.AddRange(ValorEsperado);

        var ValorRetornado = _servicoConvenio.ObterTodos();

        Assert.Equal(ValorEsperado.Count, ValorRetornado.Count);
    }

    [Theory]
    [InlineData(2)]
    [InlineData(-1)]
    public void ObterPorId_deve_lancar_Exception_quando_informado_Id_invalido_ou_inexistente(int idInformado)
    {
        ReiniciaRepositoriosDeTeste();
        List<Convenio> ListaDadosTeste = new()
        {
            new Convenio()
            {
                Id = 0,
                NumeroProcesso = 123,
                Objeto = "convenio convenio",
                Valor = 2.00M,
                DataInicio =  new DateTime(1917,01,30),
                IdEscola = 3,
                IdEmpresa = 12
            },
            new Convenio()
            {
                Id = 1,
                NumeroProcesso = 314,
                Objeto = "Curso Empreendedorismo - vendendo bolo de pote",
                Valor = 500_000_000.00M,
                DataInicio = new(2024,01,01),
                IdEmpresa = 4,
                IdEscola = 12
            }
       };
        _tabelas.Convenios.Value.AddRange(ListaDadosTeste);

        var excecaoObterPorId = Assert.Throws<Exception>(() => _servicoConvenio.ObterPorId(idInformado));

        Assert.Equal($"Nenhum Convenio com Id {idInformado} existe no contexto atual!\n", excecaoObterPorId.Message);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    public void ObterPorId_deve_retornar_Convenio_existente_quando_informado_id_valido(int idInformado)
    {
        ReiniciaRepositoriosDeTeste();
        List<Convenio> ListaDadosTeste = new()
        {
            new Convenio()
            {
                Id = 0,
                NumeroProcesso = 123,
                Objeto = "convenio convenio",
                Valor = 2.00M,
                DataInicio =  new DateTime(1917,01,30),
                IdEscola = 3,
                IdEmpresa = 12
            },
            new Convenio()
            {
                Id = 1,
                NumeroProcesso = 314,
                Objeto = "Curso Empreendedorismo - vendendo bolo de pote",
                Valor = 500_000_000.00M,
                DataInicio = new(2024,01,01),
                IdEmpresa = 4,
                IdEscola = 12
            }
       };
        _tabelas.Convenios.Value.Clear();
        _tabelas.Convenios.Value.AddRange(ListaDadosTeste);

        var ValorEsperado = ListaDadosTeste[idInformado];
        var ValorRetornado = _servicoConvenio.ObterPorId(idInformado);

        Assert.Equal(ValorEsperado.Id, ValorRetornado.Id);
        Assert.Equal(ValorEsperado.NumeroProcesso, ValorEsperado.NumeroProcesso);
        Assert.Equal(ValorEsperado.Objeto, ValorRetornado.Objeto);
        Assert.Equal(ValorEsperado.Valor, ValorRetornado.Valor);
        Assert.Equal(ValorEsperado.DataInicio.Date, ValorRetornado.DataInicio.Date);
        Assert.Equal(ValorEsperado.IdEmpresa, ValorEsperado.IdEmpresa);
        Assert.Equal(ValorEsperado.IdEscola, ValorRetornado.IdEscola);
    }

    [Theory]
    [InlineData(-12)]
    [InlineData(-1)]
    public void Criar_deve_lancar_ValidationException_quando_informado_Convenio_com_Id_invalido(int idInformado)
    {
        ReiniciaRepositoriosDeTeste();
        var convenioEntrada = CriaNovoConvenioTeste();
        var ValorEsperado = "Id deve ser um valor maior ou igual a zero!";
        convenioEntrada.Id = idInformado;

        var excecao = Assert.Throws<ValidationException>(() => _servicoConvenio.Criar(convenioEntrada));

        Assert.Equal(ValorEsperado, excecao.Errors.First().ErrorMessage);
    }
    [Theory]
    [InlineData(-12)]
    [InlineData(-1)]
    public void Criar_deve_lancar_ValidationException_quando_informado_Convenio_com_NumeroProcesso_Invalido(int numeroProcessoInformado)
    {
        ReiniciaRepositoriosDeTeste();
        var convenioEntrada = CriaNovoConvenioTeste();
        var ValorEsperado = "Numero Processo deve ser maior que zero!";
        convenioEntrada.NumeroProcesso = numeroProcessoInformado;

        var excecao = Assert.Throws<ValidationException>(() => _servicoConvenio.Criar(convenioEntrada));

        Assert.Equal(ValorEsperado, excecao.Errors.First().ErrorMessage);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("      ")]
    public void Criar_deve_lancar_ValidationException_quando_informado_Convenio_com_Objeto_null_ou_com_somente_espacos(string objetoInformado)
    {
        ReiniciaRepositoriosDeTeste();
        var convenioEntrada = CriaNovoConvenioTeste();
        var ValorEsperado = "Objeto nao pode ter valor nulo ou formado por caracteres de espaco!";
        convenioEntrada.Objeto = objetoInformado;

        var excecao = Assert.Throws<ValidationException>(() => _servicoConvenio.Criar(convenioEntrada));

        Assert.Equal(ValorEsperado, excecao.Errors.First().ErrorMessage);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-10_000)]
    public void Criar_deve_lancar_ValidationException_quando_informado_Convenio_com_Valor_invalido(decimal ValorInformado)
    {
        ReiniciaRepositoriosDeTeste();
        var convenioEntrada = CriaNovoConvenioTeste();
        var ValorEsperado = "Valor do convenio deve ser maior que zero!";
        convenioEntrada.Valor = ValorInformado;

        var excecao = Assert.Throws<ValidationException>(() => _servicoConvenio.Criar(convenioEntrada));

        Assert.Equal(ValorEsperado, excecao.Errors.First().ErrorMessage);
    }

    [Fact]
    public void Criar_develancar_ValidationException_quando_informado_Convenio_com_DataInicio_anterior_a_1889()
    {
        ReiniciaRepositoriosDeTeste();
        var ConvenioEntrada = CriaNovoConvenioTeste();
        var ValorEsperado = "Data Inicio deve ser após a proclamacao da republica!";
        ConvenioEntrada.DataInicio = new(1888, 8, 15);

        var excecao = Assert.Throws<ValidationException>(() => _servicoConvenio.Criar(ConvenioEntrada));

        Assert.Equal(ValorEsperado, excecao.Errors.First().ErrorMessage);
    }

    [Fact]
    public void Criar_deve_retornar_ValidationException_quando_quando_informado_Convenio_com_DataInicio_apos_data_atual()
    {
        ReiniciaRepositoriosDeTeste();
        var ConvenioEntrada = CriaNovoConvenioTeste();
        var ValorEsperado = "Data Inicio deve ser anterior ou igual a data atual!";
        ConvenioEntrada.DataInicio = new DateTime(5000, 3, 2);

        var excecao = Assert.Throws<ValidationException>(() => _servicoConvenio.Criar(ConvenioEntrada));

        Assert.Equal(ValorEsperado, excecao.Errors.First().ErrorMessage);
    }

    [Fact]
    public void Criar_deve_retornar_ValidationException_quando_informado_Convenio_com_DataTermino_anterior_a_DataInicio()
    {
        ReiniciaRepositoriosDeTeste();
        var convenioEntrada = CriaNovoConvenioTeste();
        var ValorEsperado = "Data Termino deve ser maior que a DataInicio!";
        convenioEntrada.DataTermino = new DateTime(1500, 12, 2);

        var excecao = Assert.Throws<ValidationException>(() => _servicoConvenio.Criar(convenioEntrada));

        Assert.Equal(ValorEsperado, excecao.Errors.First().ErrorMessage);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(-2)]
    public void Criar_deve_retornar_retornar_ValidationException_quando_informado_Convenio_com_IdEscola_negativo(int idEscolaInformado)
    {
        ReiniciaRepositoriosDeTeste();
        var convenioEntrada = CriaNovoConvenioTeste();
        var ValorEsperado = "Id Escola deve ser maior ou igual a zero!";
        convenioEntrada.IdEscola = idEscolaInformado;

        var excecao = Assert.Throws<ValidationException>(() => _servicoConvenio.Criar(convenioEntrada));

        Assert.Equal(ValorEsperado, excecao.Errors.First().ErrorMessage);
    }

    [Theory]
    [InlineData(10)]
    [InlineData(8)]
    public void Criar_deve_retornar_ValidationException_quando_informado_Convenio_com_IdEscola_referente_a_escola_inexistente(int idEscolaInformado)
    {
        ReiniciaRepositoriosDeTeste();
        var convenioEntrada = CriaNovoConvenioTeste();
        var ValorEsperado = "Id Escola deve ser referente a uma escola existente!";
        convenioEntrada.IdEscola = idEscolaInformado;

        var excecao = Assert.Throws<ValidationException>(() => _servicoConvenio.Criar(convenioEntrada));

        Assert.Equal(ValorEsperado, excecao.Errors.First().ErrorMessage);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(-2)]
    public void Criar_deve_retornar_ValidationException_quando_informado_Convenio_com_IdEmpresa_negativo(int idEmpresaInformado)
    {
        ReiniciaRepositoriosDeTeste();
        var convenioEntrada = CriaNovoConvenioTeste();
        var ValorEsperado = "Id Empresa deve ser maior ou igual a zero!";
        convenioEntrada.IdEmpresa = idEmpresaInformado;

        var excecao = Assert.Throws<ValidationException>(() => _servicoConvenio.Criar(convenioEntrada));

        Assert.Equal(ValorEsperado, excecao.Errors.First().ErrorMessage);
    }

    [Theory]
    [InlineData(4)]
    [InlineData(5)]
    public void Criar_deve_retornar_ValidationException_quando_informado_Convenio_com_IdEmpresa_referente_a_Empresa_inexistente(int idEmpresaInformado)
    {
        ReiniciaRepositoriosDeTeste();
        var convenioEntrada = CriaNovoConvenioTeste();
        var ValorEsperado = "Id Empresa deve ser referente a uma empresa existente!";
        convenioEntrada.IdEmpresa = idEmpresaInformado;

        var excecao = Assert.Throws<ValidationException>(() => _servicoConvenio.Criar(convenioEntrada));

        Assert.Equal(ValorEsperado, excecao.Errors.First().ErrorMessage);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void Criar_deve_adicionar_Convenio_no_repositorio_quando_informado_Convenio_com_Id_valido(int IdInformado)
    {
        ReiniciaRepositoriosDeTeste();
        var convenioEntrada = CriaNovoConvenioTeste();
        convenioEntrada.Id = IdInformado;

        _servicoConvenio.Criar(convenioEntrada);
        var ValorRetornado = _tabelas.Convenios.Value.FirstOrDefault(convenioEntrada);

        Assert.NotNull(ValorRetornado);
    }

    [Theory]
    [InlineData(123)]
    [InlineData(98882)]
    public void Criar_deve_adicionar_Convenio_no_repositorio_quando_informado_Convenio_com_NumeroProcesso_valido(int numeroProcessoInformado)
    {
        ReiniciaRepositoriosDeTeste();
        var convenioEntrada = CriaNovoConvenioTeste();
        convenioEntrada.NumeroProcesso = numeroProcessoInformado;

        _servicoConvenio.Criar(convenioEntrada);
        var ValorRetornado = _tabelas.Convenios.Value.FirstOrDefault(convenioEntrada);

        Assert.NotNull(ValorRetornado);
    }

    [Theory]
    [InlineData("Objeto")]
    [InlineData("Curso bolo de pote")]
    public void Criar_deve_adicionar_Convenio_no_repositorio_quando_informado_Convenio_com_Objeto_valido(string objetoInformado)
    {
        ReiniciaRepositoriosDeTeste();
        var convenioEntrada = CriaNovoConvenioTeste();
        convenioEntrada.Objeto = objetoInformado;

        _servicoConvenio.Criar(convenioEntrada);
        var ValorRetornado = _tabelas.Convenios.Value.FirstOrDefault(convenioEntrada);

        Assert.NotNull(ValorRetornado);
    }

    [Theory]
    [InlineData(10.99)]
    [InlineData(10_000)]
    public void Criar_deve_adicionar_Convenio_no_repositorio_quando_informado_Convenio_com_Valor_valido(int ValorInformado)
    {
        ReiniciaRepositoriosDeTeste();
        var convenioEntrada = CriaNovoConvenioTeste();
        convenioEntrada.Valor = ValorInformado;

        _servicoConvenio.Criar(convenioEntrada);
        var ValorRetornado = _tabelas.Convenios.Value.FirstOrDefault(convenioEntrada);

        Assert.NotNull(ValorRetornado);
    }

    [Fact]
    public void Criar_deve_adicionar_Convenio_no_repositorio_quando_informado_Convenio_com_DataInicio_valida()
    {
        ReiniciaRepositoriosDeTeste();
        var convenioEntrada = CriaNovoConvenioTeste();

        _servicoConvenio.Criar(convenioEntrada);
        var ValorRetornado = _tabelas.Convenios.Value.FirstOrDefault(convenioEntrada);

        Assert.NotNull(ValorRetornado);
    }

    [Fact]
    public void Criar_deve_adicionar_Convenio_no_repositorio_quando_informado_Convenio_com_DataTermino_valida()
    {
        ReiniciaRepositoriosDeTeste();
        var convenioEntrada = CriaNovoConvenioTeste();

        _servicoConvenio.Criar(convenioEntrada);
        var ValorRetornado = _tabelas.Convenios.Value.FirstOrDefault(convenioEntrada);

        Assert.NotNull(ValorRetornado);
    }

    [Theory]
    [InlineData(10)]
    [InlineData(20)]
    public void Criar_deve_adicionar_Convenio_no_repositorio_quando_informado_Convenio_com_IdEscola_valido_e_referente_a_escola_existente(int idEscolaInformado)
    {
        ReiniciaRepositoriosDeTeste();
        var convenioEntrada = CriaNovoConvenioTeste();
        var escolaEntrada = CriaNovaEscolaTeste();
        convenioEntrada.IdEscola = idEscolaInformado;
        escolaEntrada.Id = idEscolaInformado;
        _tabelas.Escolas.Value.Add(escolaEntrada);

        _servicoConvenio.Criar(convenioEntrada);
        var ValorRetornado = _tabelas.Convenios.Value.FirstOrDefault(convenioEntrada);

        Assert.NotNull(ValorRetornado);
    }

    [Theory]
    [InlineData(5)]
    [InlineData(10)]
    public void Criar_deve_adicionar_Convenio_no_repositorio_quando_informado_Convenio_com_IdEmpresa_valido_e_referente_a_Empresa_existente(int idEmpresaInformado)
    {
        ReiniciaRepositoriosDeTeste();
        var convenioEntrada = CriaNovoConvenioTeste();
        var EmpresaEntrada = CriaNovaEmpresaTeste();
        convenioEntrada.IdEmpresa = idEmpresaInformado;
        EmpresaEntrada.Id = idEmpresaInformado;
        _tabelas.Empresas.Value.Add(EmpresaEntrada);

        _servicoConvenio.Criar(convenioEntrada);
        var ValorRetornado = _tabelas.Convenios.Value.FirstOrDefault(convenioEntrada);

        Assert.NotNull(ValorRetornado);
    }

    [Theory]
    [InlineData(20)]
    [InlineData(30)]
    public void Atualizar_deve_retornar_Exception_quando_informado_Convenio_com_Id_inexistente(int idInformado)
    {
        ReiniciaRepositoriosDeTeste();
        var ConvenioEntrada = CriaNovoConvenioTeste();
        ConvenioEntrada.Id = idInformado;

        var excecao = Assert.Throws<Exception>(() => _servicoConvenio.Atualizar(ConvenioEntrada));

        Assert.Equal($"Nenhum Convenio com Id {idInformado} existe no contexto atual!\n", excecao.Message);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("   ")]
    public void Atualizar_deve_retornar_ValidationException_quando_informado_Convenio_invalido(string objetoInformado)
    {
        ReiniciaRepositoriosDeTeste();
        var ConvenioEntrada = CriaNovoConvenioTeste();
        var ConvenioAtualizar = CriaNovoConvenioTeste();
        ConvenioEntrada.Objeto = objetoInformado;
        _tabelas.Convenios.Value.Add(ConvenioAtualizar);

        var excecao = Assert.Throws<ValidationException>(() => _servicoConvenio.Atualizar(ConvenioEntrada));

        Assert.Equal("Objeto nao pode ter valor nulo ou formado por caracteres de espaco!", excecao.Errors.First().ErrorMessage);
    }

    [Theory]
    [InlineData(1234, "Objeto1", 2_000.0)]
    [InlineData(320, "Objeto2", 320.50)]
    public void Atualizar_deve_alterar_parametros_de_Convenio_existente_quando_informado_Convenio_valido(int numeroInformado, string objetoInformado, decimal valorInformado)
    {
        ReiniciaRepositoriosDeTeste();
        var ConvenioEntrada = CriaNovoConvenioTeste();
        var ConvenioAtualizar = CriaNovoConvenioTeste();
        ConvenioEntrada.NumeroProcesso = numeroInformado;
        ConvenioEntrada.Objeto = objetoInformado;
        ConvenioEntrada.Valor = valorInformado;
        _tabelas.Convenios.Value.Add(ConvenioAtualizar);

        _servicoConvenio.Atualizar(ConvenioEntrada);
        var ValorRetornado = _tabelas.Convenios.Value.FirstOrDefault(convenio => convenio.Id == ConvenioEntrada.Id);

        Assert.Equal(numeroInformado, ValorRetornado.NumeroProcesso);
        Assert.Equal(objetoInformado, ValorRetornado.Objeto);
        Assert.Equal(valorInformado, ValorRetornado.Valor);
    }
}