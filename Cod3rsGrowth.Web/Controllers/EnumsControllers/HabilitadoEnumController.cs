using System.Text.Json;
using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Dominio.Enums.Extencoes;
using Microsoft.AspNetCore.Mvc;

namespace Cod3rsGrowth.Web.Controllers.EnumsControllers;

[Route("api/[controller]")]
[ApiController]
public class HabilitadoEnumController : ControllerBase
{
    [HttpGet]
    public IActionResult ObterModeloJson()
    {
        var dicionarioHabilitado = new Dictionary<int, string>();
        var valoresHabilitado = Enum.GetValues(typeof(HabilitadoEnums)).Cast<HabilitadoEnums>();
        foreach (var habilitado in valoresHabilitado)
        {
            dicionarioHabilitado.Add((int)habilitado, habilitado.RetornaDescricao()); 
        }

        var enumHabilitadoJson = JsonSerializer.Serialize(dicionarioHabilitado);
        return Ok(enumHabilitadoJson);
    }
}