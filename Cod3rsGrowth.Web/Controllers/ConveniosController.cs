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
    public IActionResult ObterTodos([FromQuery] FiltroConvenioEscolaEmpresaOtd filtroConvenio)
    {
        var convenios =  _servicoConvenio.ObterTodos(filtroConvenio);
        return Ok(convenios);
    }

    [HttpGet("{id}")]
    public IActionResult ObterPorId(int id)
    {
        var convenio = _servicoConvenio.ObterPorId(id);
        return Ok(convenio);
    }

    [HttpPost]
    public IActionResult Criar([FromBody] Convenio convenioCriar)
    {
        _servicoConvenio.Criar(convenioCriar);
        return CreatedAtAction(nameof(ObterPorId), new { id = convenioCriar.Id }, convenioCriar);
    }

    [HttpPut]
    public IActionResult Atualizar([FromBody] Convenio convenioAtualizar)
    {
        _servicoConvenio.Atualizar(convenioAtualizar);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public void Deletar(int id)
    {
        _servicoConvenio.Deletar(id);
    }
}