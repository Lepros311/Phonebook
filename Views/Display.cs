using Phonebook.Controllers;
using Phonebook.Models;

namespace Phonebook.Views;

internal class Display
{
    public static void PrintAllContacts()
    {
        List<Contact> contacts = ContactController.GetContacts();
    }

    public static void PrintCategoryContacts(string category)
    {

    }
}
