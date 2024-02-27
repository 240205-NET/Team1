using System;

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

                    Console.WriteLine(String.Format("|{0,6}|{1,30}|{2,15}|{3,10}|{4,15},{5,15},{6,15}", meal.idMeal, meal.strMeal.Length < 20 ? meal.strMeal : meal.strMeal.Substring(0, 20), meal.strCategory, meal.strArea, meal.strIngredient1, meal.strIngredient2, meal.strIngredient3));
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

                    Console.WriteLine(String.Format("|{0,6}|{1,30}|", meal.idMeal, meal.strMeal.Length < 20 ? meal.strMeal : meal.strMeal.Substring(0, 20)));
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

                    Console.WriteLine(String.Format("|{0,6}|{1,30}|", meal.idMeal, meal.strMeal.Length < 20 ? meal.strMeal : meal.strMeal.Substring(0, 20)));
                    Console.WriteLine("=============================================");
                }
            }
            else
            {
                Console.WriteLine("Empty return");
            }
        }

        public static void AddRecipe()
        {
            string path = @".\TextFile.txt";

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

            WriteFile(meal, path);
        }

        public static void Serialize(Meal meal, string path)
        {
            Console.WriteLine(meal.SerilizeXML());

            string[] text1 = { meal.SerilizeXML() };
            File.WriteAllLines(path, text1);
        }

        public static void ReadFile()
        {
            string path = @".\TextFile.txt";
            if (File.Exists(path))
            {
                string[] readText = File.ReadAllLines(path);
                foreach (string s in readText)
                {
                    Console.WriteLine(s);
                }
            }
            else
            {
                Console.WriteLine("File not found!");
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