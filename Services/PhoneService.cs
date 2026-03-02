using PhoneBook.Ruksan12.Data;
using PhoneBook.Ruksan12.Models;

namespace PhoneBook.Ruksan12.Services
{
    public class PhoneService
    {
        private readonly PhoneBookContext _context;
        public PhoneService(PhoneBookContext context)
        {
            _context = context;
        }
        public void AddContact()
        {
            Console.Write("Enter Name: ");
            var name = Console.ReadLine();
            Console.Write("Enter Phone Number:");
            var phoneNumber = Console.ReadLine();
            if(!ContactValidator.IsValidPhoneNumber(phoneNumber))
            {
                Console.WriteLine("Invalid phone number. Must be 7-15 digits");
                return;
            }
            Console.Write("Enter Email: ");
            var email = Console.ReadLine();
            if (!ContactValidator.IsValidEmail(email))
            {
                Console.WriteLine("Invalid email address.");
                return;
            }
            var contact = new Contact
            {
                Name = name,
                PhoneNumber = phoneNumber,
                Email = email
            };
            _context.Contacts.Add(contact);
            _context.SaveChanges();
            Console.WriteLine("Contact added successfully!");
        }

        public void ViewContacts()
        {
            var contacts = _context.Contacts.ToList();
            Console.WriteLine("Contacts:");
            foreach (var contact in contacts)
            {
                Console.WriteLine($"ID: {contact.Id}, Name: {contact.Name}, Phone: {contact.PhoneNumber}, Email: {contact.Email}");
            }
        }

        public void EditContact()
        {
            Console.Write("Enter Contact ID to edit: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var contact = _context.Contacts.Find(id);
                if (contact != null)
                {
                    Console.Write("Enter new Name (leave blank to keep current): ");
                    var name = Console.ReadLine();
                    Console.Write("Enter new Phone Number (leave blank to keep current): ");
                    var phoneNumber = Console.ReadLine();
                    if (!string.IsNullOrEmpty(phoneNumber) && !ContactValidator.IsValidPhoneNumber(phoneNumber))
                    {
                        Console.WriteLine("Invalid phone number. Must be 7-15 digits.");
                        return;
                    }
                    Console.Write("Enter new Email (leave blank to keep current): ");
                    var email = Console.ReadLine();
                    if (!string.IsNullOrEmpty(email) && !ContactValidator.IsValidEmail(email))
                    {
                        Console.WriteLine("Invalid email address.");
                        return;
                    }
                    if (!string.IsNullOrEmpty(name)) contact.Name = name;
                    if (!string.IsNullOrEmpty(phoneNumber)) contact.PhoneNumber = phoneNumber;
                    if (!string.IsNullOrEmpty(email)) contact.Email = email;
                    _context.SaveChanges();
                    Console.WriteLine("Contact updated successfully!");
                }
                else
                {
                    Console.WriteLine("Contact not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID.");
            }
        }

        public void DeleteContact()
        {
            Console.Write("Enter Contact ID to delete: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var contact = _context.Contacts.Find(id);
                if (contact != null)
                {
                    _context.Contacts.Remove(contact);
                    _context.SaveChanges();
                    Console.WriteLine("Contact deleted successfully!");
                }
                else
                {
                    Console.WriteLine("Contact not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID.");
            }


        }
    }
}
