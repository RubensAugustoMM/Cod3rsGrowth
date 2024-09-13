using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Dominio.ObjetosTranferenciaDados;
using Cod3rsGrowth.Servico;
using Microsoft.AspNetCore.Mvc;

namespace Cod3rsGrowth.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmpresasController : ControllerBase
{
    private readonly ServicoEmpresa _servicoEmpresa;

    public EmpresasController(ServicoEmpresa servicoEmpresa)
    {
        _servicoEmpresa = servicoEmpresa;
    }

    [HttpGet]
    public IActionResult ObterTodos([FromQuery] FiltroEmpresaEnderecoOtd filtroEmpresa)
    {
        var empresas = _servicoEmpresa.ObterTodos(filtroEmpresa);
        return Ok(empresas);
    }

    [HttpGet("{id}")]
    public IActionResult ObterPorId(int id)
    {
        var empresa = _servicoEmpresa.ObterPorId(id);
        return Ok(empresa);
    }

    [HttpPost]
    public IActionResult Criar([FromBody] Empresa empresa)
    {
        _servicoEmpresa.Criar(empresa);
        return CreatedAtAction(nameof(ObterPorId), new { id = empresa.Id }, empresa);
    }

    [HttpPut]
    public IActionResult Atualizar([FromBody] Empresa empresa)
    {
        _servicoEmpresa.Atualizar(empresa);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Deletar(int id)
    {
        _servicoEmpresa.Deletar(id);
        return Ok();
    }
}