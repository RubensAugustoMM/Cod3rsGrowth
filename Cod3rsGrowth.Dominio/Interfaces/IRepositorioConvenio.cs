using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Dominio.ObjetosTranferenciaDados;

namespace Cod3rsGrowth.Dominio.Interfaces;

public interface IRepositorioConvenio
{
    List<ConvenioEscolaEmpresaOtd> ObterTodos(FiltroConvenioEscolaEmpresaOtd? filtroConvenio);
    ConvenioEscolaEmpresaOtd ObterPorId(int Id);
    void Criar(Convenio convenioCriado);
    void Atualizar(Convenio convenioAtualizado);
    void Deletar(int id);
}