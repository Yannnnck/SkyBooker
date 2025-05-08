namespace BookingService.DTOs
{
    public class CreateBookingRequest
    {
        public string FlightId { get; set; } = string.Empty;
        public string PassengerId { get; set; } = string.Empty;
        public string PassengerFirstname { get; set; } = string.Empty;
        public string PassengerLastname { get; set; } = string.Empty;
        public int TicketCount { get; set; }
    }
}
