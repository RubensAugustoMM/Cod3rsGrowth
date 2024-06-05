using Cod3rsGrowth.Dominio.Interfaces;
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

        RuleFor(convenio => convenio.Id).GreaterThanOrEqualTo(0);

        RuleFor(convenio => convenio.NumeroProcesso).GreaterThan(0)
                    .WithMessage("Numero de processo invalido!\n");

        RuleFor(convenio => convenio.Objeto).NotEmpty()
                    .WithMessage("Objeto nulo ou vazio!\n");

        RuleFor(convenio => convenio.Valor).GreaterThan(0)
                    .WithMessage("Valor do convenio deve ser maior que zero!\n");

        RuleFor(convenio => convenio.DataInicio).NotNull()
                    .GreaterThan(new DateTime(1889,9,15))
                    .LessThanOrEqualTo(DateTime.Now)
                    .WithMessage("Data início anterior a proclamacao da republica ou apos a data atual!");

        RuleFor(convenio => convenio.DataTermino).GreaterThan(convenio => convenio.DataInicio)
                    .WithMessage("DataTermino deve ser maior que a DataInicio!");

        RuleFor(convenio => convenio.IdEscola).GreaterThanOrEqualTo(0)
                    .Must(VerificarSeExisteEscola)
                    .WithMessage("IdEscola invalido no contexto!");

        RuleFor(convenio => convenio.IdEmpresa).GreaterThanOrEqualTo(0)
                    .Must(verificaSeExisteEmpresa)
                    .WithMessage("IdEmpresa invalido no contexto!");


        

    }

    private bool VerificarSeExisteEscola(int idEscola)
    {
        return _listaEscolas.Exists(escola => escola.Id == idEscola);
    }

    private bool verificaSeExisteEmpresa(int idEmpresa)
    {
        return _listaEmpresas.Exists(empresa => empresa.Id == idEmpresa);
    }
}