using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Servico;
using Microsoft.AspNetCore.Mvc;

namespace Cod3rsGrowth.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EnderecoController : ControllerBase
{
    private readonly ServicoEndereco _servicoEndereco;

    public EnderecoController(ServicoEndereco servicoEndereco)
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
    public Endereco ObterPorId(int id)
    {
        return _servicoEndereco.ObterPorId(id);
    }

    [HttpPost]
    public void Criar([FromBody] Endereco enderecoCriar)
    {
        _servicoEndereco.Criar(enderecoCriar);
    }

    [HttpPut]
    public void Atualizar([FromBody] Endereco enderecoAtualizar)
    {
        _servicoEndereco.Atualizar(enderecoAtualizar);
    }

    [HttpDelete("{id}")]
    public void Deletar(int id)
    {
        _servicoEndereco.Deletar(id);
    }
}