using OnlineCourses.Core.Entities;

namespace OnlineCourses.Core.Interfaces;

public interface INotificationRepository : IRepository<Notification>
{
    Task<IEnumerable<Notification>> GetByUsuarioIdAsync(string usuarioId);
}
