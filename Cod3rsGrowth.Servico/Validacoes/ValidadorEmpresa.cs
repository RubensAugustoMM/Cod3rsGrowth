using System.Data.Common;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;
using FluentValidation;

namespace Cod3rsGrowth.Servico.Validacoes;

public class ValidadorEmpresa : AbstractValidator<Empresa>
{
    private readonly IRepositorioEndereco _repositorioEndereco;
    private List<Endereco> _listaEnderecos;
    public ValidadorEmpresa(IRepositorioEndereco repositorioEndereco)
    {
        _repositorioEndereco = repositorioEndereco;
        _listaEnderecos = _repositorioEndereco.ObterTodos();

        RuleFor(empresa => empresa.Id).GreaterThanOrEqualTo(0).WithMessage("{PropertyName} deve ser um valor maior ou igual a zero!");
        RuleFor(empresa => empresa.Idade)
                    .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} deve ser maior ou igual a 0!")
                    .Must((empresa, idade) =>
                    {
                        var dataAbertura = empresa.DataAbertura;
                        return empresa.Idade <= DateTime.Now.Date.Year - dataAbertura.Date.Year;
                    })
                    .WithMessage("Idade diferente da diferenca da data abertura com a data atual!");
        RuleFor(empresa => empresa.RazaoSocial).NotEmpty().WithMessage("{PropertyName} nao pode ter valor nulo ou formado por caracteres de espaco!");
        RuleFor(empresa => empresa.NomeFantasia).NotEmpty().WithMessage("{PropertyName} nao pode ter valor nulo ou formado por caracteres de espaco!");
        RuleFor(empresa => empresa.Cnpj).NotEmpty().WithMessage("{PropertyName} nao pode ter valor nulo ou formado por caracteres de espaco!");
        RuleFor(empresa => empresa.Cnpj.Length).Equal(14).When(empresa => empresa.Cnpj != null).WithMessage("{PropertyName} tamanho menor que 14 characteres!");
        RuleFor(empresa => empresa.DataSituacaoCadastral).GreaterThan(empresa => empresa.DataAbertura).WithMessage("{PropertyName} deve ser maior que a DataAberturajjj");
        RuleFor(empresa => empresa.DataAbertura).LessThanOrEqualTo(DateTime.Now).WithMessage("{PropertyName} nao pode ser maior ou igual a data atual");
        RuleFor(empresa => empresa.CapitalSocial).GreaterThan(0).WithMessage("{PropertyName} nao pode ser menor ou igual a zero!");
        RuleFor(empresa => empresa.NaturezaJuridica).IsInEnum().WithMessage("Valor de {PropertyName} fora do Enum!");
        RuleFor(empresa => empresa.Porte).IsInEnum().WithMessage("Valor de {PropertyName} fora do Enum!");
        RuleFor(empresa => empresa.MatrizFilial).IsInEnum().WithMessage("Valor de {PropertyName} fora do Enum!");
        RuleFor(empresa => empresa.IdEndereco).GreaterThanOrEqualTo(0).WithMessage("{PropertyName} deve ser um valor maior ou igual a zero!")
                    .Must(VerificaSeExisteEndereco).WithMessage("{PropertyName} deve ser referente a uma escola existente!");


    }

    private bool VerificaSeExisteEndereco(int idEndereco)
    {
        return _listaEnderecos.Exists(endereco => endereco.Id == idEndereco);
    }
}
