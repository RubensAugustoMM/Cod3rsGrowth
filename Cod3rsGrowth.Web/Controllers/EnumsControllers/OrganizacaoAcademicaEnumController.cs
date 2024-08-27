using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Dominio.Enums.Extencoes;

namespace Cod3rsGrowth.Web.Controllers.EnumsControllers;

[Route("api/[controller]")]
[ApiController]
public class OrganizacaoAcademicaEnumController : ControllerBase
{
    [HttpGet]
    public IActionResult ObterModeloJson()
    {
        var organizacaoAcademicaEnumJson = new OrganizacaoAcademicaEnumJson();
        var valoresOrganizacaoAcademica = Enum.GetValues(typeof(OrganizacaoAcademicaEnums)).Cast<OrganizacaoAcademicaEnums>();
        foreach (var organizacaoAcademica in valoresOrganizacaoAcademica)
        {
            organizacaoAcademicaEnumJson.OrganizacaoAcademica.Add((int)organizacaoAcademica, organizacaoAcademica.RetornaDescricao()); 
        }

        var jsonStrng = JsonSerializer.Serialize(organizacaoAcademicaEnumJson);
        return Ok(jsonStrng);
    }
    
    private class OrganizacaoAcademicaEnumJson
    {
        public Dictionary<int, string> OrganizacaoAcademica { get; set; } = new();
    }
}
