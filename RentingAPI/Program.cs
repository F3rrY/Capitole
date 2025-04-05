using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using RentingAPI.Application.Commands;
using RentingAPI.Application.Factories;
using RentingAPI.Application.Queries;
using RentingAPI.Domain.Repositories;
using RentingAPI.Infrastructure.Data;
using RentingAPI.Infrastructure.Repositories;
using RentingAPI.Infrastructure.UnitOfWork;
using RentingAPI.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Añadimos el swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "RentingAPI", Version = "v1" });
});

// Añadimos MediatR tanto para los commands como queries (están en ensamblados distintos)
builder.Services.AddMediatR(typeof(CrearClienteCommand).Assembly);
builder.Services.AddMediatR(typeof(ObtenerClientesQuery).Assembly);

// Añadimos UnitOfWork
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Configuración de la conexión a la base de datos
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Database")));

// Registramos los repositorios
builder.Services.AddScoped<IVehiculoRepository, VehiculoRepository>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IAlquilerRepository, AlquilerRepository>();

// Registramos las factories
builder.Services.AddScoped<IAlquilerFactory, AlquilerFactory>();
builder.Services.AddScoped<IClienteFactory, ClienteFactory>();
builder.Services.AddScoped<IVehiculoFactory, VehiculoFactory>();

var app = builder.Build();

// Usamos swagger en entorno de desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "RentingAPI v1");
        c.RoutePrefix = "swagger"; 
    });
}

// Registro el middleware para manejar las excepciones
app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }
