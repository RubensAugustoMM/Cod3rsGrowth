using System.Text.Json;
using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Dominio.Enums.Extencoes;
using Microsoft.AspNetCore.Mvc;

namespace Cod3rsGrowth.Web.Controllers.EnumsControllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriaAdministrativaEnum : ControllerBase
{
    [HttpGet]
    public IActionResult ObterModeloJson()
    {
        var categoriaAdministrativaJson = new CategoriaAdministrativaEnumJson();
        var valoresCategoriaAdministrativa = Enum.GetValues(typeof(CategoriaAdministrativaEnums)).Cast<CategoriaAdministrativaEnums>();
        foreach (var categoriaAdministrativa in valoresCategoriaAdministrativa)
        {
            categoriaAdministrativaJson.CategoriaAdministrativa.Add(new EnumJson
            {
                Codigo = (int)categoriaAdministrativa,
                Valor = categoriaAdministrativa.RetornaDescricao()
            }); 
        }

        var jsonString = JsonSerializer.Serialize(categoriaAdministrativaJson);
        return Ok(jsonString);
    }

    private struct CategoriaAdministrativaEnumJson
    {
        public CategoriaAdministrativaEnumJson(){ }
        public List<EnumJson> CategoriaAdministrativa { get; set; } = new();
    }
}