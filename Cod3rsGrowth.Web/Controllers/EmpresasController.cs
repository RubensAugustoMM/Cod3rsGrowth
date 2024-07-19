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
    public IActionResult ObterTodos([FromBody] FiltroEmpresaEnderecoOtd filtroEmpresa)
    {
        var empresas = _servicoEmpresa.ObterTodos(filtroEmpresa);
        return Ok(empresas);
    }

    [HttpGet("{id}")]
    public EmpresaEnderecoOtd ObterPorId(int id)
    {
        return _servicoEmpresa.ObterPorId(id);
    }

    [HttpPost]
    public void Criar([FromBody] Empresa empresaCriar)
    {
        _servicoEmpresa.Criar(empresaCriar);
    }

    [HttpPut]
    public void Atualizar([FromBody] Empresa empresaAtualizar)
    {
        _servicoEmpresa.Atualizar(empresaAtualizar);
    }

    [HttpDelete("{id}")]
    public void Deletar(int id)
    {
        _servicoEmpresa.Deletar(id);
    }
}