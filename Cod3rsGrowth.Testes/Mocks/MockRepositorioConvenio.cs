using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Infra.Repositorios;

namespace Cod3rsGrowth.Testes.Mocks;

public class MockRepositorioConvenio : IRepositorioConvenio
{
    TabelaSingleton Tabelas = TabelaSingleton.Instance;

    public void Atualizar(Convenio convenioAtulizado)
    {
        var convenioExistente = ObterPorId(convenioAtulizado.Id);

        convenioExistente.NumeroProcesso = convenioAtulizado.NumeroProcesso;
        convenioExistente.Objeto = convenioAtulizado.Objeto;
        convenioExistente.Valor = convenioAtulizado.Valor;
        convenioExistente.DataInicio = convenioAtulizado.DataInicio;
        convenioExistente.DataTermino = convenioAtulizado.DataTermino;
        convenioExistente.IdEscola = convenioAtulizado.IdEscola;
        convenioExistente.IdEmpresa = convenioAtulizado.IdEmpresa;
    }

    public void Criar(Convenio convenioCriado)
    {
        Tabelas._convenios.Value.Add(convenioCriado);
    }

    public void Deletar(Convenio convenioDeletado)
    {
        Tabelas._convenios.Value.Remove(convenioDeletado);
    }

    public Convenio ObterPorId(int Id)
    {
        return Tabelas._convenios.Value.FirstOrDefault(c => c.Id == Id) ?? throw new NullReferenceException();
    }

    public List<Convenio> ObterTodos()
    {
        return Tabelas._convenios.Value;
    }
}