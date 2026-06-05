using OnlineCourses.Core.Entities;

namespace OnlineCourses.Core.Interfaces;

public interface ICourseRepository : IRepository<Course>
{
    Task<IEnumerable<Course>> GetByFilterAsync(string? categoria, string? nivel);
}
