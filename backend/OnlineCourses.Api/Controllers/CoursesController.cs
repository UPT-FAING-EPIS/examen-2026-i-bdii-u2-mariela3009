using Microsoft.AspNetCore.Mvc;
using OnlineCourses.Core.Entities;
using OnlineCourses.Core.Interfaces;

namespace OnlineCourses.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CoursesController : ControllerBase
{
    private readonly ICourseRepository _courseRepository;

    public CoursesController(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] string? categoria, [FromQuery] string? nivel)
    {
        var courses = await _courseRepository.GetByFilterAsync(categoria, nivel);
        return Ok(courses);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(string id)
    {
        var course = await _courseRepository.GetByIdAsync(id);
        if (course is null)
        {
            return NotFound();
        }

        return Ok(course);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] Course course)
    {
        if (course is null)
        {
            return BadRequest();
        }

        await _courseRepository.CreateAsync(course);
        return CreatedAtAction(nameof(GetByIdAsync), new { id = course.Id }, course);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(string id, [FromBody] Course course)
    {
        if (course is null || string.IsNullOrWhiteSpace(id))
        {
            return BadRequest();
        }

        var existing = await _courseRepository.GetByIdAsync(id);
        if (existing is null)
        {
            return NotFound();
        }

        course.Id = id;
        await _courseRepository.UpdateAsync(id, course);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(string id)
    {
        var existing = await _courseRepository.GetByIdAsync(id);
        if (existing is null)
        {
            return NotFound();
        }

        await _courseRepository.DeleteAsync(id);
        return NoContent();
    }
}
