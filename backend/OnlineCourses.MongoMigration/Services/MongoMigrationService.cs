using MongoDB.Driver;
using OnlineCourses.Core.Entities;
using OnlineCourses.MongoMigration.Interfaces;

namespace OnlineCourses.MongoMigration.Services;

public class MongoMigrationService : IMongoMigrationService
{
    private readonly IMongoDatabase _database;
    private readonly IMongoCollection<Course> _courses;
    private readonly IMongoCollection<User> _users;

    public MongoMigrationService(IMongoDatabase database)
    {
        _database = database ?? throw new ArgumentNullException(nameof(database));
        _courses = _database.GetCollection<Course>("Courses");
        _users = _database.GetCollection<User>("Users");
    }

    public void ApplyMigrations()
    {
        SeedCourses();
        SeedUsers();
    }

    private void SeedCourses()
    {
        var courseCount = _courses.CountDocuments(FilterDefinition<Course>.Empty);
        if (courseCount > 0)
        {
            return;
        }

        var seedCourses = new[]
        {
            new Course
            {
                Titulo = "C# Avanzado",
                Descripcion = "Domina C# moderno, patrones y buenas prácticas.",
                Categoria = "Programación",
                Nivel = "Avanzado",
                Duracion = 40,
                Instructor = "Ana Pérez",
                Precio = 199.99m,
                Temario = new List<string>
                {
                    "Clases y objetos",
                    "Delegados y eventos",
                    "LINQ avanzado",
                    "Patrones de diseño"
                },
                FechaCreacion = DateTime.UtcNow
            },
            new Course
            {
                Titulo = "Introducción a MongoDB",
                Descripcion = "Aprende a modelar datos, consultas y administración de MongoDB.",
                Categoria = "Bases de Datos",
                Nivel = "Intermedio",
                Duracion = 25,
                Instructor = "Carlos Gómez",
                Precio = 149.50m,
                Temario = new List<string>
                {
                    "Fundamentos de NoSQL",
                    "Modelado de documentos",
                    "Consultas y agregaciones",
                    "Replica sets y seguridad"
                },
                FechaCreacion = DateTime.UtcNow
            },
            new Course
            {
                Titulo = "Frontend con Angular",
                Descripcion = "Construye interfaces modernas para tu aplicación de cursos.",
                Categoria = "Desarrollo Web",
                Nivel = "Principiante",
                Duracion = 30,
                Instructor = "María López",
                Precio = 129.00m,
                Temario = new List<string>
                {
                    "Componentes y servicios",
                    "Rutas y formularios",
                    "Consumo de APIs",
                    "Despliegue básico"
                },
                FechaCreacion = DateTime.UtcNow
            }
        };

        _courses.InsertMany(seedCourses);
    }

    private void SeedUsers()
    {
        var userCount = _users.CountDocuments(FilterDefinition<User>.Empty);
        if (userCount > 0)
        {
            return;
        }

        var adminUser = new User
        {
            Nombre = "Administrador",
            Correo = "admin@onlinecourses.com",
            ContraseñaHash = "Admin1234!", // Hash simulado por ahora
            Rol = "Admin",
            FechaRegistro = DateTime.UtcNow
        };

        _users.InsertOne(adminUser);
    }
}
