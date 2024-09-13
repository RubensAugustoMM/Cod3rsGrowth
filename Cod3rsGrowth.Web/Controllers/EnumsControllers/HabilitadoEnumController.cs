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
    public IActionResult ObterTodos()
    {
        var habilitadoJson = new HabilitadoEnumJson();
        var valoresHabilitado = Enum.GetValues(typeof(HabilitadoEnums)).Cast<HabilitadoEnums>();
        foreach (var habilitado in valoresHabilitado)
        {
            habilitadoJson.Habilitado.Add(new EnumJson
            {
                Codigo = (int) habilitado,
                Valor = habilitado.RetornaDescricao() 
            }); 
        }

        var jsonString = JsonSerializer.Serialize(habilitadoJson);
        return Ok(jsonString);
    }

    private struct HabilitadoEnumJson
    {
        public HabilitadoEnumJson() { }
        public List<EnumJson> Habilitado { get; set; } = new();
    }
}