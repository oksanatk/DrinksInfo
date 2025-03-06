using DrinksInfo.Services;
using Spectre.Console;

namespace DrinksInfo.Views;

class MenuView
{
    private readonly ApiService _apiService;
    private List<string> categoriesList = null!;
    public string CategorySelection { get; set; } = "";

    public MenuView(ApiService httpSerivce)
    {
        _apiService = httpSerivce;

        _ = Initialize();
    }

    private async Task Initialize()
    {
        categoriesList = await _apiService.GetCategoriesList();
        categoriesList.Add("Quit");

        ShowCategoriesMenu();
    }

    public void ShowCategoriesMenu()
    {
        string category = AnsiConsole.Prompt(
                             new SelectionPrompt<string>()
                            .Title("Welcome! Choose a drink category.")
                            .AddChoices(categoriesList));

        AnsiConsole.WriteLine($"You chose {category}.");
    }
}
