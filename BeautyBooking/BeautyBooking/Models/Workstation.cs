using System.ComponentModel.DataAnnotations;

namespace BeautyBooking.Models
{
    public class Workstation
    {
        public int Id { get; set; }
        [MaxLength(50)] public string Name { get; set; } = string.Empty;
        public int Priority { get; set; }
        public Boolean IsActive { get; set; } = true;

        public ICollection<WorkstationCategory> WorkstationCategories { get; set; } = new List<WorkstationCategory>();
    }
}
