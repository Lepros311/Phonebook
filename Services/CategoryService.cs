using Phonebook.Controllers;
using Phonebook.Models;
using Spectre.Console;

namespace Phonebook.Services;

internal class CategoryService
{
    public static List<Category> GetCategories()
    {
        List<Category> categories = CategoryController.GetCategories();
        return categories;
    }

    internal static void DeleteCategory(Category category)
    {
        AnsiConsole.Markup("[red]WARNING: Deleting a category will delete all contacts in that category.[/]\n");
        if (AnsiConsole.Confirm("Do you wish to proceed?", false))
            CategoryController.DeleteCategory(category);
        else
            return;
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

    internal static void InsertCategory()
    {
        var category = new Category();
        category.CategoryName = AnsiConsole.Ask<string>("Category's name:");
        CategoryController.AddCategory(category);
    }

    internal static void UpdateCategory(Category category)
    {
        category.CategoryName = AnsiConsole.Ask<string>("Category's new name:");
        CategoryController.UpdateCategory(category);
    }
}
