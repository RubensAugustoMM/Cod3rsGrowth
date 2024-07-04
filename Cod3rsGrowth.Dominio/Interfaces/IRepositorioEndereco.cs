using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Dominio.Filtros;

namespace Cod3rsGrowth.Dominio.Interfaces;

public interface IRepositorioEndereco
{
    List<EnderecoOtd> ObterTodos(FiltroEnderecoOtd? filtroEndereco);
    EnderecoOtd ObterPorId(int Id);
    void Criar(Endereco enderecoCriado);
    void Atualizar(Endereco endrecoAtualizado);
    void Deletar(int id);
}