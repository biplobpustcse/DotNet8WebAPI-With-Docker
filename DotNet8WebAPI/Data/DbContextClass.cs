using Microsoft.EntityFrameworkCore;
using DotNet8WebAPI.Model;

namespace DotNet8WebAPI.Data
{
    public class DbContextClass : DbContext
    {
        protected readonly IConfiguration configuration;
        public DbContextClass(IConfiguration _Configuration) 
        {
            configuration = _Configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<Product> Products { get; set; }
    }
}
