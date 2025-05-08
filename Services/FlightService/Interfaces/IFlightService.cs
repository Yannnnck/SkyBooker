using FlightService.DTOs;

namespace FlightService.Interfaces
{
    public interface IFlightService
    {
        Task<string> CreateFlightAsync(CreateFlightDto dto);
        Task<List<FlightResponseDto>> GetAllFlightsAsync();
        Task<FlightResponseDto?> GetFlightByIdAsync(string id);
        Task<bool> ReduceSeatsAsync(string flightId, int ticketCount);
        Task<bool> UpdateFlightAsync(string id, UpdateFlightDto dto);
        Task<bool> DeleteFlightAsync(string id);
    }
}
