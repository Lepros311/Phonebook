using System.Text.RegularExpressions;

namespace Phonebook.Models;

internal class Validation
{
    public static bool IsValidEmail(string email)
    {
        var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        if (string.IsNullOrWhiteSpace(email))
            return false;

        return emailRegex.IsMatch(email);
    }

    public static bool IsValidPhoneNumber(string phoneNumber)
    {
        var phoneRegex = new Regex(@"^\d{3}-\d{3}-\d{4}$", RegexOptions.Compiled);

        if (string.IsNullOrWhiteSpace(phoneNumber))
            return false;

        return phoneRegex.IsMatch(phoneNumber);
    }
}
