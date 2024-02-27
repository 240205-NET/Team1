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
      Console.WriteLine("Please enter your username : ");
      string UserName = Console.ReadLine() ?? string.Empty;
      Console.WriteLine("Please enter your Password : ");
      string PassWord = Console.ReadLine() ?? string.Empty;

      ClientUser newUser = new()
      {
        Username = UserName,
        Password = PassWord

      };

      var json = JsonSerializer.Serialize(newUser);

      var httpClient = new HttpClient();

      var response = await httpClient.PostAsync("https://localhost:7297/api/User/signup", new StringContent(json, Encoding.UTF8, "application/json"));

      // Check if the request was successful
      if (response.IsSuccessStatusCode)
      {
        Console.WriteLine("Sign-up successful!");
      }
      else
      {
        Console.WriteLine("Sign-up failed. Please try again.");
      }

    }
    
  }

    internal class ClientUser
    {
      public string Username {get;set;}
      public string Password {get;set;}
      public string FirstName {get;set;} = string.Empty;
      public string LastName {get;set;} = string.Empty;
      public string Email {get;set;} = string.Empty;


    }
}