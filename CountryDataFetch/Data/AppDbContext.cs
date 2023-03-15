using CountryDataFetch.Models;
using Microsoft.EntityFrameworkCore;

namespace CountryDataFetch.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {

        }

        public DbSet<Country> countries { get; set; }
    }
}
