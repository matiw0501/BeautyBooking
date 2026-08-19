using System.ComponentModel.DataAnnotations;

namespace BeautyBooking.Models
{
    public class BookingStatus
    {
        public int Id { get; set; }
        [MaxLength(30)] public string Name { get; set; } = string.Empty;

    }
}
