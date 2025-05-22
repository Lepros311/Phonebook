using Phonebook.Controllers;
using Phonebook.Models;
using Phonebook.Views;

namespace Phonebook.Services;

internal class ContactService
{
    public static void GetContacts()
    {
        List<Contact> contacts = ContactController.GetContacts();
        UserInterface.ShowContactTable(contacts);
    }
}
