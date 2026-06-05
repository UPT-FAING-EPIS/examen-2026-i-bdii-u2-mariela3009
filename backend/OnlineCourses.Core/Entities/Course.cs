using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace OnlineCourses.Core.Entities;

public class Course
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public string Categoria { get; set; } = string.Empty;
    public string Nivel { get; set; } = string.Empty;
    public int Duracion { get; set; }
    public string Instructor { get; set; } = string.Empty;
    public decimal Precio { get; set; }
    public List<string> Temario { get; set; } = new();
    public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
}
