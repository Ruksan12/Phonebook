using PhoneBook.Ruksan12.Data;
using PhoneBook.Ruksan12.Models;
using PhoneBook.Ruksan12.Services;

namespace PhoneBook.Ruksan12.View
{
    public class Menu
    {
        public void ShowMenu(PhoneService phoneService)
        {
            while (true)
            {
                Console.WriteLine("|-------------------------------------------------|");
                Console.WriteLine("    Phone Book Menu:");
                Console.WriteLine("|-------------------------------------------------|");
                Console.WriteLine("1. Add Contact");
                Console.WriteLine("2. View Contacts");
                Console.WriteLine("3. Edit Contact");
                Console.WriteLine("4. Delete Contact");
                Console.WriteLine("5. Exit\n");
                Console.Write("Select an option: ");
                var choice = Console.ReadLine();
                try
                {
                    switch (choice)
                    {
                        case "1":
                            MenuCases.AddContact(phoneService);
                            break;
                        case "2":
                            MenuCases.ViewContact(phoneService);
                            break;
                        case "3":
                            MenuCases.EditContact(phoneService);
                            break;
                        case "4":
                            MenuCases.DeleteContact(phoneService);
                            break;
                        case "5":
                            return;
                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            Console.WriteLine("\nPress any key to continue.");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    Console.WriteLine("\nPress any key to continue.");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        

    }
}
