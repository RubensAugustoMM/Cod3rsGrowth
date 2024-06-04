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

    [Fact]
    public void ObterPorId_deve_lancar_Exception_Nenhuma_Empresa_com_Id_6_existe_no_contexto_atual_quando_informado_Id_6_inexistente_no_contexto()
    {
        _tabelas.Convenios.Value.Clear();

        var excecaoObterPorId = Assert.Throws<Exception>(() => _servicoEmpresa.ObterPorId(6));
        Assert.Contains("Nenhuma Empresa com Id 6 existe no contexto atual!\n", excecaoObterPorId.Message);
    }

    [Fact]
    public void ObterPorId_deve_lancar_ArgumentOutOfRangeException_valor_negativo_informado_ao_metodo_quando_informado_valor_negativo()
    {
        _tabelas.Convenios.Value.Clear();

        var excecaoObterPorId = Assert.Throws<ArgumentOutOfRangeException>(() => _servicoEmpresa.ObterPorId(-1));
        Assert.Contains("Valor negativo informado ao metodo!\n", excecaoObterPorId.Message);
    }

    [Fact]
    public void ObterPorId_deve_retornar_Empresa_com_id_0_quando_informado_0()
    {
        List<Empresa> ListaArrange = new()
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
        _tabelas.Empresas.Value.AddRange(ListaArrange);

        var ValorEsperado = ListaArrange.Find(x => x.Id == 0);

        var ValorRetornado = _servicoEmpresa.ObterPorId(0);

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

    [Fact]
    public void ObterPorId_deve_retornar_Empresa_com_id_1_quando_informado_1()
    {
        List<Empresa> ListaArrange = new()
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
        _tabelas.Empresas.Value.AddRange(ListaArrange);

        var ValorEsperado = ListaArrange.Find(x => x.Id == 1);

        var ValorRetornado = _servicoEmpresa.ObterPorId(1);

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
}