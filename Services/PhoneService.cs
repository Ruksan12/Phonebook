using PhoneBook.Ruksan12.Data;
using PhoneBook.Ruksan12.Models;

namespace PhoneBook.Ruksan12.Services
{
    public class PhoneService
    {
        private readonly PhoneBookContext _db;
        public PhoneService(PhoneBookContext context)
        {
            _db = context;
        }
        public void AddContact(Contact contact)
        {
            try
            {
                _db.Contacts.Add(contact);
                _db.SaveChanges();
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error adding contact: {ex.Message}");
            }
        }

        public List<Contact> ViewContacts()
        {
            try
            {
                return _db.Contacts.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving contacts: {ex.Message}");
                return new List<Contact>();
            }
        }

        public Contact? GetContactById(int id)
        {
            try
            {
                return _db.Contacts.Find(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving contact: {ex.Message}");
                return null;
            }
        }

        public void UpdateContact(Contact contact)
        {
            try
            {
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating contact: {ex.Message}");
            }
        }


        public void DeleteContact(Contact contact)
        {
            try
            {
                _db.Contacts.Remove(contact);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting contact: {ex.Message}");
            }
        }
    }
}
