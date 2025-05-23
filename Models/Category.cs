﻿namespace Phonebook.Models;

internal class Category
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; }

    public List<Contact> Contacts { get; set; }
}
