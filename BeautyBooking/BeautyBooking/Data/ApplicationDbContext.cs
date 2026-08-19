using BeautyBooking.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BeautyBooking.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Service> Services => Set<Service>();
        public DbSet<ServiceCategory> ServiceCategories => Set<ServiceCategory>();
        public DbSet<PriceListEntry> PriceListEntries => Set<PriceListEntry>();
        public DbSet<Workstation> Workstations => Set<Workstation>();
        public DbSet<WorkstationCategory> WorkstationCategories => Set<WorkstationCategory>();
        public DbSet<EmployeeProfile> EmployeeProfiles => Set<EmployeeProfile>();
        public DbSet<EmployeeService> EmployeeServices => Set<EmployeeService>();
        public DbSet<Booking> Bookings => Set<Booking>();
        public DbSet<BookingStatus> BookingStatuses => Set<BookingStatus>();
        public DbSet<Review> Reviews => Set<Review>();



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Booking>().HasOne(b => b.Client).WithMany().HasForeignKey(b => b.ClientId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Booking>().HasOne(b => b.EmployeeProfile).WithMany().HasForeignKey(b => b.EmployeeProfileId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Booking>().HasOne(b => b.Service).WithMany().HasForeignKey(b => b.ServiceId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Booking>().HasOne(b => b.Workstation).WithMany().HasForeignKey(b => b.WorkstationId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Booking>().HasOne(b => b.BookingStatus).WithMany().HasForeignKey(b => b.BookingStatusId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<EmployeeProfile>().HasKey(e => e.ApplicationUserId);
            builder.Entity<EmployeeProfile>().HasOne(e => e.ApplicationUser).WithOne().HasForeignKey<EmployeeProfile>(e => e.ApplicationUserId);


            builder.Entity<EmployeeService>().HasKey(es => new { es.EmployeeProfileId, es.ServiceId });    
            builder.Entity<EmployeeService>().HasOne(es => es.EmployeeProfile).WithMany(e => e.EmployeeServices).HasForeignKey(es => es.EmployeeProfileId).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<EmployeeService>().HasOne(es => es.Service).WithMany(s => s.EmployeeServices).HasForeignKey(es => es.ServiceId).OnDelete(DeleteBehavior.Restrict);

            builder.Entity<WorkstationCategory>().HasKey(wc => new { wc.WorkstationId, wc.ServiceCategoryId });
            builder.Entity<WorkstationCategory>().HasOne(wc => wc.Workstation).WithMany(w => w.WorkstationCategories).HasForeignKey(wc => wc.WorkstationId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<WorkstationCategory>().HasOne(wc => wc.ServiceCategory).WithMany().HasForeignKey(wc => wc.ServiceCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<PriceListEntry>().Property(p => p.Amount).HasPrecision(18, 2);

            builder.Entity<Review>().HasKey(r => r.BookingId);
            builder.Entity<Booking>().HasOne(b => b.Review).WithOne(r => r.Booking).HasForeignKey<Review>(r => r.BookingId);

        }
    }
}
