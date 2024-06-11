using FluentValidation;
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

    [Theory]
    [InlineData(-1)]
    [InlineData(-2)]
    public void Criar_deve_retornar_ValidationException_quando_informado_Estado_com_Id_negativo(int idInformado)
    {
        var EstadoEntrada = _estadoEntrada;
        var ValorEsperado = "Id deve ser um valor maior ou igual a zero!";
        EstadoEntrada.Id = idInformado;

        var excecao = Assert.Throws<ValidationException>(() => _servicoEstado.Criar(EstadoEntrada));

        Assert.Equal(ValorEsperado, excecao.Errors.First().ErrorMessage );
    }

    [Theory]
    [InlineData(null)]
    [InlineData("    ")]
    public void Criar_deve_retornar_ValidationException_quando_informado_Estado_com_Nome_vazio(string nomeInformado)
    {
        var EstadoEntrada = _estadoEntrada;
        var ValorEsperado = "Nome nao pode ter valor nulo ou formado por caracteres de espaco!";
        EstadoEntrada.Nome = nomeInformado;

        var excecao = Assert.Throws<ValidationException>(() => _servicoEstado.Criar(EstadoEntrada));

        Assert.Equal(ValorEsperado, excecao.Errors.First().ErrorMessage );
    }

    [Theory]
    [InlineData(null)]
    [InlineData("  ")]
    public void Criar_deve_retornar_ValidationException_quando_informado_Estado_com_Sigla_vazia(string siglaInformado)
    {
        var EstadoEntrada = _estadoEntrada;
        var ValorEsperado = "Sigla nao pode ter valor nulo ou formado por caracteres de espaco!";
        EstadoEntrada.Sigla = siglaInformado;

        var excecao = Assert.Throws<ValidationException>(() => _servicoEstado.Criar(EstadoEntrada));

        Assert.Contains(ValorEsperado, excecao.Errors.First().ErrorMessage );
    }

    [Theory]
    [InlineData("goa")]
    [InlineData("SPA")]
    public void Criar_deve_retornar_ValidationException_quando_informado_Estado_com_Sigla_com_tamanho_diferente_que_2(string siglaInformado)
    {
        var EstadoEntrada = _estadoEntrada;
        var ValorEsperado = "Sigla Length menor ou maior que 2 characteres!";
        EstadoEntrada.Sigla = siglaInformado;

        var excecao = Assert.Throws<ValidationException>(() => _servicoEstado.Criar(EstadoEntrada));

        Assert.Equal(ValorEsperado, excecao.Errors.First().ErrorMessage );
    }
    [Fact]
    public void Criar_deve_retornar_ValidationException_quando_informado_Estado_com_ListaEnderecos_null()
    {
        var EstadoEntrada = _estadoEntrada;
        var ValorEsperado = "Lista Enderecos nao pode ser nulo!";
        EstadoEntrada.ListaEnderecos = null;

        var excecao = Assert.Throws<ValidationException>(() => _servicoEstado.Criar(EstadoEntrada));

        Assert.Equal(ValorEsperado, excecao.Errors.First().ErrorMessage );
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void Criar_deve_adicionar_Estado_no_repositorio_quando_informado_Estado_com_Id_positivo(int idInformado)
    {
        var EstadoEntrada = _estadoEntrada;
        EstadoEntrada.Id = idInformado;

        _servicoEstado.Criar(EstadoEntrada);
        var ValorRetornado = _tabelas.Estados.Value.FirstOrDefault(EstadoEntrada);

        Assert.NotNull(ValorRetornado);
    }

    [Theory]
    [InlineData("Goias")]
    [InlineData("Mato Grosso")]
    public void Criar_deve_adicionar_Estado_no_repositorio_quando_informado_Estado_com_Nome_valido(string nomeInformado)
    {
        var EstadoEntrada = _estadoEntrada;
        EstadoEntrada.Nome = nomeInformado;

        _servicoEstado.Criar(EstadoEntrada);
        var ValorRetornado = _tabelas.Estados.Value.FirstOrDefault(EstadoEntrada);

        Assert.NotNull(ValorRetornado);
    }

    [Theory]
    [InlineData("RJ")]
    [InlineData("SP")]
    public void Criar_deve_adicionar_Estado_no_repositorio_quando_informado_Estado_com_Sigla_valida(string siglaInformado)
    {
        var EstadoEntrada = _estadoEntrada;
        EstadoEntrada.Sigla = siglaInformado;

        _servicoEstado.Criar(EstadoEntrada);
        var ValorRetornado = _tabelas.Estados.Value.FirstOrDefault(EstadoEntrada);

        Assert.NotNull(ValorRetornado);
    }

    [Fact]
    public void Criar_deve_adicionar_Estado_no_repositorio_quando_informado_Estado_com_ListaEnderecos_Existente()
    {
        var EstadoEntrada = _estadoEntrada;

        _servicoEstado.Criar(EstadoEntrada);
        var ValorRetornado = _tabelas.Estados.Value.FirstOrDefault(EstadoEntrada);

        Assert.NotNull(ValorRetornado);
    }
}