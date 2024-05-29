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
        _servicoEmpresa = _serviceProvider.GetService<ServicoEmpresa>();
        _tabelas = TabelaSingleton.Instance;
    }

    [Fact]
    public void ObterTodos_ListaVazia_ListaVazia()
    {
        //arrange
        _tabelas.Empresas.Value.Clear();
        var ValorEsperado = _tabelas.Empresas.Value;

        //act
        var ValorRetornado = _servicoEmpresa.ObterTodos();

        //assert
        Assert.Equal(ValorEsperado.Count, ValorRetornado.Count);
    }

    [Fact]
    public void ObterTodos_ListaUmElemento_listaUmElemento()
    {
        //arrage
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

        //act
        var ValorRetornado = _servicoEmpresa.ObterTodos();

        //assert
        Assert.Equal(ValorEsperado.Count, ValorRetornado.Count);
    }

    [Fact]
    public void ObterTodos_ListaDoisElemento_listaDoisElemento()
    {
        //arrage
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

        //act
        var ValorRetornado = _servicoEmpresa.ObterTodos();

        //assert
        Assert.Equal(ValorEsperado.Count, ValorRetornado.Count);
    }
}