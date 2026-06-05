using Microsoft.Extensions.Options;
using MongoDB.Driver;
using OnlineCourses.Core.Settings;

namespace OnlineCourses.Infrastructure;

public class MongoDbContext
{
    public IMongoClient Client { get; }
    public IMongoDatabase Database { get; }

    public MongoDbContext(IOptions<MongoDbSettings> settings)
    {
        var mongoSettings = settings?.Value ?? throw new ArgumentNullException(nameof(settings));

        if (string.IsNullOrWhiteSpace(mongoSettings.ConnectionString))
        {
            throw new ArgumentException("MongoDB connection string is required.", nameof(settings));
        }

        if (string.IsNullOrWhiteSpace(mongoSettings.DatabaseName))
        {
            throw new ArgumentException("MongoDB database name is required.", nameof(settings));
        }

        Client = new MongoClient(mongoSettings.ConnectionString);
        Database = Client.GetDatabase(mongoSettings.DatabaseName);
    }
}
