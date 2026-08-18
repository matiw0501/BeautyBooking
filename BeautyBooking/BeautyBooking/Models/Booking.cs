using BeautyBooking.Data;

namespace BeautyBooking.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }

        public string ClientId { get; set; } = string.Empty;
        public ApplicationUser Client { get; set; } = null!;

        public string EmployeeProfileId { get; set; } = string.Empty;
        public EmployeeProfile EmployeeProfile { get; set; } = null!;


        public int ServiceId { get; set; }
        public Service Service { get; set; }

        public int WorkstationId { get; set; }
        public Workstation Workstation { get; set; } = null!;

        public int BookingStatusId  { get; set; }
        public BookingStatus BookingStatus { get; set; } = null!;

        public Review? Review { get; set; }


    }
}
