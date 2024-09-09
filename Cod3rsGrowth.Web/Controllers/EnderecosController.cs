using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Servico;
using Microsoft.AspNetCore.Mvc;

namespace Cod3rsGrowth.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EnderecosController : ControllerBase
{
    private readonly ServicoEndereco _servicoEndereco;

    public EnderecosController(ServicoEndereco servicoEndereco)
    {
        _servicoEndereco = servicoEndereco;
    }

    [HttpGet]
    public IActionResult ObterTodos([FromQuery] FiltroEndereco filtroEndereco)
    {
        var enderecos = _servicoEndereco.ObterTodos(filtroEndereco);
        return Ok(enderecos);
    }

    [HttpGet("{id}")]
    public IActionResult ObterPorId(int id)
    {
        var endereco = _servicoEndereco.ObterPorId(id);
        return Ok(endereco);
    }

    [HttpPost("[action]")]
    public IActionResult Criar([FromBody] Endereco enderecoCriar)
    {
        _servicoEndereco.Criar(enderecoCriar);
        return CreatedAtAction(nameof(ObterPorId), new { id = enderecoCriar.Id }, enderecoCriar);
    }

    [HttpPut]
    public IActionResult Atualizar([FromBody] Endereco endereco)
    {
        _servicoEndereco.Atualizar(endereco);
        return Ok();
    }

    [HttpDelete("[action]/{id}")]
    public IActionResult Deletar(int id)
    {
        _servicoEndereco.Deletar(id);
        return NoContent();
    }
}