using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Dominio.ObjetosTranferenciaDados;

namespace Cod3rsGrowth.Dominio.Interfaces;

public interface IRepositorioEscola
{
    List<EscolaEnderecoOtd> ObterTodos(FiltroEscolaEnderecoOtd? filtroEscola);
    EscolaEnderecoOtd ObterPorId(int Id);
    void Criar(Escola escolaCriada);
    void Atualizar(Escola escolaAtualizada);
    void Deletar(int id);
}