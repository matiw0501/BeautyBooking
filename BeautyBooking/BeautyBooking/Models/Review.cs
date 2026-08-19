using System.ComponentModel.DataAnnotations;

namespace BeautyBooking.Models
{
    public class Review
    {
        public int BookingId { get; set; }
        public Booking Booking { get; set; } = null!;
        
        [MaxLength(400)]public string Content { get; set; } = string.Empty;
        [MaxLength(200)] public string PhotoUrl { get; set; } = string.Empty;

    }
}
