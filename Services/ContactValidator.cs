using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Ruksan12.Services
{
    public class ContactValidator
    {
        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            // Basic validation for phone number format (you can enhance this as needed)
            return !string.IsNullOrEmpty(phoneNumber) && phoneNumber.All(char.IsDigit) && phoneNumber.Length >= 7 && phoneNumber.Length <= 15;
        }
        public static bool IsValidEmail(string email)
        {
            // Basic validation for email format (you can enhance this as needed)
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
