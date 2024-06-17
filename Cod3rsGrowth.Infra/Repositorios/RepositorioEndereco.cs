using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;

namespace Cod3rsGrowth.Infra.Repositorios;

public class RepositorioEndereco : IRepositorioEndereco
{
    public void Atualizar(Endereco endrecoAtualizado)
    {
        throw new NotImplementedException();
    }

    public void Criar(Endereco enderecoCriado)
    {
        throw new NotImplementedException();
    }

    public void Deletar(int id)
    {
        throw new NotImplementedException();
    }

    public Endereco ObterPorId(int Id)
    {
        throw new NotImplementedException();
    }

    public List<Endereco> ObterTodos(string filtro)
    {
        using (var contexto = new ContextoAplicacao())
        {
            if (string.IsNullOrWhiteSpace(filtro))
                return contexto.TabelaEnderecos.ToList();

            var query = from e in contexto.TabelaEnderecos
                        where e.Cep == filtro
                        select e;

            return query.ToList();
        }
    }
}