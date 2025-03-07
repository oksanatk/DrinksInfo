using DrinksInfo.Models;
using DrinksInfo.Services;
using Spectre.Console;
using System.Reflection;

namespace DrinksInfo.Views;

class MenuView
{
    private readonly ApiService _apiService;

    public MenuView(ApiService apiSerivce)
    {
        _apiService = apiSerivce;
    }

    public async Task ShowCategoriesMenu()
    {
        string category = "";
        do
        {
            Console.Clear();
            List<string> allCategories = await _apiService.GetCategoriesListAsync();
            allCategories.Add("Quit");

            category = AnsiConsole.Prompt(
                                 new SelectionPrompt<string>()
                                .Title("Welcome! Choose a drink category.")
                                .PageSize(20)
                                .MoreChoicesText("Scroll down for more category options.")
                                .AddChoices(allCategories));

            if (category != "Quit")
            {
                await ShowDrinksInCategory(category);
            } 
        } while (category != "Quit");
    }

    private async Task ShowDrinksInCategory(string category)
    {
        string drinkPickedName = "";

        do
        {
            Console.Clear();
            List<Drink> drinksInCategory = await _apiService.GetDrinksInCategoryAsync(category);
            drinksInCategory.Add(new Drink { Name = "Go Back" });

            List<String> drinkNames = drinksInCategory.Select(d => d.Name).ToList();

            drinkPickedName = AnsiConsole.Prompt(
                                new SelectionPrompt<string>()
                                .Title($"Pick a drink from {category}:")
                                .PageSize(20)
                                .MoreChoicesText("Scroll down to see more drinks.")
                                .AddChoices(drinkNames));

            Drink drinkPicked = drinksInCategory.FirstOrDefault(d => d.Name == drinkPickedName, new Drink() { Name = "Go Back"});

            if (drinkPicked.Name != "Go Back")
            {
                await ShowDrinkDetails(drinkPicked.Id);
            } 
        } while (drinkPickedName != "Go Back"); 
    }

    private async Task ShowDrinkDetails(int id)
    {
        Drink drink = await _apiService.GetDrinkByIdAsync(id);

        foreach(PropertyInfo prop in drink.GetType().GetProperties())
        {
            Type type = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
            if (!String.IsNullOrEmpty(prop.GetValue(drink)?.ToString()))
            {
                switch (prop.Name)
                {
                    case string name when name.Contains("Instructions"):
                        AnsiConsole.MarkupLine($"[green]{prop.Name}:[/] {prop.GetValue(drink)?.ToString()}\n");
                        break;
                    case "IngredientsMeasures":

                        AnsiConsole.MarkupLine("[darkseagreen2]Ingredients and Measurements:[/]");
                        foreach(KeyValuePair<string, string> ingredientMeasure in drink.IngredientsMeasures)
                        {
                            AnsiConsole.MarkupLine($"\t[darkseagreen2]{ingredientMeasure.Key} : {ingredientMeasure.Value}[/]");
                        }
                        Console.WriteLine();

                        break;
                    case "DateModified":
                        AnsiConsole.MarkupLine($"[darkorange3]Date Modified:[/] {prop.GetValue(drink)?.ToString()}\n");
                        break;
                    case "CreativeCommonsConfirmed":
                        AnsiConsole.MarkupLine($"[darkorange3]Creative Commons Confirmed:[/] {prop.GetValue(drink)?.ToString()}\n");
                        break;
                    case "ImageThumbnailUrl":
                        AnsiConsole.MarkupLine($"[bold yellow]Image Thumbnail URL link:[/] {prop.GetValue(drink)?.ToString()} \n");
                        break;
                    default:
                        AnsiConsole.MarkupLine($"[bold yellow]{prop.Name}:[/] {prop.GetValue(drink)?.ToString()}\n");
                        break;
                }
            }
        }
        AnsiConsole.MarkupLine("\nPress the [yellow]Enter[/] key to continue.");
        Console.ReadLine();
    }
}
