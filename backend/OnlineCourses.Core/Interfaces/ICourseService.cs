using OnlineCourses.Core.Entities;

namespace OnlineCourses.Core.Interfaces;

public interface ICourseService
{
    Task<IEnumerable<Course>> GetAllAsync(string? categoria, string? nivel);
    Task<Course?> GetByIdAsync(string id);
    Task<Course> CreateAsync(Course course);
    Task UpdateAsync(string id, Course course);
    Task DeleteAsync(string id);
}
