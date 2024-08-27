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
        var estadoJson = new EstadosEnumJson();
        var valoresEstado = Enum.GetValues(typeof(EstadoEnums)).Cast<EstadoEnums>();
        foreach (var estado in valoresEstado)
        {
            estadoJson.Estados.Add(new EnumJson
            {
                Codigo = (int)estado,
                Valor = estado.RetornaDescricao()
            }); 
        }

        var jsonString = JsonSerializer.Serialize(estadoJson);
        return Ok(jsonString);
    }

    private struct EstadosEnumJson
    {
        public EstadosEnumJson(){ }
        public List<EnumJson> Estados { get; set; } = new();
    }
}