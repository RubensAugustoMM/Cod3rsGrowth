﻿using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;
using FluentValidation;

namespace Cod3rsGrowth.Servico.Validacoes;

public class ValidadorEndereco : AbstractValidator<Endereco>
{
    private readonly IRepositorioEmpresa _repositorioEmpresa;
    private readonly IRepositorioEscola _repositorioEscola;

    public ValidadorEndereco(IRepositorioEmpresa repositorioEmpresa, IRepositorioEscola repositorioEscola)
    {
        _repositorioEmpresa = repositorioEmpresa;
        _repositorioEscola = repositorioEscola;
        
        RuleFor(endereco => endereco.Id)
            .GreaterThanOrEqualTo(0)
            .WithMessage("{PropertyName} deve ser um valor maior ou igual a zero!");
        
        RuleFor(endereco => endereco.Numero)
            .GreaterThanOrEqualTo(0)
            .WithMessage("{PropertyName} deve ser um valor maior ou igual a zero!");
        
        RuleFor(endereco => endereco.Cep)
            .NotEmpty()
            .WithMessage("{PropertyName} nao pode ter valor nulo ou formado por caracteres de espaco!");
        
        RuleFor(endereco => endereco.Cep)
            .Must(VerificaSeContemSomenteNumeros)
            .When(endereco => endereco.Cep != null)
            .WithMessage("{PropertyName} e formado somente por numeros!");
        
        RuleFor(endereco => endereco.Cep.Length)
            .Equal(8).When(endereco => endereco.Cep != null)
            .WithMessage("CEP menor ou maior que 8 characteres!");
        
        RuleFor(endereco => endereco.Municipio)
            .NotEmpty()
            .WithMessage("{PropertyName} nao pode ter valor nulo ou formado por caracteres de espaco!");
        
        RuleFor(endereco => endereco.Bairro)
            .NotEmpty()
            .WithMessage("{PropertyName} nao pode ter valor nulo ou formado por caracteres de espaco!");
        
        RuleFor(endereco => endereco.Rua)
            .NotEmpty()
            .WithMessage("{PropertyName} nao pode ter valor nulo ou formado por caracteres de espaco!");

        RuleFor(endereco => endereco.Estado)
            .IsInEnum()
            .WithMessage("Valor de {PropertyName} fora do Enum!");

        RuleSet("Deletar", () => 
        {
            RuleFor(endereco => endereco.Id)
                .Must(VerificaSeExisteEmpresa)
                .WithMessage("Nao e possivel excluir Endereco relacionado a Empresa existente!");  

            RuleFor(endereco => endereco.Id)
                .Must(VerificaSeExisteEscola)
                .WithMessage("Nao e possivel excluir Endereco relacionado a Escola existente!");  
        });
    }

    private bool VerificaSeExisteEmpresa(int idendereco)
    {
        var ListaEmpresa = _repositorioEmpresa.ObterTodos(null);
        if (ListaEmpresa.FirstOrDefault(empresa => empresa.IdEndereco == idendereco) != null)
            return false;

        return true;
    }

    private bool VerificaSeExisteEscola(int idendereco)
    {
        var ListaEscola = _repositorioEscola.ObterTodos(null);
        if (ListaEscola.FirstOrDefault(escola => escola.IdEndereco == idendereco) != null)
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