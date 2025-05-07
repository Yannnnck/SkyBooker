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
    }
}