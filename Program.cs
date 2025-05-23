using Phonebook;
using Phonebook.Models;
using Phonebook.Views;
using Spectre.Console;
using Phonebook.Services;

Console.Title = "Phonebook";

//string? menuChoice;

//do
//{
//    menuChoice = UserInterface.PrintMainMenu();

//    switch (menuChoice)
//    {
//        case "Close Application":
//            Console.WriteLine("\nGoodbye!");
//            Thread.Sleep(2000);
//            Environment.Exit(0);
//            break;
//        case "View Contacts":
//            UserInterface.PrintAllRecords("View All Records");
//            UI.ReturnToMainMenu();
//            break;
//        case "Add Contact":
//            RecordsController.AddRecord();
//            UI.ReturnToMainMenu();
//            break;
//        case "Edit Contact":
//            RecordsController.EditRecord();
//            UI.ReturnToMainMenu();
//            break;
//        case "Delete Contact":
//            RecordsController.DeleteRecord();
//            UI.ReturnToMainMenu();
//            break;
//        default:
//            Console.WriteLine("Invalid choice.");
//            break;
//    }
//} while (menuChoice != "Close Application");

// Instead of a regular entry-point menu, just open the app by displaying all the contacts in alphabetical order. But insert the options of "Add Contact", "Filter by Category", "Search by Name", "Close Phonebook", at the top and bottom of the full Contacts list.  

//Display.PrintAllContacts();

var context = new ContactsContext();
context.Database.EnsureDeleted();
context.Database.EnsureCreated();

ContactService.GetContacts();
