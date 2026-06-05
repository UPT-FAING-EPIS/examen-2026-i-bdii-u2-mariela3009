using OnlineCourses.Core.Entities;

namespace OnlineCourses.Core.Interfaces;

public interface IEnrollmentRepository : IRepository<Enrollment>
{
    Task<IEnumerable<Enrollment>> GetByUsuarioIdAsync(string usuarioId);
    Task<Enrollment?> GetByUsuarioAndCursoAsync(string usuarioId, string cursoId);
}
