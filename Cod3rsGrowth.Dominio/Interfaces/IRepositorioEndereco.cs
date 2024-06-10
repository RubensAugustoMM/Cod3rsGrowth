using Cod3rsGrowth.Dominio.Modelos;

namespace Cod3rsGrowth.Dominio.Interfaces;

public interface IRepositorioEndereco
{
    List<Endereco> ObterTodos();
    Endereco ObterPorId(int Id);
    bool Criar(Endereco enderecoCriado);
    void Atualizar(Endereco endrecoAtualizado);
    void Deletar(int Id);
}