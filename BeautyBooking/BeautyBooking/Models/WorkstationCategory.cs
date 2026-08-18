namespace BeautyBooking.Models
{
    public class WorkstationCategory
    {
        public int WorkstationId { get; set; }
        public Workstation Workstation { get; set; } = null!;

        public int ServiceCategoryId { get; set; }
        public ServiceCategory ServiceCategory { get; set; } = null!;
    }
}
