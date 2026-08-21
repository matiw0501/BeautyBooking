using System.ComponentModel.DataAnnotations;

namespace BeautyBooking.Models
{
    public class Service
    {
        public int Id { get; set; }
        [MaxLength(40)] public string Name { get; set; } = string.Empty;
        [MaxLength(400)] public string Description { get; set; } = string.Empty;
        public int DurationMinutes { get; set; }
        public Boolean IsActive { get; set; } = true;
        [MaxLength(512)] public string? ImageUrl { get; set; } 

        public int ServiceCategoryId { get; set; }
        public ServiceCategory ServiceCategory { get; set; } = null!;

        public ICollection<PriceListEntry> Prices { get; set; } = new List<PriceListEntry>();
        public ICollection<EmployeeService> EmployeeServices { get; set; } = new List<EmployeeService>();

    }
}
