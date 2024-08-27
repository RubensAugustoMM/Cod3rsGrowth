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
            naturezaJuridicaJson.NaturezaJuridica.Add(new EnumJson
            {
                Codigo = (int)naturezaJuridica,
                Valor = naturezaJuridica.RetornaDescricao()
            }); 
        }

        var jsonString = JsonSerializer.Serialize(naturezaJuridicaJson);
        return Ok(jsonString);
    }
    
    private struct NaturezaJuridicaEnumJson
    {
        public NaturezaJuridicaEnumJson() { }
        public List<EnumJson> NaturezaJuridica { get; set; } = new(); 
    }
}