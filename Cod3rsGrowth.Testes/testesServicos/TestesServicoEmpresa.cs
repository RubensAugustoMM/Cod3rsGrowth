using System.Data.Common;
using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Servico;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Cod3rsGrowth.Testes;

public class TestesServicoEmpresa : TesteBase
{
    private readonly ServicoEmpresa _servicoEmpresa;
    private readonly TabelaSingleton _tabelas;
    private readonly Empresa _empresaEntrada = new()
    {
        Id = 0,
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
        IdEndereco = 1
    };
    private readonly Endereco _enderecoEntrada = new()
    {
        Id = 1,
        Numero = 13,
        Cep = "113336666",
        Municipio = "Sao Bartolomeu",
        Bairro = "joao",
        Rua = "143",
        Complemento = "Perto da merceria do Galo",
        IdEstado = 20
    };

    public TestesServicoEmpresa()
    {
        _servicoEmpresa = _serviceProvider.GetService<ServicoEmpresa>() ?? throw new Exception("Objeto _serviceProvider retornou null apos nao encontrar ServicoEmpresa!");
        _tabelas = TabelaSingleton.Instance;

        _tabelas.Enderecos.Value.Add(_enderecoEntrada);
    }

    [Fact]
    public void ao_ObterTodos_deve_retornar_lista_com_apenas_uma_Empresa()
    {
        List<Empresa> ValorEsperado = new()
        {
            new Empresa()
            {
                Id = 0,
                Idade = 3,
                RazaoSocial = "Carlinhos Ferragens LTDA",
                NomeFantasia = "Carlinhos Ferragens",
                Cnpj = "11122233344",
                SitucaoCadastral = true,
                DataSituacaoCadastral = new DateTime(1000,12,03),
                DataAbertura = new DateTime(1000,12,03),
                CapitalSocial = 13,
                NaturezaJuridica = NaturezaJuridicaEnums.EmpresarioIndividual,
                Porte = PorteEnums.EmpresaPequenoPorte,
                MatrizFilial = MatrizFilialEnums.Matriz
            }
       };
        _tabelas.Empresas.Value.Clear();
        _tabelas.Empresas.Value.AddRange(ValorEsperado);

        var ValorRetornado = _servicoEmpresa.ObterTodos();

        Assert.Equal(ValorEsperado.Count, ValorRetornado.Count);
    }

    [Fact]
    public void ao_ObterTodos_deve_retornar_lista_com_apenas_duas_Empresas()
    {
        List<Empresa> ValorEsperado = new()
        {
            new Empresa()
            {
                Id = 0,
                Idade = 3,
                RazaoSocial = "Carlinhos Ferragens LTDA",
                NomeFantasia = "Carlinhos Ferragens",
                Cnpj = "11122233344",
                SitucaoCadastral = true,
                DataSituacaoCadastral = new DateTime(1000,12,03),
                DataAbertura = new DateTime(1000,12,03),
                CapitalSocial = 13,
                NaturezaJuridica = NaturezaJuridicaEnums.EmpresarioIndividual,
                Porte = PorteEnums.EmpresaPequenoPorte,
                MatrizFilial = MatrizFilialEnums.Matriz
            },
            new Empresa()
            {
                Id = 1,
                Idade = 53454353,
                RazaoSocial = "Fast! transportes LTDA",
                NomeFantasia = "Fast! transportes",
                Cnpj = "44433322211",
                SitucaoCadastral = true,
                DataSituacaoCadastral = new DateTime(1000,12,03),
                DataAbertura = new DateTime(1000,12,03),
                CapitalSocial = 123124124,
                NaturezaJuridica = NaturezaJuridicaEnums.EmpresarioIndividual,
                Porte = PorteEnums.EmpresaPequenoPorte,
                MatrizFilial = MatrizFilialEnums.Matriz
            }
       };
        _tabelas.Empresas.Value.Clear();
        _tabelas.Empresas.Value.AddRange(ValorEsperado);

        var ValorRetornado = _servicoEmpresa.ObterTodos();

        Assert.Equal(ValorEsperado.Count, ValorRetornado.Count);
    }

