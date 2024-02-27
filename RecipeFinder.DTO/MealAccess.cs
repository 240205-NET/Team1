
using Microsoft.Extensions.Configuration;
using RecipeFinder.Logic.Model;
using System.Data.SqlClient;

namespace RecipeFinder.DTO
{
    public class MealAccess
    {

        private string? _connectionString;

        public MealAccess(IConfiguration configuration)
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

        public async Task<List<Meal>> GetMeals()
        {
            using SqlConnection conn = new(_connectionString);
            await conn.OpenAsync();

            string query = "SELECT * FROM [Meal]";
            using SqlCommand cmd = new(query, conn);
            using SqlDataReader reader = await cmd.ExecuteReaderAsync();

            await conn.CloseAsync();

            var meals = new List<Meal>();

            if (reader.HasRows)
            {
                while (await reader.ReadAsync())
                {
                    var meal = new Meal();
                    meal.Id = reader.GetInt32(0);
                    meal.Name = reader.GetString(1);
                    meal.Category = reader.GetString(2);
                    meal.Area = reader.GetString(3);
                    meal.Instructions = reader.GetString(4);
                    meal.MealThumb = reader.GetString(5);
                    meal.Tags = reader.GetString(6);
                    meal.Youtube = reader.GetString(7);
                    meal.Ingredient1 = reader.GetString(8);
                    meal.Ingredient2 = reader.GetString(9);
                    meal.Ingredient3 = reader.GetString(10);
                    meal.Ingredient4 = reader.GetString(11);
                    meal.Ingredient5 = reader.GetString(12);
                    meal.Ingredient6 = reader.GetString(13);
                    meal.Ingredient7 = reader.GetString(14);
                    meal.Ingredient8 = reader.GetString(15);
                    meal.Ingredient9 = reader.GetString(16);
                    meal.Ingredient10 = reader.GetString(17);
                    meal.Ingredient11 = reader.GetString(18);
                    meal.Ingredient12 = reader.GetString(19);
                    meal.Ingredient13 = reader.GetString(20);
                    meal.Ingredient14 = reader.GetString(21);
                    meal.Ingredient15 = reader.GetString(22);
                    meal.Measure1 = reader.GetString(23);
                    meal.Measure2 = reader.GetString(24);
                    meal.Measure3 = reader.GetString(25);
                    meal.Measure4 = reader.GetString(26);
                    meal.Measure5 = reader.GetString(27);
                    meal.Measure6 = reader.GetString(28);
                    meal.Measure7 = reader.GetString(29);
                    meal.Measure8 = reader.GetString(30);
                    meal.Measure9 = reader.GetString(31);
                    meal.Measure10 = reader.GetString(32);
                    meal.Measure11 = reader.GetString(33);
                    meal.Measure12 = reader.GetString(34);
                    meal.Measure13 = reader.GetString(35);
                    meal.Measure14 = reader.GetString(36);
                    meal.Measure15 = reader.GetString(37);
                    meals.Add(meal);
                }
            }

            return meals;
        }

        public Meal GetMeal(int id)
        {
            using SqlConnection conn = new(_connectionString);
            conn.Open();

            string query = "SELECT * FROM [Meal] WHERE Id = @Id";
            using SqlCommand cmd = new(query, conn);
            cmd.Parameters.AddWithValue("@Id", id);
            using SqlDataReader reader = cmd.ExecuteReader();

            conn.Close();

            var meal = new Meal();

            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    meal.Id = reader.GetInt32(0);
                    meal.Name = reader.GetString(1);
                    meal.Category = reader.GetString(2);
                    meal.Area = reader.GetString(3);
                    meal.Instructions = reader.GetString(4);
                    meal.MealThumb = reader.GetString(5);
                    meal.Tags = reader.GetString(6);
                    meal.Youtube = reader.GetString(7);
                    meal.Ingredient1 = reader.GetString(8);
                    meal.Ingredient2 = reader.GetString(9);
                    meal.Ingredient3 = reader.GetString(10);
                    meal.Ingredient4 = reader.GetString(11);
                    meal.Ingredient5 = reader.GetString(12);
                    meal.Ingredient6 = reader.GetString(13);
                    meal.Ingredient7 = reader.GetString(14);
                    meal.Ingredient8 = reader.GetString(15);
                    meal.Ingredient9 = reader.GetString(16);
                    meal.Ingredient10 = reader.GetString(17);
                    meal.Ingredient11 = reader.GetString(18);
                    meal.Ingredient12 = reader.GetString(19);
                    meal.Ingredient13 = reader.GetString(20);
                    meal.Ingredient14 = reader.GetString(21);
                    meal.Ingredient15 = reader.GetString(22);
                    meal.Measure1 = reader.GetString(23);
                    meal.Measure2 = reader.GetString(24);
                    meal.Measure3 = reader.GetString(25);
                    meal.Measure4 = reader.GetString(26);
                    meal.Measure5 = reader.GetString(27);
                    meal.Measure6 = reader.GetString(28);
                    meal.Measure7 = reader.GetString(29);
                    meal.Measure8 = reader.GetString(30);
                    meal.Measure9 = reader.GetString(31);
                    meal.Measure10 = reader.GetString(32);
                    meal.Measure11 = reader.GetString(33);
                    meal.Measure12 = reader.GetString(34);
                    meal.Measure13 = reader.GetString(35);
                    meal.Measure14 = reader.GetString(36);
                    meal.Measure15 = reader.GetString(37);

                }
            }

