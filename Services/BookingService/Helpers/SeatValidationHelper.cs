namespace BookingService.Helpers
{
    public static class SeatValidationHelper
    {
        public static bool ValidateSeats(int availableSeats, int requestedSeats)
        {
            if (availableSeats <= 0)
                return false;

            if (requestedSeats <= 0)
                return false;

            return availableSeats >= requestedSeats;
        }
    }
}
