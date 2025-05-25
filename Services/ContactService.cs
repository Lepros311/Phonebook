using Phonebook.Controllers;
using Phonebook.Models;
using Phonebook.Views;
using Spectre.Console;

namespace Phonebook.Services;

internal class ContactService
{
    public static List<Contact> GetContacts()
    {
        List<Contact> contacts = ContactController.GetContacts();
        return contacts;
    }

    public static void InsertContact()
    {
        Contact contact = new Contact();
        contact.ContactName = AnsiConsole.Ask<string>("Contact's name:");
        contact.Email = AnsiConsole.Ask<string>("Contact's email address:");
        contact.PhoneNumber = AnsiConsole.Ask<string>("Contact's phone number:");
        contact.CategoryId = CategoryService.GetCategoryOptionInput().CategoryId;
        ContactController.AddContact(contact);
    }
}
