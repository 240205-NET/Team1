using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MealClient.App
{
    public class Program
    {
        public static async Task Main()
        {
            Console.WriteLine("Are you a new user? (yes/no)");
            string response = Console.ReadLine()?.Trim().ToLower();

            if (response == "yes" || response == "y")
            {
                await SignUp();
            }
            else if (response == "no" || response == "n")
            {
                await SignIn();
            }
            else
            {
                Console.WriteLine("Invalid response. Please enter 'yes' or 'no'.");
            }
        }

        public static async Task SignUp()
        {
            Console.WriteLine("Please enter your username: ");
            string UserName = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Please enter your Password: ");
            string PassWord = Console.ReadLine() ?? string.Empty;
            // Additional fields for signing up
            Console.WriteLine("Please enter your first name: ");
            string FirstName = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Please enter your last name: ");
            string LastName = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Please enter your email: ");
            string Email = Console.ReadLine() ?? string.Empty;

            ClientUser newUser = new()
            {
                Username = UserName,
                Password = PassWord,
                FirstName = FirstName,
                LastName = LastName,
                Email = Email
            };

            var json = JsonSerializer.Serialize(newUser);

            var httpClient = new HttpClient();

            var response = await httpClient.PostAsync("https://recipeapi20240227165441.azurewebsites.net/api/User/signUp", new StringContent(json, Encoding.UTF8, "application/json"));

            // Check if the request was successful
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Sign-up successful!");
                // Proceed with further actions in the app
            }
            else
            {
                Console.WriteLine("Sign-up failed. Please try again.");
            }
        }

        public static async Task SignIn()
        {
            Console.WriteLine("Please enter your username: ");
            string UserName = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Please enter your Password: ");
            string PassWord = Console.ReadLine() ?? string.Empty;

            ClientUser retUser = new()
            {
              Username = UserName,
              Password = PassWord
            };

            var json = JsonSerializer.Serialize(retUser);

            var httpClient = new HttpClient();

            var response = await httpClient.PostAsync("https://recipeapi20240227165441.azurewebsites.net/api/User/signIn", new StringContent(json, Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Sign-in successful!");
            }
            else
            {
                Console.WriteLine("Sign-in failed. Please try again.");
            }

        }
    }

    internal class ClientUser
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
