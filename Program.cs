using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PhoneBook.Ruksan12.Data;
using PhoneBook.Ruksan12.Models;
using PhoneBook.Ruksan12.Services;
using PhoneBook.Ruksan12.View;
class Program
{
    public static void Main()
    {
        try
        {
            var services = new ServiceCollection();

            services.AddDbContext<PhoneBookContext>(options =>
                options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=PhoneBookDb;Trusted_Connection=True;"));

            services.AddTransient<PhoneService>();

            using var serviceProvider = services.BuildServiceProvider();

            var phoneService = serviceProvider.GetRequiredService<PhoneService>();
            Menu UserInput = new Menu();
            UserInput.ShowMenu(phoneService);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fatal error: Unable to start the application. {ex.Message}");
        }
    }
}