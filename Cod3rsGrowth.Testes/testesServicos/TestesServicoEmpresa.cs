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

    public TestesServicoEmpresa()
    {
        _servicoEmpresa = _serviceProvider.GetService<ServicoEmpresa>() ?? throw new Exception("Objeto _serviceProvider retornou null apos nao encontrar ServicoEmpresa!");
    }

    private void ReiniciaRepositoriosDeTeste()
    {
        _tabelas.Enderecos.Value.Clear();
        _tabelas.Empresas.Value.Clear();
        _tabelas.Enderecos.Value.Add(CriaNovoEnderecoTeste());
    }

    private Empresa CriaNovaEmpresaTeste()
    {
        Empresa NovaEmpresa = new()
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

        return NovaEmpresa;
    }

    private Endereco CriaNovoEnderecoTeste()
    {
        Endereco NovoEndereco = new()
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

        return NovoEndereco;
    }

    [Fact]
    public void ao_ObterTodos_deve_retornar_lista_com_apenas_uma_Empresa()
    {
        ReiniciaRepositoriosDeTeste();
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
        _tabelas.Empresas.Value.AddRange(ValorEsperado);

        var ValorRetornado = _servicoEmpresa.ObterTodos();

        Assert.Equal(ValorEsperado.Count, ValorRetornado.Count);
    }

    [Fact]
    public void ao_ObterTodos_deve_retornar_lista_com_apenas_duas_Empresas()
    {
        ReiniciaRepositoriosDeTeste();
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
        _tabelas.Empresas.Value.AddRange(ValorEsperado);

        var ValorRetornado = _servicoEmpresa.ObterTodos();

        Assert.Equal(ValorEsperado.Count, ValorRetornado.Count);
    }

    [Theory]
    [InlineData(300)]
    [InlineData(-1)]
    public void ObterPorId_deve_lancar_Exception_quando_informado_Id_invalido_ou_inexistente(int idInformado)
    {
        ReiniciaRepositoriosDeTeste();
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
        _tabelas.Empresas.Value.AddRange(ListaDadosTeste);

        var excecaoObterPorId = Assert.Throws<Exception>(() => _servicoEmpresa.ObterPorId(idInformado));

        Assert.Equal($"Nenhuma Empresa com Id {idInformado} existe no contexto atual!\n", excecaoObterPorId.Message);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    public void ObterPorId_deve_retornar_Empresa_existente_quando_informado_id_valido(int idInformado)
    {
        ReiniciaRepositoriosDeTeste();
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
    [InlineData(-2)]
    [InlineData(-1)]
    public void Criar_deve_retornar_ValidationException_quando_informado_Empresa_com_Id_invalido(int idInformado)
    {
        ReiniciaRepositoriosDeTeste();
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
        ReiniciaRepositoriosDeTeste();
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
        ReiniciaRepositoriosDeTeste();
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
        ReiniciaRepositoriosDeTeste();
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
        ReiniciaRepositoriosDeTeste();
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
        ReiniciaRepositoriosDeTeste();
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
        ReiniciaRepositoriosDeTeste();
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
        ReiniciaRepositoriosDeTeste();
        var EmpresaEntrada = CriaNovaEmpresaTeste();
        var ValorEsperado = "Cnpj Length menor ou maior que 14 characteres!";
        EmpresaEntrada.Cnpj = cnpjInformado;

        var excecao = Assert.Throws<ValidationException>(() => _servicoEmpresa.Criar(EmpresaEntrada));

        Assert.Equal(ValorEsperado, excecao.Errors.First().ErrorMessage);
    }

    [Fact]
    public void Criar_deve_retornar_ValidationException_quando_informado_Empresa_com_DataSituacaoCadastral_invalida()
    {
        ReiniciaRepositoriosDeTeste();
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
        ReiniciaRepositoriosDeTeste();
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
        ReiniciaRepositoriosDeTeste();
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
        ReiniciaRepositoriosDeTeste();
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
        ReiniciaRepositoriosDeTeste();
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
        ReiniciaRepositoriosDeTeste();
        var EmpresaEntrada = CriaNovaEmpresaTeste();
        var ValorEsperado = "Id Endereco deve ser um valor maior ou igual a zero!";
        EmpresaEntrada.IdEndereco = idEnderecoInformado;

        var excecao = Assert.Throws<ValidationException>(() => _servicoEmpresa.Criar(EmpresaEntrada));

        Assert.Equal(ValorEsperado, excecao.Errors.First().ErrorMessage);
    }

    [Theory]
    [InlineData(10)]
    [InlineData(20)]
    public void Criar_deve_retornar_ValidationException_quando_informado_Empresa_com_IdEndereco_valido_e_referente_a_Endereco_inexistente(int idEnderecoInformado)
    {
        ReiniciaRepositoriosDeTeste();
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
        ReiniciaRepositoriosDeTeste();
        var EmpresaEntrada = CriaNovaEmpresaTeste();
        EmpresaEntrada.Id = idInformado;

        _servicoEmpresa.Criar(EmpresaEntrada);
        var ValorRetornado = _tabelas.Empresas.Value.FirstOrDefault(EmpresaEntrada);

        Assert.NotNull(ValorRetornado);
    }

    [Fact]
    public void Criar_deve_adicionar_Empresa_no_repositorio_quando_informado_Empresa_com_Idade_valido()
    {
        ReiniciaRepositoriosDeTeste();
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
        ReiniciaRepositoriosDeTeste();
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
        ReiniciaRepositoriosDeTeste();
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
        ReiniciaRepositoriosDeTeste();
        var EmpresaEntrada = CriaNovaEmpresaTeste();
        EmpresaEntrada.Cnpj = cnpjInformado;

        _servicoEmpresa.Criar(EmpresaEntrada);
        var ValorRetornado = _tabelas.Empresas.Value.FirstOrDefault(EmpresaEntrada);

        Assert.NotNull(ValorRetornado);
    }

    [Fact]
    public void Criar_deve_adicionar_Empresa_no_repositorio_quando_informado_Empresa_com_DataSituacaoCadastral_valida()
    {
        ReiniciaRepositoriosDeTeste();
        var EmpresaEntrada = CriaNovaEmpresaTeste();

        _servicoEmpresa.Criar(EmpresaEntrada);
        var ValorRetornado = _tabelas.Empresas.Value.FirstOrDefault(EmpresaEntrada);

        Assert.NotNull(ValorRetornado);
    }

    [Fact]
    public void Criar_deve_adicionar_Empresa_no_repositorio_quando_informado_Empresa_com_DataAbertura_valida()
    {
        ReiniciaRepositoriosDeTeste();
        var EmpresaEntrada = CriaNovaEmpresaTeste();

        _servicoEmpresa.Criar(EmpresaEntrada);
        var ValorRetornado = _tabelas.Empresas.Value.FirstOrDefault(EmpresaEntrada);

        Assert.NotNull(ValorRetornado);
    }

    [Fact]
    public void Criar_deve_adicionar_Empresa_no_repositorio_quando_informado_Empresa_com_CapitalSocial_valido()
    {
        ReiniciaRepositoriosDeTeste();
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
        ReiniciaRepositoriosDeTeste();
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
        ReiniciaRepositoriosDeTeste();
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
        ReiniciaRepositoriosDeTeste();
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
        ReiniciaRepositoriosDeTeste();
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
    [InlineData(20)]
    [InlineData(30)]
    public void Atualizar_deve_retornar_Exception_quando_informado_Empresa_com_Id_inexistente(int idInformado)
    {
        ReiniciaRepositoriosDeTeste();
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
        ReiniciaRepositoriosDeTeste();
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
        ReiniciaRepositoriosDeTeste();
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
}