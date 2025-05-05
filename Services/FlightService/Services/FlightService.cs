using FlightService.Data;
using FlightService.DTOs;
using FlightService.Interfaces;
using FlightService.Models;
using MongoDB.Driver;

namespace FlightService.Services
{
    public class FlightService : IFlightService
    {
        private readonly MongoDbContext _context;

        public FlightService(MongoDbContext context)
        {
            _context = context;
        }

        public async Task<string> CreateFlightAsync(CreateFlightRequest request)
        {
            var flight = new Flight
            {
                FlightId = request.FlightId,
                AirlineName = request.AirlineName,
                Source = request.Source,
                Destination = request.Destination,
                DepartureTime = request.DepartureTime,
                ArrivalTime = request.ArrivalTime,
                AvailableSeats = request.AvailableSeats,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _context.Flights.InsertOneAsync(flight);
            return flight.Id;
        }

        public async Task<List<FlightResponse>> GetAllFlightsAsync()
        {
            var flights = await _context.Flights.Find(_ => true).ToListAsync();

            return flights.Select(f => new FlightResponse
            {
                Id = f.Id,
                FlightId = f.FlightId,
                AirlineName = f.AirlineName,
                Source = f.Source,
                Destination = f.Destination,
                DepartureTime = f.DepartureTime,
                ArrivalTime = f.ArrivalTime,
                AvailableSeats = f.AvailableSeats
            }).ToList();
        }

        public async Task<FlightResponse?> GetFlightByIdAsync(string id)
        {
            var flight = await _context.Flights.Find(f => f.Id == id).FirstOrDefaultAsync();
            if (flight == null) return null;

            return new FlightResponse
            {
                Id = flight.Id,
                FlightId = flight.FlightId,
                AirlineName = flight.AirlineName,
                Source = flight.Source,
                Destination = flight.Destination,
                DepartureTime = flight.DepartureTime,
                ArrivalTime = flight.ArrivalTime,
                AvailableSeats = flight.AvailableSeats
            };
        }
    }
}
