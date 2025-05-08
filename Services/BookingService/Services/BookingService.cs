using AutoMapper;
using BookingService.Data;
using BookingService.DTOs;
using BookingService.Entities;
using BookingService.Interfaces;
using BookingService.Models;
using Microsoft.EntityFrameworkCore;
using Shared.Responses;
using System.Net.Http.Json;

namespace BookingService.Services
{
    public class BookingService : IBookingService
    {
        private readonly BookingDbContext _context;
        private readonly IMapper _mapper;
        private readonly HttpClient _httpClient;

        public BookingService(BookingDbContext context, IMapper mapper, HttpClient httpClient)
        {
            _context = context;
            _mapper = mapper;
            _httpClient = httpClient;
        }

        public async Task<BookingResponseDto> CreateBookingAsync(CreateBookingRequestDto request)
        {
            // Prüfen ob Flug existiert und genügend Plätze vorhanden sind
            var flightInfo = await _httpClient.GetFromJsonAsync<FlightInfoDto>($"http://localhost:5002/api/flight/{request.FlightId}");

            if (flightInfo == null)
                throw new InvalidOperationException("Flug existiert nicht");

            if (flightInfo.AvailableSeats < request.TicketCount)
                throw new InvalidOperationException("Nicht genügend freie Plätze verfügbar");

            // Neue Buchung erstellen
            var booking = new Booking
            {
                FlightId = request.FlightId,
                PassengerId = request.PassengerId,
                PassengerFirstname = request.PassengerFirstname,
                PassengerLastname = request.PassengerLastname,
                TicketCount = request.TicketCount,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();

            // TODO: Verfügbare Plätze beim FlightService reduzieren (z.B. PATCH oder PUT Aufruf)
            var reduceSeatsPayload = new { ticketCount = request.TicketCount };
            await _httpClient.PatchAsJsonAsync($"http://localhost:5002/api/flight/{request.FlightId}/decrease-seats", reduceSeatsPayload);

            return _mapper.Map<BookingResponseDto>(booking);
        }

        public async Task<List<BookingResponseDto>> GetAllBookingsAsync()
        {
            var bookings = await _context.Bookings.ToListAsync();
            return _mapper.Map<List<BookingResponseDto>>(bookings);
        }

        public async Task<BookingResponseDto?> GetBookingByIdAsync(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            return booking == null ? null : _mapper.Map<BookingResponseDto>(booking);
        }
    }
}
