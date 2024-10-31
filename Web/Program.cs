using Application.Interfaces;
using Application.Services;
using Contract.AuthenticationModel.Helpers;
using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.Persistence;
using Infrastructure.ThirdPartyServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

internal class Program 
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();

        #region Inyeccion de Dependecias

        builder.Services.AddScoped<IVueloRepository, VueloRepository>();
        builder.Services.AddScoped<IVueloService, VueloService>();
        builder.Services.Configure<AutenticacionServiceOptions>(builder.Configuration.GetSection("AutenticacionServiceOptions"));
        builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
        
        

        builder.Services.AddSwaggerGen(setupAction =>
        {
            setupAction.AddSecurityDefinition("ApiBearerAuth", new OpenApiSecurityScheme()
            {
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer",
                Description = "Paste the token to login."
            });

            setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "ApiBearerAuth"
                            }
                        },
                        new List<string>()
                    }
                    });
        });

        builder.Services.AddAuthentication("Bearer")
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["AutenticacionServiceOptions:Issuer"],
                    ValidAudience = builder.Configuration["AutenticacionServiceOptions:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["AutenticacionServiceOptions:SecretForKey"]!))
                };
            }
   );


        builder.Services.AddScoped<IPasajeroRepository, PasajeroRepository>();
        builder.Services.AddScoped<IPasajerosService, PasajeroService>();
        


        builder.Services.AddScoped<IReservaRepository, ReservaRepository>();
        builder.Services.AddScoped<IReservaService, ReservaService>();
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

        app.UseAuthentication();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}