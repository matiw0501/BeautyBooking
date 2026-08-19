using BeautyBooking.Data;

namespace BeautyBooking.Models
{
    public class EmployeeProfile
    {
        public string ApplicationUserId { get; set; } = string.Empty;
        public ApplicationUser ApplicationUser { get; set; } = null!;
        public string PhotoUrl { get; set; } = string.Empty;
        public Boolean IsActive { get; set; } = true;

        public ICollection<EmployeeService> EmployeeServices { get; set; } = new List<EmployeeService>();
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
