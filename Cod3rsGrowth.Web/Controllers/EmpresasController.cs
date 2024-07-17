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

    // GET: api/Empresas
    [HttpGet]
    public List<EmpresaEnderecoOtd> ObterTodos([FromBody] FiltroEmpresaEnderecoOtd filtroEmpresa)
    {
        return _servicoEmpresa.ObterTodos(filtroEmpresa);
    }

    // GET: api/Empresas/5
    [HttpGet("{id}")]
    public EmpresaEnderecoOtd ObterPorId(int id)
    {
        return _servicoEmpresa.ObterPorId(id);
    }

    // POST: api/Empresas
    [HttpPost]
    public void Criar([FromBody] Empresa empresaCriar)
    {
        _servicoEmpresa.Criar(empresaCriar);
    }

    // PUT: api/Empresas/5
    [HttpPut]
    public void Atualizar([FromBody] Empresa empresaAtualizar)
    {
        _servicoEmpresa.Atualizar(empresaAtualizar);
    }

    // DELETE: api/Empresas/5
    [HttpDelete("{id}")]
    public void Deletar(int id)
    {
        _servicoEmpresa.Deletar(id);
    }
}