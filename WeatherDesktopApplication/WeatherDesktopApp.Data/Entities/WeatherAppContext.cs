using Microsoft.EntityFrameworkCore;
using WeatherDesktopApp.Data.Entities;

namespace WeatherDesktopApp.Data
{
    public class WeatherAppContext : DbContext
    {
        public WeatherAppContext(DbContextOptions<WeatherAppContext> options) : base(options) { }

        public DbSet<City> Cities { get; set; }

        public DbSet<Search> Searches { get; set; }

    }
}