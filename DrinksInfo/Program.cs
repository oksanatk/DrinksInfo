using DrinksInfo.Services;
using DrinksInfo.Views;

namespace DrinksInfo;

class Program
{
    public static void Main(string[] args)
    {
        HttpClient httpClient = new HttpClient();
        ApiService apiService = new ApiService(httpClient);
        MenuView menuView = new MenuView(apiService);
    }
}
