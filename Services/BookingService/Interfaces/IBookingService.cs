using BookingService.DTOs;

namespace BookingService.Interfaces
{
    public interface IBookingService
    {
        Task<int> CreateBookingAsync(CreateBookingRequest request);
        Task<List<BookingResponse>> GetAllBookingsAsync();
        Task<BookingResponse> GetBookingByIdAsync(int id);
        Task<bool> UpdateBookingAsync(int id, CreateBookingRequest request);
        Task<bool> DeleteBookingAsync(int id);
    }
}
