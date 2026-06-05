using OnlineCourses.Core.Entities;

namespace OnlineCourses.Core.Interfaces;

public interface IEnrollmentService
{
    Task<Enrollment> EnrollAsync(string usuarioId, string cursoId);
    Task<IEnumerable<Enrollment>> GetByUsuarioIdAsync(string usuarioId);
}
