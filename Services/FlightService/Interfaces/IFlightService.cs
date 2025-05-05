using FlightService.DTOs;

namespace FlightService.Interfaces
{
    public interface IFlightService
    {
        Task<string> CreateFlightAsync(CreateFlightRequest request);
        Task<List<FlightResponse>> GetAllFlightsAsync();
        Task<FlightResponse?> GetFlightByIdAsync(string id);
    }
}