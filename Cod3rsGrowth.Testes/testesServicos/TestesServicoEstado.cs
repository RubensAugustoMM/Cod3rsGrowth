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
    }

    private Estado CriaNovoEstadoDeTeste()
    {
        Estado NovoEstado = new()
        {
            Id = 50,
            Nome = "Goias",
            Sigla = "GO"
        };

        return NovoEstado;
    }

    [Fact]
    public void ao_ObterTodos_deve_retornar_lista_nao_nula()
    {
        var ValorRetornado = _servicoEstado.ObterTodos();

        Assert.NotNull(ValorRetornado);
    }

    [Theory]
    [InlineData(110)]
    [InlineData(-1)]
    public void ObterPorId_deve_lancar_Exception_quando_informado_Id_invalido_ou_inexistente(int idInformado)
    {
        var excecaoObterPorId = Assert.Throws<Exception>(() => _servicoEstado.ObterPorId(idInformado));

        Assert.Equal($"Nenhum Estado com Id {idInformado} existe no contexto atual!\n", excecaoObterPorId.Message);
    }

    [Theory]
    [InlineData(101)]
    [InlineData(102)]
    public void ObterPorId_deve_retornar_Estado_existente_quando_informado_id_valido(int idInformado)
    {
        var ValorEsperado = CriaNovoEstadoDeTeste();
        ValorEsperado.Id = idInformado;
        _tabelas.Estados.Value.Add(ValorEsperado);

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
    [InlineData(100)]
    [InlineData(100)]
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

    [Theory]
    [InlineData(-500)]
    [InlineData(705)]
    public void Deletar_deve_lancar_Exception_quando_informado_Id_invalido_ou_inexistente(int idInformado)
    {
        var EstadoEntrada = CriaNovoEstadoDeTeste();
        EstadoEntrada.Id = idInformado;

        var excecaoObterPorId = Assert.Throws<Exception>(() => _servicoEstado.Deletar(EstadoEntrada.Id));

        Assert.Equal($"Nenhum Estado com Id {idInformado} existe no contexto atual!\n", excecaoObterPorId.Message);
    }

    [Fact]
    public void Deletar_deve_lancar_Exception_quando_informado_Estado_com_Endereco_existente()
    {
        var EstadoEntrada = CriaNovoEstadoDeTeste();
        EstadoEntrada.Id = 701;
        Endereco EnderecoEntrada = new()
        {
            Id = 706,
            Numero = 5,
            Cep = "72311089",
            Municipio = "Hidrolandia",
            Bairro = "Pedregal",
            Rua = "Rua das Magnolias",
            Complemento = "Em frente ao bretas",
            IdEstado = 701
        };
        _tabelas.Estados.Value.Add(EstadoEntrada);
        _tabelas.Enderecos.Value.Add(EnderecoEntrada);

        var excecao = Assert.Throws<Exception>(() => _servicoEstado.Deletar(EstadoEntrada.Id));
    
        Assert.Equal("Nao e possivel excluir Estado relacionado a Endereco existente!", excecao.Message);
    }

    [Theory]
    [InlineData(702)]
    [InlineData(703)]
    public void Deletar_deve_remover_Estado_do_repositorio_quando_informado_Id_de_Estado_a_remover(int idInformado)
    {
        var EstadoEntrada = CriaNovoEstadoDeTeste();
        EstadoEntrada.Id = idInformado;
        _tabelas.Estados.Value.Add(EstadoEntrada);

        _servicoEstado.Deletar(EstadoEntrada.Id);
        var ValorRetorno = _tabelas.Convenios.Value.FirstOrDefault(c => c.Id == idInformado);

        Assert.Null(ValorRetorno);
    }
}