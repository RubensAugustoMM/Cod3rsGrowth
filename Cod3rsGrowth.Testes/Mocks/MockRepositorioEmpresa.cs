using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;

namespace Cod3rsGrowth.Testes.Mocks;

public class MockRepositorioEmpresa : IRepositorioEmpresa
{
    TabelaSingleton Tabelas = TabelaSingleton.Instance;

    public void Atualizar(Empresa empresaAtualizada)
    {
        var empresaExistente = ObterPorId(empresaAtualizada.Id);

        empresaExistente.Idade = empresaAtualizada.Idade;
        empresaExistente.RazaoSocial = empresaAtualizada.RazaoSocial;
        empresaExistente.NomeFantasia = empresaAtualizada.NomeFantasia;
        empresaExistente.Cnpj = empresaAtualizada.Cnpj;
        empresaExistente.SitucaoCadastral = empresaAtualizada.SitucaoCadastral;
        empresaExistente.DataSituacaoCadastral = empresaAtualizada.DataSituacaoCadastral;
        empresaExistente.DataAbertura = empresaAtualizada.DataAbertura;
        empresaExistente.CapitalSocial = empresaAtualizada.CapitalSocial;
        empresaExistente.NaturezaJuridica = empresaAtualizada.NaturezaJuridica;
        empresaExistente.Porte = empresaAtualizada.Porte;
        empresaExistente.MatrizFilial = empresaAtualizada.MatrizFilial;
    }

    public void Criar(Empresa empresaCriada)
    {
        Tabelas.Empresas.Value.Add(empresaCriada);
    }

    public void Deletar(int id)
    {
        Tabelas.Empresas.Value.Remove(ObterPorId(id));
    }

    public Empresa ObterPorId(int Id)
    {
        return Tabelas.Empresas.Value.FirstOrDefault(c => c.Id == Id) ?? throw new Exception($"Nenhuma Empresa com Id {Id} existe no contexto atual!\n");
    }

    public List<Empresa> ObterTodos(FiltroEmpresa filtroEmpresa)
    {
        return Tabelas.Empresas.Value;
    }
}