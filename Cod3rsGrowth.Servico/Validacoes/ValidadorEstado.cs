using Cod3rsGrowth.Dominio.Modelos;
using FluentValidation;

namespace Cod3rsGrowth.Servico.Validacoes;

public class ValidadorEstado : AbstractValidator<Estado>
{
    public ValidadorEstado()
    {
        RuleFor(endereco => endereco.Id).GreaterThanOrEqualTo(0).WithMessage("{PropertyName} deve ser um valor maior ou igual a zero!");
        RuleFor(endereco => endereco.Nome).NotEmpty().WithMessage("{PropertyName} nao pode ter valor nulo ou formado por caracteres de espaco!");
        RuleFor(endereco => endereco.Sigla).NotEmpty().WithMessage("{PropertyName} nao pode ter valor nulo ou formado por caracteres de espaco!");
        RuleFor(endereco => endereco.Sigla.Length).Equal(2).When(endereco => endereco.Sigla != null).WithMessage("{PropertyName} tamanho menor ou maior que 14 characteres!");
        RuleFor(endereco => endereco.ListaEnderecos).NotNull().WithMessage("{PropertyName} nao pode ser nulo!");
    }
}
