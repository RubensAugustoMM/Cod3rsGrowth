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
        var dicionarioNaturezaJuridica = new Dictionary<int, string>();
        var valoresNaturezaJuridica = Enum.GetValues(typeof(NaturezaJuridicaEnums)).Cast<NaturezaJuridicaEnums>();
        foreach (var naturezaJuridica in valoresNaturezaJuridica)
        {
            dicionarioNaturezaJuridica.Add((int)naturezaJuridica, naturezaJuridica.RetornaDescricao()); 
        }

        var enumNaturezaJuridicaJson = JsonSerializer.Serialize(dicionarioNaturezaJuridica);
        return Ok(enumNaturezaJuridicaJson);
    }
}