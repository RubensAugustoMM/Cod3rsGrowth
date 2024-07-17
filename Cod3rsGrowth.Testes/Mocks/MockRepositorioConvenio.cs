using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Dominio.ObjetosTranferenciaDados;

namespace Cod3rsGrowth.Testes.Mocks;

public class MockRepositorioConvenio : IRepositorioConvenio 
{
    TabelaSingleton Tabelas = TabelaSingleton.Instance;

    public void Atualizar(Convenio convenioAtulizado)
    {
        var convenioExistente = ObterPorIdModelo(convenioAtulizado.Id);

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
        Tabelas.Convenios.Value.Add(convenioCriado);
    }

    public void Deletar(int id)
    {
                Tabelas.Convenios.Value.Remove(ObterPorIdModelo(id));
    }

    public ConvenioEscolaEmpresaOtd ObterPorId(int id)
    {
        var ConvenioRetornado = ObterPorIdModelo(id);
        var escolaRetornada = Tabelas.Escolas.Value.FirstOrDefault(e => e.Id == ConvenioRetornado.IdEscola) ?? throw new Exception($"Nenhuma Escola com Id {ConvenioRetornado.IdEscola} existe no contexto atual!\n");
        var EmpresaRetornada = Tabelas.Empresas.Value.FirstOrDefault(e => e.Id == ConvenioRetornado.IdEmpresa) ?? throw new Exception($"Nenhuma Empresa com Id {ConvenioRetornado.IdEmpresa} existe no contexto atual!\n");

        var ConvenioOtdRetornado = new ConvenioEscolaEmpresaOtd()
        {
            Id = ConvenioRetornado.Id,
            NumeroProcesso = ConvenioRetornado.NumeroProcesso,
            Objeto = ConvenioRetornado.Objeto,
            Valor = ConvenioRetornado.Valor,
            DataInicio = ConvenioRetornado.DataInicio,
            DataTermino = ConvenioRetornado.DataTermino,
            IdEscola = ConvenioRetornado.IdEscola,
            NomeEscola = escolaRetornada.Nome,
            IdEmpresa = ConvenioRetornado.IdEmpresa,
            RazaoSocialEmpresa = EmpresaRetornada.RazaoSocial 
        };

        return ConvenioOtdRetornado; 
    }

    public List<ConvenioEscolaEmpresaOtd> ObterTodos(FiltroConvenioEscolaEmpresaOtd? filtroConvenio)
    {
        var ListaConvenios = Tabelas.Convenios.Value;
        List<ConvenioEscolaEmpresaOtd> ListaConvenioEscolaEmpresaOtd = new();

        foreach (var convenio in ListaConvenios)
        {
            var escolaRetornada = Tabelas.Escolas.Value.FirstOrDefault(e => e.Id == convenio.IdEscola) ?? throw new Exception($"Nenhuma Escola com Id {convenio.IdEscola} existe no contexto atual!\n");
            var EmpresaRetornada = Tabelas.Empresas.Value.FirstOrDefault(e => e.Id == convenio.IdEmpresa) ?? throw new Exception($"Nenhuma Empresa com Id {convenio.IdEmpresa} existe no contexto atual!\n");

            ListaConvenioEscolaEmpresaOtd.Add(new ConvenioEscolaEmpresaOtd()
            {
                Id = convenio.Id,
                NumeroProcesso = convenio.NumeroProcesso,
                Objeto = convenio.Objeto,
                Valor = convenio.Valor,
                DataInicio = convenio.DataInicio,
                DataTermino = convenio.DataTermino,
                IdEscola = convenio.IdEscola,
                NomeEscola = escolaRetornada.Nome,
                IdEmpresa = convenio.IdEmpresa,
                RazaoSocialEmpresa = EmpresaRetornada.RazaoSocial
            });
        }

        return ListaConvenioEscolaEmpresaOtd;
    }

    private Convenio ObterPorIdModelo(int id)
    {
        return Tabelas.Convenios.Value.FirstOrDefault(c => c.Id == id) ?? throw new Exception($"Nenhum Convenio com Id {id} existe no contexto atual!\n");
    }
}