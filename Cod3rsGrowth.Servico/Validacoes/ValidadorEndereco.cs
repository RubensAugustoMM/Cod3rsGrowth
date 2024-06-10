using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;
using FluentValidation;

namespace Cod3rsGrowth.Servico.Validacoes;

public class ValidadorEndereco : AbstractValidator<Endereco>
{
    private readonly IRepositorioEstado _repositorioEstado;

    public ValidadorEndereco(IRepositorioEstado repositorioEstado)
    {
        _repositorioEstado = repositorioEstado;
        
        RuleFor(endereco => endereco.Id).GreaterThanOrEqualTo(0).WithMessage("{PropertyName} deve ser um valor maior ou igual a zero!");
        RuleFor(endereco => endereco.Numero).GreaterThanOrEqualTo(0).WithMessage("{PropertyName} deve ser um valor maior ou igual a zero!");
        RuleFor(endereco => endereco.Cep).NotEmpty().WithMessage("{PropertyName} nao pode ter valor nulo ou formado por caracteres de espaco!");
        RuleFor(endereco => endereco.Cep).Must(VerificaSeCepContemSomenteNumeros).When(endereco => endereco.Cep != null).WithMessage("{propertyName} e formado somente por numeros!");
        RuleFor(endereco => endereco.Cep.Length).Equal(8).When(endereco => endereco.Cep != null).WithMessage("{PropertyName} tamanho menor ou maior que 8 characteres!");
        RuleFor(endereco => endereco.Municipio).NotEmpty().WithMessage("{PropertyName} nao pode ter valor nulo ou formado por caracteres de espaco!");
        RuleFor(endereco => endereco.Bairro).NotEmpty().WithMessage("{PropertyName} nao pode ter valor nulo ou formado por caracteres de espaco!");
        RuleFor(endereco => endereco.Rua).NotEmpty().WithMessage("{PropertyName} nao pode ter valor nulo ou formado por caracteres de espaco!");
        RuleFor(endereco => endereco.IdEstado).GreaterThanOrEqualTo(0).WithMessage("{PropertyName} deve ser um valor maior ou igual a zero!")
            .Must(VerificaSeExisteEstado).WithMessage("{PropertyName} deve ser referente a um estado existente!");
    }

    private bool VerificaSeCepContemSomenteNumeros(string cep)
    {
        foreach(var c in cep)
        {
            if (!(c >= '0' && c <= '9'))
                return false;
        }

        return true;
    }

    private bool VerificaSeExisteEstado(int idEstado)
    {
        var ListaEstados = _repositorioEstado.ObterTodos();
        return ListaEstados.Exists(estado => estado.Id == idEstado); 
    }
}
