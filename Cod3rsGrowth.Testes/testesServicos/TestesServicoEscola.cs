﻿using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Servico;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Cod3rsGrowth.Testes;

public class TestesServicoEscola : TesteBase
{
    private readonly ServicoEscola _servicoEscola;
    private readonly TabelaSingleton _tabelas;
    public TestesServicoEscola()
    {
        _servicoEscola = _serviceProvider.GetService<ServicoEscola>();
        _tabelas = TabelaSingleton.Instance;
    }

    [Fact]
    public void ObterTodos_ListaVazia_ListaVazia()
    {
        //arrange
        _tabelas.Escolas.Value.Clear();
        var ValorEsperado = _tabelas.Escolas.Value;

        //act
        var ValorRetornado = _servicoEscola.ObterTodos();

        //assert
        Assert.Equal(ValorEsperado.Count, ValorRetornado.Count);
    }

    [Fact]
    public void ObterTodos_ListaUmElemento_listaUmElemento()
    {
        //arrage
        List<Escola> ValorEsperado = new()
        {
            new Escola()
            {
                Id = 0,
                StatusAtividade = true,
                Nome = "Escola Rodrigo",
                CodigoMec = "3415",
                Telefone = "12355645",
                Email = "rodrigo@gmail.com",
                InicioAtividade = new DateTime(1234,12,3),
                CategoriaAdministrativa = CategoriaAdministrativaEnums.Estadual,
                OrganizacaoAcademica = OrganizacaoAcademicaEnums.EscolaGoverno,
                IdEndereco = 0
            }
       };
        _tabelas.Escolas.Value.Clear();
        _tabelas.Escolas.Value.AddRange(ValorEsperado);

        //act
        var ValorRetornado = _servicoEscola.ObterTodos();

        //assert
        Assert.Equal(ValorEsperado.Count, ValorRetornado.Count);
    }

    [Fact]
    public void ObterTodos_ListaDoisElemento_listaDoisElemento()
    {
        //arrage
        List<Escola> ValorEsperado = new()
        {
            new Escola()
            {
                Id = 0,
                StatusAtividade = true,
                Nome = "Escola Rodrigo",
                CodigoMec = "3415",
                Telefone = "12355645",
                Email = "rodrigo@gmail.com",
                InicioAtividade = new DateTime(1234,12,3),
                CategoriaAdministrativa = CategoriaAdministrativaEnums.Estadual,
                OrganizacaoAcademica = OrganizacaoAcademicaEnums.EscolaGoverno,
                IdEndereco = 0
            },
            new Escola()
            {
                Id = 1,
                StatusAtividade = true,
                Nome = "Escola Enzo menezes",
                CodigoMec = "3414",
                Telefone = "143454345",
                Email = "enz@gmail.com",
                InicioAtividade = new DateTime(1234,12,3),
                CategoriaAdministrativa = CategoriaAdministrativaEnums.Estadual,
                OrganizacaoAcademica = OrganizacaoAcademicaEnums.EscolaGoverno,
                IdEndereco = 1
            }
       };

        _tabelas.Escolas.Value.Clear();
        _tabelas.Escolas.Value.AddRange(ValorEsperado);

        //act
        var ValorRetornado = _servicoEscola.ObterTodos();

        //assert
        Assert.Equal(ValorEsperado.Count, ValorRetornado.Count);
    }
}