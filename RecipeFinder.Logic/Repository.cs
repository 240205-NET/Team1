using System;
using System.Text;
using RecipeFinder.Logic.Model;

public class Repository
{
    private readonly RecipeFinderContext _context = new RecipeFinderContext();

    public Repository()
    {

    }

    public string ListAllMeals()
    {
        var sb = new StringBuilder();
        foreach (var meal in _context.Meals)
        {
            sb.Append($"{meal.Id}: {meal.Name}");
        }
        return sb.ToString();
    }

    public string ListAllUsers()
    {
        var sb = new StringBuilder();
        foreach (var user in _context.Users)
        {
            sb.Append($"{user.Id}: {user.Username}: {user.Password}");
        }
        return sb.ToString();
    }
    public void AddNewUser()
    {
        var newUser = new User()
        {
            Id = 99,
            Username = "Username1",
            Password = "Password1".GetHashCode().ToString(),
            FirstName = "FName1",
            LastName = "Lname1",
            Email = "Email1@email.com"
        };
        _context.Add(newUser);
        _context.SaveChanges();
    }

}