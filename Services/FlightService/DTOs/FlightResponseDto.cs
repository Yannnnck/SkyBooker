namespace FlightService.DTOs
{
    public class FlightResponseDto
    {
        public string Id { get; set; }
        public string FlightId { get; set; } = string.Empty;
        public string AirlineName { get; set; } = string.Empty;
        public string Source { get; set; } = string.Empty;
        public string Destination { get; set; } = string.Empty;
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public int AvailableSeats { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
