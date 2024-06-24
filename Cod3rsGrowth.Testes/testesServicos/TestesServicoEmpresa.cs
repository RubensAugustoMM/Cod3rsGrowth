using FluentValidation;
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
        _tabelas.Enderecos.Value.Add(CriaNovoEnderecoTeste());
    }

    private Empresa CriaNovaEmpresaTeste()
    {
        Empresa NovaEmpresa = new()
        {
            Id = 20,
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
            IdEndereco = 20
        };

        return NovaEmpresa;
    }

    private Endereco CriaNovoEnderecoTeste()
    {
        Endereco NovoEndereco = new()
        {
            Id = 20,
            Numero = 13,
            Cep = "113336666",
            Municipio = "Sao Bartolomeu",
            Bairro = "joao",
            Rua = "143",
            Complemento = "Perto da merceria do Galo",
            Estado = EstadoEnums.DistritoFederal
        };

        return NovoEndereco;
    }

    [Fact]
    public void ao_ObterTodos_deve_retornar_lista_nao_nula()
    {
        var ValorRetornado = _servicoEmpresa.ObterTodos(null);

        Assert.NotNull(ValorRetornado);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(110)]
    public void ObterPorId_deve_lancar_Exception_quando_informado_Id_invalido_ou_inexistente(int idInformado)
    {
        var excecaoObterPorId = Assert.Throws<Exception>(() => _servicoEmpresa.ObterPorId(idInformado));

        Assert.Equal($"Nenhuma Empresa com Id {idInformado} existe no contexto atual!\n", excecaoObterPorId.Message);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    public void ObterPorId_deve_retornar_Empresa_existente_quando_informado_id_valido(int idInformado)
    {
        var EmpresaEntrada = CriaNovaEmpresaTeste();
        EmpresaEntrada.Id = idInformado;
        _tabelas.Empresas.Value.Add(EmpresaEntrada);

        var ValorRetornado = _servicoEmpresa.ObterPorId(idInformado);

        Assert.Equal(EmpresaEntrada.Id, ValorRetornado.Id);
        Assert.Equal(EmpresaEntrada.Idade, ValorRetornado.Idade);
        Assert.Equal(EmpresaEntrada.RazaoSocial, ValorRetornado.RazaoSocial);
        Assert.Equal(EmpresaEntrada.NomeFantasia, ValorRetornado.NomeFantasia);
        Assert.Equal(EmpresaEntrada.Cnpj, ValorRetornado.Cnpj);
        Assert.Equal(EmpresaEntrada.SitucaoCadastral, ValorRetornado.SitucaoCadastral);
        Assert.Equal(EmpresaEntrada.DataSituacaoCadastral.Date, ValorRetornado.DataSituacaoCadastral.Date);
        Assert.Equal(EmpresaEntrada.DataAbertura.Date, ValorRetornado.DataAbertura.Date);
        Assert.Equal(EmpresaEntrada.CapitalSocial, ValorRetornado.CapitalSocial);
        Assert.Equal(EmpresaEntrada.NaturezaJuridica, ValorRetornado.NaturezaJuridica);
        Assert.Equal(EmpresaEntrada.Porte, ValorRetornado.Porte);
        Assert.Equal(EmpresaEntrada.MatrizFilial, ValorRetornado.MatrizFilial);
    }

    [Theory]
    [InlineData(-2)]
    [InlineData(-1)]
    public void Criar_deve_retornar_ValidationException_quando_informado_Empresa_com_Id_invalido(int idInformado)
    {
        var EmpresaEntrada = CriaNovaEmpresaTeste();
        var ValorEsperado = "Id deve ser um valor maior ou igual a zero!";
        EmpresaEntrada.Id = idInformado;

        var excecao = Assert.Throws<ValidationException>(() => _servicoEmpresa.Criar(EmpresaEntrada));

        Assert.Equal(ValorEsperado, excecao.Errors.First().ErrorMessage);
    }

    [Theory]
    [InlineData(-2)]
    [InlineData(-1)]
    public void Criar_deve_retornar_ValidationException_quando_informado_Empresa_com_Idade_negativa(int idadeInformada)
    {
        var EmpresaEntrada = CriaNovaEmpresaTeste();
        var ValorEsperado = "Idade deve ser maior ou igual a 0!";
        EmpresaEntrada.Idade = idadeInformada;

        var excecao = Assert.Throws<ValidationException>(() => _servicoEmpresa.Criar(EmpresaEntrada));

        Assert.Equal(ValorEsperado, excecao.Errors.First().ErrorMessage);
    }

    [Theory]
    [InlineData(10)]
    [InlineData(100)]
    public void Criar_deve_retornar_ValidationException_quando_informado_Empresa_com_Idade_invalida_em_relacao_a_data_inicio(int idadeInformada)
    {
        var EmpresaEntrada = CriaNovaEmpresaTeste();
        var ValorEsperado = "Idade diferente da diferenca da data abertura com a data atual!";
        EmpresaEntrada.Idade = idadeInformada;

        var excecao = Assert.Throws<ValidationException>(() => _servicoEmpresa.Criar(EmpresaEntrada));

        Assert.Equal(ValorEsperado, excecao.Errors.First().ErrorMessage);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("     ")]
    public void Criar_deve_retornar_ValidationException_quando_informado_Empresa_com_RazaoSocial_invalido(string razaoSocialInformada)
    {
        var EmpresaEntrada = CriaNovaEmpresaTeste();
        var ValorEsperado = "Razao Social nao pode ter valor nulo ou formado por caracteres de espaco!";
        EmpresaEntrada.RazaoSocial = razaoSocialInformada;

        var excecao = Assert.Throws<ValidationException>(() => _servicoEmpresa.Criar(EmpresaEntrada));

        Assert.Equal(ValorEsperado, excecao.Errors.First().ErrorMessage);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("     ")]
    public void Criar_deve_retornar_ValidationException_quando_informado_Empresa_com_NomeFantasia_nulo_ou_vazio(string nomeFantasiaInformado)
    {
        var EmpresaEntrada = CriaNovaEmpresaTeste();
        var ValorEsperado = "Nome Fantasia nao pode ter valor nulo ou formado por caracteres de espaco!";
        EmpresaEntrada.NomeFantasia = nomeFantasiaInformado;

        var excecao = Assert.Throws<ValidationException>(() => _servicoEmpresa.Criar(EmpresaEntrada));

        Assert.Equal(ValorEsperado, excecao.Errors.First().ErrorMessage);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("     ")]
    public void Criar_deve_retornar_ValidationException_quando_informado_Empresa_com_Cnpj_nulo_ou_vazio(string cnpjInformado)
    {
        var EmpresaEntrada = CriaNovaEmpresaTeste();
        var ValorEsperado = "Cnpj nao pode ter valor nulo ou formado por caracteres de espaco!";
        EmpresaEntrada.Cnpj = cnpjInformado;

        var excecao = Assert.Throws<ValidationException>(() => _servicoEmpresa.Criar(EmpresaEntrada));

        Assert.Equal(ValorEsperado, excecao.Errors.First().ErrorMessage);
    }

    [Theory]
    [InlineData("asdfghjklqwert")]
    public void Criar_deve_retornar_ValidationException_quando_informado_Empresa_com_Cnpj_com_caracteres_nao_numericos(string cnpjInformado)
    {
        var EmpresaEntrada = CriaNovaEmpresaTeste();
        var ValorEsperado = "Cnpj deve ser formado somente por numeros!";
        EmpresaEntrada.Cnpj = cnpjInformado;

        var excecao = Assert.Throws<ValidationException>(() => _servicoEmpresa.Criar(EmpresaEntrada));

        Assert.Equal(ValorEsperado, excecao.Errors.First().ErrorMessage);
    }

    [Theory]
    [InlineData("1234")]
    [InlineData("123456789123456")]
    public void Criar_deve_retornar_ValidationException_quando_informado_Empresa_com_Cnpj_com_tamanho_diferente_de_14(string cnpjInformado)
    {
        var EmpresaEntrada = CriaNovaEmpresaTeste();
        var ValorEsperado = "Cnpj Length menor ou maior que 14 characteres!";
        EmpresaEntrada.Cnpj = cnpjInformado;

        var excecao = Assert.Throws<ValidationException>(() => _servicoEmpresa.Criar(EmpresaEntrada));

        Assert.Equal(ValorEsperado, excecao.Errors.First().ErrorMessage);
    }

    [Fact]
    public void Criar_deve_retornar_ValidationException_quando_informado_Empresa_com_DataSituacaoCadastral_invalida()
    {
        var EmpresaEntrada = CriaNovaEmpresaTeste();
        var ValorEsperado = "Data Situacao Cadastral deve ser maior que a DataAbertura";
        EmpresaEntrada.DataSituacaoCadastral = new DateTime(2000, 12, 03);

        var excecao = Assert.Throws<ValidationException>(() => _servicoEmpresa.Criar(EmpresaEntrada));

        Assert.Equal(ValorEsperado, excecao.Errors.First().ErrorMessage);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-300)]
    public void Criar_deve_retornar_ValidationException_quando_informado_Empresa_com_CapitalSocial_invalido(decimal capitalSocialInformado)
    {
        var EmpresaEntrada = CriaNovaEmpresaTeste();
        var ValorEsperado = "Capital Social nao pode ser menor ou igual a zero!";
        EmpresaEntrada.CapitalSocial = capitalSocialInformado;

        var excecao = Assert.Throws<ValidationException>(() => _servicoEmpresa.Criar(EmpresaEntrada));

        Assert.Equal(ValorEsperado, excecao.Errors.First().ErrorMessage);
    }

    [Theory]
    [InlineData(-3)]
    [InlineData(30)]
    public void Criar_deve_retornar_ValidationException_quando_informado_Empresa_com_NaturezaJuridica_invalida(int naturezaJuridiaInformada)
    {
        var EmpresaEntrada = CriaNovaEmpresaTeste();
        var ValorEsperado = "Valor de Natureza Juridica fora do Enum!";
        EmpresaEntrada.NaturezaJuridica = (NaturezaJuridicaEnums)naturezaJuridiaInformada;

        var excecao = Assert.Throws<ValidationException>(() => _servicoEmpresa.Criar(EmpresaEntrada));

        Assert.Equal(ValorEsperado, excecao.Errors.First().ErrorMessage);
    }

    [Theory]
    [InlineData(-3)]
    [InlineData(30)]
    public void Criar_deve_retornar_ValidationException_quando_informado_Empresa_com_Porte_invalido(int porteInformada)
    {
        var EmpresaEntrada = CriaNovaEmpresaTeste();
        var ValorEsperado = "Valor de Porte fora do Enum!";
        EmpresaEntrada.Porte = (PorteEnums)porteInformada;

        var excecao = Assert.Throws<ValidationException>(() => _servicoEmpresa.Criar(EmpresaEntrada));

        Assert.Equal(ValorEsperado, excecao.Errors.First().ErrorMessage);
    }

    [Theory]
    [InlineData(-3)]
    [InlineData(30)]
    public void Criar_deve_retornar_ValidationException_quando_informado_Empresa_com_MatrizFilial_invalida(int matrizFilialInformada)
    {
        var EmpresaEntrada = CriaNovaEmpresaTeste();
        var ValorEsperado = "Valor de Matriz Filial fora do Enum!";
        EmpresaEntrada.MatrizFilial = (MatrizFilialEnums)matrizFilialInformada;

        var excecao = Assert.Throws<ValidationException>(() => _servicoEmpresa.Criar(EmpresaEntrada));

        Assert.Equal(ValorEsperado, excecao.Errors.First().ErrorMessage);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(-2)]
    public void Criar_deve_retornar_ValidationException_quando_informado_Empresa_com_IdEndereco_valido_e_referente_a_Endereco_negativo(int idEnderecoInformado)
    {
        var EmpresaEntrada = CriaNovaEmpresaTeste();
        var ValorEsperado = "Id Endereco deve ser um valor maior ou igual a zero!";
        EmpresaEntrada.IdEndereco = idEnderecoInformado;

        var excecao = Assert.Throws<ValidationException>(() => _servicoEmpresa.Criar(EmpresaEntrada));

        Assert.Equal(ValorEsperado, excecao.Errors.First().ErrorMessage);
    }

    [Theory]
    [InlineData(100)]
    [InlineData(200)]
    public void Criar_deve_retornar_ValidationException_quando_informado_Empresa_com_IdEndereco_valido_e_referente_a_Endereco_inexistente(int idEnderecoInformado)
    {
        var EmpresaEntrada = CriaNovaEmpresaTeste();
        var ValorEsperado = "Id Endereco deve ser referente a uma endereco existente!";
        EmpresaEntrada.IdEndereco = idEnderecoInformado;

        var excecao = Assert.Throws<ValidationException>(() => _servicoEmpresa.Criar(EmpresaEntrada));

        Assert.Equal(ValorEsperado, excecao.Errors.First().ErrorMessage);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void Criar_deve_adicionar_Empresa_no_repositorio_quando_informado_Empresa_com_Id_valido(int idInformado)
    {
        var EmpresaEntrada = CriaNovaEmpresaTeste();
        EmpresaEntrada.Id = idInformado;

        _servicoEmpresa.Criar(EmpresaEntrada);
        var ValorRetornado = _tabelas.Empresas.Value.FirstOrDefault(EmpresaEntrada);

        Assert.NotNull(ValorRetornado);
    }

    [Fact]
    public void Criar_deve_adicionar_Empresa_no_repositorio_quando_informado_Empresa_com_Idade_valido()
    {
        var EmpresaEntrada = CriaNovaEmpresaTeste();

        _servicoEmpresa.Criar(EmpresaEntrada);
        var ValorRetornado = _tabelas.Empresas.Value.FirstOrDefault(EmpresaEntrada);

        Assert.NotNull(ValorRetornado);
    }

    [Theory]
    [InlineData("Pedro Gomez")]
    [InlineData("Pedregal")]
    public void Criar_deve_adicionar_Empresa_no_repositorio_quando_informado_Empresa_com_RazaoSocial_valida(string razaoSocialInformada)
    {
        var EmpresaEntrada = CriaNovaEmpresaTeste();
        EmpresaEntrada.RazaoSocial = razaoSocialInformada;

        _servicoEmpresa.Criar(EmpresaEntrada);
        var ValorRetornado = _tabelas.Empresas.Value.FirstOrDefault(EmpresaEntrada);

        Assert.NotNull(ValorRetornado);
    }

    [Theory]
    [InlineData("Pedro Gomez")]
    [InlineData("Pedregal")]
    public void Criar_deve_adicionar_Empresa_no_repositorio_quando_informado_Empresa_com_NomeFantasia_valido(string nomeFantasiaInformado)
    {
        var EmpresaEntrada = CriaNovaEmpresaTeste();
        EmpresaEntrada.NomeFantasia = nomeFantasiaInformado;

        _servicoEmpresa.Criar(EmpresaEntrada);
        var ValorRetornado = _tabelas.Empresas.Value.FirstOrDefault(EmpresaEntrada);

        Assert.NotNull(ValorRetornado);
    }

    [Theory]
    [InlineData("12345678901234")]
    [InlineData("09876543210987")]
    public void Criar_deve_adicionar_Empresa_no_repositorio_quando_informado_Empresa_com_Cnpj_valido(string cnpjInformado)
    {
        var EmpresaEntrada = CriaNovaEmpresaTeste();
        EmpresaEntrada.Cnpj = cnpjInformado;

        _servicoEmpresa.Criar(EmpresaEntrada);
        var ValorRetornado = _tabelas.Empresas.Value.FirstOrDefault(EmpresaEntrada);

        Assert.NotNull(ValorRetornado);
    }

    [Fact]
    public void Criar_deve_adicionar_Empresa_no_repositorio_quando_informado_Empresa_com_DataSituacaoCadastral_valida()
    {
        var EmpresaEntrada = CriaNovaEmpresaTeste();

        _servicoEmpresa.Criar(EmpresaEntrada);
        var ValorRetornado = _tabelas.Empresas.Value.FirstOrDefault(EmpresaEntrada);

        Assert.NotNull(ValorRetornado);
    }

    [Fact]
    public void Criar_deve_adicionar_Empresa_no_repositorio_quando_informado_Empresa_com_DataAbertura_valida()
    {
        var EmpresaEntrada = CriaNovaEmpresaTeste();

        _servicoEmpresa.Criar(EmpresaEntrada);
        var ValorRetornado = _tabelas.Empresas.Value.FirstOrDefault(EmpresaEntrada);

        Assert.NotNull(ValorRetornado);
    }

    [Fact]
    public void Criar_deve_adicionar_Empresa_no_repositorio_quando_informado_Empresa_com_CapitalSocial_valido()
    {
        var EmpresaEntrada = CriaNovaEmpresaTeste();

        _servicoEmpresa.Criar(EmpresaEntrada);
        var ValorRetornado = _tabelas.Empresas.Value.FirstOrDefault(EmpresaEntrada);

        Assert.NotNull(ValorRetornado);
    }

    [Theory]
    [InlineData(NaturezaJuridicaEnums.EmpresarioIndividual)]
    [InlineData(NaturezaJuridicaEnums.MicroempreendedorIndividual)]
    public void Criar_deve_adicionar_Empresa_no_repositorio_quando_informado_Empresa_com_NaturezaJuridica_valida(NaturezaJuridicaEnums naturezaJuridicaInformada)
    {
        var EmpresaEntrada = CriaNovaEmpresaTeste();
        EmpresaEntrada.NaturezaJuridica = naturezaJuridicaInformada;

        _servicoEmpresa.Criar(EmpresaEntrada);
        var ValorRetornado = _tabelas.Empresas.Value.FirstOrDefault(EmpresaEntrada);

        Assert.NotNull(ValorRetornado);
    }

    [Theory]
    [InlineData(PorteEnums.EmpresaPequenoPorte)]
    [InlineData(PorteEnums.Microempresa)]
    public void Criar_deve_adicionar_Empresa_no_repositorio_quando_informado_Empresa_com_Porte_valido(PorteEnums porteInformado)
    {
        var EmpresaEntrada = CriaNovaEmpresaTeste();
        EmpresaEntrada.Porte = porteInformado;

        _servicoEmpresa.Criar(EmpresaEntrada);
        var ValorRetornado = _tabelas.Empresas.Value.FirstOrDefault(EmpresaEntrada);

        Assert.NotNull(ValorRetornado);
    }

    [Theory]
    [InlineData(MatrizFilialEnums.Matriz)]
    [InlineData(MatrizFilialEnums.Filial)]
    public void Criar_deve_adicionar_Empresa_no_repositorio_quando_informado_Empresa_com_MatrizFilial_valida(MatrizFilialEnums matrizFilialInformado)
    {
        var EmpresaEntrada = CriaNovaEmpresaTeste();
        EmpresaEntrada.MatrizFilial = matrizFilialInformado;

        _servicoEmpresa.Criar(EmpresaEntrada);
        var ValorRetornado = _tabelas.Empresas.Value.FirstOrDefault(EmpresaEntrada);

        Assert.NotNull(ValorRetornado);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void Criar_deve_adicionar_Empresa_no_repositorio_quando_informado_Empresa_com_IdEndereco_valido_e_referente_a_Endereco_Existente(int idEnderecoInformado)
    {
        var EmpresaEntrada = CriaNovaEmpresaTeste();
        var EnderecoEntrada = CriaNovoEnderecoTeste();
        EmpresaEntrada.IdEndereco = idEnderecoInformado;
        EnderecoEntrada.Id = idEnderecoInformado;
        _tabelas.Enderecos.Value.Clear();
        _tabelas.Enderecos.Value.Add(EnderecoEntrada);

        _servicoEmpresa.Criar(EmpresaEntrada);
        var ValorRetornado = _tabelas.Empresas.Value.FirstOrDefault(EmpresaEntrada);

        Assert.NotNull(ValorRetornado);
    }

    [Theory]
    [InlineData(201)]
    [InlineData(202)]
    public void Atualizar_deve_retornar_Exception_quando_informado_Empresa_com_Id_inexistente(int idInformado)
    {
        var EmpresaEntrada = CriaNovaEmpresaTeste();
        EmpresaEntrada.Id = idInformado;

        var excecao = Assert.Throws<Exception>(() => _servicoEmpresa.Atualizar(EmpresaEntrada));

        Assert.Equal($"Nenhuma Empresa com Id {idInformado} existe no contexto atual!\n", excecao.Message);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("   ")]
    public void Atualizar_deve_retornar_ValidationException_quando_informado_Empresa_invalido(string razaoSocialInformado)
    {
        var EmpresaEntrada = CriaNovaEmpresaTeste();
        _tabelas.Empresas.Value.Add(EmpresaEntrada);
        EmpresaEntrada.RazaoSocial = razaoSocialInformado;
        var excecao = Assert.Throws<ValidationException>(() => _servicoEmpresa.Atualizar(EmpresaEntrada));

        Assert.Equal("Razao Social nao pode ter valor nulo ou formado por caracteres de espaco!", excecao.Errors.First().ErrorMessage);
    }

    [Theory]
    [InlineData("razaoSocial", PorteEnums.Microempresa, 300000)]
    [InlineData("Rodrigos", PorteEnums.MicroeempreendedorIndividual, 320.50)]
    public void Atualizar_deve_alterar_parametros_de_Empresa_existente_quando_informado_Empresa_valido(string razaoSocialInformado, PorteEnums porteInformado, decimal capitalSocialInformado)
    {
        var EmpresaEntrada = CriaNovaEmpresaTeste();
        var EmpresaAtualizar = CriaNovaEmpresaTeste();
        EmpresaEntrada.RazaoSocial = razaoSocialInformado;
        EmpresaEntrada.Porte = porteInformado;
        EmpresaEntrada.CapitalSocial = capitalSocialInformado;
        _tabelas.Empresas.Value.Add(EmpresaAtualizar);

        _servicoEmpresa.Atualizar(EmpresaEntrada);
        var ValorRetornado = _tabelas.Empresas.Value.FirstOrDefault(empresa => empresa.Id == EmpresaEntrada.Id);

        Assert.Equal(razaoSocialInformado, ValorRetornado.RazaoSocial);
        Assert.Equal(porteInformado, ValorRetornado.Porte);
        Assert.Equal(capitalSocialInformado, ValorRetornado.CapitalSocial);
    }

    [Theory]
    [InlineData(-200)]
    [InlineData(405)]
    public void Deletar_deve_lancar_Exception_quando_informado_Id_invalido_ou_inexistente(int idInformado)
    {
        var excecao = Assert.Throws<Exception>(() => _servicoEmpresa.Deletar(idInformado));

        Assert.Equal($"Nenhuma Empresa com Id {idInformado} existe no contexto atual!\n", excecao.Message);
    }

    [Fact]
    public void Deletar_deve_lancar_ValidaitonException_quando_informado_Empresa_com_Convenio_Existente()
    {
        var EmpresaEntrada = CriaNovaEmpresaTeste();
        EmpresaEntrada.Id = 401;
        Convenio ConvenioEntrada = new()
        {
            Id = 406,
            NumeroProcesso = 123,
            Objeto = "objeto",
            Valor = 2.0M,
            DataInicio = new DateTime(1900, 2, 3),
            IdEscola = 10,
            IdEmpresa = EmpresaEntrada.Id
        };
        _tabelas.Empresas.Value.Add(EmpresaEntrada);
        _tabelas.Convenios.Value.Add(ConvenioEntrada);

        var excecao = Assert.Throws<ValidationException>(() => _servicoEmpresa.Deletar(EmpresaEntrada.Id));

        Assert.Equal("Nao e possivel excluir Empresa pois possui convenio ativo!", excecao.Message);
    }

    [Theory]
    [InlineData(-200)]
    [InlineData(405)]
    public void Deletar_deve_lancar_Exception_quando_informado_Empresa_com_IdEndreco_invalido_ou_inexistente(int idEnderecoInformado)
    {
        var EmpresaEntrada = CriaNovaEmpresaTeste();
        EmpresaEntrada.Id = idEnderecoInformado + 3;
        EmpresaEntrada.IdEndereco = idEnderecoInformado;
        _tabelas.Empresas.Value.Add(EmpresaEntrada);

        var excecao = Assert.Throws<Exception>(() => _servicoEmpresa.Deletar(EmpresaEntrada.Id));

        Assert.Equal($"Nenhum Endereco com Id {idEnderecoInformado} existe no contexto atual!\n", excecao.Message);
    }

    [Theory]
    [InlineData(402)]
    [InlineData(403)]
    public void Deletar_deve_remover_Empresa_do_repositorio_quando_informado_Id_de_Empresa_a_remover(int idInformado)
    {
        Endereco EntradaEndereco = new()
        {
            Id = 406,
            Numero = 5,
            Cep = "72311089",
            Municipio = "Hidrolandia",
            Bairro = "Pedregal",
            Rua = "Rua das Magnolias",
            Complemento = "Em frente ao bretas",
            Estado = EstadoEnums.Bahia
        };

        var EmpresaEntrada = CriaNovaEmpresaTeste();
        EmpresaEntrada.Id = idInformado;
        _tabelas.Empresas.Value.Add(EmpresaEntrada);
        _tabelas.Enderecos.Value.Add(EntradaEndereco);

        _servicoEmpresa.Deletar(EmpresaEntrada.Id);
        var ValorRetorno = _tabelas.Convenios.Value.FirstOrDefault(c => c.Id == idInformado);

        Assert.Null(ValorRetorno);
    }
}