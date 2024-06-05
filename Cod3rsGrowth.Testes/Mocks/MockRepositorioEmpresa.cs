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
        empresaExistente.ListaConvenios = empresaAtualizada.ListaConvenios;
    }

    public bool Criar(Empresa empresaCriada)
    {
        Tabelas.Empresas.Value.Add(empresaCriada);

        return true;
    }

    public void Deletar(int Id)
    {
        var EmpresaDeletada = ObterPorId(Id);

        Tabelas.Empresas.Value.Remove(EmpresaDeletada);
    }

    public Empresa ObterPorId(int Id)
    {
        return Tabelas.Empresas.Value.FirstOrDefault(c => c.Id == Id) ?? throw new Exception($"Nenhuma Empresa com Id {Id} existe no contexto atual!\n");
    }

    public List<Empresa> ObterTodos()
    {
        return Tabelas.Empresas.Value;
    }
}