namespace Cod3rsGrowth.Web;

public class ConfiguracoesStringConexao
{
    public static string RetornaStringConexao()
    {
        return System.Configuration.ConfigurationManager
            .ConnectionStrings["ConvenioEscolaEmpresaBD"]
            .ConnectionString;
    }
}