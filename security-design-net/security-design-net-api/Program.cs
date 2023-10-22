using Microsoft.EntityFrameworkCore;
using Security.Design.Net.Api.Context;
using Security.Design.Net.Api.DTOs.PassagemDTO;
using Security.Design.Net.Api.Routes;
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

builder.Services.AddScoped<IPassagensRoute, PassagensRoute>();


var app = builder.Build();

var sampleTodos = new Todo[] {
    new(1, "Walk the dog"),
    new(2, "Do the dishes", DateOnly.FromDateTime(DateTime.Now)),
    new(3, "Do the laundry", DateOnly.FromDateTime(DateTime.Now.AddDays(1))),
    new(4, "Clean the bathroom"),
    new(5, "Clean the car", DateOnly.FromDateTime(DateTime.Now.AddDays(2)))
};

var todosApi = app.MapGroup("/todos");
todosApi.MapGet("/", () => sampleTodos).WithName("GetWeatherForecast").WithOpenApi(); ;
todosApi.MapGet("/{id}", (int id) =>
    sampleTodos.FirstOrDefault(a => a.Id == id) is { } todo
        ? Results.Ok(todo)
        : Results.NotFound()).WithName("GetWeatherForecast2")
.WithOpenApi();

var carrosApi = app.MapGroup("/carros");


var passagensApi = app.MapGroup("/passagens");

passagensApi.MapPost("/", async (PassagemCreateDTO dto, IPassagensRoute passagensRoute, CancellationToken token) => await passagensRoute.InserirAsync(dto, token));


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.MapSwagger().RequireAuthorization();

app.Run();

public record Todo(int Id, string? Title, DateOnly? DueBy = null, bool IsComplete = false);

[JsonSerializable(typeof(Todo[]))]
internal partial class AppJsonSerializerContext : JsonSerializerContext
{

}
