

using Microsoft.Extensions.Configuration;
using RecipeFinder.Logic.Model;
using System.Data.SqlClient;

namespace RecipeFinder.DTO
{
    public class MealPlanAccess
    {

        private string? _connectionString;

        public MealPlanAccess(IConfiguration configuration)
        {
            try
            {
                _connectionString = configuration.GetConnectionString("DefaultConnection");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Error with connection string...");
                Environment.Exit(1);
            }
        }

        public List<MealPlan>GetMealPlans(int userID)
        {

            using SqlConnection conn = new(_connectionString);
            conn.Open();

            string query = "SELECT * FROM [MealPlan] WHERE UserID = @UserID";
            using SqlCommand cmd = new(query, conn);
            cmd.Parameters.AddWithValue("@UserID", userID);
            using SqlDataReader reader = cmd.ExecuteReader();

            List<MealPlan> mealplans = new();

            conn.Close();
            while (reader.Read())
            {

                MealPlan curr = new();
                curr.UserID = reader.GetInt32(0);
                curr.MealID = reader.GetInt32(1);
                curr.Date = reader.GetDateTime(2);
                mealplans.Add(curr);


            }
            return mealplans;
        }

        public void AddMealPlan(MealPlan mealplan)
        {
            using SqlConnection conn = new(_connectionString);
            conn.Open();

            string query = "INSERT INTO [MealPlan] (UserID, MealID, Date) VALUES (@UserID, @MealID, @Date)";
            using SqlCommand cmd = new(query, conn);
            cmd.Parameters.AddWithValue("@UserID", mealplan.UserID);
            cmd.Parameters.AddWithValue("@MealID", mealplan.MealID);
            cmd.Parameters.AddWithValue("@Date", mealplan.Date);
            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public void DeleteMealPlan(int userID, int mealID, DateTime date)
        {
            using SqlConnection conn = new(_connectionString);
            conn.Open();

            string query = "DELETE FROM [MealPlan] WHERE UserID = @UserID AND MealID = @MealID AND Date = @Date";
            using SqlCommand cmd = new(query, conn);
            cmd.Parameters.AddWithValue("@UserID", userID);
            cmd.Parameters.AddWithValue("@MealID", mealID);
            cmd.Parameters.AddWithValue("@Date", date);
            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public void UpdateMealPlan(MealPlan mealplan)
        {
            using SqlConnection conn = new(_connectionString);
            conn.Open();

            string query = "UPDATE [MealPlan] SET UserID = @UserID, MealID = @MealID, Date = @Date WHERE UserID = @UserID AND MealID = @MealID AND Date = @Date";
            using SqlCommand cmd = new(query, conn);
            cmd.Parameters.AddWithValue("@UserID", mealplan.UserID);
            cmd.Parameters.AddWithValue("@MealID", mealplan.MealID);
            cmd.Parameters.AddWithValue("@Date", mealplan.Date);
            cmd.ExecuteNonQuery();

            conn.Close();
        }

    }
}
