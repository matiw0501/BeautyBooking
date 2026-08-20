using BeautyBooking.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BeautyBooking.Data
{
    public class DbSeeder
    {
        public static async Task SeedAsync(IServiceProvider services)
        {
            var db = services.GetRequiredService<ApplicationDbContext>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();

            await db.Database.MigrateAsync();

            string[] roles = { "Klient", "Pracownik", "Administrator" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
            const string adminEmail = "admin@klinikapiekna.pl";
            if (await userManager.FindByEmailAsync(adminEmail) is null) {
                var admin = new ApplicationUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true,
                    FirstName = "Admin",
                    LastName = "Admin"
                };
                await userManager.CreateAsync(admin, "Admin123!");
                await userManager.AddToRoleAsync(admin, "Administrator");
            }

            if (!await db.BookingStatuses.AnyAsync()) {
                db.BookingStatuses.AddRange(
                    new BookingStatus { Name = "Zarezerwowana" },
                    new BookingStatus { Name = "Czeka na przedpłate" }, //najlepiej 24h na oplacanie
                    new BookingStatus { Name = "Opłacona przedpłata" },
                    new BookingStatus { Name = "Zrealizowana" },
                    new BookingStatus { Name = "Nieobecność" },
                    new BookingStatus { Name = "Odwołana" }
                    );
                await db.SaveChangesAsync();
            }

            if (!await db.ServiceCategories.AnyAsync())
            {
                db.ServiceCategories.AddRange(
                    new ServiceCategory { Name = "Manicure" },
                    new ServiceCategory { Name = "Pedicure" },
                    new ServiceCategory { Name = "Zabiegi laserowe" },
                    new ServiceCategory { Name = "Zabiegi na twarz" }
                    );
                await db.SaveChangesAsync();
            }
            if (!await db.Services.AnyAsync())
            {
                var manicure = await db.ServiceCategories.FirstAsync(c => c.Name == "Manicure");
                var pedicure = await db.ServiceCategories.FirstAsync(c => c.Name == "Pedicure");
                var laser = await db.ServiceCategories.FirstAsync(c => c.Name == "Zabiegi laserowe");
                var twarz = await db.ServiceCategories.FirstAsync(c => c.Name == "Zabiegi na twarz");

                var listOfService = new List<Service>
                {
                    new() { Name = "Manicure hybrydowy", Description = "Trwaly manicure hybrydowy", DurationMinutes = 60, ServiceCategory = manicure},
                    new() { Name = "Pedicure klasyczny", Description = "Pielegnacja stop i paznokci", DurationMinutes = 75, ServiceCategory = pedicure},
                    new() { Name = "Epilacja laserowa nóg", Description = "Trwałe usuwanie owłosienia.", DurationMinutes = 45, ServiceCategory = laser },
                    new() { Name = "Oczyszczanie twarzy",  Description = "Głębokie oczyszczanie skóry.",  DurationMinutes = 60, ServiceCategory = twarz }
                };
                db.Services.AddRange(listOfService);
                await db.SaveChangesAsync();

                db.PriceListEntries.AddRange(
                    new() { Service = listOfService[0], Amount = 120m, ValidFrom = DateTime.UtcNow },
                    new() { Service = listOfService[1], Amount = 100m, ValidFrom = DateTime.UtcNow },
                    new() { Service = listOfService[2], Amount = 150m, ValidFrom = DateTime.UtcNow },
                    new() { Service = listOfService[3], Amount = 180m, ValidFrom = DateTime.UtcNow }
                    );
                await db.SaveChangesAsync( );
                   
            }
        }
    }
}
