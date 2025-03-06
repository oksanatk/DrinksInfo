

namespace DrinksInfo.Services;

class ApiService
{
    private readonly HttpClient _httpClient;

    public ApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    internal async Task<List<string>> GetCategoriesList()
    {
        return new List<string>();
    }
}
