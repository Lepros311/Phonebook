﻿namespace Phonebook.Models;

internal class Contact
{
    public int ContactId { get; set; }

    public string ContactName { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    public int CategoryId { get; set; }

    public Category Category { get; set; }
}
