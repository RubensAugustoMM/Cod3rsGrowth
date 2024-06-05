using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Servico;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Cod3rsGrowth.Testes;

public class TestesServicoConvenio : TesteBase
{
    private readonly ServicoConvenio _servicoConvenio;
    private readonly TabelaSingleton _tabelas;
    public static TheoryData<DateTime> CasosDataInicioInvalidos = new()
    {
        {new DateTime(1500,2,3)},
        {new DateTime(4000,1,1)}
    };
    public static TheoryData<DateTime> CasosDataTerminoInvalidos = new()
    {
        {new DateTime(1899,2,3)},
        {new DateTime(1500,2,3)}
    };
    public static TheoryData<DateTime> CasosDataInicioValidos = new()
    {
        {new DateTime(1900,2,3)},
        {new DateTime(2000,3,4)}
    };
    public static TheoryData<DateTime> CasosDataTerminoValidos = new()
    {
        {new DateTime(3000,2,3)},
        {new DateTime(2050,2, 4)}
    };

    public TestesServicoConvenio()
    {
        _servicoConvenio = _serviceProvider.GetService<ServicoConvenio>() ?? throw new Exception("Objeto _serviceProvider retornou null apos nao encontrar ServicoConvenio!");

        _tabelas = TabelaSingleton.Instance;
    }

    [Fact]
    public void ao_ObterTodos_deve_retornar_lista_com_apenas_um_Convenio()
    {
        List<Convenio> ValorEsperado = new()
        {
            new Convenio()
            {
                Id = 0,
                NumeroProcesso = 123,
                Objeto = "convenio convenio",
                Valor = 2.00,
                DataInicio =  new DateTime(1917,01,30),
                IdEscola = 3,
                IdEmpresa = 12
            }
       };
        _tabelas.Convenios.Value.Clear();
        _tabelas.Convenios.Value.AddRange(ValorEsperado);

        var ValorRetornado = _servicoConvenio.ObterTodos();

        Assert.Equal(ValorEsperado.Count, ValorRetornado.Count);
    }

