using CompanyService.Entities;
using Microsoft.EntityFrameworkCore;

namespace CompanyService.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Sector> Sectors { get; set; }
    }
}
