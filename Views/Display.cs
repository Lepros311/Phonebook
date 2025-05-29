using Phonebook.Models;
using Spectre.Console;

namespace Phonebook.Views;

internal class Display
{
    public static void PrintContactsTable(List<Contact> contacts, string heading)
    {
        Console.Clear();

        var rule = new Rule($"[green]{heading}[/]");
        rule.Justification = Justify.Left;
        AnsiConsole.Write(rule);

        var table = new Table()
            .Border(TableBorder.Rounded)
            .AddColumn(new TableColumn("[dodgerblue1]Contact Name[/]"))
            .AddColumn(new TableColumn("[dodgerblue1]Phone Number[/]"))
            .AddColumn(new TableColumn("[dodgerblue1]Email Address[/]"))
            .AddColumn(new TableColumn("[dodgerblue1]Category[/]"));

        foreach (Contact contact in contacts)
        {
            table.AddRow(contact.ContactName, contact.PhoneNumber, contact.Email, contact.Category.ToString());
        }

        AnsiConsole.Write(table);
    }

    static internal void PrintCategoriesTable(List<Category> categories, string heading)
    {
        Console.Clear();

        var rule = new Rule($"[green]{heading}[/]");
        rule.Justification = Justify.Left;
        AnsiConsole.Write(rule);

        var table = new Table();
        table.AddColumn("[dodgerblue1]Category Name[/]");

        foreach (Category category in categories)
        {
            table.AddRow(category.ToString());
        }

        AnsiConsole.Write(table);
    }
}
