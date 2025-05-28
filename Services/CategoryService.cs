using Phonebook.Controllers;
using Phonebook.Models;
using Phonebook.Views;
using Spectre.Console;

namespace Phonebook.Services;

internal class CategoryService
{
    public static List<Category> GetCategories()
    {
        List<Category> categories = CategoryController.GetCategories();
        return categories;
    }

    internal static void DeleteCategory()
    {
        var rule = new Rule($"[green]Delete Category[/]");
        rule.Justification = Justify.Left;
        AnsiConsole.Write(rule);
        Console.WriteLine();
        Category category = GetCategoryOptionInput();
        Console.WriteLine($"Category to delete: {category}\n");

        AnsiConsole.Markup("[red]WARNING: Deleting a category will delete all contacts in that category.[/]\n");
        if (AnsiConsole.Confirm("Do you wish to proceed?", false))
        {
            CategoryController.DeleteCategory(category);
            Display.PrintCategoriesTable(CategoryService.GetCategories(), "Delete Category");
            Console.WriteLine("\nCategory deleted successfully!");
        }
        else
        {
            Console.WriteLine("\nCategory not deleted.");
            return;
        }
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
        Display.PrintCategoriesTable(CategoryService.GetCategories(), "Add Category");
        var category = new Category();
        category.CategoryName = AnsiConsole.Ask<string>("New Category's name:");
        CategoryController.AddCategory(category);
        Display.PrintCategoriesTable(CategoryService.GetCategories(), "Add Category");
        Console.WriteLine("\nCategory added successfully!");
    }

    internal static void UpdateCategory()
    {
        var rule = new Rule($"[green]Edit Category[/]");
        rule.Justification = Justify.Left;
        AnsiConsole.Write(rule);
        Console.WriteLine();
        Category category = GetCategoryOptionInput();
        Console.WriteLine($"Category's current name: {category}\n");
        category.CategoryName = AnsiConsole.Ask<string>("Category's new name:");
        CategoryController.UpdateCategory(category);
        Display.PrintCategoriesTable(CategoryService.GetCategories(), "Edit Category");
        Console.WriteLine("\nCategory edited successfully!");
    }
}
