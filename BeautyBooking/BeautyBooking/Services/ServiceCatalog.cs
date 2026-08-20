using BeautyBooking.Data;
using Microsoft.EntityFrameworkCore;

namespace BeautyBooking.Services
{
    public record ServiceListItem(
           int Id,
           string Name,
           string CategoryName,
           int DurationMinutes,
           decimal? CurrentPrice
           );
    public class ServiceCatalog(ApplicationDbContext db)
    {
        public async Task<List<ServiceListItem>> GetActiveServicesAsync()
        {
            var now = DateTime.UtcNow;

            return await db.Services.Where(s => s.IsActive).OrderBy(s => s.ServiceCategory.Name).ThenBy(s => s.Name)
                .Select(s => new ServiceListItem(
                    s.Id,
                    s.Name,
                    s.ServiceCategory.Name,
                    s.DurationMinutes,
                    s.Prices
                        .Where(p => p.ValidFrom <= now && (p.ValidTo == null || p.ValidTo >= now))
                        .OrderByDescending(p => p.ValidFrom)
                        .Select(p => (decimal?)p.Amount)
                        .FirstOrDefault()))
                    .ToListAsync();
                        
        }

       

    }
}
