using Microsoft.EntityFrameworkCore;
using Security.Design.Net.Api.Context;
using Security.Design.Net.Api.DTOs.PassagemDTO;
using Security.Design.Net.Api.Repositories;
using Security.Design.Net.Api.Routes;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
});


var directoryProject = Directory.GetCurrentDirectory();


builder.Configuration
       .SetBasePath(directoryProject)
       .AddJsonFile(path: "appsettings.json", optional: false, reloadOnChange: true);

builder.Services
       .AddDbContext<ExampleDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")!));

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));


builder.Services.AddScoped<IPassagemRepository, PassagemRepository>();

var app = builder.Build();

app.MapPassagensEndpoint();


var carrosApi = app.MapGroup("/carros");



//var passagensApi = app.MapGroup("/passagens").WithOpenApi();

//passagensApi.MapPost("/", async (PassagemCreateDTO dto, IPassagensRoute passagensRoute, CancellationToken cancellationToken) 
//    =>  await passagensRoute.InserirAsync(dto, cancellationToken));


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.MapSwagger().RequireAuthorization();

app.Run();

[JsonSerializable(typeof(object))]
internal partial class AppJsonSerializerContext : JsonSerializerContext
{
}
