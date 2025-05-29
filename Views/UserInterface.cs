using Phonebook.Models;
using Phonebook.Services;
using Spectre.Console;

namespace Phonebook.Views;

public class UserInterface
{
    public static void PrintSelectionMainMenu()
    {
        var isAppRunning = true;
        while (isAppRunning)
        {
            Console.Clear();
            var options = new[] { "View/Manage/Interact with Contacts", "View & Manage Categories", "Close Phonebook" };

            var mainMenuChoice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("MAIN MENU")
                .PageSize(10)
                .AddChoices(options));

            switch (mainMenuChoice)
            {
                case "View/Manage/Interact with Contacts":
                    PrintSelectionContactsMenu();
                    break;
                case "View & Manage Categories":
                    PrintSelectionCategoriesMenu();
                    break;
                case "Close Phonebook":
                    Console.WriteLine("Goodbye!");
                    Thread.Sleep(2000);
                    isAppRunning = false;
                    break;
            }
        }

    }

    static internal void PrintSelectionCategoriesMenu()
    {
        var isCategoriesMenuRunning = true;
        while (isCategoriesMenuRunning)
        {
            Console.Clear();

            var options = new[] { "View Categories", "Add Category", "Edit Category", "Delete Category", "Return to Main Menu" };

            var categoriesMenuChoice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("CATEGORIES MENU")
                .PageSize(10)
                .AddChoices(options));

            switch (categoriesMenuChoice)
            {
                case "View Categories":
                    List<Category> categories = CategoryService.GetCategories();
                    Display.PrintCategoriesTable(categories, "View Categories");
                    ReturnToPreviousMenu();
                    break;
                case "Add Category":
                    CategoryService.InsertCategory();
                    ReturnToPreviousMenu();
                    break;
                case "Edit Category":
                    CategoryService.UpdateCategory();
                    ReturnToPreviousMenu();
                    break;
                case "Delete Category":
                    CategoryService.DeleteCategory();
                    ReturnToPreviousMenu();
                    break;
                case "Return to Main Menu":
                    isCategoriesMenuRunning = false;
                    break;
            }
        }
    }

    static internal void PrintSelectionContactsMenu()
    {
        var isContactsMenuRunning = true;
        while (isContactsMenuRunning)
        {
            Console.Clear();

            var options = new[] { "View Contacts", "Add Contact", "Edit Contact", "Delete Contact", "Return to Main Menu" };

            var contactsMenuChoice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("CONTACTS MENU")
                .PageSize(10)
                .AddChoices(options));

            switch (contactsMenuChoice)
            {
                case "View Contacts":
                    List<Contact> contacts = ContactService.GetContacts();
                    Display.PrintContactsTable(contacts, "View Contacts");
                    ReturnToPreviousMenu();
                    break;
                case "Add Contact":
                    ContactService.InsertContact();
                    ReturnToPreviousMenu();
                    break;
                case "Edit Contact":
                    ContactService.UpdateContact();
                    ReturnToPreviousMenu();
                    break;
                case "Delete Contact":
                    ContactService.DeleteContact();
                    ReturnToPreviousMenu();
                    break;
                case "Return to Main Menu":
                    isContactsMenuRunning = false;
                    break;
            }
        }
    }

    public static void ReturnToPreviousMenu()
    {
        Console.Write("\nPress any key to return to the previous menu...");
        Console.ReadKey();
    }
}