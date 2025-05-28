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
                    PrintSelectionOfContacts();
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

            var categoryMenuChoice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("CATEGORIES MENU")
                .PageSize(10)
                .AddChoices(options));

            switch (categoryMenuChoice)
            {
                case "View Categories":
                    Display.PrintCategoriesTable(CategoryService.GetCategories(), "View Categories");
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

    static internal void PrintSelectionCategoryMenu(Category category)
    {
        var isCategoryMenuRunning = true;
        while (isCategoryMenuRunning)
        {
            Console.Clear();

            Console.WriteLine("CATEGORY\n");

            string nameHeader = $"  {category}".PadRight(25);

            AnsiConsole.Markup($"[underline yellow]{nameHeader}[/]\n");

            var options = new[] { "Edit Category Name", "Delete Category", "Return to Categories" };

            var categoryActionChoice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .PageSize(10)
                .AddChoices(options));

            switch (categoryActionChoice)
            {
                case "[[Return to Main Menu]]":
                    isCategoryMenuRunning = false;
                    break;
                case "Edit Category Name":
                    //CategoryService.UpdateCategory(category);
                    break;
                case "Delete Category":
                    //CategoryService.DeleteCategory(category);
                    isCategoryMenuRunning = false;
                    break;
                case "Return to Categories":
                    isCategoryMenuRunning = false;
                    break;
            }

        }
    }

    static public void PrintSelectionOfContacts()
    {
        var isSelectionOfContactsRunning = true;
        while (isSelectionOfContactsRunning)
        {
            Console.Clear();

            List<Contact> contacts = ContactService.GetContacts();

            Console.WriteLine("CONTACTS\n");

            string nameHeader = "  Name".PadRight(25);
            string phoneHeader = "   Phone Number".PadRight(15);
            string emailHeader = "    Email Address".PadRight(30);
            string categoryHeader = "     Category";

            AnsiConsole.Markup($"[underline green]{nameHeader}[/][underline green]{phoneHeader}[/][underline green]{emailHeader}[/][underline green]{categoryHeader}[/]\n");

            List<Contact> modifiedContacts = new List<Contact>
            {
                new Contact { ContactName = "[[Add Contact]]", PhoneNumber = string.Empty, Email = string.Empty, Category = new Category() },
                new Contact { ContactName = "[[Return to Main Menu]]", PhoneNumber = string.Empty, Email = string.Empty, Category = new Category() }
            };
            modifiedContacts.AddRange(contacts);

            var contactChoice = AnsiConsole.Prompt(
                new SelectionPrompt<Contact>()
                .PageSize(12)
                .AddChoices(modifiedContacts));

            switch (contactChoice.ContactName)
            {
                case "[[Add Contact]]":
                    ContactService.InsertContact();
                    break;
                case "[[Return to Main Menu]]":
                    isSelectionOfContactsRunning = false;
                    break;
                default:
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