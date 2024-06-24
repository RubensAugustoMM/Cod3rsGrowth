using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;
using FluentValidation;

namespace Cod3rsGrowth.Servico.Validacoes;

public class ValidadorEscola : AbstractValidator<Escola>
{
    private readonly IRepositorioEndereco _repositorioEndereco;
    private readonly IRepositorioConvenio _repositorioConvenio;

    public ValidadorEscola(IRepositorioEndereco repositorioEndereco, IRepositorioConvenio repositorioConvenio)
    {
        _repositorioEndereco = repositorioEndereco;
        _repositorioConvenio = repositorioConvenio;

        RuleFor(escola => escola.Id)
            .GreaterThanOrEqualTo(0)
            .WithMessage("{PropertyName} deve ser um valor maior ou igual a zero!");

        RuleFor(escola => escola.Nome)
            .NotEmpty()
            .WithMessage("{PropertyName} nao pode ter valor nulo ou formado por caracteres de espaco!");

        RuleFor(escola => escola.CodigoMec)
            .NotEmpty()
            .WithMessage("{PropertyName} nao pode ter valor nulo ou formado por caracteres de espaco!");

        RuleFor(escola => escola.CodigoMec)
            .Must(VerificaSeContemSomenteNumeros)
            .When(empresa => empresa.CodigoMec != null)
            .WithMessage("{PropertyName} e formado somente por numeros!");
            
        RuleFor(escola => escola.CodigoMec.Length)
            .Equal(8)
            .When(escola => escola.CodigoMec != null)
            .WithMessage("{PropertyName} menor ou maior que 8 characteres!");

        RuleFor(escola => escola.Telefone)
            .NotEmpty()
            .WithMessage("{PropertyName} nao pode ter valor nulo ou formado por caracteres de espaco!");

        RuleFor(escola => escola.Telefone)
            .Must(VerificaSeContemSomenteNumeros)
            .When(empresa => empresa.Telefone != null)
            .WithMessage("{PropertyName} e formado somente por numeros!");
            
        RuleFor(escola => escola.Email)
            .NotEmpty()
            .WithMessage("{PropertyName} nao pode ter valor nulo ou formado por caracteres de espaco!")
            .EmailAddress()
            .WithMessage("A string inserida nao e um {PropertyName} valido!");

        RuleFor(escola => escola.InicioAtividade)
            .LessThanOrEqualTo(DateTime.Now)
            .WithMessage("{PropertyName} nao pode ser maior ou igual a data atual");

        RuleFor(escola => escola.CategoriaAdministrativa)
            .IsInEnum()
            .WithMessage("Valor de {PropertyName} fora do Enum!");

        RuleFor(escola => escola.OrganizacaoAcademica)
            .IsInEnum()
            .WithMessage("Valor de {PropertyName} fora do Enum!");

        RuleFor(escola => escola.IdEndereco)
            .GreaterThanOrEqualTo(0)
            .WithMessage("{PropertyName} deve ser um valor maior ou igual a zero!")
            .Must(VerificaSeExisteEndereco)
            .WithMessage("{PropertyName} deve ser referente a uma endereco existente!");

        RuleSet("Deletar", () =>
        {
            RuleFor(escola => escola.Id)
                .Must(VerificaSeExisteConvenio)
                .WithMessage("Nao e possivel excluir Escola pois possui convenio ativo!");  
        });
    }

    private bool VerificaSeExisteEndereco(int idEndereco)
    {
        var ListaEnderecos = _repositorioEndereco.ObterTodos(null);
        if (ListaEnderecos.FirstOrDefault(endereco => endereco.Id == idEndereco) == null)
            return false;

        return true;
    }

    private bool VerificaSeExisteConvenio(int idEscola)
    {
        var ListaConvenios = _repositorioConvenio.ObterTodos(null);
        if (ListaConvenios.FirstOrDefault(convenio => convenio.IdEscola == idEscola) != null)
            return false;

        return true;
    }

    private bool VerificaSeContemSomenteNumeros(string stringEntrada)
    {
        foreach(var c in stringEntrada)
        {
            if (!(c >= '0' && c <= '9'))
                return false;
        }

        return true;
    }
}