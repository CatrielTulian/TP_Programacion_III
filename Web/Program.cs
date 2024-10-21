using Application.Interfaces;
using Application.Services;
using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Inyeccion de Dependecias

builder.Services.AddScoped<IVueloRepository, VueloRepository>();
builder.Services.AddScoped<IVueloService, VueloService>();
builder.Services.AddDbContext<VuelosDbContext>(x => x.UseSqlite(builder.Configuration.GetConnectionString("VuelosDbConnection")));

builder.Services.AddScoped<IPasajeroRepository, PasajeroRepository>();
builder.Services.AddScoped<IPasajerosService, PasajeroService>();
builder.Services.AddDbContext<VuelosDbContext>(x => x.UseSqlite(builder.Configuration.GetConnectionString("VuelosDbConnection")));

#endregion

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
