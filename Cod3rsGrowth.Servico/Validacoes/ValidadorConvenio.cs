﻿using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;
using FluentValidation;

namespace Cod3rsGrowth.Servico.Validacoes;

public class ValidadorConvenio: AbstractValidator<Convenio>
{
    private readonly IRepositorioEscola _repositorioEscola;
    private readonly IRepositorioEmpresa _repositorioEmpresa;
    private List<Escola> _listaEscolas;
    private List<Empresa> _listaEmpresas;

    public ValidadorConvenio(IRepositorioEscola repositorioEscola, IRepositorioEmpresa repositorioEmpresa)
    {
        _repositorioEscola = repositorioEscola;
        _repositorioEmpresa = repositorioEmpresa;

        _listaEscolas = repositorioEscola.ObterTodos();
        _listaEmpresas = repositorioEmpresa.ObterTodos();

        RuleFor(convenio => convenio.Id).GreaterThanOrEqualTo(0).WithMessage("{PropertyName} deve ser um valor maior ou igual a zero!");
        RuleFor(convenio => convenio.NumeroProcesso).GreaterThan(0).WithMessage("{PropertyName} deve ser maior que zero!");
        RuleFor(convenio => convenio.Objeto).NotEmpty().WithMessage("{PropertyName} nao pode ter valor nulo ou formado por caracteres de espaco!");
        RuleFor(convenio => convenio.Valor).GreaterThan(0).WithMessage("{PropertyName} do convenio deve ser maior que zero!");
        RuleFor(convenio => convenio.DataInicio)
                    .GreaterThan(new DateTime(1889,9,15)).WithMessage("{PropertyName} deve ser após a proclamacao da republica!")
                    .LessThanOrEqualTo(DateTime.Now).WithMessage("{PropertyName} deve ser anterior ou igual a data atual!");
        RuleFor(convenio => convenio.DataTermino).GreaterThan(convenio => convenio.DataInicio).WithMessage("{PropertyName} deve ser maior que a DataInicio!");
        RuleFor(convenio => convenio.IdEscola)
                    .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} deve ser maior ou igual a zero!")
                    .Must(VerificarSeExisteEscola).WithMessage("{PropertyName} deve ser referente a uma escola existente!");
        RuleFor(convenio => convenio.IdEmpresa)
                    .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} deve ser maior ou igual a zero!")
                    .Must(VerificaSeExisteEmpresa).WithMessage("{PropertyName} deve ser referente a uma escola existente!");
    }

    private bool VerificarSeExisteEscola(int idEscola)
    {
        return _listaEscolas.Exists(escola => escola.Id == idEscola);
    }

    private bool VerificaSeExisteEmpresa(int idEmpresa)
    {
        return _listaEmpresas.Exists(empresa => empresa.Id == idEmpresa);
    }
}