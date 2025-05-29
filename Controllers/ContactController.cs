using Microsoft.EntityFrameworkCore;
using Phonebook.Models;

namespace Phonebook.Controllers;

internal class ContactController
{
    public static void AddContact(Contact contact)
    {
        using var db = new ContactsContext();
        db.Add(contact);
        db.SaveChanges();
    }

    public static void DeleteContact(Contact contact)
    {
        using var db = new ContactsContext();
        db.Remove(contact);
        db.SaveChanges();
    }

    public static void UpdateContact(Contact contact)
    {
        using var db = new ContactsContext();
        db.Update(contact);
        db.SaveChanges();
    }

    public static List<Contact> GetContacts()
    {
        using var db = new ContactsContext();
        var contacts = db.Contacts.Include(x => x.Category).ToList();
        return contacts;
    }
}
