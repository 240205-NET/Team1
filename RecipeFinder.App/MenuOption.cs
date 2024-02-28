using System;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace RecipeFinder
{
    public class MenuOption
    {
        public static async Task ShowAllRecipes()
        {

            var mealResponse = await APIReader.Reader("https://www.themealdb.com/api/json/v1/1/search.php?f=%");
            if (mealResponse is not null)
            {

                Console.WriteLine("========================================================================================================");
                Console.WriteLine(String.Format("|{0,6}|{1,30}|{2,15}|{3,10}|{4,45}|", "ID", "Name", "Category", "Area", "Ingredients"));
                Console.WriteLine("========================================================================================================");
                foreach (var meal in mealResponse.meals)
                {

                    Console.WriteLine(String.Format("|{1,30}|{2,15}|{3,10}|{4,15},{5,15},{6,15}", meal.Name.Length < 20 ? meal.Name : meal.Name.Substring(0, 20), meal.Category, meal.Area, meal.Ingredient1, meal.Ingredient2, meal.Ingredient3));
                    Console.WriteLine("========================================================================================================");
                }
            }
            else
            {
                Console.WriteLine("Empty return");
            }

        }

        public static async Task ShowRecipesByCategory(string cat)
        {
            var mealResponse = await APIReader.Reader("https://www.themealdb.com/api/json/v1/1/filter.php?c=" + cat);
            if (mealResponse is not null)
            {
                Console.WriteLine("=============================================");
                Console.WriteLine(String.Format("|{0,6}|{1,30}|", "ID", "Name"));
                Console.WriteLine("==============================================");
                foreach (var meal in mealResponse.meals)
                {

                    Console.WriteLine(String.Format("|{1,30}|", meal.Name.Length < 20 ? meal.Name : meal.Name.Substring(0, 20)));
                    Console.WriteLine("===========================================");
                }
            }
            else
            {
                Console.WriteLine("Empty return");
            }
        }
        public static async Task ShowRecipesByIngredient(string ing)
        {
            var mealResponse = await APIReader.Reader("https://www.themealdb.com/api/json/v1/1/filter.php?i=" + ing);
            if (mealResponse is not null)
            {
                Console.WriteLine("==============================================");
                Console.WriteLine(String.Format("|{0,6}|{1,30}|", "ID", "Name"));
                Console.WriteLine("================================================");
                foreach (var meal in mealResponse.meals)
                {

                    Console.WriteLine(String.Format("|{1,30}|", meal.Name.Length < 20 ? meal.Name : meal.Name.Substring(0, 20)));
                    Console.WriteLine("=============================================");
                }
            }
            else
            {
                Console.WriteLine("Empty return");
            }
        }
        static string url = "https://localhost:7297/"; //add api uri
        public static async void AddRecipe(){
            string uri = url + "api/Meal/";
            
            /*
            string id = "0";
            Console.Write("Recipe Name: ");
            string? recipeName = Console.ReadLine();
            Console.Write("Recipe Category: ");
            string? category = Console.ReadLine();
            Console.Write("Recipe Area: ");
            string? area = Console.ReadLine();
            Console.Write("Ingredient 1: ");
            string? ingr1 = Console.ReadLine();
            Console.Write("Ingredient 2: ");
            string? ingr2 = Console.ReadLine();
            Console.Write("Ingredient 3: ");
            string? ingr3 = Console.ReadLine();

            Meal meal = new Meal();
            meal.idMeal = id;
            meal.strMeal = recipeName;
            meal.strCategory = category;
            meal.strArea = area;
            meal.strIngredient1 = ingr1;
            meal.strIngredient2 = ingr2;
            meal.strIngredient3 = ingr3;
            */

            Meal meal = new Meal();
            Console.Write("Name: ");
            meal.Name = Console.ReadLine(); 
            Console.Write("Category: ");
            meal.Category = Console.ReadLine(); 
            Console.Write("Area: ");
            meal.Area = Console.ReadLine(); 
            Console.Write("Instructions: ");
            meal.Instructions = Console.ReadLine(); 
            Console.Write("Meal_thumb: ");
            meal.Meal_thumb = Console.ReadLine(); 
            Console.Write("Tags: ");
            meal.Tags = Console.ReadLine(); 
            Console.Write("Youtube: ");
            meal.Youtube = Console.ReadLine(); 
            Console.Write("Ingredient1: ");
            meal.Ingredient1 = Console.ReadLine(); 
            Console.Write("Ingredient2: ");
            meal.Ingredient2 = Console.ReadLine(); 
            Console.Write("Ingredient3: ");
            meal.Ingredient3 = Console.ReadLine(); 
            Console.Write("Ingredient4: ");
            meal.Ingredient4 = Console.ReadLine(); 
            Console.Write("Ingredient5: ");
            meal.Ingredient5 = Console.ReadLine(); 
            Console.Write("Ingredient6: ");
            meal.Ingredient6 = Console.ReadLine(); 
            Console.Write("Ingredient7: ");
            meal.Ingredient7 = Console.ReadLine(); 
            Console.Write("Ingredient8: ");
            meal.Ingredient8 = Console.ReadLine(); 
            Console.Write("Ingredient9: ");
            meal.Ingredient9 = Console.ReadLine(); 
            Console.Write("Ingredient10: ");
            meal.Ingredient10 = Console.ReadLine(); 
            Console.Write("Ingredient11: ");
            meal.Ingredient11 = Console.ReadLine(); 
            Console.Write("Ingredient12: ");
            meal.Ingredient12 = Console.ReadLine(); 
            Console.Write("Ingredient13: ");
            meal.Ingredient13 = Console.ReadLine(); 
            Console.Write("Ingredient14: ");
            meal.Ingredient14 = Console.ReadLine(); 
            Console.Write("Ingredient15: ");
            meal.Ingredient15 = Console.ReadLine(); 
            Console.Write("Measure1: ");
            meal.Measure1 = Console.ReadLine(); 
            Console.Write("Measure2: ");
            meal.Measure2 = Console.ReadLine(); 
            Console.Write("Measure3: ");
            meal.Measure3 = Console.ReadLine(); 
            Console.Write("Measure4: ");
            meal.Measure4 = Console.ReadLine(); 
            Console.Write("Measure5: ");
            meal.Measure5 = Console.ReadLine(); 
            Console.Write("Measure6: ");
            meal.Measure6 = Console.ReadLine(); 
            Console.Write("Measure7: ");
            meal.Measure7 = Console.ReadLine(); 
            Console.Write("Measure8: ");
            meal.Measure8 = Console.ReadLine(); 
            Console.Write("Measure9: ");
            meal.Measure9 = Console.ReadLine(); 
            Console.Write("Measure10: ");
            meal.Measure10 = Console.ReadLine(); 
            Console.Write("Measure11: ");
            meal.Measure11 = Console.ReadLine(); 
            Console.Write("Measure12: ");
            meal.Measure12 = Console.ReadLine(); 
            Console.Write("Measure13: ");
            meal.Measure13 = Console.ReadLine(); 
            Console.Write("Measure14: ");
            meal.Measure14 = Console.ReadLine();             
            Console.Write("Measure15: ");
            meal.Measure15 = Console.ReadLine(); 

            HttpClient client = new HttpClient();
            try{
                HttpResponseMessage response = await client.PostAsJsonAsync<Meal>(uri, meal);
                if(!response.IsSuccessStatusCode){
                    Console.WriteLine(response.StatusCode + "\n" + response.Content);
                }
            }catch (Exception e){
                Console.WriteLine(e.Message);
            }
        }

        public static void Serialize(Meal meal, string path)
        {
            Console.WriteLine(meal.SerilizeXML());

            string[] text1 = { meal.SerilizeXML() };
            File.WriteAllLines(path, text1);
        }

        public static async void ShowMyRecipes()
        {
            string uri = url + "api/Meal/";
            HttpClient client = new HttpClient();
            try{
                List<Meal> meals = await client.GetFromJsonAsync<List<Meal>>(uri) ?? throw new NullReferenceException("No meals found");
                foreach(var m in meals)
                    Console.WriteLine(m);
            }catch (Exception e){
                Console.WriteLine(e.Message);
            }
        }

        public static void WriteFile(Meal meal, string path)
        {

            string[] text = { meal.ToString() };

            if (File.Exists(path))
            {
                File.AppendAllLines(path, text);
            }
            else
            {
                File.WriteAllLines(path, text); // WriteAllLines requires an IEnumerable (a collection) of strings
                                                // File.WriteLine(path, <string>); // WriteLine will operate on a single string
            }
        }

    }


}