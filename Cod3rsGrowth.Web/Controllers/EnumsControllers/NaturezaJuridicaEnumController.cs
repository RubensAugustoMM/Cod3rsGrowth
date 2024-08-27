using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Dominio.Enums.Extencoes;

namespace Cod3rsGrowth.Web.Controllers.EnumsControllers;

[Route("api/[controller]")]
[ApiController]
public class NaturezaJuridicaEnumController : ControllerBase
{
    [HttpGet]
    public IActionResult ObterModeloJson()
    {
        var naturezaJuridicaJson = new NaturezaJuridicaEnumJson();
        var valoresNaturezaJuridica = Enum.GetValues(typeof(NaturezaJuridicaEnums)).Cast<NaturezaJuridicaEnums>();
        foreach (var naturezaJuridica in valoresNaturezaJuridica)
        {
            naturezaJuridicaJson.NaturezaJuridica.Add((int)naturezaJuridica, naturezaJuridica.RetornaDescricao()); 
        }

        var jsonString = JsonSerializer.Serialize(naturezaJuridicaJson);
        return Ok(jsonString);
    }
    
    private class NaturezaJuridicaEnumJson
    {
        public Dictionary<int, string> NaturezaJuridica { get; set; } = new(); 
    }
}