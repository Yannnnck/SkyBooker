using System.ComponentModel.DataAnnotations;

namespace BookingService.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }

        public string FlightId { get; set; } = string.Empty;

        public string UserId { get; set; } = string.Empty;

        public DateTime BookingDate { get; set; }
    }
}
