using Newtonsoft.Json;

namespace DrinksInfo.Models;

class Root
{
    [JsonProperty("drinks")]
    public Drink[] Drinks { get; set; } = null!;
}
