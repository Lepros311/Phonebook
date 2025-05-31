using Phonebook;
using Phonebook.Views;

Console.Title = "Phonebook";

var context = new ContactsContext();
context.Database.EnsureCreated();

await UserInterface.PrintSelectionMainMenu();