    [Theory]
    [InlineData(2)]
    [InlineData(-1)]
    public void ObterPorId_deve_lancar_Exception_quando_informado_Id_invalido_ou_inexistente(int idInformado)
    {
        List<Empresa> ListaDadosTeste = new()
        {
            new Empresa()
            {
                Id = 0,
                Idade = 3,
                RazaoSocial = "Carlinhos Ferragens LTDA",
                NomeFantasia = "Carlinhos Ferragens",
                Cnpj = "11122233344",
                SitucaoCadastral = true,
                DataSituacaoCadastral = new DateTime(1000,12,03),
                DataAbertura = new DateTime(1000,12,03),
                CapitalSocial = 13,
                NaturezaJuridica = NaturezaJuridicaEnums.EmpresarioIndividual,
                Porte = PorteEnums.EmpresaPequenoPorte,
                MatrizFilial = MatrizFilialEnums.Matriz
            },
            new Empresa()
            {
                Id = 1,
                Idade = 53454353,
                RazaoSocial = "Fast! transportes LTDA",
                NomeFantasia = "Fast! transportes",
                Cnpj = "44433322211",
                SitucaoCadastral = true,
                DataSituacaoCadastral = new DateTime(1000,12,03),
                DataAbertura = new DateTime(1000,12,03),
                CapitalSocial = 123124124,
                NaturezaJuridica = NaturezaJuridicaEnums.EmpresarioIndividual,
                Porte = PorteEnums.EmpresaPequenoPorte,
                MatrizFilial = MatrizFilialEnums.Matriz
            }
       };
        _tabelas.Empresas.Value.Clear();
        _tabelas.Empresas.Value.AddRange(ListaDadosTeste);

        var excecaoObterPorId = Assert.Throws<Exception>(() => _servicoEmpresa.ObterPorId(idInformado));

        Assert.Equal($"Nenhuma Empresa com Id {idInformado} existe no contexto atual!\n", excecaoObterPorId.Message);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    public void ObterPorId_deve_retornar_Empresa_existente_quando_informado_id_valido(int idInformado)
    {
        List<Empresa> ListaDadosTeste = new()
        {
            new Empresa()
            {
                Id = 0,
                Idade = 3,
                RazaoSocial = "Carlinhos Ferragens LTDA",
                NomeFantasia = "Carlinhos Ferragens",
                Cnpj = "11122233344",
                SitucaoCadastral = true,
                DataSituacaoCadastral = new DateTime(1000,12,03),
                DataAbertura = new DateTime(1000,12,03),
                CapitalSocial = 13,
                NaturezaJuridica = NaturezaJuridicaEnums.EmpresarioIndividual,
                Porte = PorteEnums.EmpresaPequenoPorte,
                MatrizFilial = MatrizFilialEnums.Matriz
            },
            new Empresa()
            {
                Id = 1,
                Idade = 53454353,
                RazaoSocial = "Fast! transportes LTDA",
                NomeFantasia = "Fast! transportes",
                Cnpj = "44433322211",
                SitucaoCadastral = true,
                DataSituacaoCadastral = new DateTime(1000,12,03),
                DataAbertura = new DateTime(1000,12,03),
                CapitalSocial = 123124124,
                NaturezaJuridica = NaturezaJuridicaEnums.EmpresarioIndividual,
                Porte = PorteEnums.EmpresaPequenoPorte,
                MatrizFilial = MatrizFilialEnums.Matriz
            }
       };
        _tabelas.Empresas.Value.Clear();
        _tabelas.Empresas.Value.AddRange(ListaDadosTeste);

        var ValorEsperado = ListaDadosTeste[idInformado];
        var ValorRetornado = _servicoEmpresa.ObterPorId(idInformado);

        Assert.Equal(ValorEsperado.Id, ValorRetornado.Id);
        Assert.Equal(ValorEsperado.Idade, ValorRetornado.Idade);
        Assert.Equal(ValorEsperado.RazaoSocial, ValorEsperado.RazaoSocial);
        Assert.Equal(ValorEsperado.NomeFantasia, ValorEsperado.NomeFantasia);
        Assert.Equal(ValorEsperado.Cnpj, ValorEsperado.Cnpj);
        Assert.Equal(ValorEsperado.SitucaoCadastral, ValorEsperado.SitucaoCadastral);
        Assert.Equal(ValorEsperado.DataSituacaoCadastral.Date, ValorEsperado.DataSituacaoCadastral.Date);
        Assert.Equal(ValorEsperado.DataAbertura.Date, ValorEsperado.DataAbertura.Date);
        Assert.Equal(ValorEsperado.CapitalSocial, ValorEsperado.CapitalSocial);
        Assert.Equal(ValorEsperado.NaturezaJuridica, ValorEsperado.NaturezaJuridica);
        Assert.Equal(ValorEsperado.Porte, ValorEsperado.Porte);
        Assert.Equal(ValorEsperado.MatrizFilial, ValorRetornado.MatrizFilial);
    }

    [Theory]
    [InlineData(-12)]
    [InlineData(-1)]
    public void Criar_deve_retornar_False_quando_informado_Empresa_com_Id_invalido(int idInformado)
    {
        var empresaEntrada = _empresaEntrada;
        empresaEntrada.Id = idInformado;

        var ResultadoRetornado = _servicoEmpresa.Criar(empresaEntrada);

        Assert.False(ResultadoRetornado);
    }

    [Theory]
    [InlineData(-12)]
    [InlineData(2)]
    public void Criar_deve_retornar_False_quando_informado_Empresa_com_Idade_invalido(int idadeInformada)
    {
        var empresaEntrada = _empresaEntrada;
        empresaEntrada.Idade = idadeInformada;

        var ResultadoRetornado = _servicoEmpresa.Criar(empresaEntrada);

        Assert.False(ResultadoRetornado);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("     ")]
    public void Criar_deve_retornar_False_quando_informado_Empresa_com_RazaoSocial_invalida(string razaoSocialInformada)
    {
        var empresaEntrada = _empresaEntrada;
        empresaEntrada.RazaoSocial = razaoSocialInformada;

        var ResultadoRetornado = _servicoEmpresa.Criar(empresaEntrada);

        Assert.False(ResultadoRetornado);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("     ")]
    public void Criar_deve_retornar_False_quando_informado_Empresa_com_NomeFantasia_invalido(string nomeFantasiaInformado)
    {
        var empresaEntrada = _empresaEntrada;
        empresaEntrada.NomeFantasia = nomeFantasiaInformado;

        var ResultadoRetornado = _servicoEmpresa.Criar(empresaEntrada);

        Assert.False(ResultadoRetornado);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("     ")]
    [InlineData("E")]
    [InlineData("123456789123456")]
    public void Criar_deve_retornar_False_quando_informado_Empresa_com_Cnpj_invalido(string cnpjInformado)
    {
        var empresaEntrada = _empresaEntrada;
        empresaEntrada.Cnpj = cnpjInformado;

        var ResultadoRetornado = _servicoEmpresa.Criar(empresaEntrada);

        Assert.False(ResultadoRetornado);
    }

    [Fact]
    public void Criar_deve_retornar_False_quando_informado_Empresa_com_DataSituacaoCadastral_invalida()
    {
        var empresaEntrada = _empresaEntrada;
        empresaEntrada.DataSituacaoCadastral = new DateTime(2000, 12, 03);

        var ResultadoRetornado = _servicoEmpresa.Criar(empresaEntrada);

        Assert.False(ResultadoRetornado);
    }

    [Fact]
    public void Criar_deve_retornar_False_quando_informado_Empresa_com_DataAbertura_invalida()
    {
        var empresaEntrada = _empresaEntrada;
        empresaEntrada.DataAbertura = new DateTime(3000,12, 3);
        empresaEntrada.DataSituacaoCadastral = new DateTime(3001, 12, 3);
        empresaEntrada.Idade = DateTime.Now.Date.Year - empresaEntrada.DataAbertura.Date.Year;

        var ResultadoRetornado = _servicoEmpresa.Criar(empresaEntrada);

        Assert.False(ResultadoRetornado);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-300)]
    public void Criar_deve_retornar_False_quando_informado_Empresa_com_CapitalSocial_invalido(decimal capitalSocialInformado)
    {
        var empresaEntrada = _empresaEntrada;
        empresaEntrada.CapitalSocial = capitalSocialInformado;

        var ResultadoRetornado = _servicoEmpresa.Criar(empresaEntrada);

        Assert.False(ResultadoRetornado);
    }

