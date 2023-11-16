using System.Text.Json.Serialization;

namespace NorthMaui
{
    public class FoodItem
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        
        [JsonPropertyName("name")]
        public string Name { get; set; }


    }
}