﻿using System.Collections;
using System.Collections.ObjectModel;
using System.Data;
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
        _servicoConvenio = _serviceProvider.GetService<ServicoConvenio>();
        _tabelas = TabelaSingleton.Instance;
    }

    [Fact]
    public void ObterTodos_ListaVazia_ListaVazia()
    {
        //arrage
        _tabelas.Convenios.Value.Clear();
        var ValorEsperado = _tabelas.Convenios.Value;
        //act
        var ValorRetornado = _servicoConvenio.ObterTodos();
        //assert
        Assert.Equal(ValorEsperado.Count, ValorRetornado.Count);
    }

    [Fact]
    public void ObterTodos_ListaUmElemento_listaUmElemento()
    {
        //arrage
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

        //act
        var ValorRetornado = _servicoConvenio.ObterTodos();

        //assert
        Assert.Equal(ValorEsperado.Count, ValorRetornado.Count);
    }

    [Fact]
    public void ObterTodos_ListaDoisElemento_listaDoisElemento()
    {
        //arrage
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

        //act
        var ValorRetornado = _servicoConvenio.ObterTodos();

        //assert
        Assert.Equal(ValorEsperado.Count, ValorRetornado.Count);
    }
}