namespace BeautyBooking.Models
{
    public class PriceListEntry
    {
        public int Id { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
        public decimal Amount { get; set; }

        public int ServiceId { get; set; }
        public Service Service { get; set; } = null!;
    }
}
