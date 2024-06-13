using FluentValidation;
using Cod3rsGrowth.Dominio.Enums;
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
        _servicoConvenio = _serviceProvider.GetService<ServicoConvenio>() ?? throw new Exception("Objeto _serviceProvider retornou null apos nao encontrar ServicoConvenio!");

        _tabelas = TabelaSingleton.Instance;
        _tabelas.Escolas.Value.Add(CriaNovaEscolaTeste());
        _tabelas.Empresas.Value.Add(CriaNovaEmpresaTeste());
    }

    
    

    private Convenio CriaNovoConvenioDeTeste()
    {
        Convenio ConvenioRetornar = new()
        {
            Id = 10,
            NumeroProcesso = 123,
            Objeto = "objeto",
            Valor = 2.0M,
            DataInicio = new DateTime(1900, 2, 3),
            IdEscola = 10,
            IdEmpresa = 10
        };

        return ConvenioRetornar;
    }

    private Empresa CriaNovaEmpresaTeste()
    {
        Empresa empresaNova = new()
        {
            Id = 10,
            Idade = 3,
            RazaoSocial = "Carlinhos Ferragens LTDA",
            NomeFantasia = "Carlinhos Ferragens",
            Cnpj = "11122233344",
            SitucaoCadastral = true,
            DataSituacaoCadastral = new DateTime(1000, 12, 03),
            DataAbertura = new DateTime(1000, 12, 03),
            CapitalSocial = 13,
            NaturezaJuridica = NaturezaJuridicaEnums.EmpresarioIndividual,
            Porte = PorteEnums.EmpresaPequenoPorte,
            MatrizFilial = MatrizFilialEnums.Matriz
        };

        return empresaNova;
    }

    private Escola CriaNovaEscolaTeste()
    {
        Escola NovaEscola = new()
        {
            Id = 10,
            StatusAtividade = true,
            Nome = "Escola Rodrigo",
            CodigoMec = "3415",
            Telefone = "12355645",
            Email = "rodrigo@gmail.com",
            InicioAtividade = new DateTime(1234, 12, 3),
            CategoriaAdministrativa = CategoriaAdministrativaEnums.Estadual,
            OrganizacaoAcademica = OrganizacaoAcademicaEnums.EscolaGoverno

        };

        return NovaEscola;
    }

    [Fact]
    public void ao_ObterTodos_deve_retornar_lista_nao_vazia()
    {         
        var ValorRetornado = _servicoConvenio.ObterTodos();

        Assert.NotNull(ValorRetornado);
    }

    [Theory]
    [InlineData(110)]
    [InlineData(-1)]
    public void ObterPorId_deve_lancar_Exception_quando_informado_Id_invalido_ou_inexistente(int idInformado)
    {
        var excecaoObterPorId = Assert.Throws<Exception>(() => _servicoConvenio.ObterPorId(idInformado));

        Assert.Equal($"Nenhum Convenio com Id {idInformado} existe no contexto atual!\n", excecaoObterPorId.Message);
    }

    [Theory]
    [InlineData(101)]
    [InlineData(102)]
    public void ObterPorId_deve_retornar_Convenio_existente_quando_informado_id_valido(int idInformado)
    {
        var ConvenioEntrada = CriaNovoConvenioDeTeste();
        ConvenioEntrada.Id = idInformado;
        _tabelas.Convenios.Value.Add(ConvenioEntrada);

        var ValorRetornado = _servicoConvenio.ObterPorId(idInformado);

        Assert.Equal(ConvenioEntrada.Id, ValorRetornado.Id);
        Assert.Equal(ConvenioEntrada.NumeroProcesso, ConvenioEntrada.NumeroProcesso);
        Assert.Equal(ConvenioEntrada.Objeto, ValorRetornado.Objeto);
        Assert.Equal(ConvenioEntrada.Valor, ValorRetornado.Valor);
        Assert.Equal(ConvenioEntrada.DataInicio.Date, ValorRetornado.DataInicio.Date);
        Assert.Equal(ConvenioEntrada.IdEmpresa, ConvenioEntrada.IdEmpresa);
        Assert.Equal(ConvenioEntrada.IdEscola, ValorRetornado.IdEscola);
    }

    [Theory]
    [InlineData(-12)]
    [InlineData(-1)]
    public void Criar_deve_lancar_ValidationException_quando_informado_Convenio_com_Id_invalido(int idInformado)
    {
        var convenioEntrada = CriaNovoConvenioDeTeste();
        var ValorEsperado = "Id deve ser um valor maior ou igual a zero!";
        convenioEntrada.Id = idInformado;

        var excecao = Assert.Throws<ValidationException>(() => _servicoConvenio.Criar(convenioEntrada));

        Assert.Equal(ValorEsperado, excecao.Errors.First().ErrorMessage);
    }
    [Theory]
    [InlineData(-12)]
    [InlineData(-1)]
    public void Criar_deve_lancar_ValidationException_quando_informado_Convenio_com_NumeroProcesso_Invalido(int numeroProcessoInformado)
    {
        var convenioEntrada = CriaNovoConvenioDeTeste();
        var ValorEsperado = "Numero Processo deve ser maior que zero!";
        convenioEntrada.NumeroProcesso = numeroProcessoInformado;

        var excecao = Assert.Throws<ValidationException>(() => _servicoConvenio.Criar(convenioEntrada));

        Assert.Equal(ValorEsperado, excecao.Errors.First().ErrorMessage);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("      ")]
    public void Criar_deve_lancar_ValidationException_quando_informado_Convenio_com_Objeto_null_ou_com_somente_espacos(string objetoInformado)
    {
        var convenioEntrada = CriaNovoConvenioDeTeste();
        var ValorEsperado = "Objeto nao pode ter valor nulo ou formado por caracteres de espaco!";
        convenioEntrada.Objeto = objetoInformado;

        var excecao = Assert.Throws<ValidationException>(() => _servicoConvenio.Criar(convenioEntrada));

        Assert.Equal(ValorEsperado, excecao.Errors.First().ErrorMessage);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-10_000)]
    public void Criar_deve_lancar_ValidationException_quando_informado_Convenio_com_Valor_invalido(decimal ValorInformado)
    {
        var convenioEntrada = CriaNovoConvenioDeTeste();
        var ValorEsperado = "Valor do convenio deve ser maior que zero!";
        convenioEntrada.Valor = ValorInformado;

        var excecao = Assert.Throws<ValidationException>(() => _servicoConvenio.Criar(convenioEntrada));

        Assert.Equal(ValorEsperado, excecao.Errors.First().ErrorMessage);
    }

    [Fact]
    public void Criar_develancar_ValidationException_quando_informado_Convenio_com_DataInicio_anterior_a_1889()
    {
        var ConvenioEntrada = CriaNovoConvenioDeTeste();
        var ValorEsperado = "Data Inicio deve ser após a proclamacao da republica!";
        ConvenioEntrada.DataInicio = new(1888, 8, 15);

        var excecao = Assert.Throws<ValidationException>(() => _servicoConvenio.Criar(ConvenioEntrada));

        Assert.Equal(ValorEsperado, excecao.Errors.First().ErrorMessage);
    }

    [Fact]
    public void Criar_deve_retornar_ValidationException_quando_quando_informado_Convenio_com_DataInicio_apos_data_atual()
    {
        var ConvenioEntrada = CriaNovoConvenioDeTeste();
        var ValorEsperado = "Data Inicio deve ser anterior ou igual a data atual!";
        ConvenioEntrada.DataInicio = new DateTime(5000, 3, 2);

        var excecao = Assert.Throws<ValidationException>(() => _servicoConvenio.Criar(ConvenioEntrada));

        Assert.Equal(ValorEsperado, excecao.Errors.First().ErrorMessage);
    }

    [Fact]
    public void Criar_deve_retornar_ValidationException_quando_informado_Convenio_com_DataTermino_anterior_a_DataInicio()
    {
        var convenioEntrada = CriaNovoConvenioDeTeste();
        var ValorEsperado = "Data Termino deve ser maior que a DataInicio!";
        convenioEntrada.DataTermino = new DateTime(1500, 12, 2);

        var excecao = Assert.Throws<ValidationException>(() => _servicoConvenio.Criar(convenioEntrada));

        Assert.Equal(ValorEsperado, excecao.Errors.First().ErrorMessage);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(-2)]
    public void Criar_deve_retornar_retornar_ValidationException_quando_informado_Convenio_com_IdEscola_negativo(int idEscolaInformado)
    {
        var convenioEntrada = CriaNovoConvenioDeTeste();
        var ValorEsperado = "Id Escola deve ser maior ou igual a zero!";
        convenioEntrada.IdEscola = idEscolaInformado;

        var excecao = Assert.Throws<ValidationException>(() => _servicoConvenio.Criar(convenioEntrada));

        Assert.Equal(ValorEsperado, excecao.Errors.First().ErrorMessage);
    }

    [Theory]
    [InlineData(101)]
    [InlineData(102)]
    public void Criar_deve_retornar_ValidationException_quando_informado_Convenio_com_IdEscola_referente_a_escola_inexistente(int idEscolaInformado)
    {
        var convenioEntrada = CriaNovoConvenioDeTeste();
        var ValorEsperado = "Id Escola deve ser referente a uma escola existente!";
        convenioEntrada.IdEscola = idEscolaInformado;

        var excecao = Assert.Throws<ValidationException>(() => _servicoConvenio.Criar(convenioEntrada));

        Assert.Equal(ValorEsperado, excecao.Errors.First().ErrorMessage);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(-2)]
    public void Criar_deve_retornar_ValidationException_quando_informado_Convenio_com_IdEmpresa_negativo(int idEmpresaInformado)
    {
        var convenioEntrada = CriaNovoConvenioDeTeste();
        var ValorEsperado = "Id Empresa deve ser maior ou igual a zero!";
        convenioEntrada.IdEmpresa = idEmpresaInformado;

        var excecao = Assert.Throws<ValidationException>(() => _servicoConvenio.Criar(convenioEntrada));

        Assert.Equal(ValorEsperado, excecao.Errors.First().ErrorMessage);
    }

    [Theory]
    [InlineData(4)]
    [InlineData(5)]
    public void Criar_deve_retornar_ValidationException_quando_informado_Convenio_com_IdEmpresa_referente_a_Empresa_inexistente(int idEmpresaInformado)
    {
        var convenioEntrada = CriaNovoConvenioDeTeste();
        var ValorEsperado = "Id Empresa deve ser referente a uma empresa existente!";
        convenioEntrada.IdEmpresa = idEmpresaInformado;

        var excecao = Assert.Throws<ValidationException>(() => _servicoConvenio.Criar(convenioEntrada));

        Assert.Equal(ValorEsperado, excecao.Errors.First().ErrorMessage);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void Criar_deve_adicionar_Convenio_no_repositorio_quando_informado_Convenio_com_Id_valido(int IdInformado)
    {
        var convenioEntrada = CriaNovoConvenioDeTeste();
        convenioEntrada.Id = IdInformado;

        _servicoConvenio.Criar(convenioEntrada);
        var ValorRetornado = _tabelas.Convenios.Value.FirstOrDefault(convenioEntrada);

        Assert.NotNull(ValorRetornado);
    }

    [Theory]
    [InlineData(123)]
    [InlineData(98882)]
    public void Criar_deve_adicionar_Convenio_no_repositorio_quando_informado_Convenio_com_NumeroProcesso_valido(int numeroProcessoInformado)
    {
        var convenioEntrada = CriaNovoConvenioDeTeste();
        convenioEntrada.NumeroProcesso = numeroProcessoInformado;

        _servicoConvenio.Criar(convenioEntrada);
        var ValorRetornado = _tabelas.Convenios.Value.FirstOrDefault(convenioEntrada);

        Assert.NotNull(ValorRetornado);
    }

    [Theory]
    [InlineData("Objeto")]
    [InlineData("Curso bolo de pote")]
    public void Criar_deve_adicionar_Convenio_no_repositorio_quando_informado_Convenio_com_Objeto_valido(string objetoInformado)
    {
        var convenioEntrada = CriaNovoConvenioDeTeste();
        convenioEntrada.Objeto = objetoInformado;

        _servicoConvenio.Criar(convenioEntrada);
        var ValorRetornado = _tabelas.Convenios.Value.FirstOrDefault(convenioEntrada);

        Assert.NotNull(ValorRetornado);
    }

    [Theory]
    [InlineData(10.99)]
    [InlineData(10_000)]
    public void Criar_deve_adicionar_Convenio_no_repositorio_quando_informado_Convenio_com_Valor_valido(int ValorInformado)
    {
        var convenioEntrada = CriaNovoConvenioDeTeste();
        convenioEntrada.Valor = ValorInformado;

        _servicoConvenio.Criar(convenioEntrada);
        var ValorRetornado = _tabelas.Convenios.Value.FirstOrDefault(convenioEntrada);

        Assert.NotNull(ValorRetornado);
    }

    [Fact]
    public void Criar_deve_adicionar_Convenio_no_repositorio_quando_informado_Convenio_com_DataInicio_valida()
    {
        var convenioEntrada = CriaNovoConvenioDeTeste();

        _servicoConvenio.Criar(convenioEntrada);
        var ValorRetornado = _tabelas.Convenios.Value.FirstOrDefault(convenioEntrada);

        Assert.NotNull(ValorRetornado);
    }

    [Fact]
    public void Criar_deve_adicionar_Convenio_no_repositorio_quando_informado_Convenio_com_DataTermino_valida()
    {
        var convenioEntrada = CriaNovoConvenioDeTeste();

        _servicoConvenio.Criar(convenioEntrada);
        var ValorRetornado = _tabelas.Convenios.Value.FirstOrDefault(convenioEntrada);

        Assert.NotNull(ValorRetornado);
    }

    [Theory]
    [InlineData(10)]
    [InlineData(20)]
    public void Criar_deve_adicionar_Convenio_no_repositorio_quando_informado_Convenio_com_IdEscola_valido_e_referente_a_escola_existente(int idEscolaInformado)
    {
        var convenioEntrada = CriaNovoConvenioDeTeste();
        var escolaEntrada = CriaNovaEscolaTeste();
        convenioEntrada.IdEscola = idEscolaInformado;
        escolaEntrada.Id = idEscolaInformado;
        _tabelas.Escolas.Value.Add(escolaEntrada);

        _servicoConvenio.Criar(convenioEntrada);
        var ValorRetornado = _tabelas.Convenios.Value.FirstOrDefault(convenioEntrada);

        Assert.NotNull(ValorRetornado);
    }

    [Theory]
    [InlineData(5)]
    [InlineData(10)]
    public void Criar_deve_adicionar_Convenio_no_repositorio_quando_informado_Convenio_com_IdEmpresa_valido_e_referente_a_Empresa_existente(int idEmpresaInformado)
    {
        var convenioEntrada = CriaNovoConvenioDeTeste();
        var EmpresaEntrada = CriaNovaEmpresaTeste();
        convenioEntrada.IdEmpresa = idEmpresaInformado;
        EmpresaEntrada.Id = idEmpresaInformado;
        _tabelas.Empresas.Value.Add(EmpresaEntrada);

        _servicoConvenio.Criar(convenioEntrada);
        var ValorRetornado = _tabelas.Convenios.Value.FirstOrDefault(convenioEntrada);

        Assert.NotNull(ValorRetornado);
    }

    [Theory]
    [InlineData(20)]
    [InlineData(30)]
    public void Atualizar_deve_retornar_Exception_quando_informado_Convenio_com_Id_inexistente(int idInformado)
    {
        var ConvenioEntrada = CriaNovoConvenioDeTeste();
        ConvenioEntrada.Id = idInformado;

        var excecao = Assert.Throws<Exception>(() => _servicoConvenio.Atualizar(ConvenioEntrada));

        Assert.Equal($"Nenhum Convenio com Id {idInformado} existe no contexto atual!\n", excecao.Message);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("   ")]
    public void Atualizar_deve_retornar_ValidationException_quando_informado_Convenio_invalido(string objetoInformado)
    {
        var ConvenioEntrada = CriaNovoConvenioDeTeste();
        var ConvenioAtualizar = CriaNovoConvenioDeTeste();
        ConvenioEntrada.Objeto = objetoInformado;
        _tabelas.Convenios.Value.Add(ConvenioAtualizar);

        var excecao = Assert.Throws<ValidationException>(() => _servicoConvenio.Atualizar(ConvenioEntrada));

        Assert.Equal("Objeto nao pode ter valor nulo ou formado por caracteres de espaco!", excecao.Errors.First().ErrorMessage);
    }

    [Theory]
    [InlineData(1234, "Objeto1", 2_000.0)]
    [InlineData(320, "Objeto2", 320.50)]
    public void Atualizar_deve_alterar_parametros_de_Convenio_existente_quando_informado_Convenio_valido(int numeroInformado, string objetoInformado, decimal valorInformado)
    {
        var ConvenioEntrada = CriaNovoConvenioDeTeste();
        var ConvenioAtualizar = CriaNovoConvenioDeTeste();
        ConvenioEntrada.NumeroProcesso = numeroInformado;
        ConvenioEntrada.Objeto = objetoInformado;
        ConvenioEntrada.Valor = valorInformado;
        _tabelas.Convenios.Value.Add(ConvenioAtualizar);

        _servicoConvenio.Atualizar(ConvenioEntrada);
        var ValorRetornado = _tabelas.Convenios.Value.FirstOrDefault(convenio => convenio.Id == ConvenioEntrada.Id);

        Assert.Equal(numeroInformado, ValorRetornado.NumeroProcesso);
        Assert.Equal(objetoInformado, ValorRetornado.Objeto);
        Assert.Equal(valorInformado, ValorRetornado.Valor);
    }

    [Theory]
    [InlineData(-100)]
    [InlineData(305)]
    public void Deletar_deve_lancar_Exception_quando_informado_Id_invalido_ou_inexistente(int idInformado)
    {
        var excecao = Assert.Throws<Exception>(() => _servicoConvenio.Deletar(idInformado));

        Assert.Equal($"Nenhum Convenio com Id {idInformado} existe no contexto atual!\n", excecao.Message);
    }

    [Theory]
    [InlineData(301)]
    [InlineData(302)]
    public void Deletar_deve_remover_Convenio_do_repositorio_quando_informado_Id_item_a_remover(int idInformado)
    {
        var ConvenioEntrada = CriaNovoConvenioDeTeste();
        ConvenioEntrada.Id = idInformado;
        _tabelas.Convenios.Value.Add(ConvenioEntrada);

        _servicoConvenio.Deletar(ConvenioEntrada.Id);
        var ValorRetorno = _tabelas.Convenios.Value.FirstOrDefault(c => c.Id == idInformado);

        Assert.Null(ValorRetorno);
    }
}