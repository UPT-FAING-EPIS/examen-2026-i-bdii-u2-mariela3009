using OnlineCourses.Core.Entities;

namespace OnlineCourses.Core.Interfaces;

public interface IUserRepository : IRepository<User>
{
    Task<User?> GetByEmailAsync(string correo);
}
