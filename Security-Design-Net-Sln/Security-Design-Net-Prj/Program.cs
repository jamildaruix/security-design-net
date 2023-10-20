using Security_Design_Net_Prj.Routes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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

RouteGroupBuilder carrosGroup = app.MapGroup("/carros");

carrosGroup.MapGet("/", CarrosRoute.GetAll).WithOpenApi();
carrosGroup.MapGet("/{id}", CarrosRoute.GetById).WithOpenApi();

carrosGroup.MapPost("/", CarrosRoute.Post).WithOpenApi();

carrosGroup.MapPut("/{id}", CarrosRoute.Put).WithOpenApi();


app.Run();
