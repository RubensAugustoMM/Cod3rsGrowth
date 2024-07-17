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

    // GET: api/Endereco
    [HttpGet]
    public List<Endereco> ObterTodos([FromBody] FiltroEndereco filtroEndereco)
    {
        return _servicoEndereco.ObterTodos(filtroEndereco);
    }

    // GET: api/Endereco/5
    [HttpGet("{id}")]
    public Endereco ObterPorId(int id)
    {
        return _servicoEndereco.ObterPorId(id);
    }

    // POST: api/Endereco
    [HttpPost]
    public void Criar([FromBody] Endereco enderecoCriar)
    {
        _servicoEndereco.Criar(enderecoCriar);
    }

    // PUT: api/Endereco/5
    [HttpPut]
    public void Atualizar([FromBody] Endereco enderecoAtualizar)
    {
        _servicoEndereco.Atualizar(enderecoAtualizar);
    }

    // DELETE: api/Endereco/5
    [HttpDelete("{id}")]
    public void Deletar(int id)
    {
        _servicoEndereco.Deletar(id);
    }
}