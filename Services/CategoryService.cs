using Phonebook.Models;
using Spectre.Console;
using Phonebook.Controllers;

namespace Phonebook.Services;

internal class CategoryService
{
    public static List<Category> GetCategories()
    {
        List<Category> categories = CategoryController.GetCategories();
        return categories;
    }

    internal static Category GetCategoryOptionInput()
    {
        var categories = CategoryController.GetCategories();
        var categoriesArray = categories.Select(x => x.CategoryName).ToArray();
        var option = AnsiConsole.Prompt(new SelectionPrompt<string>()
            .Title("Choose Category")
            .AddChoices(categoriesArray));
        var category = categories.Single(x => x.CategoryName == option);
        return category;
    }
}
