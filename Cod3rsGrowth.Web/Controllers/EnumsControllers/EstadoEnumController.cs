using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Cod3rsGrowth.Web.Controllers.EnumsControllers;

public class EstadoEnumController : ControllerBase
{
    [HttpGet]
    public IActionResult ObterJson()
    {
        var enumEstadoJson = JsonSerializer.Serialize<>() 
    }
}