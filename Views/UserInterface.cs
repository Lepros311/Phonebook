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
            var options = new[] { "View All Contacts", "View Contacts by Category", "Search Contacts by Name", "Manage Categories", "Close Phonebook" };

            var mainMenuChoice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("MAIN MENU")
                .PageSize(15)
                .AddChoices(options));

            switch (mainMenuChoice)
            {
                case "View All Contacts":
                    PrintSelectionContacts(ContactService.GetContacts());
                    break;
                case "View Contacts by Category":
                    //ProductsMenu();
                    break;
                case "Search Contacts by Name":
                    //OrdersMenu();
                    break;
                case "Manage Categories":
                    //ReportService.CreateMonthlyReport();
                    break;
                case "Close Phonebook":
                    Console.WriteLine("Goodbye!");
                    isAppRunning = false;
                    break;
            }
        }

    }

    static internal Contact PrintSelectionContacts(List<Contact> contacts)
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
            .AddChoices(contacts.Prepend(new Contact { ContactName = "[[Return to Main Menu]]", PhoneNumber = string.Empty, Email = string.Empty, Category = new Category() })));

        return contactChoice;
    }
}