    [Theory]
    [InlineData(-3)]
    [InlineData(30)]
    public void Criar_deve_retornar_False_quando_informado_Empresa_com_NaturezaJuridica_invalida(int naturezaJuridiaInformada)
    {
        var empresaEntrada = _empresaEntrada;
        empresaEntrada.NaturezaJuridica = (NaturezaJuridicaEnums)naturezaJuridiaInformada;

        var ResultadoRetornado = _servicoEmpresa.Criar(empresaEntrada);

        Assert.False(ResultadoRetornado);
    }

    [Theory]
    [InlineData(-3)]
    [InlineData(30)]
    public void Criar_deve_retornar_False_quando_informado_Empresa_com_Porte_invalido(int porteInformada)
    {
        var empresaEntrada = _empresaEntrada;
        empresaEntrada.Porte = (PorteEnums)porteInformada;

        var ResultadoRetornado = _servicoEmpresa.Criar(empresaEntrada);

        Assert.False(ResultadoRetornado);
    }

    [Theory]
    [InlineData(-3)]
    [InlineData(30)]
    public void Criar_deve_retornar_False_quando_informado_Empresa_com_MatrizFilial_invalida(int matrizFilialInformada)
    {
        var empresaEntrada = _empresaEntrada;
        empresaEntrada.MatrizFilial = (MatrizFilialEnums)matrizFilialInformada;

        var ResultadoRetornado = _servicoEmpresa.Criar(empresaEntrada);

        Assert.False(ResultadoRetornado);
    }

