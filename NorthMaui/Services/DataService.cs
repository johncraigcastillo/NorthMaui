using Newtonsoft.Json;

namespace NorthMaui.Services
{
    public class DataService
    {
        HttpClient client = new HttpClient();

        public async Task<List<FoodItem>> GetFoodItemsAsync()
        {
            var responseString = await client.GetStringAsync("https://jsonplaceholder.typicode.com/posts");
            return JsonConvert.DeserializeObject<List<FoodItem>>(responseString);
        }
    }
}