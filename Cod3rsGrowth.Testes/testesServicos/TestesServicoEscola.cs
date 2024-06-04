using Cod3rsGrowth.Dominio.Enums;
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
        _servicoEscola = _serviceProvider.GetService<ServicoEscola>() ?? throw new Exception("Objeto _serviceProvider retornou null apos nao encontrar ServicoEscola!");
        _tabelas = TabelaSingleton.Instance;
    }

    [Fact]
    public void ao_ObterTodos_deve_retornar_lista_com_apenas_uma_Escola()
    {
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
                OrganizacaoAcademica = OrganizacaoAcademicaEnums.EscolaGoverno
            }
       };

        _tabelas.Escolas.Value.Clear();
        _tabelas.Escolas.Value.AddRange(ValorEsperado);

        var ValorRetornado = _servicoEscola.ObterTodos();

        Assert.Equal(ValorEsperado.Count, ValorRetornado.Count);
    }

    [Fact]
    public void ao_ObterTodos_deve_retornar_lista_com_apenas_duas_Escolas()
    {
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
                OrganizacaoAcademica = OrganizacaoAcademicaEnums.EscolaGoverno
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
                OrganizacaoAcademica = OrganizacaoAcademicaEnums.EscolaGoverno
            }
       };

        _tabelas.Escolas.Value.Clear();
        _tabelas.Escolas.Value.AddRange(ValorEsperado);

        var ValorRetornado = _servicoEscola.ObterTodos();

        Assert.Equal(ValorEsperado.Count, ValorRetornado.Count);
    }

    [Fact]
    public void ObterPorId_deve_lancar_Exception_Nenhuma_Escola_com_Id_6_existe_no_contexto_atual_quando_informado_Id_6_inexistente_no_contexto()
    {
        _tabelas.Convenios.Value.Clear();

        var excecaoObterPorId = Assert.Throws<Exception>(() => _servicoEscola.ObterPorId(6));
        Assert.Contains("Nenhuma Escola com Id 6 existe no contexto atual!\n", excecaoObterPorId.Message);
    }

    [Fact]
    public void ObterPorId_deve_lancar_ArgumentOutOfRangeException_valor_negativo_informado_ao_metodo_quando_informado_valor_negativo()
    {
        _tabelas.Convenios.Value.Clear();

        var excecaoObterPorId = Assert.Throws<ArgumentOutOfRangeException>(() => _servicoEscola.ObterPorId(-1));
        Assert.Contains("Valor negativo informado ao metodo!\n", excecaoObterPorId.Message);
    }

    [Fact]
    public void ObterPorId_deve_retornar_Escola_com_id_0_quando_informado_0()
    {
        List<Escola> ListaArrange = new()
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
                OrganizacaoAcademica = OrganizacaoAcademicaEnums.EscolaGoverno
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
                OrganizacaoAcademica = OrganizacaoAcademicaEnums.EscolaGoverno
            }
       };


        _tabelas.Escolas.Value.Clear();
        _tabelas.Escolas.Value.AddRange(ListaArrange);

        var ValorEsperado = ListaArrange.Find(x => x.Id == 0);

        var ValorRetornado = _servicoEscola.ObterPorId(0);

        Assert.Equal(ValorEsperado.Id, ValorRetornado.Id);   
        Assert.Equal(ValorEsperado.StatusAtividade, ValorRetornado.StatusAtividade);
        Assert.Equal(ValorEsperado.CodigoMec, ValorRetornado.CodigoMec);
        Assert.Equal(ValorEsperado.Telefone, ValorRetornado.Telefone);
        Assert.Equal(ValorEsperado.Email, ValorRetornado.Email);
        Assert.Equal(ValorEsperado.InicioAtividade.Date, ValorRetornado.InicioAtividade.Date);
        Assert.Equal(ValorEsperado.CategoriaAdministrativa, ValorRetornado.CategoriaAdministrativa);
        Assert.Equal(ValorEsperado.OrganizacaoAcademica, ValorRetornado.OrganizacaoAcademica);
    }

    [Fact]
    public void ObterPorId_deve_retornar_Escola_com_id_1_quando_informado_1()
    {
        List<Escola> ListaArrange = new()
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
                OrganizacaoAcademica = OrganizacaoAcademicaEnums.EscolaGoverno
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
                OrganizacaoAcademica = OrganizacaoAcademicaEnums.EscolaGoverno
            }
       };

        _tabelas.Escolas.Value.Clear();
        _tabelas.Escolas.Value.AddRange(ListaArrange);

        var ValorEsperado = ListaArrange.Find(x => x.Id == 1);

        var ValorRetornado = _servicoEscola.ObterPorId(1);

        Assert.Equal(ValorEsperado.Id, ValorRetornado.Id);   
        Assert.Equal(ValorEsperado.StatusAtividade, ValorRetornado.StatusAtividade);
        Assert.Equal(ValorEsperado.CodigoMec, ValorRetornado.CodigoMec);
        Assert.Equal(ValorEsperado.Telefone, ValorRetornado.Telefone);
        Assert.Equal(ValorEsperado.Email, ValorRetornado.Email);
        Assert.Equal(ValorEsperado.InicioAtividade.Date, ValorRetornado.InicioAtividade.Date);
        Assert.Equal(ValorEsperado.CategoriaAdministrativa, ValorRetornado.CategoriaAdministrativa);
        Assert.Equal(ValorEsperado.OrganizacaoAcademica, ValorRetornado.OrganizacaoAcademica);
    }
}