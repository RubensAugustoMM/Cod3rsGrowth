using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Servico;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Cod3rsGrowth.Testes;

public class TestesServicoConvenio : TesteBase
{
    private readonly ServicoConvenio _servicoConvenio;
    private readonly TabelaSingleton _tabelas;

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
    public void Criar_deve_lancar_Exception_quando_informado_Convenio_com_NumeroProcesso_Invalido(int numeroProcessoInformado)
    {
        Convenio ConvenioEntrada = new()
        {
            Id = 0,
            NumeroProcesso = 123,
            Objeto = "convenio convenio",
            Valor = numeroProcessoInformado,
            DataInicio = new DateTime(1917, 01, 30),
            IdEscola = 3,
            IdEmpresa = 12
        };
        _tabelas.Convenios.Value.Clear();

        var excecaoObterPorId = Assert.Throws<Exception>(() => _servicoConvenio.Criar(ConvenioEntrada));

        Assert.Equal("Numero de processo invalido!\n", excecaoObterPorId.Message);
    }

    [Theory]
    [InlineData(null)]
    //[InlineData("      ")]
    public void Criar_deve_lancar_Exception_quando_informado_Convenio_com_Objeto_null_ou_com_somente_espacos(string objetoInformado)
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
        _tabelas.Convenios.Value.Clear();

        var excecaoCriar = Assert.Throws<Exception>(() => _servicoConvenio.Criar(ConvenioEntrada));

        Assert.Equal($"Objeto nulo ou somente com espacos!\n", excecaoCriar.Message);
    }

    [Fact]
    public void Criar_deve_lancar_Exception_quando_informado_Convenio_com_Valor_invalido()
    {
        // Given

        // When

        // Then
    }

    [Fact]
    public void Criar_deve_lancar_Exception_quando_informado_Convenio_com_DataInicio_invalida()
    {
        // Given

        // When

        // Then
    }

    [Fact]
    public void Criar_deve_lancar_Exception_quando_informado_Convenio_com_DataTermino_invalida()
    {
        // Given
    
        // When
    
        // Then
    }   

    [Fact]
    public void Criar_deve_lancar_Exception_quando_informado_Convenio_com_IdEscola_invalida_ou_inexistente()
    {
        // Given
    
        // When
    
        // Then
    }   

    [Fact]
    public void Criar_deve_lancar_Exception_quando_informado_Convenio_com_IdEmpresa_invalida_ou_inexistente()
    {
        // Given
    
        // When
    
        // Then
    }   
}