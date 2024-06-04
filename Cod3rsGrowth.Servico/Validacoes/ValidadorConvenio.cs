using Cod3rsGrowth.Dominio.Modelos;
using FluentValidation;

namespace Cod3rsGrowth.Servico.Validacoes;

public class ValidadorConvenio: AbstractValidator<Convenio>
{
    public ValidadorConvenio()
    {
        RuleFor(convenio => convenio.NumeroProcesso).GreaterThan(0).WithMessage("Numero de processo invalido!\n");
    }
}