    [Theory]
    [InlineData(-3)]
    [InlineData(5)]
    public void Criar_deve_retornar_False_quando_informado_Empresa_com_IdEndereco_valido_e_referente_a_Endereco_inexistente(int idEnderecoInformado)
    {
        var empresaEntrada = _empresaEntrada;
        _empresaEntrada.IdEndereco = idEnderecoInformado;

        var ResultadoRetornado = _servicoEmpresa.Criar(empresaEntrada);

        Assert.False(ResultadoRetornado);
    }

    [Fact]
    public void Criar_deve_retornar_False_e_nao_adicionar_Empresa_no_repositorio_caso_Empresa_invalida()
    {
        var empresaEntrada = _empresaEntrada;
        empresaEntrada.Id = 23;
        empresaEntrada.RazaoSocial = null;

        var empresaValida = _servicoEmpresa.Criar(empresaEntrada);

        Assert.False(empresaValida);
        var excecaoObterPorId = Assert.Throws<Exception>(() => _servicoEmpresa.ObterPorId(empresaEntrada.Id));
    }    

    [Fact]
    public void Criar_deve_retornar_True_quando_informado_Empresa_com_Id_invalido()
    {
        var ResultadoRetornado = _servicoEmpresa.Criar(_empresaEntrada);

        Assert.True(ResultadoRetornado);
    }

    [Fact]
    public void Criar_deve_retornar_True_quando_informado_Empresa_com_Idade_invalido()
    {
        var ResultadoRetornado = _servicoEmpresa.Criar(_empresaEntrada);

        Assert.True(ResultadoRetornado);
    }

    [Fact]
    public void Criar_deve_retornar_True_quando_informado_Empresa_com_RazaoSocial_valida()
    {
        var ResultadoRetornado = _servicoEmpresa.Criar(_empresaEntrada);

        Assert.True(ResultadoRetornado);
    }

    [Fact]
    public void Criar_deve_retornar_True_quando_informado_Empresa_com_NomeFantasia_invalido()
    {
        var ResultadoRetornado = _servicoEmpresa.Criar(_empresaEntrada);

        Assert.True(ResultadoRetornado);
    }

