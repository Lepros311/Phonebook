using Phonebook.Models;
using Spectre.Console;

namespace Phonebook.Views;

internal class Display
{
    public static void PrintContactsTable(List<Contact> contacts)
    {
        var table = new Table();
        table.AddColumn("[green]Category Name[/]");

        foreach (Contact contact in contacts)
        {
            table.AddRow(contact.ToString());
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
