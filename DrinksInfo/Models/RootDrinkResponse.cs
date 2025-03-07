using Newtonsoft.Json;

namespace DrinksInfo.Models;

class RootDrinkResponse
{
    [JsonProperty("drinks")]
    public Drink[] Drinks { get; set; } = null!;
}
