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
        var habilitadoJson = new HabilitadoEnumJson();
        var valoresHabilitado = Enum.GetValues(typeof(HabilitadoEnums)).Cast<HabilitadoEnums>();
        foreach (var habilitado in valoresHabilitado)
        {
            habilitadoJson.Habilitado.Add((int)habilitado, habilitado.RetornaDescricao()); 
        }

        var jsonString = JsonSerializer.Serialize(habilitadoJson);
        return Ok(jsonString);
    }

    private class HabilitadoEnumJson
    {
        public Dictionary<int, string> Habilitado { get; set; } = new();
    }
}