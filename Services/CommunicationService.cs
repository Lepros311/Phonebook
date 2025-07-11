﻿using Phonebook.Models;
using Phonebook.Views;
using Spectre.Console;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.Json;

namespace Phonebook.Services;

internal class CommunicationService
{
    public static void SendEmail()
    {
        Contact contact = ContactService.GetContactOptionInput("Send Email");
        List<Contact> contactAsList = new List<Contact> { contact };
        Display.PrintContactsTable(contactAsList, "Send Email");

        bool isValidEmail;
        string fromEmail;
        do
        {
            Console.WriteLine();
            fromEmail = AnsiConsole.Ask<string>("From Email Address:");
            if (Validation.IsValidEmail(fromEmail))
            {
                isValidEmail = true;
            }
            else
            {
                Console.WriteLine("Invalid input or format.");
                isValidEmail = false;
            }
        } while (!isValidEmail);

        Console.Write("\nEmail Subject: ");
        string subject = Console.ReadLine();

        Console.WriteLine("\nEmail Body (Press ENTER when finished):");
        string body = Console.ReadLine();

        if (AnsiConsole.Confirm($"[yellow]Send email?[/]", false))
        {
            using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587))
            {
                string emailAddress = Environment.GetEnvironmentVariable("EMAIL_ADDRESS");
                string emailAppPassword = Environment.GetEnvironmentVariable("EMAIL_APP_PASSWORD");

                smtpClient.Credentials = new NetworkCredential(emailAddress, emailAppPassword);

                smtpClient.EnableSsl = true;


                MailMessage mailMessage = new MailMessage
                {
                    From = new MailAddress(fromEmail),
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

    public static async Task SendSms()
    {
        Contact contact = ContactService.GetContactOptionInput("Send SMS");
        List<Contact> contactAsList = new List<Contact> { contact };
        Display.PrintContactsTable(contactAsList, "Send SMS");

        string apiUrl = "https://textbelt.com/text";
        string apiKey = Environment.GetEnvironmentVariable("TEXTBELT_API_KEY");

        Console.WriteLine("\nSMS Message (Press ENTER when finished):");
        string messageText = Console.ReadLine();

        if (AnsiConsole.Confirm($"[yellow]Send SMS?[/]", false))
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    Dictionary<string, string> postData = new Dictionary<string, string>
                    {
                        { "phone", contact.PhoneNumber },
                        { "message", messageText },
                        { "key", apiKey }
                    };

                    string json = System.Text.Json.JsonSerializer.Serialize(postData);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(apiUrl, content);
                    string result = await response.Content.ReadAsStringAsync();

                    var responseData = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, object>>(result);
                    if (responseData.ContainsKey("success") && ((JsonElement)responseData["success"]).GetBoolean())
                    {
                        Console.WriteLine("\nSMS sent successfully!");
                    }
                    else
                    {
                        Console.WriteLine("\nError sending SMS: " + responseData["error"]);
                    }
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine($"\nHTTP Request Error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\nUnexpected Error: {ex.Message}");
                }
            }
        }
        else
        {
            Console.WriteLine("\nSMS cancelled.");
            return;
        }
    }
}
