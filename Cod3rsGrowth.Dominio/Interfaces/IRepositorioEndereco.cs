using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Dominio.Filtros;

namespace Cod3rsGrowth.Dominio.Interfaces;

public interface IRepositorioEndereco
{
    List<Endereco> ObterTodos(FiltroEndereco? filtroEndereco);
    Endereco ObterPorId(int Id);
    void Criar(ref Endereco enderecoCriado);
    void Atualizar(Endereco endrecoAtualizado);
    void Deletar(int id);
}