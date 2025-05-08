using AutoMapper;
using FlightService.DTOs;
using FlightService.Interfaces;
using FlightService.Models;
using MongoDB.Driver;

namespace FlightService.Services
{
    public class FlightService : IFlightService
    {
        private readonly IMongoCollection<Flight> _flightCollection;
        private readonly IMapper _mapper;

        public FlightService(IMongoDatabase database, IMapper mapper)
        {
            _flightCollection = database.GetCollection<Flight>("flights");
            _mapper = mapper;
        }

        public async Task<string> CreateFlightAsync(CreateFlightDto dto)
        {
            var flight = _mapper.Map<Flight>(dto);
            await _flightCollection.InsertOneAsync(flight);
            return flight.Id;
        }

        public async Task<List<FlightResponseDto>> GetAllFlightsAsync()
        {
            var flights = await _flightCollection.Find(_ => true).ToListAsync();
            return _mapper.Map<List<FlightResponseDto>>(flights);
        }

        public async Task<FlightResponseDto?> GetFlightByIdAsync(string id)
        {
            var flight = await _flightCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
            return flight == null ? null : _mapper.Map<FlightResponseDto>(flight);
        }

        public async Task<bool> UpdateFlightAsync(string id, UpdateFlightDto dto)
        {
            var filter = Builders<Flight>.Filter.Eq(f => f.Id, id);
            var update = Builders<Flight>.Update
                .Set(f => f.AirlineName, dto.AirlineName)
                .Set(f => f.Source, dto.Source)
                .Set(f => f.Destination, dto.Destination)
                .Set(f => f.DepartureTime, dto.DepartureTime)
                .Set(f => f.ArrivalTime, dto.ArrivalTime)
                .Set(f => f.AvailableSeats, dto.AvailableSeats)
                .Set(f => f.UpdatedAt, DateTime.UtcNow);

            var result = await _flightCollection.UpdateOneAsync(filter, update);
            return result.MatchedCount > 0;
        }

        public async Task<bool> DeleteFlightAsync(string id)
        {
            var result = await _flightCollection.DeleteOneAsync(f => f.Id == id);
            return result.DeletedCount > 0;
        }
        public async Task<bool> ReduceSeatsAsync(string flightId, int ticketCount)
        {
            var flight = await _flightCollection.Find(f => f.FlightId == flightId).FirstOrDefaultAsync();
            if (flight == null || flight.AvailableSeats < ticketCount)
                return false;

            var update = Builders<Flight>.Update
                .Inc(f => f.AvailableSeats, -ticketCount)
                .Set(f => f.UpdatedAt, DateTime.UtcNow);

            var result = await _flightCollection.UpdateOneAsync(f => f.FlightId == flightId, update);

            return result.ModifiedCount > 0;
        }

    }
}