using BookingService.DTOs;
using BookingService.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Shared.Responses;

namespace BookingService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Erstellt eine Buchung")]
        [ProducesResponseType(typeof(ApiResponse<int>), 200)]
        public async Task<IActionResult> CreateBooking([FromBody] CreateBookingRequest request)
        {
            var id = await _bookingService.CreateBookingAsync(request);
            return Ok(ApiResponse<int>.SuccessResponse(id, "Buchung erfolgreich erstellt"));
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Alle Buchungen abrufen")]
        [ProducesResponseType(typeof(ApiResponse<List<BookingResponse>>), 200)]
        public async Task<IActionResult> GetAllBookings()
        {
            var bookings = await _bookingService.GetAllBookingsAsync();
            return Ok(ApiResponse<List<BookingResponse>>.SuccessResponse(bookings, "Alle Buchungen"));
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Eine Buchung per ID abrufen")]
        [ProducesResponseType(typeof(ApiResponse<BookingResponse>), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetBookingById(int id)
        {
            var booking = await _bookingService.GetBookingByIdAsync(id);
            if (booking == null)
                return NotFound(ApiResponse<string>.FailureResponse("Buchung nicht gefunden"));

            return Ok(ApiResponse<BookingResponse>.SuccessResponse(booking, "Buchung gefunden"));
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Eine Buchung aktualisieren")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> UpdateBooking(int id, [FromBody] CreateBookingRequest request)
        {
            var success = await _bookingService.UpdateBookingAsync(id, request);
            if (!success)
                return NotFound(ApiResponse<string>.FailureResponse("Buchung nicht gefunden"));

            return NoContent();
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Eine Buchung löschen")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var success = await _bookingService.DeleteBookingAsync(id);
            if (!success)
                return NotFound(ApiResponse<string>.FailureResponse("Buchung nicht gefunden"));

            return NoContent();
        }
    }
}
