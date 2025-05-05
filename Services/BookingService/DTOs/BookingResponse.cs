namespace BookingService.DTOs
{
    public class BookingResponse
    {
        public string Id { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public string FlightId { get; set; } = string.Empty;
        public DateTime BookingDate { get; set; }
    }
}
