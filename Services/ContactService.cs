using Phonebook.Controllers;
using Phonebook.Models;
using Phonebook.Views;
using Spectre.Console;

namespace Phonebook.Services;

internal class ContactService
{
    public static List<Contact> GetContacts()
    {
        List<Contact> contacts = ContactController.GetContacts();
        return contacts;
    }

    public static void InsertContact()
    {
        Display.PrintContactsTable(ContactService.GetContacts(), "Add Contact");
        Contact contact = new Contact();
        Console.WriteLine();
        contact.ContactName = AnsiConsole.Ask<string>("New contact's name:");

        bool isValidPhoneNumber;
        do
        {
            contact.PhoneNumber = AnsiConsole.Ask<string>("New contact's phone number (###-###-####):");
            if (Validation.IsValidPhoneNumber(contact.PhoneNumber))
            {
                isValidPhoneNumber = true;
            }
            else
            {
                Console.WriteLine("Invalid input or format.");
                isValidPhoneNumber = false;
            }
        } while (!isValidPhoneNumber);

        bool isValidEmail;
        do
        {
            contact.Email = AnsiConsole.Ask<string>("New contact's email address (name@domain.com):");
            if (Validation.IsValidEmail(contact.Email))
            {
                isValidEmail = true;
            }
            else
            {
                Console.WriteLine("Invalid input or format.");
                isValidEmail = false;
            }
        } while (!isValidEmail);

        contact.CategoryId = CategoryService.GetCategoryOptionInput().CategoryId;
        ContactController.AddContact(contact);
        Display.PrintContactsTable(ContactService.GetContacts(), "Add Contact");
        Console.WriteLine("\nContact added successfully!");
    }

    internal static void DeleteContact()
    {
        Contact contact = GetContactOptionInput("Delete Contact");
        Console.WriteLine($"  {contact}\n");

        if (AnsiConsole.Confirm($"[yellow]Do you really want to delete {contact.ContactName}?[/]", false))
        {
            ContactController.DeleteContact(contact);
            Display.PrintContactsTable(ContactService.GetContacts(), "Delete Contact");
            Console.WriteLine("\nContact deleted successfully!");
        }
        else
        {
            Console.WriteLine("\nContact not deleted.");
            return;
        }
    }

    internal static Contact GetContactOptionInput(string heading)
    {
        var rule = new Rule($"[green]{heading}[/]");
        rule.Justification = Justify.Left;
        AnsiConsole.Write(rule);

        List<Contact> contacts = ContactController.GetContacts();

        string nameHeader = "  Name".PadRight(25);
        string phoneHeader = "   Phone Number".PadRight(20);
        string emailHeader = "    Email Address".PadRight(30);
        string categoryHeader = "     Category";

        Console.WriteLine();

        AnsiConsole.Markup($"[underline dodgerblue3]{nameHeader}[/][underline dodgerblue3]{phoneHeader}[/][underline dodgerblue3]{emailHeader}[/][underline dodgerblue3]{categoryHeader}[/]\n");

        var contactChoice = AnsiConsole.Prompt(new SelectionPrompt<Contact>()
            .Title("Choose Contact:")
            .AddChoices(contacts));

        return contactChoice;
    }

    internal static void UpdateContact()
    {
        Contact contact = GetContactOptionInput("Edit Contact");

        List<Contact> contactAsList = new List<Contact> { contact };
        Display.PrintContactsTable(contactAsList, "Edit Contact");

        Console.WriteLine();

        contact.ContactName = AnsiConsole.Confirm("Update name?", false) ? AnsiConsole.Ask<string>("Contact's new name:") : contact.ContactName;

        if (AnsiConsole.Confirm("Update phone number?", false))
        {
            bool isValidPhoneNumber;
            do
            {
                contact.PhoneNumber = AnsiConsole.Ask<string>("Contact's new phone number (###-###-####):");
                if (Validation.IsValidPhoneNumber(contact.PhoneNumber))
                {
                    isValidPhoneNumber = true;
                }
                else
                {
                    Console.WriteLine("Invalid input or format.");
                    isValidPhoneNumber = false;
                }
            } while (!isValidPhoneNumber);
        }
        else
        {
            contact.PhoneNumber = contact.PhoneNumber;
        }

        if (AnsiConsole.Confirm("Update email address?", false))
        {
            bool isValidEmail;
            do
            {
                contact.Email = AnsiConsole.Ask<string>("Contact's new email address (name@domain.com):");
                if (Validation.IsValidEmail(contact.Email))
                {
                    isValidEmail = true;
                }
                else
                {
                    Console.WriteLine("Invalid input or format.");
                    isValidEmail = false;
                }
            } while (!isValidEmail);
        }
        else
        {
            contact.Email = contact.Email;
        }

        contact.Category = AnsiConsole.Confirm("Update category?", false) ? CategoryService.GetCategoryOptionInput() : contact.Category;

        ContactController.UpdateContact(contact);
        Display.PrintContactsTable(ContactService.GetContacts(), "Edit Contact");
        Console.WriteLine("\nContact edited successfully!");
    }
}
