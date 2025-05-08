using AutoMapper;
using BookingService.Data;
using BookingService.DTOs;
using BookingService.Models;
using BookingService.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookingService.Services
{
    public class BookingService : IBookingService
    {
        private readonly BookingDbContext _context;
        private readonly IMapper _mapper;

        public BookingService(BookingDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> CreateBookingAsync(CreateBookingRequest request)
        {
            var booking = _mapper.Map<Booking>(request);
            booking.CreatedAt = DateTime.UtcNow;
            booking.UpdatedAt = DateTime.UtcNow;

            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
            return booking.Id;
        }

        public async Task<List<BookingResponse>> GetAllBookingsAsync()
        {
            var bookings = await _context.Bookings.ToListAsync();
            return _mapper.Map<List<BookingResponse>>(bookings);
        }

        public async Task<BookingResponse?> GetBookingByIdAsync(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            return booking == null ? null : _mapper.Map<BookingResponse>(booking);
        }

        public async Task<bool> UpdateBookingAsync(int id, CreateBookingRequest request)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null)
                return false;

            _mapper.Map(request, booking);
            booking.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteBookingAsync(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null)
                return false;

            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}