namespace BookingService.DTOs
{
    public class BookingResponse
    {
        public int Id { get; set; }
        public string FlightId { get; set; } = string.Empty;
        public string PassengerId { get; set; } = string.Empty;
        public string PassengerFirstname { get; set; } = string.Empty;
        public string PassengerLastname { get; set; } = string.Empty;
        public int TicketCount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
