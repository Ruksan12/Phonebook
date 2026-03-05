using Xunit;
using PhoneBook.Ruksan12.Services;

namespace Phonebook.Tests;

public class ContactValidatorTests
{
    [Fact]
    public void ValidPhoneNumber_ReturnsTrue()
    {
        bool result = ContactValidator.IsValidPhoneNumber("1234567");

        Assert.True(result);
    }

    [Fact]
    public void TooShortPhoneNumber_ReturnsFalse()
    {
        bool result = ContactValidator.IsValidPhoneNumber("123");

        Assert.False(result);
    }

    [Fact]
    public void PhoneWithLetters_ReturnsFalse()
    {
        bool result = ContactValidator.IsValidPhoneNumber("12345abc");

        Assert.False(result);
    }

    [Fact]
    public void ValidEmail_ReturnsTrue()
    {
        bool result = ContactValidator.IsValidEmail("alice@example.com");

        Assert.True(result);
    }

    [Fact]
    public void InvalidEmail_ReturnsFalse()
    {
        bool result = ContactValidator.IsValidEmail("not-an-email");

        Assert.False(result);
    }
}