using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Dominio.ObjetosTranferenciaDados;
using Cod3rsGrowth.Servico;
using Microsoft.AspNetCore.Mvc;

namespace Cod3rsGrowth.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EscolasController : ControllerBase
{
    private readonly ServicoEscola _servicoEscola;

    public EscolasController(ServicoEscola servicoEscola)
    {
        _servicoEscola = servicoEscola;
    }

    [HttpGet]
    public IActionResult ObterTodos([FromQuery] FiltroEscolaEnderecoOtd filtroEscola)
    {
        var escolas = _servicoEscola.ObterTodos(filtroEscola);
        return Ok(escolas);
    }

    [HttpGet("{id}")]
    public IActionResult ObterPorId(int id)
    {
        var escola = _servicoEscola.ObterPorId(id);
        return Ok(escola);
    }

    [HttpPost]
    public IActionResult Criar([FromBody] Escola escolaCriar)
    {
        _servicoEscola.Criar(escolaCriar);
        return CreatedAtAction(nameof(ObterPorId), new { id = escolaCriar.Id }, escolaCriar);
    }

    [HttpPut]
    public IActionResult Atualizar([FromBody] Escola escolaAtualizar)
    {
        _servicoEscola.Atualizar(escolaAtualizar);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Deletar(int id)
    {
        _servicoEscola.Deletar(id);
        return NoContent();
    }
}