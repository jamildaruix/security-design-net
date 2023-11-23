using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Security.Design.Api.Context;
using Security.Design.Api.DTOs.AirfareDTO;
using Security.Design.Api.Events;
using Security.Design.Api.Repositories;
using Security.Design.Api.Validators;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpContextAccessor();

var directoryProject = Directory.GetCurrentDirectory();

builder.Configuration
       .SetBasePath(directoryProject)
       .AddJsonFile(path: "appsettings.json", optional: false, reloadOnChange: true);

builder.Services
       .AddDbContext<ExampleDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")!));

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddValidatorsFromAssemblyContaining<Assembly>();


builder.Services.AddScoped<IValidator<AirfareCreateDTO>, AirfareCreateDTOValidator>();
builder.Services.AddScoped<IValidator<AirTicketPriceUpdateDTO>, AirTicketPriceUpdateDTOValidator>();



builder.Services.AddScoped<IAirfareRepository, AirfareRepository>()
                .AddScoped<IEventStore, BuyTicketAirfaceVersionEvent>();


builder.Services.AddRouting(options =>
{
    options.LowercaseUrls = true;
    options.LowercaseQueryStrings = true;
});

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
