using Microsoft.EntityFrameworkCore;
using Phonebook.Models;

namespace Phonebook.Controllers;

internal class CategoryController
{
    internal static List<Category> GetCategories()
    {
        using var db = new ContactsContext();
        List<Category> categories = db.Categories.Include(x => x.Contacts).ToList();
        return categories;
    }
}
