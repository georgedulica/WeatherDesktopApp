using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;
using WeatherDesktopApp.Data;

namespace WeatherDesktopApplication;

public partial class App : Application
{
    public static IHost AppHost { get; private set; }

    public App()
    {
        AppHost = CreateHostBuilder(null).Build();
        AppHost.Start();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((context, config) =>
            {
                // Add User Secrets
                var env = context.HostingEnvironment;
                config.AddUserSecrets<App>();
            })
            .ConfigureServices((hostContext, services) =>
            {
                var configuration = hostContext.Configuration;

                // Get connection string from user secrets
                var connectionString = configuration.GetConnectionString("WeatherAppDb");

                // Register DbContext with SQL Server
                services.AddDbContext<WeatherAppContext>(options =>
                    options.UseSqlServer(connectionString));

                // Register other services
                services.AddSingleton<MainWindow>();
            });
}