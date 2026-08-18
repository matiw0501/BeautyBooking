namespace BeautyBooking.Models
{
    public class EmployeeService
    {
        public string EmployeeProfileId { get; set; } = string.Empty;
        public EmployeeProfile EmployeeProfile { get; set; } = null!;

        public int ServiceId { get; set; }
        public Service Service { get; set; } = null!;
    }
}