    [Fact]
    public void ao_ObterTodos_deve_retornar_lista_com_apenas_dois_Convenios()
    {
        List<Convenio> ValorEsperado = new()
        {
            new Convenio()
            {
                Id = 0,
                NumeroProcesso = 123,
                Objeto = "convenio convenio",
                Valor = 2.00,
                DataInicio =  new DateTime(1917,01,30),
                IdEscola = 3,
                IdEmpresa = 12
            },
            new Convenio()
            {
                Id = 1,
                NumeroProcesso = 314,
                Objeto = "Curso Empreendedorismo - vendendo bolo de pote",
                Valor = 500_000_000.00,
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
        List<Convenio> ListaDadosTeste = new()
        {
            new Convenio()
            {
                Id = 0,
                NumeroProcesso = 123,
                Objeto = "convenio convenio",
                Valor = 2.00,
                DataInicio =  new DateTime(1917,01,30),
                IdEscola = 3,
                IdEmpresa = 12
            },
            new Convenio()
            {
                Id = 1,
                NumeroProcesso = 314,
                Objeto = "Curso Empreendedorismo - vendendo bolo de pote",
                Valor = 500_000_000.00,
                DataInicio = new(2024,01,01),
                IdEmpresa = 4,
                IdEscola = 12
            }
       };
        _tabelas.Convenios.Value.Clear();
        _tabelas.Convenios.Value.AddRange(ListaDadosTeste);

        var excecaoObterPorId = Assert.Throws<Exception>(() => _servicoConvenio.ObterPorId(idInformado));

        Assert.Equal($"Nenhum Convenio com Id {idInformado} existe no contexto atual!\n", excecaoObterPorId.Message);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    public void ObterPorId_deve_retornar_Convenio_existente_quando_informado_id_valido(int idInformado)
    {
        List<Convenio> ListaDadosTeste = new()
        {
            new Convenio()
            {
                Id = 0,
                NumeroProcesso = 123,
                Objeto = "convenio convenio",
                Valor = 2.00,
                DataInicio =  new DateTime(1917,01,30),
                IdEscola = 3,
                IdEmpresa = 12
            },
            new Convenio()
            {
                Id = 1,
                NumeroProcesso = 314,
                Objeto = "Curso Empreendedorismo - vendendo bolo de pote",
                Valor = 500_000_000.00,
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
    public void Criar_deve_retornar_False_quando_informado_Convenio_com_Id_invalido(int IdInformado)
    {
        Convenio ConvenioEntrada = new()
        {
            Id = IdInformado,
            NumeroProcesso = 123,
            Objeto = "convenio convenio",
            Valor = 2.0,
            DataInicio = new DateTime(1917, 01, 30),
            IdEscola = 3,
            IdEmpresa = 12
        };
        Escola EscolaEntrada = new()
        {

            Id = 3,
            StatusAtividade = true,
            Nome = "Escola Rodrigo",
            CodigoMec = "3415",
            Telefone = "12355645",
            Email = "rodrigo@gmail.com",
            InicioAtividade = new DateTime(1234, 12, 3),
            CategoriaAdministrativa = CategoriaAdministrativaEnums.Estadual,
            OrganizacaoAcademica = OrganizacaoAcademicaEnums.EscolaGoverno

        };
        Empresa EmpresaEntrada = new()
        {
            Id = 12,
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
        _tabelas.Convenios.Value.Clear();
        _tabelas.Escolas.Value.Clear();
        _tabelas.Empresas.Value.Clear();
        _tabelas.Escolas.Value.Add(EscolaEntrada);
        _tabelas.Empresas.Value.Add(EmpresaEntrada);

        var ConvenioValido =  _servicoConvenio.Criar(ConvenioEntrada);

        Assert.False(ConvenioValido);
    }

    [Theory]
    [InlineData(-12)]
    [InlineData(-1)]
    public void Criar_deve_retornar_False_quando_informado_Convenio_com_NumeroProcesso_Invalido(int numeroProcessoInformado)
    {
        Convenio ConvenioEntrada = new()
        {
            Id = 0,
            NumeroProcesso = numeroProcessoInformado,
            Objeto = "convenio convenio",
            Valor = 2.0,
            DataInicio = new DateTime(1917, 01, 30),
            IdEscola = 3,
            IdEmpresa = 12
        };
        Escola EscolaEntrada = new()
        {

            Id = 3,
            StatusAtividade = true,
            Nome = "Escola Rodrigo",
            CodigoMec = "3415",
            Telefone = "12355645",
            Email = "rodrigo@gmail.com",
            InicioAtividade = new DateTime(1234, 12, 3),
            CategoriaAdministrativa = CategoriaAdministrativaEnums.Estadual,
            OrganizacaoAcademica = OrganizacaoAcademicaEnums.EscolaGoverno

        };
        Empresa EmpresaEntrada = new()
        {
            Id = 12,
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
        _tabelas.Convenios.Value.Clear();
        _tabelas.Escolas.Value.Clear();
        _tabelas.Empresas.Value.Clear();
        _tabelas.Escolas.Value.Add(EscolaEntrada);
        _tabelas.Empresas.Value.Add(EmpresaEntrada);

        var ConvenioValido =  _servicoConvenio.Criar(ConvenioEntrada);

        Assert.False(ConvenioValido);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("      ")]
    public void Criar_deve_retornar_False_quando_informado_Convenio_com_Objeto_null_ou_com_somente_espacos(string objetoInformado)
    {
        Convenio ConvenioEntrada = new()
        {
            Id = 0,
            NumeroProcesso = 123,
            Objeto = objetoInformado,
            Valor = 2.00,
            DataInicio = new DateTime(1917, 01, 30),
            IdEscola = 3,
            IdEmpresa = 12
        };
        Escola EscolaEntrada = new()
        {

            Id = 3,
            StatusAtividade = true,
            Nome = "Escola Rodrigo",
            CodigoMec = "3415",
            Telefone = "12355645",
            Email = "rodrigo@gmail.com",
            InicioAtividade = new DateTime(1234, 12, 3),
            CategoriaAdministrativa = CategoriaAdministrativaEnums.Estadual,
            OrganizacaoAcademica = OrganizacaoAcademicaEnums.EscolaGoverno

        };
        Empresa EmpresaEntrada = new()
        {
            Id = 12,
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
        _tabelas.Convenios.Value.Clear();
        _tabelas.Escolas.Value.Clear();
        _tabelas.Empresas.Value.Clear();
        _tabelas.Escolas.Value.Add(EscolaEntrada);
        _tabelas.Empresas.Value.Add(EmpresaEntrada);

        var convenioValido = _servicoConvenio.Criar(ConvenioEntrada);

        Assert.False(convenioValido);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-10_000)]
    public void Criar_deve_retornar_False_quando_informado_Convenio_com_Valor_invalido(int ValorInformado)
    {
        Convenio ConvenioEntrada = new()
        {
            Id = 0,
            NumeroProcesso = 123,
            Objeto = "objeto",
            Valor = ValorInformado,
            DataInicio = new DateTime(1917, 01, 30),
            IdEscola = 3,
            IdEmpresa = 12
        };
        Escola EscolaEntrada = new()
        {

            Id = 3,
            StatusAtividade = true,
            Nome = "Escola Rodrigo",
            CodigoMec = "3415",
            Telefone = "12355645",
            Email = "rodrigo@gmail.com",
            InicioAtividade = new DateTime(1234, 12, 3),
            CategoriaAdministrativa = CategoriaAdministrativaEnums.Estadual,
            OrganizacaoAcademica = OrganizacaoAcademicaEnums.EscolaGoverno

        };
        Empresa EmpresaEntrada = new()
        {
            Id = 12,
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
        _tabelas.Convenios.Value.Clear();
        _tabelas.Escolas.Value.Clear();
        _tabelas.Empresas.Value.Clear();
        _tabelas.Escolas.Value.Add(EscolaEntrada);
        _tabelas.Empresas.Value.Add(EmpresaEntrada);

        var convenioValido = _servicoConvenio.Criar(ConvenioEntrada);

        Assert.False(convenioValido);
    }
 
    [Theory, MemberData(nameof(CasosDataInicioInvalidos))]
    public void Criar_deve_retornar_False_quando_informado_Convenio_com_DataInicio_invalida(DateTime DataInicioInformada)
    {
        Convenio ConvenioEntrada = new()
        {
            Id = 0,
            NumeroProcesso = 123,
            Objeto = "objeto",
            Valor = 2.0,
            DataInicio = DataInicioInformada,
            IdEscola = 3,
            IdEmpresa = 12
        };
        Escola EscolaEntrada = new()
        {

            Id = 3,
            StatusAtividade = true,
            Nome = "Escola Rodrigo",
            CodigoMec = "3415",
            Telefone = "12355645",
            Email = "rodrigo@gmail.com",
            InicioAtividade = new DateTime(1234, 12, 3),
            CategoriaAdministrativa = CategoriaAdministrativaEnums.Estadual,
            OrganizacaoAcademica = OrganizacaoAcademicaEnums.EscolaGoverno

        };
        Empresa EmpresaEntrada = new()
        {
            Id = 12,
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
        _tabelas.Convenios.Value.Clear();
        _tabelas.Escolas.Value.Clear();
        _tabelas.Empresas.Value.Clear();
        _tabelas.Escolas.Value.Add(EscolaEntrada);
        _tabelas.Empresas.Value.Add(EmpresaEntrada);

        var convenioValido = _servicoConvenio.Criar(ConvenioEntrada);

        Assert.False(convenioValido);
    }

    [Theory, MemberData(nameof(CasosDataTerminoInvalidos))]
    public void Criar_deve_retornar_False_quando_informado_Convenio_com_DataTermino_anterior_a_DataInicio(DateTime DataTerminoInformada)
    {
        Convenio ConvenioEntrada = new()
        {
            Id = 0,
            NumeroProcesso = 123,
            Objeto = "objeto",
            Valor = 2.0,
            DataInicio = new DateTime(1900,2,3),
            DataTermino = DataTerminoInformada,
            IdEscola = 3,
            IdEmpresa = 12
        };
        Escola EscolaEntrada = new()
        {

            Id = 3,
            StatusAtividade = true,
            Nome = "Escola Rodrigo",
            CodigoMec = "3415",
            Telefone = "12355645",
            Email = "rodrigo@gmail.com",
            InicioAtividade = new DateTime(1234, 12, 3),
            CategoriaAdministrativa = CategoriaAdministrativaEnums.Estadual,
            OrganizacaoAcademica = OrganizacaoAcademicaEnums.EscolaGoverno

        };
        Empresa EmpresaEntrada = new()
        {
            Id = 12,
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
        _tabelas.Convenios.Value.Clear();
        _tabelas.Escolas.Value.Clear();
        _tabelas.Empresas.Value.Clear();
        _tabelas.Escolas.Value.Add(EscolaEntrada);
        _tabelas.Empresas.Value.Add(EmpresaEntrada);

        var convenioValido = _servicoConvenio.Criar(ConvenioEntrada);

        Assert.False(convenioValido);
    }   

    [Theory]
    [InlineData(-1)]
    [InlineData(-6)]
    public void Criar_deve_retornar_False_quando_informado_Convenio_com_IdEscola_invalido(int idEscolaInformado)
    {
        Convenio ConvenioEntrada = new()
        {
            Id = 0,
            NumeroProcesso = 123,
            Objeto = "objeto",
            Valor = 2.0,
            DataInicio = new DateTime(1900,2,3),
            IdEscola = idEscolaInformado,
            IdEmpresa = 12
        };
        Empresa EmpresaEntrada = new()
        {
            Id = 12,
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
        _tabelas.Convenios.Value.Clear();
        _tabelas.Escolas.Value.Clear();
        _tabelas.Empresas.Value.Clear();
        _tabelas.Empresas.Value.Add(EmpresaEntrada);

        var convenioValido = _servicoConvenio.Criar(ConvenioEntrada);

        Assert.False(convenioValido);
    }   

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void Criar_deve_retornar_False_quando_informado_Convenio_com_IdEscola_referente_a_escola_existente(int idEscolaInformado)
    {
        Convenio ConvenioEntrada = new()
        {
            Id = 0,
            NumeroProcesso = 123,
            Objeto = "objeto",
            Valor = 2.0,
            DataInicio = new DateTime(1900, 2, 3),
            IdEscola = idEscolaInformado,
            IdEmpresa = 12
        };
        Empresa EmpresaEntrada = new()
        {
            Id = 12,
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
        _tabelas.Convenios.Value.Clear();
        _tabelas.Escolas.Value.Clear();
        _tabelas.Empresas.Value.Clear();
        _tabelas.Empresas.Value.Add(EmpresaEntrada);

        var convenioValido = _servicoConvenio.Criar(ConvenioEntrada);

        Assert.False(convenioValido);
    }      

    [Theory]
    [InlineData(-1)]
    [InlineData(-6)]
    public void Criar_deve_retornar_False_quando_informado_Convenio_com_IdEmpresa_invalido(int idEmpresaInformado)
    {
        Convenio ConvenioEntrada = new()
        {
            Id = 0,
            NumeroProcesso = 123,
            Objeto = "objeto",
            Valor = 2.0,
            DataInicio = new DateTime(1900, 2, 3),
            DataTermino = new DateTime(2000, 2, 3),
            IdEscola = 3,
            IdEmpresa = idEmpresaInformado
        };
        Escola EscolaEntrada = new()
        {

            Id = 3,
            StatusAtividade = true,
            Nome = "Escola Rodrigo",
            CodigoMec = "3415",
            Telefone = "12355645",
            Email = "rodrigo@gmail.com",
            InicioAtividade = new DateTime(1234, 12, 3),
            CategoriaAdministrativa = CategoriaAdministrativaEnums.Estadual,
            OrganizacaoAcademica = OrganizacaoAcademicaEnums.EscolaGoverno

        };
        _tabelas.Convenios.Value.Clear();
        _tabelas.Escolas.Value.Clear();
        _tabelas.Empresas.Value.Clear();
        _tabelas.Escolas.Value.Add(EscolaEntrada);

        var convenioValido = _servicoConvenio.Criar(ConvenioEntrada);

        Assert.False(convenioValido);
    }     

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void Criar_deve_retornar_False_quando_informado_Convenio_com_IdEmpresa_referente_a_Empresa_existente(int idEmpresaInformado)
    {
        Convenio ConvenioEntrada = new()
        {
            Id = 0,
            NumeroProcesso = 123,
            Objeto = "objeto",
            Valor = 2.0,
            DataInicio = new DateTime(1900,2,3),
            IdEscola = 3,
            IdEmpresa = idEmpresaInformado
        };
        Escola EscolaEntrada = new()
        {

            Id = 3,
            StatusAtividade = true,
            Nome = "Escola Rodrigo",
            CodigoMec = "3415",
            Telefone = "12355645",
            Email = "rodrigo@gmail.com",
            InicioAtividade = new DateTime(1234, 12, 3),
            CategoriaAdministrativa = CategoriaAdministrativaEnums.Estadual,
            OrganizacaoAcademica = OrganizacaoAcademicaEnums.EscolaGoverno

        };
        _tabelas.Convenios.Value.Clear();
        _tabelas.Escolas.Value.Clear();
        _tabelas.Empresas.Value.Clear();
        _tabelas.Escolas.Value.Add(EscolaEntrada);

        var convenioValido = _servicoConvenio.Criar(ConvenioEntrada);

        Assert.False(convenioValido);
    }      

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void Criar_deve_retornar_True_quando_informado_Convenio_com_Id_valido(int IdInformado)
    {
        Convenio ConvenioEntrada = new()
        {
            Id = IdInformado,
            NumeroProcesso = 123,
            Objeto = "convenio convenio",
            Valor = 2.0,
            DataInicio = new DateTime(1917, 01, 30),
            IdEscola = 3,
            IdEmpresa = 12
        };
        Escola EscolaEntrada = new()
        {

            Id = 3,
            StatusAtividade = true,
            Nome = "Escola Rodrigo",
            CodigoMec = "3415",
            Telefone = "12355645",
            Email = "rodrigo@gmail.com",
            InicioAtividade = new DateTime(1234, 12, 3),
            CategoriaAdministrativa = CategoriaAdministrativaEnums.Estadual,
            OrganizacaoAcademica = OrganizacaoAcademicaEnums.EscolaGoverno

        };
        Empresa EmpresaEntrada = new()
        {
            Id = 12,
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
        _tabelas.Convenios.Value.Clear();
        _tabelas.Escolas.Value.Clear();
        _tabelas.Empresas.Value.Clear();
        _tabelas.Escolas.Value.Add(EscolaEntrada);
        _tabelas.Empresas.Value.Add(EmpresaEntrada);

        var ConvenioValido =  _servicoConvenio.Criar(ConvenioEntrada);

        Assert.True(ConvenioValido);
    }

    [Theory]
    [InlineData(123)]
    [InlineData(98882)]
    public void Criar_deve_retornar_True_quando_informado_Convenio_com_NumeroProcesso_valido(int numeroProcessoInformado)
    {
        Convenio ConvenioEntrada = new()
        {
            Id = 0,
            NumeroProcesso = numeroProcessoInformado,
            Objeto = "convenio convenio",
            Valor = 2.0,
            DataInicio = new DateTime(1917, 01, 30),
            IdEscola = 3,
            IdEmpresa = 12
        };
        Escola EscolaEntrada = new()
        {

            Id = 3,
            StatusAtividade = true,
            Nome = "Escola Rodrigo",
            CodigoMec = "3415",
            Telefone = "12355645",
            Email = "rodrigo@gmail.com",
            InicioAtividade = new DateTime(1234, 12, 3),
            CategoriaAdministrativa = CategoriaAdministrativaEnums.Estadual,
            OrganizacaoAcademica = OrganizacaoAcademicaEnums.EscolaGoverno

        };
        Empresa EmpresaEntrada = new()
        {
            Id = 12,
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
        _tabelas.Convenios.Value.Clear();
        _tabelas.Escolas.Value.Clear();
        _tabelas.Empresas.Value.Clear();
        _tabelas.Escolas.Value.Add(EscolaEntrada);
        _tabelas.Empresas.Value.Add(EmpresaEntrada);

        var ConvenioValido =  _servicoConvenio.Criar(ConvenioEntrada);

        Assert.True(ConvenioValido);
    }

    [Theory]
    [InlineData("Objeto")]
    [InlineData("Curso bolo de pote")]
    public void Criar_deve_retornar_True_quando_informado_Convenio_com_Objeto_valido(string objetoInformado)
    {
        Convenio ConvenioEntrada = new()
        {
            Id = 0,
            NumeroProcesso = 123,
            Objeto = objetoInformado,
            Valor = 2.00,
            DataInicio = new DateTime(1917, 01, 30),
            IdEscola = 3,
            IdEmpresa = 12
        };
        Escola EscolaEntrada = new()
        {

            Id = 3,
            StatusAtividade = true,
            Nome = "Escola Rodrigo",
            CodigoMec = "3415",
            Telefone = "12355645",
            Email = "rodrigo@gmail.com",
            InicioAtividade = new DateTime(1234, 12, 3),
            CategoriaAdministrativa = CategoriaAdministrativaEnums.Estadual,
            OrganizacaoAcademica = OrganizacaoAcademicaEnums.EscolaGoverno

        };
        Empresa EmpresaEntrada = new()
        {
            Id = 12,
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
        _tabelas.Convenios.Value.Clear();
        _tabelas.Escolas.Value.Clear();
        _tabelas.Empresas.Value.Clear();
        _tabelas.Escolas.Value.Add(EscolaEntrada);
        _tabelas.Empresas.Value.Add(EmpresaEntrada);

        var convenioValido = _servicoConvenio.Criar(ConvenioEntrada);

        Assert.True(convenioValido);
    }

    [Theory]
    [InlineData(10.99)]
    [InlineData(10_000)]
    public void Criar_deve_retornar_True_quando_informado_Convenio_com_Valor_valido(int ValorInformado)
    {
        Convenio ConvenioEntrada = new()
        {
            Id = 0,
            NumeroProcesso = 123,
            Objeto = "objeto",
            Valor = ValorInformado,
            DataInicio = new DateTime(1917, 01, 30),
            IdEscola = 3,
            IdEmpresa = 12
        };
        Escola EscolaEntrada = new()
        {

            Id = 3,
            StatusAtividade = true,
            Nome = "Escola Rodrigo",
            CodigoMec = "3415",
            Telefone = "12355645",
            Email = "rodrigo@gmail.com",
            InicioAtividade = new DateTime(1234, 12, 3),
            CategoriaAdministrativa = CategoriaAdministrativaEnums.Estadual,
            OrganizacaoAcademica = OrganizacaoAcademicaEnums.EscolaGoverno

        };
        Empresa EmpresaEntrada = new()
        {
            Id = 12,
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
        _tabelas.Convenios.Value.Clear();
        _tabelas.Escolas.Value.Clear();
        _tabelas.Empresas.Value.Clear();
        _tabelas.Escolas.Value.Add(EscolaEntrada);
        _tabelas.Empresas.Value.Add(EmpresaEntrada);

        var convenioValido = _servicoConvenio.Criar(ConvenioEntrada);

        Assert.True(convenioValido);
    }
 
    [Theory, MemberData(nameof(CasosDataInicioValidos))]
    public void Criar_deve_retornar_True_quando_informado_Convenio_com_DataInicio_valida(DateTime DataInicioInformada)
    {
        Convenio ConvenioEntrada = new()
        {
            Id = 0,
            NumeroProcesso = 123,
            Objeto = "objeto",
            Valor = 2.0,
            DataInicio = DataInicioInformada,
            IdEscola = 3,
            IdEmpresa = 12
        };
        Escola EscolaEntrada = new()
        {

            Id = 3,
            StatusAtividade = true,
            Nome = "Escola Rodrigo",
            CodigoMec = "3415",
            Telefone = "12355645",
            Email = "rodrigo@gmail.com",
            InicioAtividade = new DateTime(1234, 12, 3),
            CategoriaAdministrativa = CategoriaAdministrativaEnums.Estadual,
            OrganizacaoAcademica = OrganizacaoAcademicaEnums.EscolaGoverno

        };
        Empresa EmpresaEntrada = new()
        {
            Id = 12,
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
        _tabelas.Convenios.Value.Clear();
        _tabelas.Escolas.Value.Clear();
        _tabelas.Empresas.Value.Clear();
        _tabelas.Escolas.Value.Add(EscolaEntrada);
        _tabelas.Empresas.Value.Add(EmpresaEntrada);

        var convenioValido = _servicoConvenio.Criar(ConvenioEntrada);

        Assert.True(convenioValido);
    }

    [Theory, MemberData(nameof(CasosDataTerminoValidos))]
    public void Criar_deve_retornar_True_quando_informado_Convenio_com_DataTermino_valida(DateTime DataTerminoInformada)
    {
        Convenio ConvenioEntrada = new()
        {
            Id = 0,
            NumeroProcesso = 123,
            Objeto = "objeto",
            Valor = 2.0,
            DataInicio = new DateTime(1900,2,3),
            DataTermino = DataTerminoInformada,
            IdEscola = 3,
            IdEmpresa = 12
        };
        Escola EscolaEntrada = new()
        {

            Id = 3,
            StatusAtividade = true,
            Nome = "Escola Rodrigo",
            CodigoMec = "3415",
            Telefone = "12355645",
            Email = "rodrigo@gmail.com",
            InicioAtividade = new DateTime(1234, 12, 3),
            CategoriaAdministrativa = CategoriaAdministrativaEnums.Estadual,
            OrganizacaoAcademica = OrganizacaoAcademicaEnums.EscolaGoverno

        };
        Empresa EmpresaEntrada = new()
        {
            Id = 12,
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
        _tabelas.Convenios.Value.Clear();
        _tabelas.Escolas.Value.Clear();
        _tabelas.Empresas.Value.Clear();
        _tabelas.Escolas.Value.Add(EscolaEntrada);
        _tabelas.Empresas.Value.Add(EmpresaEntrada);

        var convenioValido = _servicoConvenio.Criar(ConvenioEntrada);

        Assert.True(convenioValido);
    }   

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void Criar_deve_retornar_True_quando_informado_Convenio_com_IdEscola_valido_e_referente_a_escola_existente(int idEscolaInformado)
    {
        Convenio ConvenioEntrada = new()
        {
            Id = 0,
            NumeroProcesso = 123,
            Objeto = "objeto",
            Valor = 2.0,
            DataInicio = new DateTime(1900, 2, 3),
            IdEscola = idEscolaInformado,
            IdEmpresa = 12
        };
        Escola EscolaEntrada = new()
        {

            Id = idEscolaInformado,
            StatusAtividade = true,
            Nome = "Escola Rodrigo",
            CodigoMec = "3415",
            Telefone = "12355645",
            Email = "rodrigo@gmail.com",
            InicioAtividade = new DateTime(1234, 12, 3),
            CategoriaAdministrativa = CategoriaAdministrativaEnums.Estadual,
            OrganizacaoAcademica = OrganizacaoAcademicaEnums.EscolaGoverno

        };
        Empresa EmpresaEntrada = new()
        {
            Id = 12,
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
        _tabelas.Convenios.Value.Clear();
        _tabelas.Escolas.Value.Clear();
        _tabelas.Empresas.Value.Clear();
        _tabelas.Escolas.Value.Add(EscolaEntrada);
        _tabelas.Empresas.Value.Add(EmpresaEntrada);

        var convenioValido = _servicoConvenio.Criar(ConvenioEntrada);

        Assert.True(convenioValido);
    }      

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void Criar_deve_retornar_True_quando_informado_Convenio_com_IdEmpresa_valido_e_referente_a_Empresa_existente(int idEmpresaInformado)
    {
        Convenio ConvenioEntrada = new()
        {
            Id = 0,
            NumeroProcesso = 123,
            Objeto = "objeto",
            Valor = 2.0,
            DataInicio = new DateTime(1900,2,3),
            IdEscola = 3,
            IdEmpresa = idEmpresaInformado
        };
        Escola EscolaEntrada = new()
        {

            Id = 3,
            StatusAtividade = true,
            Nome = "Escola Rodrigo",
            CodigoMec = "3415",
            Telefone = "12355645",
            Email = "rodrigo@gmail.com",
            InicioAtividade = new DateTime(1234, 12, 3),
            CategoriaAdministrativa = CategoriaAdministrativaEnums.Estadual,
            OrganizacaoAcademica = OrganizacaoAcademicaEnums.EscolaGoverno

        };
        Empresa EmpresaEntrada = new()
        {
            Id = idEmpresaInformado,
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
        _tabelas.Convenios.Value.Clear();
        _tabelas.Escolas.Value.Clear();
        _tabelas.Empresas.Value.Clear();
        _tabelas.Escolas.Value.Add(EscolaEntrada);
        _tabelas.Empresas.Value.Add(EmpresaEntrada);

        var convenioValido = _servicoConvenio.Criar(ConvenioEntrada);

        Assert.True(convenioValido);
    }    
}