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

    // GET: api/Escolas
    [HttpGet]
    public List<EscolaEnderecoOtd> ObterTodos([FromBody] FiltroEscolaEnderecoOtd filtroEscola)
    {
        return _servicoEscola.ObterTodos(filtroEscola);
    }

    // GET: api/Escolas/5
    [HttpGet("{id}")]
    public EscolaEnderecoOtd ObterPorId(int id)
    {
        return _servicoEscola.ObterPorId(id);
    }

    // POST: api/Escolas
    [HttpPost]
    public void Criar([FromBody] Escola escolaCriar)
    {
        _servicoEscola.Criar(escolaCriar);
    }

    // PUT: api/Escolas/5
    [HttpPut]
    public void Atualizar([FromBody] Escola escolaAtualizar)
    {
        _servicoEscola.Atualizar(escolaAtualizar);
    }

    // DELETE: api/Escolas/5
    [HttpDelete("{id}")]
    public void Deletar(int id)
    {
        _servicoEscola.Deletar(id);
    }
}