using CompanyService.Entities;
using Microsoft.EntityFrameworkCore;

namespace CompanyService.Data
{
    public class ApplicationDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=host.docker.internal,1433;User ID=sa;Password=Udemy#123;initial Catalog=CompanyDb;integrated Security=true;TrustServerCertificate=True;");
        }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Sector> Sectors { get; set; }
    }
}
