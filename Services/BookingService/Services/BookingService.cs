using BookingService.Data;
using BookingService.Interfaces;
using BookingService.Models;

namespace BookingService.Services
{
    public class BookingService : IBookingService
    {
        private readonly BookingDbContext _context;

        public BookingService(BookingDbContext context)
        {
            _context = context;
        }

        public async Task<string> CreateBookingAsync(string flightId, string userId)
        {
            var booking = new Booking
            {
                FlightId = flightId,
                UserId = userId
            };

            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();

            return booking.FlightId; // oder wenn du später eine BookingId hinzufügst, booking.Id
        }
    }
}
