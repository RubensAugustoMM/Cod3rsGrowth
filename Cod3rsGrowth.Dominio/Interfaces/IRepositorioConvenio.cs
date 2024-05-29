using Cod3rsGrowth.Dominio.Modelos;

namespace Cod3rsGrowth.Dominio.Interfaces;

public interface IRepositorioConvenio
{
    List<Convenio> ObterTodos();
    Convenio ObterPorId(int Id);
    void Criar(Convenio convenioCriado);
    void Atualizar(Convenio convenioAtualizado);
    void Deletar(int Id);
}