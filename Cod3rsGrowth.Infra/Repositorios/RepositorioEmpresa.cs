using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;

namespace Cod3rsGrowth.Infra.Repositorios;

public class RepositorioEmpresa : IRepositorioEmpresa
{
    public void Atualizar(Empresa empresaAtualizada)
    {
        throw new NotImplementedException();
    }

    public void Criar(Empresa empresaCriada)
    {
        throw new NotImplementedException();
    }

    public void Deletar(int id)
    {
        throw new NotImplementedException();
    }

    public Empresa ObterPorId(int Id)
    {
        throw new NotImplementedException();
    }

    public List<Empresa> ObterTodos(string filtro)
    {
        using (var contexto = new ContextoAplicacao())
        {
            if (string.IsNullOrWhiteSpace(filtro))
                return contexto.TabelaEmpresas.ToList();

            var query = from e in contexto.TabelaEmpresas
                        where e.NomeFantasia == filtro || e.RazaoSocial == filtro
                        select e;

            return query.ToList();
        }
    }
}