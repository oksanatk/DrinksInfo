using DrinksInfo.Services;
using DrinksInfo.Views;

namespace DrinksInfo;

class Program
{
    public static async Task Main(string[] args)
    {
        using HttpClient httpClient = new HttpClient();
        ApiService apiService = new ApiService(httpClient);
        MenuView menuView = new MenuView(apiService);

        await menuView.ShowCategoriesMenu();
    }
}
