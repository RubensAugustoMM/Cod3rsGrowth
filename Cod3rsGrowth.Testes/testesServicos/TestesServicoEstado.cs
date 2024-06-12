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

    public TestesServicoEstado()
    {
        _servicoEstado = _serviceProvider.GetService<ServicoEstado>() ?? throw new Exception("Nome _serviceProvider retornou null apos nao encontrar ServicoEstado!");
        _tabelas = TabelaSingleton.Instance;

        _tabelas.Estados.Value.Clear();
    }

    private Estado CriaNovoEstadoDeTeste()
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
    public void ao_ObterTodos_deve_retornar_lista_com_apenas_um_Estado()
    {
        List<Estado> ValorEsperado = new()
        {
            new Estado()
            {
                Id = 1,
                Nome = "Goias",
                Sigla = "GO"
            }
       };
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
                Id = 1,
                Nome = "Goias",
                Sigla = "GO"
            },
            new Estado()
            {
                Id = 2,
                Nome = "Rio de Janeiro",
                Sigla = "RJ"
            }
       };
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
                Id = idInformado,
                Nome = "Goias",
                Sigla = "GO"
            },
            new Estado()
            {
                Id = 2,
                Nome = "Rio de Janeiro",
                Sigla = "RJ"
            }
       };
        _tabelas.Estados.Value.AddRange(ListaDadosTeste);

        var ValorEsperado = ListaDadosTeste.FirstOrDefault(estado => estado.Id == idInformado);
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
        var EstadoEntrada = CriaNovoEstadoDeTeste();
        var ValorEsperado = "Id deve ser um valor maior ou igual a zero!";
        EstadoEntrada.Id = idInformado;

        var excecao = Assert.Throws<ValidationException>(() => _servicoEstado.Criar(EstadoEntrada));

        Assert.Equal(ValorEsperado, excecao.Errors.First().ErrorMessage);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("    ")]
    public void Criar_deve_retornar_ValidationException_quando_informado_Estado_com_Nome_vazio(string nomeInformado)
    {
        var EstadoEntrada = CriaNovoEstadoDeTeste();
        var ValorEsperado = "Nome nao pode ter valor nulo ou formado por caracteres de espaco!";
        EstadoEntrada.Nome = nomeInformado;

        var excecao = Assert.Throws<ValidationException>(() => _servicoEstado.Criar(EstadoEntrada));

        Assert.Equal(ValorEsperado, excecao.Errors.First().ErrorMessage);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("  ")]
    public void Criar_deve_retornar_ValidationException_quando_informado_Estado_com_Sigla_vazia(string siglaInformado)
    {
        var EstadoEntrada = CriaNovoEstadoDeTeste();
        var ValorEsperado = "Sigla nao pode ter valor nulo ou formado por caracteres de espaco!";
        EstadoEntrada.Sigla = siglaInformado;

        var excecao = Assert.Throws<ValidationException>(() => _servicoEstado.Criar(EstadoEntrada));

        Assert.Contains(ValorEsperado, excecao.Errors.First().ErrorMessage);
    }

    [Theory]
    [InlineData("goa")]
    [InlineData("SPA")]
    public void Criar_deve_retornar_ValidationException_quando_informado_Estado_com_Sigla_com_tamanho_diferente_que_2(string siglaInformado)
    {
        var EstadoEntrada = CriaNovoEstadoDeTeste();
        var ValorEsperado = "Sigla Length menor ou maior que 2 characteres!";
        EstadoEntrada.Sigla = siglaInformado;

        var excecao = Assert.Throws<ValidationException>(() => _servicoEstado.Criar(EstadoEntrada));

        Assert.Equal(ValorEsperado, excecao.Errors.First().ErrorMessage);
    }
    [Fact]
    public void Criar_deve_retornar_ValidationException_quando_informado_Estado_com_ListaEnderecos_null()
    {
        var EstadoEntrada = CriaNovoEstadoDeTeste();
        var ValorEsperado = "Lista Enderecos nao pode ser nulo!";
        EstadoEntrada.ListaEnderecos = null;

        var excecao = Assert.Throws<ValidationException>(() => _servicoEstado.Criar(EstadoEntrada));

        Assert.Equal(ValorEsperado, excecao.Errors.First().ErrorMessage);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void Criar_deve_adicionar_Estado_no_repositorio_quando_informado_Estado_com_Id_positivo(int idInformado)
    {
        var EstadoEntrada = CriaNovoEstadoDeTeste();
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
        var EstadoEntrada = CriaNovoEstadoDeTeste();
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
        var EstadoEntrada = CriaNovoEstadoDeTeste();
        EstadoEntrada.Sigla = siglaInformado;

        _servicoEstado.Criar(EstadoEntrada);
        var ValorRetornado = _tabelas.Estados.Value.FirstOrDefault(EstadoEntrada);

        Assert.NotNull(ValorRetornado);
    }

    [Fact]
    public void Criar_deve_adicionar_Estado_no_repositorio_quando_informado_Estado_com_ListaEnderecos_Existente()
    {
        var EstadoEntrada = CriaNovoEstadoDeTeste();

        _servicoEstado.Criar(EstadoEntrada);
        var ValorRetornado = _tabelas.Estados.Value.FirstOrDefault(EstadoEntrada);

        Assert.NotNull(ValorRetornado);
    }

    [Theory]
    [InlineData(20)]
    [InlineData(30)]
    public void Atualizar_deve_retornar_Exception_quando_informado_Estado_com_Id_inexistente(int idInformado)
    {
        var EstadoEntrada = CriaNovoEstadoDeTeste();
        EstadoEntrada.Id = idInformado;

        var excecao = Assert.Throws<Exception>(() => _servicoEstado.Atualizar(EstadoEntrada));

        Assert.Equal($"Nenhum Estado com Id {idInformado} existe no contexto atual!\n", excecao.Message);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("   ")]
    public void Atualizar_deve_retornar_ValidationException_quando_informado_Estado_invalido(string nomeInformado)
    {
        var EstadoEntrada = CriaNovoEstadoDeTeste();
        _tabelas.Estados.Value.Add(CriaNovoEstadoDeTeste());
        EstadoEntrada.Nome = nomeInformado;

        var excecao = Assert.Throws<ValidationException>(() => _servicoEstado.Atualizar(EstadoEntrada));

        Assert.Equal("Nome nao pode ter valor nulo ou formado por caracteres de espaco!", excecao.Errors.First().ErrorMessage);
    }

    [Theory]
    [InlineData("Nome1", "Go")]
    [InlineData("Nome2", "Sp")]
    public void Atualizar_deve_alterar_parametros_de_Estado_existente_quando_informado_Estado_valido(string nomeInformado, string siglaInformado)
    {
        var EstadoEntrada = CriaNovoEstadoDeTeste();
        var EstadoAtualizar = CriaNovoEstadoDeTeste();
        EstadoEntrada.Nome = nomeInformado;
        EstadoEntrada.Sigla = siglaInformado;
        _tabelas.Estados.Value.Add(EstadoAtualizar);

        _servicoEstado.Atualizar(EstadoEntrada);
        var ValorRetornado = _tabelas.Estados.Value.FirstOrDefault(estado => estado.Id == EstadoEntrada.Id);

        Assert.Equal(nomeInformado, ValorRetornado.Nome);
        Assert.Equal(siglaInformado, ValorRetornado.Sigla);
    }
}