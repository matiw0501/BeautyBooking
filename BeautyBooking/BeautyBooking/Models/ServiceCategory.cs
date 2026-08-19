using System.ComponentModel.DataAnnotations;

namespace BeautyBooking.Models
{
    public class ServiceCategory
    {
        public int Id { get; set; }
        [MaxLength(30)] public string Name { get; set; } = string.Empty;

        public ICollection<Service> Services { get; set; } = new List<Service>();
    }
}
