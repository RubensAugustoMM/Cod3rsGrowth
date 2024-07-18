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
    public List<EscolaEnderecoOtd> ObterTodos([FromBody] FiltroEscolaEnderecoOtd filtroEscola)
    {
        return _servicoEscola.ObterTodos(filtroEscola);
    }

    [HttpGet("{id}")]
    public EscolaEnderecoOtd ObterPorId(int id)
    {
        return _servicoEscola.ObterPorId(id);
    }

    [HttpPost]
    public void Criar([FromBody] Escola escolaCriar)
    {
        _servicoEscola.Criar(escolaCriar);
    }

    [HttpPut]
    public void Atualizar([FromBody] Escola escolaAtualizar)
    {
        _servicoEscola.Atualizar(escolaAtualizar);
    }

    [HttpDelete("{id}")]
    public void Deletar(int id)
    {
        _servicoEscola.Deletar(id);
    }
}