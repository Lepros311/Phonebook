using Phonebook.Models;
using Phonebook.Services;
using Spectre.Console;
using System.Net;
using System.Numerics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Phonebook.Views;

public class UserInterface
{
    public static void PrintSelectionMainMenu()
    {
        var isAppRunning = true;
        while (isAppRunning)
        {
            Console.Clear();
            var options = new[] { "View Contacts", "View Contacts by Category", "Search Contacts by Name", "View Categories", "Close Phonebook" };

            var mainMenuChoice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("MAIN MENU")
                .PageSize(15)
                .AddChoices(options));

            switch (mainMenuChoice)
            {
                case "View Contacts":
                    PrintSelectionOfContacts(ContactService.GetContacts());
                    break;
                case "View Contacts by Category":
                    //ProductsMenu();
                    break;
                case "Search Contacts by Name":
                    //OrdersMenu();
                    break;
                case "View Categories":
                    PrintSelectionOfCategories(CategoryService.GetCategories());
                    break;
                case "Close Phonebook":
                    Console.WriteLine("Goodbye!");
                    isAppRunning = false;
                    break;
            }
        }

    }

    static internal Category PrintSelectionOfCategories(List<Category> categories)
    {
        Console.Clear();

        Console.WriteLine("CATEGORIES\n");

        string nameHeader = "  Name".PadRight(25);

        AnsiConsole.Markup($"[underline green]{nameHeader}[/]\n");

        var categoryChoice = AnsiConsole.Prompt(
            new SelectionPrompt<Category>()
            .PageSize(10)
            .AddChoices(categories.Append(new Category { CategoryName = "[[Return to Main Menu]]" })));

        return categoryChoice;
    }

    static internal Contact PrintSelectionOfContacts(List<Contact> contacts)
    {
        Console.Clear();

        Console.WriteLine("CONTACTS\n");

        string nameHeader = "  Name".PadRight(25);
        string phoneHeader = "   Phone Number".PadRight(15);
        string emailHeader = "    Email Address".PadRight(30);
        string categoryHeader = "     Category";

        AnsiConsole.Markup($"[underline green]{nameHeader}[/][underline green]{phoneHeader}[/][underline green]{emailHeader}[/][underline green]{categoryHeader}[/]\n");

        var contactChoice = AnsiConsole.Prompt(
            new SelectionPrompt<Contact>()
            .PageSize(10)
            .AddChoices(contacts.Append(new Contact { ContactName = "[[Return to Main Menu]]", PhoneNumber = string.Empty, Email = string.Empty, Category = new Category() })));

        return contactChoice;
    }
}