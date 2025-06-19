using BookingService.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingService.Data
{
    public class ApplicationDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=host.docker.internal,1433;User ID=sa;Password=Udemy#123;initial Catalog=CompanyDb;integrated Security=true;TrustServerCertificate=True;");
        }
        public DbSet<Booking> Bookings { get; set; }
    }
}
