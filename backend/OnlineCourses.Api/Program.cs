using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using OnlineCourses.Core.Settings;
using OnlineCourses.Core.Interfaces;
using OnlineCourses.Infrastructure;
using OnlineCourses.Infrastructure.Repositories;
using OnlineCourses.MongoMigration.Interfaces;
using OnlineCourses.MongoMigration.Services;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// 1. Configurar y mapear la sección de MongoDB desde appsettings.json
builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDb"));

// 2. Registrar el contexto único de conexión a MongoDB Atlas (Singleton)
builder.Services.AddSingleton<MongoDbContext>();

// 3. Registrar el driver de IMongoDatabase directamente extrayéndolo de nuestro contexto
builder.Services.AddScoped<IMongoDatabase>(sp => sp.GetRequiredService<MongoDbContext>().Database);

// 4. Registrar la librería de migración automática de datos NoSQL
builder.Services.AddScoped<IMongoMigrationService, MongoMigrationService>();

// 5. Registrar los Repositorios de datos (Scoped)
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();

// 6. Configuraciones básicas de la API (Controladores y Swagger)
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuración de CORS para el Frontend Angular
builder.Services.AddCors(options =>
{
    options.AddPolicy("FrontendPolicy", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Configuración de Autenticación JWT basada en tus configuraciones del JSON
var jwtSettings = builder.Configuration.GetSection("Jwt");
var key = Encoding.UTF8.GetBytes(jwtSettings["Secret"] ?? "CambiarEstaClaveMuySegura123!");

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});

builder.Services.AddAuthorization();

var app = builder.Build();

// === INVOCACIÓN AUTOMÁTICA DE LA MIGRACIÓN NO SQL ===
using (var scope = app.Services.CreateScope())
{
    try
    {
        var migrationService = scope.ServiceProvider.GetRequiredService<IMongoMigrationService>();
        migrationService.ApplyMigrations();
        Console.WriteLine("--> ¡Migración y Seed Data aplicados con éxito en MongoDB Atlas! <--");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"--> Error al ejecutar la migración: {ex.Message} <--");
    }
}

// Pipeline de ejecución de Middlewares
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("FrontendPolicy");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();