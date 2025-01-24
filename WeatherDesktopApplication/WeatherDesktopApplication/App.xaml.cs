using Microsoft.EntityFrameworkCore;
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
            .ConfigureServices((hostContext, services) =>
            {
                // Register DbContext with SQL Server
                services.AddDbContext<WeatherAppContext>(options =>
                    options.UseSqlServer("Your-SQL-Server-Connection-String"));

                // Register other services
                services.AddSingleton<MainWindow>();
            });

    protected override async void OnStartup(StartupEventArgs e)
    {
        // Resolve MainWindow and show it
        var mainWindow = AppHost.Services.GetRequiredService<MainWindow>();
        mainWindow.Show();

        base.OnStartup(e);
    }

    protected override async void OnExit(ExitEventArgs e)
    {
        using (AppHost)
        {
            await AppHost.StopAsync();
        }

        base.OnExit(e);
    }
}
