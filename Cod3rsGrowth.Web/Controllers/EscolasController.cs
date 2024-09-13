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
    public IActionResult Criar([FromBody] Escola escola)
    {
        _servicoEscola.Criar(escola);
        return CreatedAtAction(nameof(ObterPorId), new { id = escola.Id }, escola);
    }

    [HttpPut]
    public IActionResult Atualizar([FromBody] Escola escola)
    {
        _servicoEscola.Atualizar(escola);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Deletar(int id)
    {
        _servicoEscola.Deletar(id);
        return Ok();
    }
}