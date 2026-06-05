using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace OnlineCourses.Core.Entities;

public class Enrollment
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    [BsonRepresentation(BsonType.ObjectId)]
    public string UsuarioId { get; set; } = string.Empty;
    [BsonRepresentation(BsonType.ObjectId)]
    public string CursoId { get; set; } = string.Empty;
    public DateTime FechaMatricula { get; set; } = DateTime.UtcNow;
    public string Estado { get; set; } = "Activo";
    public int Progreso { get; set; }
}
