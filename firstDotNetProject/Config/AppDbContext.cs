using firstDotNetProject.Entities;
using Microsoft.EntityFrameworkCore;

namespace firstDotNetProject.Config
{
    public class AppDbContext : DbContext
    {
        protected readonly IConfiguration _configuration;

        public AppDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("postgresDb"));
        }

        public DbSet<User> Users { get; set; }
    }
}
