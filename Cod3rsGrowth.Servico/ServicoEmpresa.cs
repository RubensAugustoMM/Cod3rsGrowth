using Cod3rsGrowth.Dominio;
using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Dominio.ObjetosTranferenciaDados;
using Cod3rsGrowth.Servico.Validacoes;
using FluentValidation;

namespace Cod3rsGrowth.Servico;

public class ServicoEmpresa : IRepositorioEmpresa
{
    private readonly IRepositorioEmpresa _repositorioEmpresa;
    private readonly IRepositorioEndereco _repositorioEndereco;
    private readonly ValidadorEmpresa _validadorEmpresa;
    
    public ServicoEmpresa(IRepositorioEmpresa repositorioEmpresa, IRepositorioEndereco repositorioEndereco,ValidadorEmpresa validadorEmpresa)
    {
        _repositorioEmpresa = repositorioEmpresa;
        _repositorioEndereco = repositorioEndereco;
        _validadorEmpresa = validadorEmpresa;
    }

    public void Atualizar(Empresa empresaAtualizada)
    {
        ObterPorId(empresaAtualizada.Id);
        _validadorEmpresa.ValidateAndThrow(empresaAtualizada);
        _repositorioEmpresa.Atualizar(empresaAtualizada);
    }

    public void Criar(Empresa empresaCriada)
    {
        _validadorEmpresa.ValidateAndThrow(empresaCriada);
        _repositorioEmpresa.Criar(empresaCriada);
    }

    public void Deletar(int id)
    {
        var EmpresaEnderecoOtdDeletar = ObterPorId(id);
        Empresa EmpresaDeletar = new Empresa()
        {
            Id = EmpresaEnderecoOtdDeletar.Id,
            RazaoSocial = EmpresaEnderecoOtdDeletar.RazaoSocial,
            NomeFantasia = EmpresaEnderecoOtdDeletar.NomeFantasia,
            Cnpj = EmpresaEnderecoOtdDeletar.Cnpj,
            SituacaoCadastral = EmpresaEnderecoOtdDeletar.SituacaoCadastral,
            DataSituacaoCadastral = EmpresaEnderecoOtdDeletar.DataSituacaoCadastral,
            Idade = EmpresaEnderecoOtdDeletar.Idade,
            DataAbertura = EmpresaEnderecoOtdDeletar.DataAbertura,
            NaturezaJuridica = EmpresaEnderecoOtdDeletar.NaturezaJuridica,
            Porte = EmpresaEnderecoOtdDeletar.Porte,
            MatrizFilial = EmpresaEnderecoOtdDeletar.MatrizFilial,
            IdEndereco = EmpresaEnderecoOtdDeletar.IdEndereco
        };

        var ResultadoValidacao = _validadorEmpresa.Validate(EmpresaDeletar, options => options.IncludeRuleSets("Deletar"));

        if (!ResultadoValidacao.IsValid)
            throw new ValidationException(ResultadoValidacao.Errors.First().ErrorMessage);

        _repositorioEmpresa.Deletar(id);
    }

    public EmpresaEnderecoOtd ObterPorId(int Id)
    {
        return _repositorioEmpresa.ObterPorId(Id);
    }

    public List<EmpresaEnderecoOtd> ObterTodos(FiltroEmpresaEnderecoOtd? filtroEmpresaEnderecoOtd)
    {
        return _repositorioEmpresa.ObterTodos(filtroEmpresaEnderecoOtd);
    }
}