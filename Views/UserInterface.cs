using Spectre.Console;
using Phonebook.Models;
using Phonebook.Controllers;

namespace Phonebook.Views;

public class UserInterface
{
    public static Contact PrintMainMenu(List<Contact> contacts)
    {
        Console.Clear();

        List<Contact> modifiedContacts = new List<Contact>
            {
                new Contact { ContactName = "-Add Contact-", Email = string.Empty, PhoneNumber = string.Empty, Category =  Category.GetCategoryByName(string.Empty) },
                new Contact { ContactName = "-Filter by Category-", Email = string.Empty, PhoneNumber = string.Empty, Category =  Category.GetCategoryByName(string.Empty) },
                new Contact { ContactName = "-Search by Name-", Email = string.Empty, PhoneNumber = string.Empty, Category =  Category.GetCategoryByName(string.Empty) },
                new Contact { ContactName = "-Manage Categories-", Email = string.Empty, PhoneNumber = string.Empty, Category =  Category.GetCategoryByName(string.Empty) },
                new Contact { ContactName = "-Close Phonebook-", Email = string.Empty, PhoneNumber = string.Empty, Category =  Category.GetCategoryByName(string.Empty) }
            };
        modifiedContacts.AddRange(contacts);

        var menuChoiceOrContact = AnsiConsole.Prompt(
            new SelectionPrompt<Contact>()
            .Title("CONTACTS")
            .PageSize(15)
            .AddChoices(modifiedContacts)
            .UseConverter(c => $"{c.ContactName.PadRight(20)}{c.PhoneNumber.PadRight(15)}{c.Email.PadRight(25)}{c.Category.CategoryName.PadRight(15)}"));

        return menuChoiceOrContact;
    }

    static internal void ShowContactTable(List<Contact> contacts)
    {
        var table = new Table();
        table.AddColumn("Name");
        table.AddColumn("Email Address");
        table.AddColumn("Phone Number");
        table.AddColumn("Category");

        foreach (var contact in contacts)
        {
            table.AddRow(contact.ContactName, contact.Email, contact.PhoneNumber, contact.Category.CategoryName);
        }

        AnsiConsole.Write(table);

        Console.Write("Press any key to continue...");
        Console.ReadKey();
        Console.Clear();
    }
}