            return meal;
        }

        public void AddMeal(Meal meal)
        {
            using SqlConnection conn = new(_connectionString);
            conn.Open();

            
            string query = "INSERT INTO [Meal] (Name, Category, Area, Instructions, MealThumb, Tags, Youtube, Ingredient1, Ingredient2, Ingredient3, Ingredient4, Ingredient5, Ingredient6, Ingredient7, Ingredient8, Ingredient9, Ingredient10, Ingredient11, Ingredient12, Ingredient13, Ingredient14, Ingredient15, Measure1, Measure2, Measure3, Measure4, Measure5, Measure6, Measure7, Measure8, Measure9, Measure10, Measure11, Measure12, Measure13, Measure14, Measure15) VALUES (@Name, @Category, @Area, @Instructions, @MealThumb, @Tags, @Youtube, @Ingredient1, @Ingredient2, @Ingredient3, @Ingredient4, @Ingredient5, @Ingredient6, @Ingredient7, @Ingredient8, @Ingredient9, @Ingredient10, @Ingredient11, @Ingredient12, @Ingredient13, @Ingredient14, @Ingredient15, @Measure1, @Measure2, @Measure3, @Measure4, @Measure5, @Measure6, @Measure7, @Measure8, @Measure9, @Measure10, @Measure11, @Measure12, @Measure13, @Measure14, @Measure15)";

            using SqlCommand cmd = new(query, conn);
            cmd.Parameters.AddWithValue("@Name", meal.Name);
            cmd.Parameters.AddWithValue("@Category", meal.Category);
            cmd.Parameters.AddWithValue("@Area", meal.Area);
            cmd.Parameters.AddWithValue("@Instructions", meal.Instructions);
            cmd.Parameters.AddWithValue("@MealThumb", meal.MealThumb);
            cmd.Parameters.AddWithValue("@Tags", meal.Tags);
            cmd.Parameters.AddWithValue("@Youtube", meal.Youtube);
            cmd.Parameters.AddWithValue("@Ingredient1", meal.Ingredient1);
            cmd.Parameters.AddWithValue("@Ingredient2", meal.Ingredient2);
            cmd.Parameters.AddWithValue("@Ingredient3", meal.Ingredient3);
            cmd.Parameters.AddWithValue("@Ingredient4", meal.Ingredient4);
            cmd.Parameters.AddWithValue("@Ingredient5", meal.Ingredient5);
            cmd.Parameters.AddWithValue("@Ingredient6", meal.Ingredient6);
            cmd.Parameters.AddWithValue("@Ingredient7", meal.Ingredient7);
            cmd.Parameters.AddWithValue("@Ingredient8", meal.Ingredient8);
            cmd.Parameters.AddWithValue("@Ingredient9", meal.Ingredient9);
            cmd.Parameters.AddWithValue("@Ingredient10", meal.Ingredient10);
            cmd.Parameters.AddWithValue("@Ingredient11", meal.Ingredient11);
            cmd.Parameters.AddWithValue("@Ingredient12", meal.Ingredient12);
            cmd.Parameters.AddWithValue("@Ingredient13", meal.Ingredient13);
            cmd.Parameters.AddWithValue("@Ingredient14", meal.Ingredient14);
            cmd.Parameters.AddWithValue("@Ingredient15", meal.Ingredient15);
            cmd.Parameters.AddWithValue("@Measure1", meal.Measure1);
            cmd.Parameters.AddWithValue("@Measure2", meal.Measure2);
            cmd.Parameters.AddWithValue("@Measure3", meal.Measure3);
            cmd.Parameters.AddWithValue("@Measure4", meal.Measure4);
            cmd.Parameters.AddWithValue("@Measure5", meal.Measure5);
            cmd.Parameters.AddWithValue("@Measure6", meal.Measure6);
            cmd.Parameters.AddWithValue("@Measure7", meal.Measure7);
            cmd.Parameters.AddWithValue("@Measure8", meal.Measure8);
            cmd.Parameters.AddWithValue("@Measure9", meal.Measure9);
            cmd.Parameters.AddWithValue("@Measure10", meal.Measure10);
            cmd.Parameters.AddWithValue("@Measure11", meal.Measure11);
            cmd.Parameters.AddWithValue("@Measure12", meal.Measure12);
            cmd.Parameters.AddWithValue("@Measure13", meal.Measure13);
            cmd.Parameters.AddWithValue("@Measure14", meal.Measure14);
            cmd.Parameters.AddWithValue("@Measure15", meal.Measure15);


            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public void UpdateMeal(Meal meal)
        {

            using SqlConnection conn = new(_connectionString);

            conn.Open();

            string query = "UPDATE [Meal] SET Name = @Name, Category = @Category, Area = @Area, Instructions = @Instructions, MealThumb = @MealThumb, Tags = @Tags, Youtube = @Youtube, Ingredient1 = @Ingredient1, Ingredient2 = @Ingredient2, Ingredient3 = @Ingredient3, Ingredient4 = @Ingredient4, Ingredient5 = @Ingredient5, Ingredient6 = @Ingredient6, Ingredient7 = @Ingredient7, Ingredient8 = @Ingredient8, Ingredient9 = @Ingredient9, Ingredient10 = @Ingredient10, Ingredient11 = @Ingredient11, Ingredient12 = @Ingredient12, Ingredient13 = @Ingredient13, Ingredient14 = @Ingredient14, Ingredient15 = @Ingredient15, Measure1 = @Measure1, Measure2 = @Measure2, Measure3 = @Measure3, Measure4 = @Measure4, Measure5 = @Measure5, Measure6 = @Measure6, Measure7 = @Measure7, Measure8 = @Measure8, Measure9 = @Measure9, Measure10 = @Measure10, Measure11 = @Measure11, Measure12 = @Measure12, Measure13 = @Measure13, Measure14 = @Measure14, Measure15 = @Measure15 WHERE Id = @Id";

            using SqlCommand cmd = new(query, conn);
            cmd.Parameters.AddWithValue("@Id", meal.Id);
            cmd.Parameters.AddWithValue("@Name", meal.Name);
            cmd.Parameters.AddWithValue("@Category", meal.Category);
            cmd.Parameters.AddWithValue("@Area", meal.Area);
            cmd.Parameters.AddWithValue("@Instructions", meal.Instructions);
            cmd.Parameters.AddWithValue("@MealThumb", meal.MealThumb);
            cmd.Parameters.AddWithValue("@Tags", meal.Tags);
            cmd.Parameters.AddWithValue("@Youtube", meal.Youtube);
            cmd.Parameters.AddWithValue("@Ingredient1", meal.Ingredient1);
            cmd.Parameters.AddWithValue("@Ingredient2", meal.Ingredient2);
            cmd.Parameters.AddWithValue("@Ingredient3", meal.Ingredient3);
            cmd.Parameters.AddWithValue("@Ingredient4", meal.Ingredient4);
            cmd.Parameters.AddWithValue("@Ingredient5", meal.Ingredient5);
            cmd.Parameters.AddWithValue("@Ingredient6", meal.Ingredient6);
            cmd.Parameters.AddWithValue("@Ingredient7", meal.Ingredient7);
            cmd.Parameters.AddWithValue("@Ingredient8", meal.Ingredient8);
            cmd.Parameters.AddWithValue("@Ingredient9", meal.Ingredient9);
            cmd.Parameters.AddWithValue("@Ingredient10", meal.Ingredient10);
            cmd.Parameters.AddWithValue("@Ingredient11", meal.Ingredient11);
            cmd.Parameters.AddWithValue("@Ingredient12", meal.Ingredient12);
            cmd.Parameters.AddWithValue("@Ingredient13", meal.Ingredient13);
            cmd.Parameters.AddWithValue("@Ingredient14", meal.Ingredient14);
            cmd.Parameters.AddWithValue("@Ingredient15", meal.Ingredient15);
            cmd.Parameters.AddWithValue("@Measure1", meal.Measure1);
            cmd.Parameters.AddWithValue("@Measure2", meal.Measure2);
            cmd.Parameters.AddWithValue("@Measure3", meal.Measure3);
            cmd.Parameters.AddWithValue("@Measure4", meal.Measure4);
            cmd.Parameters.AddWithValue("@Measure5", meal.Measure5);
            cmd.Parameters.AddWithValue("@Measure6", meal.Measure6);
            cmd.Parameters.AddWithValue("@Measure7", meal.Measure7);
            cmd.Parameters.AddWithValue("@Measure8", meal.Measure8);
            cmd.Parameters.AddWithValue("@Measure9", meal.Measure9);
            cmd.Parameters.AddWithValue("@Measure10", meal.Measure10);
            cmd.Parameters.AddWithValue("@Measure11", meal.Measure11);
            cmd.Parameters.AddWithValue("@Measure12", meal.Measure12);
            cmd.Parameters.AddWithValue("@Measure13", meal.Measure13);
            cmd.Parameters.AddWithValue("@Measure14", meal.Measure14);
            cmd.Parameters.AddWithValue("@Measure15", meal.Measure15);

            cmd.ExecuteNonQuery();

            conn.Close();



        }

        public bool DeleteMeal(int id)
        {
            using SqlConnection conn = new(_connectionString);
            conn.Open();

            string query = "DELETE FROM [Meal] WHERE Id = @Id";
            using SqlCommand cmd = new(query, conn);
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.ExecuteNonQuery();

            conn.Close();

            return true;
        }
    }
}
