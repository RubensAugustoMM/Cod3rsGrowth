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
    public TestesServicoEmpresa()
    {
        _servicoEmpresa = _serviceProvider.GetService<ServicoEmpresa>() ?? throw new Exception("Objeto _serviceProvider retornou null apos nao encontrar ServicoEmpresa!");
        _tabelas = TabelaSingleton.Instance;
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
        Empresa EmpresaEntrada = new()
        {
            Id = idInformado,
            Idade = 53454353,
            RazaoSocial = "Fast! transportes LTDA",
            NomeFantasia = "Fast! transportes",
            Cnpj = "44433322211",
            SitucaoCadastral = true,
            DataSituacaoCadastral = new DateTime(1000, 12, 03),
            DataAbertura = new DateTime(1000, 12, 03),
            CapitalSocial = 123124124,
            NaturezaJuridica = NaturezaJuridicaEnums.EmpresarioIndividual,
            Porte = PorteEnums.EmpresaPequenoPorte,
            MatrizFilial = MatrizFilialEnums.Matriz,
            IdEndereco = 1
        };
        Endereco EnderecoEntrada = new()
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
        _tabelas.Empresas.Value.Clear();
        _tabelas.Enderecos.Value.Clear();
        _tabelas.Empresas.Value.Add(EmpresaEntrada);
        _tabelas.Enderecos.Value.Add(EnderecoEntrada);

        var ResultadoRetornado = _servicoEmpresa.Criar(EmpresaEntrada);

        Assert.False(ResultadoRetornado);
    }
}