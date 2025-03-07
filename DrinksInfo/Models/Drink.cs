using Newtonsoft.Json;

namespace DrinksInfo.Models;

class Drink
{
    [JsonProperty("strDrink")]
    public string Name { get; set; } = "";
    [JsonProperty("strDrinkAlternate")]
    public string AlternateName { get; set; } = "";
    [JsonProperty("idDrink")]
    public int Id { get; set; }
    [JsonProperty("strDrinkThumb")]
    public string ImageThumbnailUrl { get; set; } = "";
    [JsonProperty("strTags")]
    public string Tags { get; set; } = "";
    [JsonProperty("strVideo")]
    public string? VideoUrl { get; set; } = "";
    [JsonProperty("strCategory")]
    public string Category { get; set; } = "";
    [JsonProperty("strIBA")]
    public string IbaName { get; set; } = "";
    [JsonProperty("strAlcoholic")]
    public string Alcoholic { get; set; } = "";
    [JsonProperty("strGlass")]
    public string Glass { get; set; } = "";
    [JsonProperty("strInstructions")]
    public string Instructions { get; set; } = "";
    [JsonProperty("strInstructionsES")]
    public string InstructionsEs { get; set; } = "";
    [JsonProperty("strInstructionsDE")]
    public string InstructionsDe { get; set; } = "";
    [JsonProperty("strInstructionsFR")]
    public string InstructionsFr { get; set; } = "";
    [JsonProperty("strInstructionsIT")]
    public string InstructionsIt { get; set; } = "";
    [JsonProperty("strInstructionsZH-HANS")]
    public string InstructionsZh_Hans { get; set; } = "";
    [JsonProperty("strInstructionsZH-HANT")]
    public string InstructoinsZh_Hant { get; set; } = "";
    [JsonIgnore]
    public Dictionary<string, string> IngredientsMeasures { get; set; } = new();
    [JsonProperty("strImageSource")]
    public string ImageSource { get; set; } = "";
    [JsonProperty("strImageAttributon")]
    public string ImageAttribution { get; set; } = "";
    [JsonProperty("strCreativeCommonsConfirmed")]
    public string CreativeCommonsConfirmed { get; set; } = "";
    [JsonProperty("dateModified")]
    public DateTime DateModified { get; set; }

    public void PopulateIngredientsMeasurements(Dictionary<string, object> rawData)
    {
        for(int i=1; i <= 15; i++)
        {
            string ingredientKey = $"strIngredient{i}";
            string measurementKey = $"strMeasure{i}";

            if (rawData.TryGetValue(ingredientKey, out var ingredient) && ingredient is string ingredientValue 
                 && !String.IsNullOrEmpty(ingredientValue))
            {
                string measurementValue = rawData.TryGetValue(measurementKey, out var measure) && measure is string m ? m : "";
                IngredientsMeasures[ingredientValue] = measurementValue;
            }
        }
    }

}
