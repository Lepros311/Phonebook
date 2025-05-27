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

    internal static void AddCategory(Category category)
    {
        using var db = new ContactsContext();
        db.Add(category);
        db.SaveChanges();
    }

    internal static void DeleteCategory(Category category)
    {
        using var db = new ContactsContext();
        db.Remove(category);
        db.SaveChanges();
    }

    internal static void UpdateCategory(Category category)
    {
        using var db = new ContactsContext();
        db.Update(category);
        db.SaveChanges();
    }
}
