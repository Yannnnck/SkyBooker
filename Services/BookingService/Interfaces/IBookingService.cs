namespace BookingService.Interfaces
{
    public interface IBookingService
    {
        Task<string> CreateBookingAsync(string flightId, string userId);
    }
}
