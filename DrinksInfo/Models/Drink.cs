using Newtonsoft.Json;

namespace DrinksInfo.Models;

class Drink
{
    [JsonProperty("strDrink")]
    public string Name { get; set; } = "";
    [JsonProperty("strDrinkAlternate")]
    public string? AlternateName { get; set; }
    [JsonProperty("idDrink")]
    public int Id { get; set; }
    [JsonProperty("strDrinkThumb")]
    public string ImageThumbnailUrl { get; set; } = "";
    [JsonProperty("strTags")]
    public List<string> Tags { get; set; } = null!;
    [JsonProperty("strVideo")]
    public string? VideoUrl { get; set; }
    [JsonProperty("strCategory")]
    public string Category { get; set; } = null!;
    [JsonProperty("strIBA")]
    public string IbaName { get; set; }
    [JsonProperty("strAlcoholic")]
    public string Alcoholic { get; set; }
    [JsonProperty("strGlass")]
    public string Glass { get; set; }
    [JsonProperty("strInstructions")]
    public string Instructions { get; set; } = null!;
    [JsonProperty("strInstructionsES")]
    public string InstructionsEs { get; set; } = null!;
    [JsonProperty("strInstructionsDE")]
    public string InstructionsDe { get; set; } = null!;
    [JsonProperty("strInstructionsFR")]
    public string InstructionsFr { get; set; } = null!;
    [JsonProperty("strInstructionsIT")]
    public string InstructionsIt { get; set; }
    [JsonProperty("strInstructionsZH-HANS")]
    public string InstructionsZh_Hans { get; set; }
    [JsonProperty("strInstructionsZH-HANT")]
    public string InstructoinsZh_Hant { get; set; }
    // TODO - get ingedients and measures into a list or dictionary
    public List<string> Ingredients { get; set; }
    public List<string> Measures { get; set; }
    public Dictionary<string,string> IngredientMeasures { get; set; }
    [JsonProperty("strImageSource")]
    public string ImageSource { get; set; }
    [JsonProperty("strImageAttributon")]
    public string ImageAttribution { get; set; }
    [JsonProperty("strCreativeCommonsConfirmed")]
    public string CreativeCommonsConfirmed { get; set; }
    // TODO - datetime
    public DateTime DateModified { get; set; }

}
