using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Dominio.Enums.Extencoes;

namespace Cod3rsGrowth.Web.Controllers.EnumsControllers;

[Route("api/[controller]")]
[ApiController]
public class PorteEnumController : ControllerBase
{
    [HttpGet]
    public IActionResult ObterTodos()
    {
        var porteEnumJson = new PorteEnumJson();
        var valoresPorte = Enum.GetValues(typeof(PorteEnums)).Cast<PorteEnums>();
        foreach (var porte in valoresPorte)
        {
            porteEnumJson.Porte.Add(new EnumJson
            {
                Codigo = (int)porte,
                Valor =  porte.RetornaDescricao()
            }); 
        }

        var jsonStrng = JsonSerializer.Serialize(porteEnumJson);
        return Ok(jsonStrng);
    }
    
    private struct PorteEnumJson
    {
        public PorteEnumJson() { }
        public List<EnumJson> Porte { get; set; } = new();
    }
}