using EvolveDb;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MySqlConnector;
using RestWithAspNet.Business;
using RestWithAspNet.Business.Implementations;
using RestWithAspNet.Hypermedia.Enricher;
using RestWithAspNet.Hypermedia.Filter;
using RestWithAspNet.Model.Context;
using RestWithAspNet.Repository;
using RestWithAspNet.Repository.Implementations;
using Serilog;
using System.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

var appName = "Rest API's RESTful from 0 to azure with asp.net core and Docker";
var apiVersion = "v1";
var apiDescription = $"API RESTful developed with '{appName}'";

// Add services to the container.

builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddControllers();

//Add swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen( c =>
{
    c.SwaggerDoc(apiVersion, 
        new OpenApiInfo
        {
            Title = appName,
            Version = apiVersion,
            Description = apiDescription,
            Contact = new OpenApiContact
            {
                Name = "Ronaldo Silva",
                Url = new Uri("https://github.com/ronaldojssilva/RestWithAspNet")
            }
        });
});

//DB Connection
var connection = builder.Configuration["MySQLConnection:MySQLConnectionString"];
builder.Services.AddDbContext<MySQLContext>(
    options => options.UseMySql(connection,
                     new MySqlServerVersion(new Version(8, 2, 0)
    )));

//Log
//Log.Logger = new LoggerConfiguration()
//	.WriteTo.Console()
//	.CreateLogger();

//Migrations
if (builder.Environment.IsDevelopment())
{
    MigrateDatabase(connection);
}

//Content negotiation
builder.Services.AddMvc(options =>
{
    options.RespectBrowserAcceptHeader = true;

    options.FormatterMappings.SetMediaTypeMappingForFormat("xml", "application/xml");
    options.FormatterMappings.SetMediaTypeMappingForFormat("json", "application/json");

}).AddXmlSerializerFormatters();

//HATEOS
var filterOptions = new HyperMediaFilterOptions();
filterOptions.ContentResponseEnricherList.Add(new PersonEnricher());
filterOptions.ContentResponseEnricherList.Add(new BookEnricher());
builder.Services.AddSingleton(filterOptions);


//Versioning API
builder.Services.AddApiVersioning();

//Dependency Injection
builder.Services.AddScoped<IPersonBusiness, PersonBusinessImplementation>();
builder.Services.AddScoped<IBookBusiness, BookBusinessImplementation>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

//Add swagger
app.UseSwagger();//gera o json com a documentação
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json",
        $"{appName} - {apiVersion}");
}); // gera a pagina html para o json gerado
var option = new RewriteOptions();
option.AddRedirect("^$", "swagger");
app.UseRewriter(option);


app.UseAuthorization();

app.MapControllers();
//HATEOS
//app.MapControllerRoute("DefaultApi", "{controller=values}/{id?}");
//app.MapControllerRoute("DefaultApi", "{controller=values}/v{}/{id?}");
app.MapControllerRoute("DefaultApi", "api/{controller=values}/v{version=apiVersion}/{id?}");
//app.MapControllerRoute("DefaultApi", "");

app.Run();

void MigrateDatabase(string? connection)
{
    try
    {
        var evolveConnection = new MySqlConnection(connection);
        var evolve = new Evolve(evolveConnection, Log.Information)
        {
            Locations = new List<string> { "db/migrations", "db/dataset" },
            IsEraseDisabled = true
        };
        evolve.Migrate();
    }
    catch (Exception ex)
    {
        Log.Error("Database migration failed", ex);
        throw;
    }
}