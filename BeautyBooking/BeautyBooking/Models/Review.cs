namespace BeautyBooking.Models
{
    public class Review
    {
        public int BookingId { get; set; }
        public Booking Booking { get; set; } = null!;
        
        public string Content { get; set; } = string.Empty;
        public string PhotoUrl { get; set; } = string.Empty;

    }
}
