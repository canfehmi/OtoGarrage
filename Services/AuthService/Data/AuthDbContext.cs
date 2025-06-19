using Microsoft.EntityFrameworkCore;

namespace AuthService.Data
{
    public class AuthDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=host.docker.internal,1433;User ID=sa;Password=Udemy#123;initial Catalog=CompanyDb;integrated Security=true;TrustServerCertificate=True;");
        }
        public DbSet<Entities.User> Users { get; set; }
    }
}
