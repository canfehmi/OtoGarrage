using BookingService.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingService.Data
{
    public class ApplicationDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=mssql;User ID=sa;Password=YourStrong!Passw0rd;initial Catalog=CompanyDb;TrustServerCertificate=True;");
        }
        public DbSet<Booking> Bookings { get; set; }
    }
}
