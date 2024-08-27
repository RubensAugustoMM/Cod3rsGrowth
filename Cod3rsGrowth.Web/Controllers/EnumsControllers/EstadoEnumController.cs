using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Dominio.Enums.Extencoes;

namespace Cod3rsGrowth.Web.Controllers.EnumsControllers;

[Route("api/[controller]")]
[ApiController]
public class EstadoEnumController : ControllerBase
{
    [HttpGet]
    public IActionResult ObterModeloJson()
    {
        var estadoJson = new EstadoEnumJson();
        var valoresEstado = Enum.GetValues(typeof(EstadoEnums)).Cast<EstadoEnums>();
        foreach (var estado in valoresEstado)
        {
            estadoJson.Estados.Add((int)estado, estado.RetornaDescricao()); 
        }

        var jsonString = JsonSerializer.Serialize<EstadoEnumJson>(estadoJson);
        return Ok(jsonString);
    }

    private class EstadoEnumJson
    {
        public Dictionary<int, string> Estados { get; set; } = new(); 
    }
}