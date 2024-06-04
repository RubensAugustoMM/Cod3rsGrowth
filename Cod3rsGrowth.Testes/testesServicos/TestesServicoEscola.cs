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

    [Theory]
    [InlineData(2)]
    [InlineData(-1)]
    public void ObterPorId_deve_lancar_Exception_quando_informado_Id_invalido_ou_inexistente(int idInformado)
    {
        List<Escola> ListaDadosTeste = new()
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
        _tabelas.Escolas.Value.AddRange(ListaDadosTeste);

        var excecaoObterPorId = Assert.Throws<Exception>(() => _servicoEscola.ObterPorId(idInformado));

        Assert.Equal($"Nenhuma Escola com Id {idInformado} existe no contexto atual!\n", excecaoObterPorId.Message);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    public void ObterPorId_deve_retornar_Escola_existente_quando_informado_id_valido(int idInformado)
    {
        List<Escola> ListaDadosTeste = new()
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
        _tabelas.Escolas.Value.AddRange(ListaDadosTeste);

        var ValorEsperado = ListaDadosTeste[idInformado];
        var ValorRetornado = _servicoEscola.ObterPorId(idInformado);

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