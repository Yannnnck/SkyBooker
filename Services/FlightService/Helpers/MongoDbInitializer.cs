using MongoDB.Driver;
using FlightService.Data;
using FlightService.Models;

namespace FlightService.Helpers
{
    public static class MongoDbInitializer
    {
        public static void Initialize(MongoDbContext context)
        {
            var database = context.Database;

            // Sicherstellen, dass die Collection existiert
            var collections = database.ListCollectionNames().ToList();
            if (!collections.Contains("flights"))
            {
                database.CreateCollection("flights");
            }

            // Optional: Beispiel-Daten einfügen, wenn du willst
            var flights = database.GetCollection<Flight>("flights");
            if (flights.CountDocuments(_ => true) == 0)
            {
                flights.InsertOne(new Flight
                {
                    FlightId = "SKY100",
                    AirlineName = "Sky Airlines",
                    Source = "Zürich",
                    Destination = "Berlin",
                    DepartureTime = DateTime.UtcNow.AddHours(2),
                    ArrivalTime = DateTime.UtcNow.AddHours(4),
                    AvailableSeats = 150,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                });
            }
        }
    }
}
