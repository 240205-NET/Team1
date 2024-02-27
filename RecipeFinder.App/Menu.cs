using System;
using System.Linq.Expressions;

namespace RecipeFinder
{
    public class Menu
    {

        static bool loop = true;
        public static async Task ExecuteMenu()
        {

            while (loop)
            {
                Console.WriteLine("==========Menu============");
                Console.WriteLine("1. Show all Recipes");
                Console.WriteLine("2. Show Recipes by Categories");
                Console.WriteLine("3. Show Recipes by Ingredients");
                Console.WriteLine("4. Add a Recipe");
                Console.WriteLine("5. Show my Recipes\n\n");
                Console.WriteLine("0. To Exit!");
                Console.Write("Enter your choice:\t");
                string? choice = Console.ReadLine();
                await RespondToMenu(choice);
            }
        }

        public static async Task RespondToMenu(string choice)
        {

            switch (choice)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("=====All Recipes========");
                    await MenuOption.ShowAllRecipes();
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine("=====Recipes by category");
                    await MenuOption.ShowRecipesByCategory("seafood");
                    break;
                case "3":
                    Console.Clear();
                    Console.WriteLine("=========Recipe by ingredient========");
                    await MenuOption.ShowRecipesByIngredient("chicken_breast");
                    break;
                case "4":
                    Console.Clear();
                    Console.WriteLine("======Add a Recipe========");
                    MenuOption.AddRecipe();
                    break;
                case "5":
                    Console.Clear();
                    Console.WriteLine("======My Recipes========");
                    MenuOption.ReadFile();
                    break;
                case "0":
                    loop = false;
                    break;
                default:
                    Console.WriteLine("Not a valid choice");
                    break;
            }


        }
    }
}