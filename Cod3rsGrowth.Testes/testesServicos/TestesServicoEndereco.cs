using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Servico;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Cod3rsGrowth.Testes;

public class TestesServicoEndereco : TesteBase
{
    private readonly ServicoEndereco _servicoEndereco;
    private readonly TabelaSingleton _tabelas;
    public TestesServicoEndereco()
    {
        _servicoEndereco = _serviceProvider.GetService<ServicoEndereco>() ?? throw new Exception("Objeto _serviceProvider retornou null apos nao encontrar ServicoEndereco!");
        _tabelas = TabelaSingleton.Instance;
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
                Cep = "113336666",
                Municipio = "Sao Bartolomeu",
                Bairro = "joao",
                Rua = "143",
                Complemento = "Perto da merceria do Galo",
                IdEstado = 20
            }
       };

        _tabelas.Enderecos.Value.Clear();
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

        _tabelas.Enderecos.Value.Clear();
        _tabelas.Enderecos.Value.AddRange(ValorEsperado);

        var ValorRetornado = _servicoEndereco.ObterTodos();

        Assert.Equal(ValorEsperado.Count, ValorRetornado.Count);
    }

    [Fact]
    public void ObterPorId_deve_lancar_Exception_Nenhum_Endereco_com_Id_6_existe_no_contexto_atual_quando_informado_Id_6_inexistente_no_contexto()
    {
        _tabelas.Convenios.Value.Clear();

        var excecaoObterPorId = Assert.Throws<Exception>(() => _servicoEndereco.ObterPorId(6));
        Assert.Contains("Nenhum Endereco com Id 6 existe no contexto atual!\n", excecaoObterPorId.Message);
    }

    [Fact]
    public void ObterPorId_deve_lancar_ArgumentOutOfRangeException_valor_negativo_informado_ao_metodo_quando_informado_valor_negativo()
    {
        _tabelas.Convenios.Value.Clear();

        var excecaoObterPorId = Assert.Throws<ArgumentOutOfRangeException>(() => _servicoEndereco.ObterPorId(-1));
        Assert.Contains("Valor negativo informado ao metodo!\n", excecaoObterPorId.Message);
    }

    [Fact]
    public void ObterPorId_deve_retornar_Endereco_com_id_0_quando_informado_0()
    {
        List<Endereco> ListaArrange = new()
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

        _tabelas.Enderecos.Value.Clear();
        _tabelas.Enderecos.Value.AddRange(ListaArrange);

        var ValorEsperado = ListaArrange.Find(x => x.Id == 0);

        var ValorRetornado = _servicoEndereco.ObterPorId(0);

        Assert.Equal(ValorEsperado.Id, ValorRetornado.Id);
        Assert.Equal(ValorEsperado.Numero, ValorRetornado.Numero);
        Assert.Equal(ValorEsperado.Cep, ValorRetornado.Cep);
        Assert.Equal(ValorEsperado.Municipio, ValorRetornado.Municipio);
        Assert.Equal(ValorEsperado.Bairro, ValorRetornado.Bairro);
        Assert.Equal(ValorEsperado.Rua, ValorRetornado.Rua);
        Assert.Equal(ValorEsperado.Complemento, ValorRetornado.Complemento);
        Assert.Equal(ValorEsperado.IdEstado, ValorRetornado.IdEstado);
    }

    [Fact]
    public void ObterPorId_deve_retornar_Endereco_com_id_1_quando_informado_1()
    {
        List<Endereco> ListaArrange = new()
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

        _tabelas.Enderecos.Value.Clear();
        _tabelas.Enderecos.Value.AddRange(ListaArrange);

        var ValorEsperado = ListaArrange.Find(x => x.Id == 1);

        var ValorRetornado = _servicoEndereco.ObterPorId(1);

        Assert.Equal(ValorEsperado.Id, ValorRetornado.Id);
        Assert.Equal(ValorEsperado.Numero, ValorRetornado.Numero);
        Assert.Equal(ValorEsperado.Cep, ValorRetornado.Cep);
        Assert.Equal(ValorEsperado.Municipio, ValorRetornado.Municipio);
        Assert.Equal(ValorEsperado.Bairro, ValorRetornado.Bairro);
        Assert.Equal(ValorEsperado.Rua, ValorRetornado.Rua);
        Assert.Equal(ValorEsperado.Complemento, ValorRetornado.Complemento);
        Assert.Equal(ValorEsperado.IdEstado, ValorRetornado.IdEstado);
    }
}