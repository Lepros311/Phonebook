using Microsoft.EntityFrameworkCore;
using Phonebook.Models;

namespace Phonebook.Controllers;

internal class ContactController
{
    public static void AddContact()
    {

    }

    public static void DeleteContact()
    {

    }

    public static void UpdateContact()
    {

    }

    public static List<Contact> GetContacts()
    {
        using var db = new ContactsContext();
        var contacts = db.Contacts.Include(x => x.Category).ToList();
        return contacts;
    }
}
