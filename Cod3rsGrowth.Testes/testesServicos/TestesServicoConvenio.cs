﻿using FluentValidation;
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
    private readonly Convenio _convenioEntrada = new()
    {
        Id = 0,
        NumeroProcesso = 123,
        Objeto = "objeto",
        Valor = 2.0,
        DataInicio = new DateTime(1900, 2, 3),
        IdEscola = 3,
        IdEmpresa = 12
    };
    private readonly Escola _escolaEntrada = new()
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
    private readonly Empresa _empresaEntrada = new()
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

    public TestesServicoConvenio()
    {
        _servicoConvenio = _serviceProvider.GetService<ServicoConvenio>() ?? throw new Exception("Objeto _serviceProvider retornou null apos nao encontrar ServicoConvenio!");
        _tabelas = TabelaSingleton.Instance;

        _tabelas.Empresas.Value.Add(_empresaEntrada);
        _tabelas.Escolas.Value.Add(_escolaEntrada);
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
    public void Criar_deve_lancar_ValidationException_quando_informado_Convenio_com_Id_invalido(int idInformado)
    {
        var convenioEntrada = _convenioEntrada;
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
        var convenioEntrada = _convenioEntrada;
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
        var convenioEntrada = _convenioEntrada;
        var ValorEsperado = "Objeto nao pode ter valor nulo ou formado por caracteres de espaco!";
        convenioEntrada.Objeto = objetoInformado;

        var excecao = Assert.Throws<ValidationException>(() => _servicoConvenio.Criar(convenioEntrada));

        Assert.Equal(ValorEsperado, excecao.Errors.First().ErrorMessage);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-10_000)]
    public void Criar_deve_lancar_ValidationException_quando_informado_Convenio_com_Valor_invalido(int ValorInformado)
    {
        var convenioEntrada = _convenioEntrada;
        var ValorEsperado = "Valor do convenio deve ser maior que zero!";
        convenioEntrada.Valor = ValorInformado;

        var excecao = Assert.Throws<ValidationException>(() => _servicoConvenio.Criar(convenioEntrada));

        Assert.Equal(ValorEsperado, excecao.Errors.First().ErrorMessage);
    }
 
    [Fact]
    public void Criar_develancar_ValidationException_quando_informado_Convenio_com_DataInicio_anterior_a_1889()
    {
        var ConvenioEntrada = _convenioEntrada;
        var ValorEsperado = "Data Inicio deve ser após a proclamacao da republica!";
        ConvenioEntrada.DataInicio = new(1888,8,15);

        var excecao = Assert.Throws<ValidationException>(() => _servicoConvenio.Criar(ConvenioEntrada));

        Assert.Equal(ValorEsperado, excecao.Errors.First().ErrorMessage);
    }

    [Fact]
    public void Criar_deve_retornar_ValidationException_quando_quando_informado_Convenio_com_DataInicio_apos_data_atual()
    {
        var ConvenioEntrada = _convenioEntrada;
        var ValorEsperado = "Data Inicio deve ser anterior ou igual a data atual!";
        ConvenioEntrada.DataInicio = new DateTime(5000,3,2);

        var excecao = Assert.Throws<ValidationException>(() => _servicoConvenio.Criar(ConvenioEntrada));

        Assert.Equal(ValorEsperado, excecao.Errors.First().ErrorMessage);
    }

    [Fact]
    public void Criar_deve_retornar_ValidationException_quando_informado_Convenio_com_DataTermino_anterior_a_DataInicio()
    {
        var convenioEntrada = _convenioEntrada;
        var ValorEsperado = "Data Termino deve ser maior que a DataInicio!";
        convenioEntrada.DataTermino = new DateTime(1500,12,2);

        var excecao = Assert.Throws<ValidationException>(() => _servicoConvenio.Criar(convenioEntrada));

        Assert.Equal(ValorEsperado, excecao.Errors.First().ErrorMessage);
    }   

    [Theory]
    [InlineData(-1)]
    [InlineData(-2)]
    public void Criar_deve_retornar_retornar_ValidationException_quando_informado_Convenio_com_IdEscola_negativo(int idEscolaInformado)
    {
        var convenioEntrada = _convenioEntrada;
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
        var convenioEntrada = _convenioEntrada;
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
        var convenioEntrada = _convenioEntrada;
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
        var convenioEntrada = _convenioEntrada;
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
        var convenioEntrada = _convenioEntrada;
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
        var convenioEntrada = _convenioEntrada;
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
        var convenioEntrada = _convenioEntrada;
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
        var convenioEntrada = _convenioEntrada;
        convenioEntrada.Valor = ValorInformado;

        _servicoConvenio.Criar(convenioEntrada);
        var ValorRetornado = _tabelas.Convenios.Value.FirstOrDefault(convenioEntrada);

        Assert.NotNull(ValorRetornado);
    }
 
    [Fact]
    public void Criar_deve_adicionar_Convenio_no_repositorio_quando_informado_Convenio_com_DataInicio_valida()
    {
        var convenioEntrada = _convenioEntrada; 

        _servicoConvenio.Criar(convenioEntrada);
        var ValorRetornado = _tabelas.Convenios.Value.FirstOrDefault(convenioEntrada);

        Assert.NotNull(ValorRetornado);
    }

    [Fact]
    public void Criar_deve_adicionar_Convenio_no_repositorio_quando_informado_Convenio_com_DataTermino_valida()
    {
        var convenioEntrada = _convenioEntrada;

        _servicoConvenio.Criar(convenioEntrada);
        var ValorRetornado = _tabelas.Convenios.Value.FirstOrDefault(convenioEntrada);

        Assert.NotNull(ValorRetornado);
    }   

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void Criar_deve_adicionar_Convenio_no_repositorio_quando_informado_Convenio_com_IdEscola_valido_e_referente_a_escola_existente(int idEscolaInformado)
    {
        var convenioEntrada = _convenioEntrada;
        var escolaEntrada = _escolaEntrada;
        convenioEntrada.IdEscola = idEscolaInformado;
        escolaEntrada.Id = idEscolaInformado;
        _tabelas.Escolas.Value.Add(escolaEntrada);

        _servicoConvenio.Criar(convenioEntrada);
        var ValorRetornado = _tabelas.Convenios.Value.FirstOrDefault(convenioEntrada);

        Assert.NotNull(ValorRetornado);
    }      

    [Theory]
    [InlineData(1)]
    [InlineData(10)]
    public void Criar_deve_adicionar_Convenio_no_repositorio_quando_informado_Convenio_com_IdEmpresa_valido_e_referente_a_Empresa_existente(int idEmpresaInformado)
    {
        var convenioEntrada = _convenioEntrada;
        var empresaEntrada = _empresaEntrada;
        convenioEntrada.IdEmpresa = idEmpresaInformado;
        empresaEntrada.Id = idEmpresaInformado;
        _tabelas.Empresas.Value.Add(empresaEntrada);

        _servicoConvenio.Criar(convenioEntrada);
        var ValorRetornado = _tabelas.Convenios.Value.FirstOrDefault(convenioEntrada);

        Assert.NotNull(ValorRetornado);
    }
}