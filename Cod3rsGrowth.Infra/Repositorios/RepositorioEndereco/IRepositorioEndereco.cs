using Cod3rsGrowth.Dominio.Modelos;

namespace Cod3rsGrowth.Infra.Repositorios;

public interface IRepositorioEndereco
{
    List<Endereco> ObterTodos();
    Endereco ObterPorId(int Id);
    void Criar(Endereco entidade);
    void Atualizar(Endereco entidade);
    void Deletar(Endereco entidade);
}