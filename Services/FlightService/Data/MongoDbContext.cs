using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace FlightService.Data
{
    public class MongoDbContext
    {
        public IMongoDatabase Database { get; }

        public MongoDbContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetConnectionString("MongoDb"));
            Database = client.GetDatabase("SkyBookerDb");
        }
    }
}
