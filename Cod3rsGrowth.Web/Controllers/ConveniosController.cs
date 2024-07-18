using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Dominio.ObjetosTranferenciaDados;
using Cod3rsGrowth.Servico;
using Microsoft.AspNetCore.Mvc;

namespace Cod3rsGrowth.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ConveniosController : ControllerBase
{
    private readonly ServicoConvenio _servicoConvenio;

    public ConveniosController(ServicoConvenio servicoConvenio)
    {
        _servicoConvenio = servicoConvenio;
    }

    [HttpGet]
    public List<ConvenioEscolaEmpresaOtd> ObterTodos([FromBody] FiltroConvenioEscolaEmpresaOtd filtroConvenio)
    {
        return _servicoConvenio.ObterTodos(filtroConvenio);
    }

    [HttpGet("{id}")]
    public ConvenioEscolaEmpresaOtd ObterPorId(int id)
    {
        return _servicoConvenio.ObterPorId(id);
    }

    [HttpPost]
    public void Criar([FromBody] Convenio convenioCriar)
    {
        _servicoConvenio.Criar(convenioCriar);
    }

    [HttpPut]
    public void Atualizar([FromBody] Convenio convenioAtualizar)
    {
        _servicoConvenio.Atualizar(convenioAtualizar);
    }

    [HttpDelete("{id}")]
    public void Deletar(int id)
    {
        _servicoConvenio.Deletar(id);
    }
}