using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RecipeFinder
{
    public class APIReader
    {
        public static async Task<MealResponse> Reader(string url)
        {
            using (HttpClient client = new HttpClient())
            {

                try
                {
                    HttpResponseMessage res = await client.GetAsync(url);
                    if (res.IsSuccessStatusCode)
                    {
                        string resBody = await res.Content.ReadAsStringAsync();
                        var mealResponse = JsonSerializer.Deserialize<MealResponse>(resBody);
                        if (mealResponse?.meals == null)
                        {
                            Console.WriteLine("No meals found");
                        }
                        else
                        {
                            return mealResponse;

                        }
                    }
                    else
                    {
                        Console.WriteLine("Error reading API");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
            }
            return null;
        }
    }
}