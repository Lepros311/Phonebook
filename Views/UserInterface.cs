using Spectre.Console;

namespace Phonebook.Views;

public class UserInterface
{
    public static string PrintMainMenu()
    {
        Console.Clear();

        var menuChoice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("MAIN MENU")
            .PageSize(10)
            .AddChoices(new[]
            {
                    "Close Application", "View All Records", "Add Record", "Edit Record", "Delete Record", "View Report"
            }));

        return menuChoice;
    }
}
