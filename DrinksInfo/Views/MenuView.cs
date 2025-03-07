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
                                .PageSize(20)
                                .MoreChoicesText("Scroll down for more category options.")
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
        string drinkPickedName = "";

        do
        {
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
                AnsiConsole.WriteLine($"You picked {drinkPickedName}. The id is {drinkPicked.Id}");
                // TODO - display drink details

                GetDrinkDetails(drinkPicked.Id);
            } 
        } while (drinkPickedName != "Go Back"); 
    }

    private async Task GetDrinkDetails(int id)
    {
        Drink drinkChosen = await _apiService.GetDrinkByIdAsync(id);
    }
}
