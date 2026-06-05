using Microsoft.AspNetCore.Mvc;
using OnlineCourses.Core.Entities;
using OnlineCourses.Core.Interfaces;

namespace OnlineCourses.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EnrollmentsController : ControllerBase
{
    private readonly IEnrollmentRepository _enrollmentRepository;
    private readonly ICourseRepository _courseRepository;

    public EnrollmentsController(
        IEnrollmentRepository enrollmentRepository,
        ICourseRepository courseRepository)
    {
        _enrollmentRepository = enrollmentRepository;
        _courseRepository = courseRepository;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] Enrollment enrollment)
    {
        if (enrollment is null || string.IsNullOrWhiteSpace(enrollment.UsuarioId) || string.IsNullOrWhiteSpace(enrollment.CursoId))
        {
            return BadRequest();
        }

        var course = await _courseRepository.GetByIdAsync(enrollment.CursoId);
        if (course is null)
        {
            return BadRequest(new { Message = "Curso no encontrado." });
        }

        await _enrollmentRepository.CreateAsync(enrollment);
        return CreatedAtAction(nameof(GetByUsuarioIdAsync), new { userId = enrollment.UsuarioId }, enrollment);
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetByUsuarioIdAsync(string userId)
    {
        if (string.IsNullOrWhiteSpace(userId))
        {
            return BadRequest();
        }

        var enrollments = await _enrollmentRepository.GetByUsuarioIdAsync(userId);
        var courseIds = enrollments.Select(x => x.CursoId).Distinct();
        var courses = new List<Course>();

        foreach (var courseId in courseIds)
        {
            var course = await _courseRepository.GetByIdAsync(courseId);
            if (course is not null)
            {
                courses.Add(course);
            }
        }

        return Ok(new
        {
            UserId = userId,
            Enrollments = enrollments,
            Courses = courses
        });
    }
}
