using Phonebook.Controllers;

namespace Phonebook.Models;

public class Category
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; }

    public List<Contact> Contacts { get; set; }

    public override string ToString()
    {
        return $"{CategoryName}";
    }

    public static Category GetCategoryByName(string name)
    {
        List<Category> categories = CategoryController.GetCategories();
        return categories.FirstOrDefault(c => c.CategoryName.Equals(name, StringComparison.OrdinalIgnoreCase));
    }
}
