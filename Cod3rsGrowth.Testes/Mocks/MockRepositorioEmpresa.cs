using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Infra.Repositorios;

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

    public void Criar(Empresa empresaCriada)
    {
        Tabelas._empresas.Value.Add(empresaCriada);
    }

    public void Deletar(Empresa empresaDeletada)
    {
        Tabelas._empresas.Value.Remove(empresaDeletada);
    }

    public Empresa ObterPorId(int Id)
    {
        return Tabelas._empresas.Value.FirstOrDefault(c => c.Id == Id) ?? throw new NullReferenceException();
    }

    public List<Empresa> ObterTodos()
    {
        return Tabelas._empresas.Value;
    }
}