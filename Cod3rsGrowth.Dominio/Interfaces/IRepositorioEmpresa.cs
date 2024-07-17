using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Dominio.ObjetosTranferenciaDados;

namespace Cod3rsGrowth.Dominio.Interfaces;

public interface IRepositorioEmpresa
{
    List<EmpresaEnderecoOtd> ObterTodos(FiltroEmpresaEnderecoOtd? FiltroEmpresa);
    EmpresaEnderecoOtd ObterPorId(int Id);
    void Criar(Empresa empresaCriada);
    void Atualizar(Empresa empresaAtualizada);
    void Deletar(int id);
}