using DrinksInfo.Models;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace DrinksInfo.Services;

class ApiService
{
    private readonly HttpClient _httpClient;

    public ApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    internal async Task<List<string>> GetCategoriesListAsync()
    {
        List<string> categoryNames = new();

        HttpResponseMessage response = await _httpClient.GetAsync("https://www.thecocktaildb.com/api/json/v1/1/list.php?c=list");
        string jsonContent = await response.Content.ReadAsStringAsync();
        Root? rootDrinks = JsonConvert.DeserializeObject<Root>(jsonContent);

        if (rootDrinks !=null && rootDrinks.Drinks != null)
        {
            foreach(Drink d in rootDrinks.Drinks)
            {
                if (!String.IsNullOrWhiteSpace(d.Category))
                {
                    categoryNames.Add(d.Category);
                }
            }
        }
        return categoryNames;
    }


    internal async Task<List<Drink>> GetDrinksInCategoryAsync(string category)
    {
        List<Drink> drinksInCategory = new();

        Uri categoryEndpoint = new Uri($"https://www.thecocktaildb.com/api/json/v1/1/filter.php?c={category}");

        HttpResponseMessage httpResponse = await _httpClient.GetAsync(categoryEndpoint);
        string jsonContent = await httpResponse.Content.ReadAsStringAsync();
        Root? root = JsonConvert.DeserializeObject<Root>(jsonContent);

        if (root != null)
        {
            foreach(Drink d in root.Drinks)
            {
                drinksInCategory.Add(d);
            }
        }
        return drinksInCategory;
    }

    internal async Task<Drink> GetDrinkByIdAsync(int id)
    {
        HttpResponseMessage httpResponse = await _httpClient.GetAsync($"https://www.thecocktaildb.com/api/json/v1/1/lookup.php?i={id}");
        string jsonContent = await httpResponse.Content.ReadAsStringAsync();
        Root? root = JsonConvert.DeserializeObject<Root>(jsonContent);

        if (root != null)
        {

        }

        return new Drink();
    }
}
