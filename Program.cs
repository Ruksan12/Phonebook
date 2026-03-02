using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PhoneBook.Ruksan12.Data;
using PhoneBook.Ruksan12.Services;
class Menu
{
    public static void Main()
    {
        var services = new ServiceCollection();
        services.AddDbContext<PhoneBookContext>(options =>
            options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=PhoneBookDb;Trusted_Connection=True;"));
        services.AddTransient<PhoneService>();
        using var serviceProvider = services.BuildServiceProvider();
        var phoneService = serviceProvider.GetRequiredService<PhoneService>();
        while (true)
        {
            Console.WriteLine("Phone Book Menu:");
            Console.WriteLine("1. Add Contact");
            Console.WriteLine("2. View Contacts");
            Console.WriteLine("3. Edit Contact");
            Console.WriteLine("4. Delete Contact");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");
            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    phoneService.AddContact();
                    break;
                case "2":
                    phoneService.ViewContacts();
                    break;
                case "3":
                    phoneService.EditContact();
                    break;
                case "4":
                    phoneService.DeleteContact();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }

        }
    }
}