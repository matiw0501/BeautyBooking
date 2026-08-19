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
        }
    }
}
