namespace BeautyBooking.Models
{
    public class Workstation
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Priority { get; set; }
        public Boolean isActive { get; set; } = true;

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
        public ICollection<WorkstationCategory> WorkstationCategories { get; set; } = new List<WorkstationCategory>();
    }
}
