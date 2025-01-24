using Microsoft.EntityFrameworkCore;
using WeatherDesktopApp.Data.Entities;

namespace WeatherDesktopApp.Data
{
    public class WeatherAppContext : DbContext
    {
        public DbSet<City> Cities { get; set; }

        public DbSet<Search> Searches { get; set; }
    }
}
