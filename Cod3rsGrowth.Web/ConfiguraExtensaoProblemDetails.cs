using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using FluentValidation;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;

namespace Cod3rsGrowth.Web;

public static class ConfiguraExtensaoProblemDeitals
{
    public static void UsarTratadorDeExcecoesProblemDetails(this IApplicationBuilder aplicacao,ILoggerFactory fabrigaArquivador)
    {
        aplicacao.UseExceptionHandler(construtor =>
        {
            construtor.Run(async contexto =>
            {
                var recursoTratadorDeExcecoes = contexto.Features.Get<IExceptionHandlerFeature>();

                if (recursoTratadorDeExcecoes != null)
                {
                    var excecao = recursoTratadorDeExcecoes.Error;

                    var detalhesProblema = new ProblemDetails
                    {
                        Instance = contexto.Request.HttpContext.Request.Path
                    };

                    var arquivador = fabrigaArquivador.CreateLogger("GlobalExceptionHandler");

                    switch (excecao)
                    {
                        case BadHttpRequestException pedidoMalHttp:
                            var tituloExcecaoMalHttp = "A requisição é invalida";
                            var tipoExcecaoMalHttp = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1";
                            
                            detalhesProblema.Title = tituloExcecaoMalHttp;
                            detalhesProblema.Status = StatusCodes.Status400BadRequest;
                            detalhesProblema.Type = tipoExcecaoMalHttp;
                            detalhesProblema.Detail = pedidoMalHttp.Message;
                            break;
                        case ValidationException excecaoValidacao:
                            arquivador.LogError($"Erro Inesperado: {recursoTratadorDeExcecoes.Error}");
                            
                            var tituloExcecaoValidacao = "Erro ao Validar Objeto";
                            var tipoExcecaoValidacao = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1";
                            
                            detalhesProblema.Title = tituloExcecaoValidacao;
                            detalhesProblema.Status = StatusCodes.Status500InternalServerError;
                            detalhesProblema.Type = tipoExcecaoValidacao;
                            
                            string detalhes = "";
                            foreach (var erro in excecaoValidacao.Errors)
                            {
                                detalhes += erro.ErrorMessage + "\n";
                            }

                            detalhesProblema.Detail = excecaoValidacao.Message + detalhes;
                            break;
                        case SqlException excecaoSql:
                            arquivador.LogError($"Erro Inesperado: {recursoTratadorDeExcecoes.Error}");
                            
                            var tituloExcecaoSql = "Exceção na banco de dados";
                            var tipoExcecaoSql = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1";
                        
                            detalhesProblema.Title = tituloExcecaoSql;
                            detalhesProblema.Status = StatusCodes.Status500InternalServerError;
                            detalhesProblema.Type = tipoExcecaoSql;
                            detalhesProblema.Detail = excecaoSql.Message;
                            break;
                        default:
                        arquivador.LogError($"Erro Inesperado: {recursoTratadorDeExcecoes.Error}");
                        
                        var tipoExcecaoPadrao = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1";

                        detalhesProblema.Title = excecao.Message;
                        detalhesProblema.Status = StatusCodes.Status500InternalServerError;
                        detalhesProblema.Type =  tipoExcecaoPadrao;
                        detalhesProblema.Detail = excecao.StackTrace;
                        break;
                    }

                    var json = JsonConvert.SerializeObject(detalhesProblema, new JsonSerializerSettings());
                    await contexto.Response.WriteAsync(json);
                }
            });
        });
    } 
}