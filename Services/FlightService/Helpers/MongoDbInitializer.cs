using MongoDB.Driver;
using FlightService.Models;

namespace FlightService.Data
{
    public static class MongoDbInitializer
    {
        public static void Initialize(MongoDbContext context)
        {
            // Prüfen, ob Flights Collection existiert
            var collectionNames = context.Flights.Database.ListCollectionNames().ToList();
            if (!collectionNames.Contains(nameof(Flight)))
            {
                context.Database.CreateCollection(nameof(Flight));
            }
        }
    }
}