    [Fact]
    public void Criar_deve_retornar_True_quando_informado_Empresa_com_Cnpj_valido()
    {
        var ResultadoRetornado = _servicoEmpresa.Criar(_empresaEntrada);

        Assert.True(ResultadoRetornado);
    }

    [Fact]
    public void Criar_deve_retornar_True_quando_informado_Empresa_com_DataSituacaoCadastral_valida()
    {
        var ResultadoRetornado = _servicoEmpresa.Criar(_empresaEntrada);

        Assert.True(ResultadoRetornado);
    }

    [Fact]
    public void Criar_deve_retornar_True_quando_informado_Empresa_com_DataAbertura_valida()
    {
        var ResultadoRetornado = _servicoEmpresa.Criar(_empresaEntrada);

        Assert.True(ResultadoRetornado);
    }

    [Fact]
    public void Criar_deve_retornar_True_quando_informado_Empresa_com_CapitalSocial_valido()
    {
        var ResultadoRetornado = _servicoEmpresa.Criar(_empresaEntrada);

        Assert.True(ResultadoRetornado);
    }

    [Fact]
    public void Criar_deve_retornar_True_quando_informado_Empresa_com_NaturezaJuridica_valida()
    {
        var ResultadoRetornado = _servicoEmpresa.Criar(_empresaEntrada);

        Assert.True(ResultadoRetornado);
    }

    [Fact]
    public void Criar_deve_retornar_True_quando_informado_Empresa_com_Porte_valido()
    {
        var ResultadoRetornado = _servicoEmpresa.Criar(_empresaEntrada);

        Assert.True(ResultadoRetornado);
    }

    [Fact]
    public void Criar_deve_retornar_True_quando_informado_Empresa_com_MatrizFilial_valida()
    {
        var ResultadoRetornado = _servicoEmpresa.Criar(_empresaEntrada);

        Assert.True(ResultadoRetornado);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void Criar_deve_retornar_True_quando_informado_Empresa_com_IdEndereco_valido_e_referente_a_Endereco_Existente(int idEnderecoInformado)
    {
        var empresaEntrada = _empresaEntrada;
        var enderecoEntrada = _enderecoEntrada;
        empresaEntrada.IdEndereco = idEnderecoInformado;
        enderecoEntrada.Id = idEnderecoInformado;
        _tabelas.Enderecos.Value.Clear();
        _tabelas.Enderecos.Value.Add(enderecoEntrada);

        var ResultadoRetornado = _servicoEmpresa.Criar(empresaEntrada);

        Assert.True(ResultadoRetornado);
    }

    [Fact]
    public void Criar_deve_retornar_True_e_adicionar_Empresa_no_repositorio_caso_Empresa_valida()
    {
        var empresaValida = _servicoEmpresa.Criar(_empresaEntrada);
        var empresaRetornada = _servicoEmpresa.ObterPorId(_empresaEntrada.Id);

        Assert.True(empresaValida);
        Assert.Equal(_empresaEntrada.Id, empresaRetornada.Id);
        Assert.Equal(_empresaEntrada.Idade, empresaRetornada.Idade);
        Assert.Equal(_empresaEntrada.RazaoSocial, empresaRetornada.RazaoSocial);
        Assert.Equal(_empresaEntrada.NomeFantasia, empresaRetornada.NomeFantasia);
        Assert.Equal(_empresaEntrada.Cnpj, empresaRetornada.Cnpj);
        Assert.Equal(_empresaEntrada.SitucaoCadastral, empresaRetornada.SitucaoCadastral);
        Assert.Equal(_empresaEntrada.DataSituacaoCadastral.Date, empresaRetornada.DataSituacaoCadastral.Date);
        Assert.Equal(_empresaEntrada.DataAbertura.Date, empresaRetornada.DataAbertura.Date);
        Assert.Equal(_empresaEntrada.CapitalSocial, empresaRetornada.CapitalSocial);
        Assert.Equal(_empresaEntrada.NaturezaJuridica, empresaRetornada.NaturezaJuridica);
        Assert.Equal(_empresaEntrada.Porte, empresaRetornada.Porte);
        Assert.Equal(_empresaEntrada.MatrizFilial, empresaRetornada.MatrizFilial);
    }    
}