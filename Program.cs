using Phonebook.Views;

Console.Title = "Phonebook";

string? menuChoice;

do
{
    menuChoice = UserInterface.PrintMainMenu();

    switch (menuChoice)
    {
        case "Close Application":
            Console.WriteLine("\nGoodbye!");
            Thread.Sleep(2000);
            Environment.Exit(0);
            break;
        case "View All Records":
            UserInterface.PrintAllRecords("View All Records");
            UI.ReturnToMainMenu();
            break;
        case "Add Record":
            RecordsController.AddRecord();
            UI.ReturnToMainMenu();
            break;
        case "Edit Record":
            RecordsController.EditRecord();
            UI.ReturnToMainMenu();
            break;
        case "Delete Record":
            RecordsController.DeleteRecord();
            UI.ReturnToMainMenu();
            break;
        case "View Report":
            repository = new CodingSessionRepository(connection);
            var reportData = repository.GetReportData();
            Display.PrintReport(reportData);
            UI.ReturnToMainMenu();
            break;
        default:
            Console.WriteLine("Invalid choice.");
            break;
    }
} while (menuChoice != "Close Application");
