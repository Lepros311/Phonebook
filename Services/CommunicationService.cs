using Phonebook.Models;
using Phonebook.Views;
using Spectre.Console;
using System.Net;
using System.Net.Mail;

namespace Phonebook.Services;

internal class CommunicationService
{
    public static void SendEmail()
    {
        Contact contact = ContactService.GetContactOptionInput("Send Email");
        List<Contact> contactAsList = new List<Contact> { contact };
        Display.PrintContactsTable(contactAsList, "Send Email");

        Console.Write("\nEmail Subject: ");
        string subject = Console.ReadLine();

        Console.WriteLine("\nEmail Body (Press ENTER when finished):");
        string body = Console.ReadLine();

        if (AnsiConsole.Confirm($"[yellow]Send email?[/]", false))
        {
            using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587))
            {
                smtpClient.Credentials = new NetworkCredential("lepros311@gmail.com", "hrkztlnwycnvgypc");

                smtpClient.EnableSsl = true;


                MailMessage mailMessage = new MailMessage
                {
                    From = new MailAddress("lepros311@gmail.com"),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = false
                };

                mailMessage.To.Add(contact.Email);

                try
                {
                    smtpClient.Send(mailMessage);
                    Console.WriteLine("\nEmail sent successfully!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\nFailed to send email: {ex.Message}");
                }
            }
        }
        else
        {
            Console.WriteLine("\nEmail cancelled.");
            return;
        }
    }

    public static void SendSms()
    {

    }
}
