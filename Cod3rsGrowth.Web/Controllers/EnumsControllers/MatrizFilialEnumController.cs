using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Dominio.Enums.Extencoes;


namespace Cod3rsGrowth.Web.Controllers.EnumsControllers;


[Route("api/[controller]")]
[ApiController]
public class MatrizFilialEnumController : ControllerBase
{
    
    [HttpGet]
    public IActionResult ObterTodos()
    {
        var matrizFilialEnumJson = new MatrizFilialEnumJson();
        var valoresMatrizFilial = Enum.GetValues(typeof(MatrizFilialEnums)).Cast<MatrizFilialEnums>();
        foreach (var matrizFilial in valoresMatrizFilial)
        {
            matrizFilialEnumJson.MatrizFilial.Add(new EnumJson
            {
                Codigo = (int)matrizFilial,
                Valor =  matrizFilial.RetornaDescricao()
            }); 
        }

        var jsonStrng = JsonSerializer.Serialize(matrizFilialEnumJson);
        return Ok(jsonStrng);
    }
    
    private struct MatrizFilialEnumJson
    {
        public MatrizFilialEnumJson() { }
        public List<EnumJson> MatrizFilial { get; set; } = new();
    }
}