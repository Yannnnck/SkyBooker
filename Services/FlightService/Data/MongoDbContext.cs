using FlightService.Models;
using MongoDB.Driver;

public class MongoDbContext
{
    public IMongoDatabase Database { get; }
    public IMongoCollection<Flight> Flights { get; }

    public MongoDbContext(IConfiguration configuration)
    {
        var client = new MongoClient(configuration.GetConnectionString("MongoDb"));
        Database = client.GetDatabase("FlightDb");

        Flights = Database.GetCollection<Flight>(nameof(Flight));
    }
}
