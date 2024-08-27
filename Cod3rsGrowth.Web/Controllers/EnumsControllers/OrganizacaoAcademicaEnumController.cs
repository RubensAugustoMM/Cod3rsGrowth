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
        var dicionarioOrganizacaoAcademica = new Dictionary<int, string>();
        var valoresOrganizacaoAcademica = Enum.GetValues(typeof(OrganizacaoAcademicaEnums)).Cast<OrganizacaoAcademicaEnums>();
        foreach (var organizacaoAcademica in valoresOrganizacaoAcademica)
        {
            dicionarioOrganizacaoAcademica.Add((int)organizacaoAcademica, organizacaoAcademica.RetornaDescricao()); 
        }

        var enumOrganizacaoAcademicaJson = JsonSerializer.Serialize(dicionarioOrganizacaoAcademica);
        return Ok(enumOrganizacaoAcademicaJson);
    }
}
