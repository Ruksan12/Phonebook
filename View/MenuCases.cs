using PhoneBook.Ruksan12.Models;
using PhoneBook.Ruksan12.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Ruksan12.View
{
    public class MenuCases
    {
        public static void AddContact(PhoneService phoneService)
        {
            Console.Clear();
            Console.Write("Enter Name: ");
            var name = Console.ReadLine();

            string phoneNumber;
            while (true)
            {
                Console.Write("Enter Phone Number: ");
                phoneNumber = Console.ReadLine();
                if (ContactValidator.IsValidPhoneNumber(phoneNumber))
                    break;
                Console.WriteLine("Invalid phone number. Must be 7-15 digits.\n");
            }

            string email;
            while (true)
            {
                Console.Write("Enter Email: ");
                email = Console.ReadLine();
                if (ContactValidator.IsValidEmail(email))
                    break;
                Console.WriteLine("Invalid email address.\n");
            }

            var addContact = new Contact
            {
                Name = name,
                PhoneNumber = phoneNumber,
                Email = email
            };
            phoneService.AddContact(addContact);
            Console.WriteLine("Contact added successfully!");
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
            Console.Clear();
        }

        public static void ViewContact(PhoneService phoneService)
        {
            Console.Clear();
            var contacts = phoneService.ViewContacts();
            Console.WriteLine("Contacts:");
            foreach (var contact in contacts)
            {
                Console.WriteLine($"ID: {contact.Id}, Name: {contact.Name}, Phone: {contact.PhoneNumber}, Email: {contact.Email}");
            }
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
            Console.Clear();
        }

        public static void EditContact(PhoneService phoneService)
        {
            Console.Clear();
            int editId;
            while (true)
            {
                Console.Write("Enter Contact ID to edit: ");
                if (int.TryParse(Console.ReadLine(), out editId))
                    break;
                Console.WriteLine("Invalid ID. Please enter a number.\n");
            }

            var contactToEdit = phoneService.GetContactById(editId);
            if (contactToEdit != null)
            {
                Console.Write("Enter new Name (leave blank to keep current): ");
                var newName = Console.ReadLine();

                string newPhone;
                while (true)
                {
                    Console.Write("Enter new Phone Number (leave blank to keep current): ");
                    newPhone = Console.ReadLine();
                    if (string.IsNullOrEmpty(newPhone) || ContactValidator.IsValidPhoneNumber(newPhone))
                        break;
                    Console.WriteLine("Invalid phone number. Must be 7-15 digits.\n");
                }

                string newEmail;
                while (true)
                {
                    Console.Write("Enter new Email (leave blank to keep current): ");
                    newEmail = Console.ReadLine();
                    if (string.IsNullOrEmpty(newEmail) || ContactValidator.IsValidEmail(newEmail))
                        break;
                    Console.WriteLine("Invalid email address.\n");
                }

                if (!string.IsNullOrEmpty(newName)) contactToEdit.Name = newName;
                if (!string.IsNullOrEmpty(newPhone)) contactToEdit.PhoneNumber = newPhone;
                if (!string.IsNullOrEmpty(newEmail)) contactToEdit.Email = newEmail;
                phoneService.UpdateContact(contactToEdit);
                Console.WriteLine("Contact updated successfully!");
            }
            else
            {
                Console.WriteLine("Contact not found.");
            }
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
            Console.Clear();
        }

        public static void DeleteContact(PhoneService phoneService)
        {
            Console.Clear();
            int deleteId;
            while (true)
            {
                Console.Write("Enter Contact ID to delete: ");
                if (int.TryParse(Console.ReadLine(), out deleteId))
                    break;
                Console.WriteLine("Invalid ID. Please enter a number.\n");
            }

            var contactToDelete = phoneService.GetContactById(deleteId);
            if (contactToDelete != null)
            {
                phoneService.DeleteContact(contactToDelete);
                Console.WriteLine("Contact deleted successfully!");
            }
            else
            {
                Console.WriteLine("Contact not found.");
            }
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
            Console.Clear();
        }

    }
}
