using DrinksInfo.Models;
using DrinksInfo.Services;
using Spectre.Console;

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
            List<string> allCategories = await _apiService.GetCategoriesListAsync();
            allCategories.Add("Quit");

            category = AnsiConsole.Prompt(
                                 new SelectionPrompt<string>()
                                .Title("Welcome! Choose a drink category.")
                                .AddChoices(allCategories));

            AnsiConsole.WriteLine($"You chose {category}.");
            if (category != "Quit")
            {
                await ShowDrinksInCategory(category);
            } 
        } while (category != "Quit");
    }

    private async Task ShowDrinksInCategory(string category)
    {
        Drink drinkPicked = new();

        do
        {
            List<Drink> drinksInCategory = await _apiService.GetDrinksInCategoryAsync(category);
            drinksInCategory.Add(new Drink { Category = "Go Back" });

            drinkPicked = AnsiConsole.Prompt(
                                new SelectionPrompt<Drink>()
                                .Title($"Pick a drink from {category}:")
                                .AddChoices(drinksInCategory));
            if (drinkPicked.Category != "Go Back")
            {
                AnsiConsole.WriteLine($"You picked {drinkPicked}");
                // TODO - display drink details
            } 
        } while (drinkPicked.Category != "Go Back"); 
    }
}
