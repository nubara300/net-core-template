using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CoreTemplate.DataAccess
{
    public class AppDBContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public AppDBContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public AppDBContext()
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
            }
        }

    }
}