using Spectre.Console;
using Phonebook.Models;

namespace Phonebook.Views;

public class UserInterface
{
    //public static string PrintMainMenu()
    //{
    //    Console.Clear();

    //    var menuChoice = AnsiConsole.Prompt(
    //        new SelectionPrompt<string>()
    //        .Title("MAIN MENU")
    //        .PageSize(10)
    //        .AddChoices(new[]
    //        {
    //                "Close Application", "View All Records", "Add Record", "Edit Record", "Delete Record", "View Report"
    //        }));

    //    return menuChoice;
    //}

    static internal void ShowContactTable(List<Contact> contacts)
    {
        var table = new Table();
        table.AddColumn("Id");
        table.AddColumn("Name");
        table.AddColumn("Email Address");
        table.AddColumn("Phone Number");
        table.AddColumn("Category");

        foreach (var contact in contacts)
        {
            table.AddRow(contact.ContactId.ToString(), contact.ContactName, contact.Email, contact.PhoneNumber, contact.Category.CategoryName);
        }

        AnsiConsole.Write(table);

        Console.Write("Enter any key to continue...");
        Console.ReadKey();
        Console.Clear();
    }
}
