using MongoDB.Driver;
using OnlineCourses.Core.Entities;
using OnlineCourses.Core.Interfaces;

namespace OnlineCourses.Infrastructure.Repositories;

public class EnrollmentRepository : IEnrollmentRepository
{
    private readonly IMongoCollection<Enrollment> _enrollments;

    public EnrollmentRepository(MongoDbContext dbContext)
    {
        _enrollments = dbContext.Database.GetCollection<Enrollment>("Enrollments");
    }

    public async Task<IEnumerable<Enrollment>> GetAllAsync()
    {
        return await _enrollments.Find(Builders<Enrollment>.Filter.Empty).ToListAsync();
    }

    public async Task<Enrollment?> GetByIdAsync(string id)
    {
        var filter = Builders<Enrollment>.Filter.Eq(x => x.Id, id);
        return await _enrollments.Find(filter).FirstOrDefaultAsync();
    }

    public async Task CreateAsync(Enrollment entity)
    {
        await _enrollments.InsertOneAsync(entity);
    }

    public async Task UpdateAsync(string id, Enrollment entity)
    {
        var filter = Builders<Enrollment>.Filter.Eq(x => x.Id, id);
        await _enrollments.ReplaceOneAsync(filter, entity);
    }

    public async Task DeleteAsync(string id)
    {
        var filter = Builders<Enrollment>.Filter.Eq(x => x.Id, id);
        await _enrollments.DeleteOneAsync(filter);
    }

    public async Task<IEnumerable<Enrollment>> GetByUsuarioIdAsync(string usuarioId)
    {
        var filter = Builders<Enrollment>.Filter.Eq(x => x.UsuarioId, usuarioId);
        return await _enrollments.Find(filter).ToListAsync();
    }

    public async Task<Enrollment?> GetByUsuarioAndCursoAsync(string usuarioId, string cursoId)
    {
        var filter = Builders<Enrollment>.Filter.And(
            Builders<Enrollment>.Filter.Eq(x => x.UsuarioId, usuarioId),
            Builders<Enrollment>.Filter.Eq(x => x.CursoId, cursoId)
        );

        return await _enrollments.Find(filter).FirstOrDefaultAsync();
    }
}
