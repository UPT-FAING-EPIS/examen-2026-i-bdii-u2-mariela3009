namespace OnlineCourses.Core.Interfaces;

public interface IUnitOfWork
{
    ICourseRepository Courses { get; }
    IEnrollmentRepository Enrollments { get; }
    IUserRepository Users { get; }
    INotificationRepository Notifications { get; }
    Task CommitAsync();
}
