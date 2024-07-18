using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Infra;
using Cod3rsGrowth.Infra.Repositorios;
using Cod3rsGrowth.Servico;
using Cod3rsGrowth.Servico.Validacoes;
using LinqToDB.AspNet;
using LinqToDB.AspNet.Logging;
using LinqToDB;

var builder = WebApplication.CreateBuilder(args);

string StringConexao = ConfiguracoesStringConexao.RetornaStringConexao();
// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddLinqToDBContext<ContextoAplicacao>((provider, options) =>
        options
            .UseSqlServer(StringConexao)
            .UseDefaultLogging(provider))
    .AddScoped<IRepositorioConvenio, RepositorioConvenio>()
    .AddScoped<IRepositorioEmpresa, RepositorioEmpresa>()
    .AddScoped<IRepositorioEndereco, RepositorioEndereco>()
    .AddScoped<IRepositorioEscola, RepositorioEscola>()
    .AddScoped<ValidadorConvenio>()
    .AddScoped<ValidadorEmpresa>()
    .AddScoped<ValidadorEndereco>()
    .AddScoped<ValidadorEscola>()
    .AddScoped<ServicoConvenio>()
    .AddScoped<ServicoEmpresa>()
    .AddScoped<ServicoEndereco>()
    .AddScoped<ServicoEscola>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public class ConfiguracoesStringConexao
{
    public static string RetornaStringConexao()
    {
        return System.Configuration.ConfigurationManager
            .ConnectionStrings["ConvenioEscolaEmpresaBD"]
            .ConnectionString;
    }
}