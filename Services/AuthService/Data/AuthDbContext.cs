using Microsoft.EntityFrameworkCore;

namespace AuthService.Data
{
    public class AuthDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=mssql;User ID=sa;Password=YourStrong!Passw0rd;initial Catalog=CompanyDb;integrated Security=true;TrustServerCertificate=True;");
        }
        public DbSet<Entities.User> Users { get; set; }
    }
}
