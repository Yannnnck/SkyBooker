using FlightService.DTOs;

namespace FlightService.Interfaces
{
    public interface IFlightService
    {
        Task<string> CreateFlightAsync(CreateFlightDto dto);
        Task<List<FlightResponseDto>> GetAllFlightsAsync();
        Task<FlightResponseDto?> GetFlightByIdAsync(string id);
    }
}