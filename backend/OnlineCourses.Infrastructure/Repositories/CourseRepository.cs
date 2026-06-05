using MongoDB.Driver;
using OnlineCourses.Core.Entities;
using OnlineCourses.Core.Interfaces;

namespace OnlineCourses.Infrastructure.Repositories;

public class CourseRepository : ICourseRepository
{
    private readonly IMongoCollection<Course> _courses;

    public CourseRepository(MongoDbContext dbContext)
    {
        _courses = dbContext.Database.GetCollection<Course>("Courses");
    }

    public async Task<IEnumerable<Course>> GetAllAsync()
    {
        return await _courses.Find(Builders<Course>.Filter.Empty).ToListAsync();
    }

    public async Task<Course?> GetByIdAsync(string id)
    {
        var filter = Builders<Course>.Filter.Eq(x => x.Id, id);
        return await _courses.Find(filter).FirstOrDefaultAsync();
    }

    public async Task CreateAsync(Course entity)
    {
        await _courses.InsertOneAsync(entity);
    }

    public async Task UpdateAsync(string id, Course entity)
    {
        var filter = Builders<Course>.Filter.Eq(x => x.Id, id);
        await _courses.ReplaceOneAsync(filter, entity);
    }

    public async Task DeleteAsync(string id)
    {
        var filter = Builders<Course>.Filter.Eq(x => x.Id, id);
        await _courses.DeleteOneAsync(filter);
    }

    public async Task<IEnumerable<Course>> GetByFilterAsync(string? categoria, string? nivel)
    {
        var filter = Builders<Course>.Filter.Empty;

        if (!string.IsNullOrWhiteSpace(categoria))
        {
            filter &= Builders<Course>.Filter.Eq(x => x.Categoria, categoria);
        }

        if (!string.IsNullOrWhiteSpace(nivel))
        {
            filter &= Builders<Course>.Filter.Eq(x => x.Nivel, nivel);
        }

        return await _courses.Find(filter).ToListAsync();
    }
}
