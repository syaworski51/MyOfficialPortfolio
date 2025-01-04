using MongoDB.Driver;

namespace MyOfficialPortfolio.Data
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IConfiguration configuration)
        {
            var secrets = configuration.GetSection("Secrets:MongoDB");
            var connectionString = secrets["ConnectionString"];
            var database = secrets["Database"];

            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(database);
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return _database.GetCollection<T>(name);
        }
    }
}
