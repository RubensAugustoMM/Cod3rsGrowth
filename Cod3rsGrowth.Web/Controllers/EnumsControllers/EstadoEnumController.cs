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
        var dicionarioEstado = new Dictionary<int, string>();
        var valoresEstado = Enum.GetValues(typeof(EstadoEnums)).Cast<EstadoEnums>();
        foreach (var estado in valoresEstado)
        {
            dicionarioEstado.Add((int)estado, estado.RetornaDescricao()); 
        }

        var enumEstadoJson = JsonSerializer.Serialize(dicionarioEstado);
        return Ok(enumEstadoJson);
    }
}