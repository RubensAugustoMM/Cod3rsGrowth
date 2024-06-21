using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;
using FluentValidation;

namespace Cod3rsGrowth.Servico.Validacoes;

public class ValidadorEmpresa : AbstractValidator<Empresa>
{
    private readonly IRepositorioEndereco _repositorioEndereco;
    private readonly IRepositorioConvenio _repositorioConvenio;

    public ValidadorEmpresa(IRepositorioEndereco repositorioEndereco, IRepositorioConvenio repositorioConvenio)
    {
        _repositorioEndereco = repositorioEndereco;
        _repositorioConvenio = repositorioConvenio;

        RuleFor(empresa => empresa.Id)
            .GreaterThanOrEqualTo(0)
            .WithMessage("{PropertyName} deve ser um valor maior ou igual a zero!");

        RuleFor(empresa => empresa.Idade)
            .GreaterThanOrEqualTo(0)
            .WithMessage("{PropertyName} deve ser maior ou igual a 0!")
            .Must(ValidaIdadeDaEmpresa)
            .WithMessage("{PropertyName} diferente da diferenca da data abertura com a data atual!");
        
        RuleFor(empresa => empresa.RazaoSocial)
            .NotEmpty()
            .WithMessage("{PropertyName} nao pode ter valor nulo ou formado por caracteres de espaco!");
        
        RuleFor(empresa => empresa.NomeFantasia)
            .NotEmpty()
            .WithMessage("{PropertyName} nao pode ter valor nulo ou formado por caracteres de espaco!");
        
        RuleFor(empresa => empresa.Cnpj)
            .NotEmpty()
            .WithMessage("{PropertyName} nao pode ter valor nulo ou formado por caracteres de espaco!");
        
        RuleFor(empresa => empresa.Cnpj)
            .Must(VerificaSeCnpjContemSomenteNumeros)
            .When(empresa => empresa.Cnpj != null)
            .WithMessage("{PropertyName} deve ser formado somente por numeros!");
        
        RuleFor(empresa => empresa.Cnpj.Length)
            .Equal(14)
            .When(empresa => empresa.Cnpj != null)
            .WithMessage("{PropertyName} menor ou maior que 14 characteres!");
        
        RuleFor(empresa => empresa.DataSituacaoCadastral)
            .GreaterThan(empresa => empresa.DataAbertura)
            .WithMessage("{PropertyName} deve ser maior que a DataAbertura");
        
        RuleFor(empresa => empresa.DataAbertura)
            .LessThanOrEqualTo(DateTime.Now)
            .WithMessage("{PropertyName} nao pode ser maior ou igual a data atual");
        
        RuleFor(empresa => empresa.CapitalSocial)
            .GreaterThan(0)
            .WithMessage("{PropertyName} nao pode ser menor ou igual a zero!");
        
        RuleFor(empresa => empresa.NaturezaJuridica)
            .IsInEnum()
            .WithMessage("Valor de {PropertyName} fora do Enum!");
        
        RuleFor(empresa => empresa.Porte)
            .IsInEnum()
            .WithMessage("Valor de {PropertyName} fora do Enum!");
        
        RuleFor(empresa => empresa.MatrizFilial)
            .IsInEnum()
            .WithMessage("Valor de {PropertyName} fora do Enum!");
        
        RuleFor(empresa => empresa.IdEndereco)
            .GreaterThanOrEqualTo(0)
            .WithMessage("{PropertyName} deve ser um valor maior ou igual a zero!")
            .Must(VerificaSeExisteEndereco)
            .WithMessage("{PropertyName} deve ser referente a uma endereco existente!");

        RuleSet("Deletar", () =>
        {
            RuleFor(empresa => empresa.Id)
                .Must(VerificaSeExisteConvenio)
                .WithMessage("Nao e possivel excluir Empresa pois possui convenio ativo!");  
        });
    }

    private bool VerificaSeExisteEndereco(int idEndereco)
    {
        var ListaEnderecos = _repositorioEndereco.ObterTodos(null);
        if (ListaEnderecos.FirstOrDefault(endereco => endereco.Id == idEndereco) == null)
            return false;

        return true;
    }

    private bool VerificaSeExisteConvenio(int idEmpresa)
    {
        var ListaConvenios = _repositorioConvenio.ObterTodos(null);
        if (ListaConvenios.FirstOrDefault(convenio => convenio.IdEmpresa == idEmpresa) != null)
            return false;

        return true;
    }

    private bool VerificaSeCnpjContemSomenteNumeros(string cnpj)
    {
        foreach(var c in cnpj)
        {
            if (!(c >= '0' && c <= '9'))
                return false;
        }

        return true;
    }

    private bool ValidaIdadeDaEmpresa(Empresa empresa, int idade)
    {
        var dataAbertura = empresa.DataAbertura;
        return empresa.Idade <= DateTime.Now.Date.Year - dataAbertura.Date.Year;
    } 
}