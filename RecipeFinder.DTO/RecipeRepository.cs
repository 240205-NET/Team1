using Microsoft.Extensions.Configuration;
using RecipeFinder.Logic.Model;

namespace RecipeFinder.DTO
{
    public class RecipeRepository
    {

        readonly private MealAccess  _meal;
        readonly private UserAccess _user;
        readonly private MealPlanAccess _mealPlan;

        public RecipeRepository(IConfiguration configuration)
        {

            string connectionString = configuration.GetConnectionString("DefaultConnection")?? throw new InvalidOperationException("Default Connection missing");

            _meal = new MealAccess(connectionString);
            _user = new UserAccess(connectionString);
            _mealPlan = new MealPlanAccess(connectionString);

        }

        public async Task<User> GetUserById(int id)
        {

            return await _user.GetUser(id);

        }
    }
}
