using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;
using FluentValidation;

namespace Cod3rsGrowth.Servico.Validacoes;

public class ValidadorEstado : AbstractValidator<Estado>
{
    private readonly IRepositorioEndereco _repositorioEndereco;
    public ValidadorEstado(IRepositorioEndereco repositorioEndereco)
    {
        _repositorioEndereco = repositorioEndereco;

        RuleFor(endereco => endereco.Id)
            .GreaterThanOrEqualTo(0)
            .WithMessage("{PropertyName} deve ser um valor maior ou igual a zero!");

        RuleFor(endereco => endereco.Nome)
            .NotEmpty()
            .WithMessage("{PropertyName} nao pode ter valor nulo ou formado por caracteres de espaco!");

        RuleFor(endereco => endereco.Sigla)
            .NotEmpty()
            .WithMessage("{PropertyName} nao pode ter valor nulo ou formado por caracteres de espaco!");

        RuleFor(endereco => endereco.Sigla.Length)
            .Equal(2).When(endereco => endereco.Sigla != null)
            .WithMessage("{PropertyName} menor ou maior que 2 characteres!");

        RuleFor(endereco => endereco.ListaEnderecos)
            .NotNull()
            .WithMessage("{PropertyName} nao pode ser nulo!");

        RuleSet("Deletar", () =>
        {
            RuleFor(escola => escola.Id)
                .Must(VerificaSeExisteEndereco)
                .WithMessage("Nao e possivel excluir Estado relacionado a Endereco existente!");  
        });
    }

    private bool VerificaSeExisteEndereco(int idEstado)
    {
        var ListaEndereco = _repositorioEndereco.ObterTodos();
        if (ListaEndereco.FirstOrDefault(endereco => endereco.IdEstado == idEstado) != null)
            return false;

        return true;
    }
}
