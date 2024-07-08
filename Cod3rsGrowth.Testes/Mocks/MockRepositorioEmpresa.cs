using Cod3rsGrowth.Dominio;
using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Dominio.ObjetosTranferenciaDados;

namespace Cod3rsGrowth.Testes.Mocks;

public class MockRepositorioEmpresa : IRepositorioEmpresa
{
    TabelaSingleton Tabelas = TabelaSingleton.Instance;

    public void Atualizar(Empresa empresaAtualizada)
    {
        var EmpresaExistente = ObterPorIdModelo(empresaAtualizada.Id);

        EmpresaExistente.Idade = empresaAtualizada.Idade;
        EmpresaExistente.RazaoSocial = empresaAtualizada.RazaoSocial;
        EmpresaExistente.NomeFantasia = empresaAtualizada.NomeFantasia;
        EmpresaExistente.Cnpj = empresaAtualizada.Cnpj;
        EmpresaExistente.SitucaoCadastral = empresaAtualizada.SitucaoCadastral;
        EmpresaExistente.DataSituacaoCadastral = empresaAtualizada.DataSituacaoCadastral;
        EmpresaExistente.DataAbertura = empresaAtualizada.DataAbertura;
        EmpresaExistente.CapitalSocial = empresaAtualizada.CapitalSocial;
        EmpresaExistente.NaturezaJuridica = empresaAtualizada.NaturezaJuridica;
        EmpresaExistente.Porte = empresaAtualizada.Porte;
        EmpresaExistente.MatrizFilial = empresaAtualizada.MatrizFilial;
        EmpresaExistente.IdEndereco = empresaAtualizada.IdEndereco;
    }

    public void Criar(Empresa empresaCriada)
    {
        Tabelas.Empresas.Value.Add(empresaCriada);
    }

    public void Deletar(int id)
    {
        Tabelas.Empresas.Value.Remove(ObterPorIdModelo(id));
    }

    public EmpresaEnderecoOtd ObterPorId(int id)
    {
        var EmpresaRetornada = ObterPorIdModelo(id);
        var EnderecoRetornada = Tabelas.Enderecos.Value.FirstOrDefault(e => e.Id == EmpresaRetornada.IdEndereco) ?? throw new Exception($"Nenhum Endereco com Id {EmpresaRetornada.IdEndereco} existe no contexto atual!\n");

        var EmpresaOtdRetornada = new EmpresaEnderecoOtd()
        {
            Idade = EmpresaRetornada.Idade,
            RazaoSocial = EmpresaRetornada.RazaoSocial,
            NomeFantasia = EmpresaRetornada.NomeFantasia,
            Cnpj = EmpresaRetornada.Cnpj,
            SitucaoCadastral = EmpresaRetornada.SitucaoCadastral,
            DataSituacaoCadastral = EmpresaRetornada.DataSituacaoCadastral,
            DataAbertura = EmpresaRetornada.DataAbertura,
            CapitalSocial = EmpresaRetornada.CapitalSocial,
            NaturezaJuridica = EnumExtencoes.RetornaDescricao(EmpresaRetornada.NaturezaJuridica),
            Porte = EnumExtencoes.RetornaDescricao(EmpresaRetornada.Porte),
            MatrizFilial = EnumExtencoes.RetornaDescricao(EmpresaRetornada.MatrizFilial),
            IdEndereco = EmpresaRetornada.IdEndereco,
            Estado = EnumExtencoes.RetornaDescricao(EnderecoRetornada.Estado) 
        };

        return EmpresaOtdRetornada;
    }

    public List<EmpresaEnderecoOtd> ObterTodos(FiltroEmpresaEnderecoOtd filtroEmpresa)
    {
        var ListaEmpresas = Tabelas.Empresas.Value;
        List<EmpresaEnderecoOtd> ListaEmpresaEnderecoOtd = new();

        foreach (var empresa in ListaEmpresas)
        {
            var EnderecoRetornado = Tabelas.Enderecos.Value.FirstOrDefault(e => e.Id == empresa.IdEndereco) ?? throw new Exception($"Nenhum Endereco com Id {empresa.IdEndereco} existe no contexto atual!\n");

            ListaEmpresaEnderecoOtd.Add(new EmpresaEnderecoOtd()
            {
                Id = empresa.Id,
                RazaoSocial = empresa.RazaoSocial,
                NomeFantasia = empresa.NomeFantasia,
                Cnpj = empresa.Cnpj,
                SitucaoCadastral = empresa.SitucaoCadastral,
                DataSituacaoCadastral = empresa.DataSituacaoCadastral,
                NaturezaJuridica = EnumExtencoes.RetornaDescricao(empresa.NaturezaJuridica),
                Porte = EnumExtencoes.RetornaDescricao(empresa.Porte),
                MatrizFilial = EnumExtencoes.RetornaDescricao(empresa.MatrizFilial),
                CapitalSocial = empresa.CapitalSocial,
                IdEndereco = empresa.IdEndereco,
                Estado = EnumExtencoes.RetornaDescricao(EnderecoRetornado.Estado)
            });
        }

        return ListaEmpresaEnderecoOtd;
    }

    private Empresa ObterPorIdModelo(int id)
    {
        return Tabelas.Empresas.Value.FirstOrDefault(c => c.Id == id) ?? throw new Exception($"Nenhuma Empresa com Id {id} existe no contexto atual!\n");
    }
}