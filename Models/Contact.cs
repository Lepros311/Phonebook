namespace Phonebook.Models;

public class Contact
{
    public int ContactId { get; set; }

    public string ContactName { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    public int CategoryId { get; set; }

    public Category Category { get; set; }

    public override string ToString()
    {
        return $"{ContactName.PadRight(25)} {PhoneNumber.PadRight(15)} {Email.PadRight(30)} {Category.CategoryName}";
    }
}
