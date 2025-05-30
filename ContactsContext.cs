﻿using Microsoft.EntityFrameworkCore;
using Phonebook.Models;

namespace Phonebook;

internal class ContactsContext : DbContext
{
    public DbSet<Contact> Contacts { get; set; }

    public DbSet<Category> Categories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=contactsDb;Trusted_Connection=True;Initial Catalog=contactsDb");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contact>().HasOne(con => con.Category).WithMany(cat => cat.Contacts).HasForeignKey(con => con.CategoryId);

        modelBuilder.Entity<Category>()
            .HasData(new List<Category>
            {
                new Category
                {
                    CategoryId = 1,
                    CategoryName = "Friends"
                },
                new Category
                {
                    CategoryId = 2,
                    CategoryName = "Family"
                },
                new Category
                {
                    CategoryId = 3,
                    CategoryName = "Coworkers"
                },
                new Category
                {
                    CategoryId = 4,
                    CategoryName = "Other"
                }
            });

        modelBuilder.Entity<Contact>()
           .HasData(new List<Contact>
           {
                new Contact
                {
                    ContactId = 1,
                    CategoryId = 1,
                    ContactName = "Tom Smith",
                    Email = "tsmith@example.com",
                    PhoneNumber = "555-593-4929"
                },
                new Contact
                {
                    ContactId = 2,
                    CategoryId = 1,
                    ContactName = "Judy Garland",
                    Email = "jgarland@example.com",
                    PhoneNumber = "555-492-4921"
                },
                new Contact
                {
                    ContactId = 3,
                    CategoryId = 2,
                    ContactName = "Frank Mitchell",
                    Email = "fmitchelle@example.com",
                    PhoneNumber = "555-492-5921"
                },
                new Contact
                {
                    ContactId = 4,
                    CategoryId = 2,
                    ContactName = "Sally Struthers",
                    Email = "sstruthers@example.com",
                    PhoneNumber = "555-592-9599"
                },
                new Contact
                {
                    ContactId = 5,
                    CategoryId = 3,
                    ContactName = "Otis McBeefcake",
                    Email = "omcbeefcake@example.com",
                    PhoneNumber = "555-494-5929"
                },
                new Contact
                {
                    ContactId = 6,
                    CategoryId = 3,
                    ContactName = "Amy Powershell",
                    Email = "apowershell@example.com",
                    PhoneNumber = "555-992-3214"
                },
                new Contact
                {
                    ContactId = 7,
                    CategoryId = 4,
                    ContactName = "Bobby Thompson",
                    Email = "bthompson@example.com",
                    PhoneNumber = "555-399-3290"
                },
                new Contact
                {
                    ContactId = 8,
                    CategoryId = 4,
                    ContactName = "Greta Shoehorn",
                    Email = "gshoehorn@example.com",
                    PhoneNumber = "555-233-9942"
                }
           });
    }
}
