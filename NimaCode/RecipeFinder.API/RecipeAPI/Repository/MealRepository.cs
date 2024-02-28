using RecipeAPI.Model;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace RecipeAPI.Repository
{
    public class MealRepository : IRepository<Meal>
    {
        private readonly string _connectionString;
        private readonly ILogger<MealRepository> _logger;

        public MealRepository(string connectionString, ILogger<MealRepository> logger)
        {
            _connectionString = connectionString;
            _logger = logger;
        }

        public async Task<IEnumerable<Meal>> GetAll()
        {
            List<Meal> meals = new();

            string query = "SELECT * FROM [RecipeFinder].[Meal]";

            SqlConnection connection = new(_connectionString);

            SqlCommand command = new(query, connection);

            await connection.OpenAsync();

            var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                Meal meal = new()
                {
                    ID = reader.GetInt32(reader.GetOrdinal("ID")),
                    Name = reader.GetString(reader.GetOrdinal("Name")),
                    Category = reader.GetString(reader.GetOrdinal("Category")),
                    Area = reader.GetString(reader.GetOrdinal("Area")),
                    Instructions = reader.GetString(reader.GetOrdinal("Instructions")),
                    Meal_thumb = reader.IsDBNull(reader.GetOrdinal("Meal_thumb")) ? null : reader.GetString(reader.GetOrdinal("Meal_thumb")),
                    Tags = reader.IsDBNull(reader.GetOrdinal("Tags")) ? null : reader.GetString(reader.GetOrdinal("Tags")),
                    Youtube = reader.IsDBNull(reader.GetOrdinal("Youtube")) ? null : reader.GetString(reader.GetOrdinal("Youtube")),
                    Ingredient1 = reader.GetString(reader.GetOrdinal("Ingredient1")),
                    Ingredient2 = reader.IsDBNull(reader.GetOrdinal("Ingredient2")) ? null : reader.GetString(reader.GetOrdinal("Ingredient2")),
                    Ingredient3 = reader.IsDBNull(reader.GetOrdinal("Ingredient3")) ? null : reader.GetString(reader.GetOrdinal("Ingredient3")),
                    Ingredient4 = reader.IsDBNull(reader.GetOrdinal("Ingredient4")) ? null : reader.GetString(reader.GetOrdinal("Ingredient4")),
                    Ingredient5 = reader.IsDBNull(reader.GetOrdinal("Ingredient5")) ? null : reader.GetString(reader.GetOrdinal("Ingredient5")),
                    Ingredient6 = reader.IsDBNull(reader.GetOrdinal("Ingredient6")) ? null : reader.GetString(reader.GetOrdinal("Ingredient6")),
                    Ingredient7 = reader.IsDBNull(reader.GetOrdinal("Ingredient7")) ? null : reader.GetString(reader.GetOrdinal("Ingredient7")),
                    Ingredient8 = reader.IsDBNull(reader.GetOrdinal("Ingredient8")) ? null : reader.GetString(reader.GetOrdinal("Ingredient8")),
                    Ingredient9 = reader.IsDBNull(reader.GetOrdinal("Ingredient9")) ? null : reader.GetString(reader.GetOrdinal("Ingredient9")),
                    Ingredient10 = reader.IsDBNull(reader.GetOrdinal("Ingredient10")) ? null : reader.GetString(reader.GetOrdinal("Ingredient10")),
                    Ingredient11 = reader.IsDBNull(reader.GetOrdinal("Ingredient11")) ? null : reader.GetString(reader.GetOrdinal("Ingredient11")),
                    Ingredient12 = reader.IsDBNull(reader.GetOrdinal("Ingredient12")) ? null : reader.GetString(reader.GetOrdinal("Ingredient12")),
                    Ingredient13 = reader.IsDBNull(reader.GetOrdinal("Ingredient13")) ? null : reader.GetString(reader.GetOrdinal("Ingredient13")),
                    Ingredient14 = reader.IsDBNull(reader.GetOrdinal("Ingredient14")) ? null : reader.GetString(reader.GetOrdinal("Ingredient14")),
                    Ingredient15 = reader.IsDBNull(reader.GetOrdinal("Ingredient15")) ? null : reader.GetString(reader.GetOrdinal("Ingredient15")),
                    Measure1 = reader.GetString(reader.GetOrdinal("Measure1")),
                    Measure2 = reader.IsDBNull(reader.GetOrdinal("Measure2")) ? null : reader.GetString(reader.GetOrdinal("Measure2")),
                    Measure3 = reader.IsDBNull(reader.GetOrdinal("Measure3")) ? null : reader.GetString(reader.GetOrdinal("Measure3")),
                    Measure4 = reader.IsDBNull(reader.GetOrdinal("Measure4")) ? null : reader.GetString(reader.GetOrdinal("Measure4")),
                    Measure5 = reader.IsDBNull(reader.GetOrdinal("Measure5")) ? null : reader.GetString(reader.GetOrdinal("Measure5")),
                    Measure6 = reader.IsDBNull(reader.GetOrdinal("Measure6")) ? null : reader.GetString(reader.GetOrdinal("Measure6")),
                    Measure7 = reader.IsDBNull(reader.GetOrdinal("Measure7")) ? null : reader.GetString(reader.GetOrdinal("Measure7")),
                    Measure8 = reader.IsDBNull(reader.GetOrdinal("Measure8")) ? null : reader.GetString(reader.GetOrdinal("Measure8")),
                    Measure9 = reader.IsDBNull(reader.GetOrdinal("Measure9")) ? null : reader.GetString(reader.GetOrdinal("Measure9")),
                    Measure10 = reader.IsDBNull(reader.GetOrdinal("Measure10")) ? null : reader.GetString(reader.GetOrdinal("Measure10")),
                    Measure11 = reader.IsDBNull(reader.GetOrdinal("Measure11")) ? null : reader.GetString(reader.GetOrdinal("Measure11")),
                    Measure12 = reader.IsDBNull(reader.GetOrdinal("Measure12")) ? null : reader.GetString(reader.GetOrdinal("Measure12")),
                    Measure13 = reader.IsDBNull(reader.GetOrdinal("Measure13")) ? null : reader.GetString(reader.GetOrdinal("Measure13")),
                    Measure14 = reader.IsDBNull(reader.GetOrdinal("Measure14")) ? null : reader.GetString(reader.GetOrdinal("Measure14")),
                    Measure15 = reader.IsDBNull(reader.GetOrdinal("Measure15")) ? null : reader.GetString(reader.GetOrdinal("Measure15"))
                };

                meals.Add(meal);
            }
            return meals;
        }

        public async Task<Meal?> GetById(int id)
        {
            string query = @"SELECT * FROM [RecipeFinder].[Meal] WHERE ID = @ID";

            using SqlConnection connection = new(this._connectionString);

            SqlCommand command = new(query, connection);

            command.Parameters.AddWithValue("@ID", id);

            await connection.OpenAsync();

            var reader = await command.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                Meal meal = new()
                {
                    ID = reader.GetInt32(reader.GetOrdinal("ID")),
                    Name = reader.GetString(reader.GetOrdinal("Name")),
                    Category = reader.GetString(reader.GetOrdinal("Category")),
                    Area = reader.GetString(reader.GetOrdinal("Area")),
                    Instructions = reader.GetString(reader.GetOrdinal("Instructions")),
                    Meal_thumb = reader.IsDBNull(reader.GetOrdinal("Meal_thumb")) ? null : reader.GetString(reader.GetOrdinal("Meal_thumb")),
                    Tags = reader.IsDBNull(reader.GetOrdinal("Tags")) ? null : reader.GetString(reader.GetOrdinal("Tags")),
                    Youtube = reader.IsDBNull(reader.GetOrdinal("Youtube")) ? null : reader.GetString(reader.GetOrdinal("Youtube")),
                    Ingredient1 = reader.GetString(reader.GetOrdinal("Ingredient1")),
                    Ingredient2 = reader.IsDBNull(reader.GetOrdinal("Ingredient2")) ? null : reader.GetString(reader.GetOrdinal("Ingredient2")),
                    Ingredient3 = reader.IsDBNull(reader.GetOrdinal("Ingredient3")) ? null : reader.GetString(reader.GetOrdinal("Ingredient3")),
                    Ingredient4 = reader.IsDBNull(reader.GetOrdinal("Ingredient4")) ? null : reader.GetString(reader.GetOrdinal("Ingredient4")),
                    Ingredient5 = reader.IsDBNull(reader.GetOrdinal("Ingredient5")) ? null : reader.GetString(reader.GetOrdinal("Ingredient5")),
                    Ingredient6 = reader.IsDBNull(reader.GetOrdinal("Ingredient6")) ? null : reader.GetString(reader.GetOrdinal("Ingredient6")),
                    Ingredient7 = reader.IsDBNull(reader.GetOrdinal("Ingredient7")) ? null : reader.GetString(reader.GetOrdinal("Ingredient7")),
                    Ingredient8 = reader.IsDBNull(reader.GetOrdinal("Ingredient8")) ? null : reader.GetString(reader.GetOrdinal("Ingredient8")),
                    Ingredient9 = reader.IsDBNull(reader.GetOrdinal("Ingredient9")) ? null : reader.GetString(reader.GetOrdinal("Ingredient9")),
                    Ingredient10 = reader.IsDBNull(reader.GetOrdinal("Ingredient10")) ? null : reader.GetString(reader.GetOrdinal("Ingredient10")),
                    Ingredient11 = reader.IsDBNull(reader.GetOrdinal("Ingredient11")) ? null : reader.GetString(reader.GetOrdinal("Ingredient11")),
                    Ingredient12 = reader.IsDBNull(reader.GetOrdinal("Ingredient12")) ? null : reader.GetString(reader.GetOrdinal("Ingredient12")),
                    Ingredient13 = reader.IsDBNull(reader.GetOrdinal("Ingredient13")) ? null : reader.GetString(reader.GetOrdinal("Ingredient13")),
                    Ingredient14 = reader.IsDBNull(reader.GetOrdinal("Ingredient14")) ? null : reader.GetString(reader.GetOrdinal("Ingredient14")),
                    Ingredient15 = reader.IsDBNull(reader.GetOrdinal("Ingredient15")) ? null : reader.GetString(reader.GetOrdinal("Ingredient15")),
                    Measure1 = reader.GetString(reader.GetOrdinal("Measure1")),
                    Measure2 = reader.IsDBNull(reader.GetOrdinal("Measure2")) ? null : reader.GetString(reader.GetOrdinal("Measure2")),
                    Measure3 = reader.IsDBNull(reader.GetOrdinal("Measure3")) ? null : reader.GetString(reader.GetOrdinal("Measure3")),
                    Measure4 = reader.IsDBNull(reader.GetOrdinal("Measure4")) ? null : reader.GetString(reader.GetOrdinal("Measure4")),
                    Measure5 = reader.IsDBNull(reader.GetOrdinal("Measure5")) ? null : reader.GetString(reader.GetOrdinal("Measure5")),
                    Measure6 = reader.IsDBNull(reader.GetOrdinal("Measure6")) ? null : reader.GetString(reader.GetOrdinal("Measure6")),
                    Measure7 = reader.IsDBNull(reader.GetOrdinal("Measure7")) ? null : reader.GetString(reader.GetOrdinal("Measure7")),
                    Measure8 = reader.IsDBNull(reader.GetOrdinal("Measure8")) ? null : reader.GetString(reader.GetOrdinal("Measure8")),
                    Measure9 = reader.IsDBNull(reader.GetOrdinal("Measure9")) ? null : reader.GetString(reader.GetOrdinal("Measure9")),
                    Measure10 = reader.IsDBNull(reader.GetOrdinal("Measure10")) ? null : reader.GetString(reader.GetOrdinal("Measure10")),
                    Measure11 = reader.IsDBNull(reader.GetOrdinal("Measure11")) ? null : reader.GetString(reader.GetOrdinal("Measure11")),
                    Measure12 = reader.IsDBNull(reader.GetOrdinal("Measure12")) ? null : reader.GetString(reader.GetOrdinal("Measure12")),
                    Measure13 = reader.IsDBNull(reader.GetOrdinal("Measure13")) ? null : reader.GetString(reader.GetOrdinal("Measure13")),
                    Measure14 = reader.IsDBNull(reader.GetOrdinal("Measure14")) ? null : reader.GetString(reader.GetOrdinal("Measure14")),
                    Measure15 = reader.IsDBNull(reader.GetOrdinal("Measure15")) ? null : reader.GetString(reader.GetOrdinal("Measure15"))
                };
                return meal;
            }
            else
                return null;
        }

        public async Task Add(Meal meal)
        {
            string query = @"INSERT INTO [RecipeFinder].[Meal] (Name, Category, Area, Instructions, Meal_thumb, Tags, Youtube,Ingredient1, Ingredient2, Ingredient3, Ingredient4, Ingredient5, Ingredient6, Ingredient7, Ingredient8, Ingredient9, Ingredient10, Ingredient11, Ingredient12, Ingredient13, Ingredient14, Ingredient15, Measure1, Measure2, Measure3, Measure4, Measure5, Measure6, Measure7, Measure8, Measure9, Measure10, Measure11, Measure12,Measure13, Measure14, Measure15) 
              VALUES (@Name, @Category, @Area, @Instructions, @Meal_thumb, @Tags, @Youtube, @Ingredient1, @Ingredient2, @Ingredient3, @Ingredient4, @Ingredient5, @Ingredient6, @Ingredient7, @Ingredient8, @Ingredient9, @Ingredient10, @Ingredient11, @Ingredient12, @Ingredient13, @Ingredient14, @Ingredient15, @Measure1, @Measure2, @Measure3, @Measure4, @Measure5, @Measure6, @Measure7, @Measure8, @Measure9, @Measure10, @Measure11, @Measure12, @Measure13, @Measure14, @Measure15)";

            SqlConnection connection = new(this._connectionString);

            SqlCommand command = new(query, connection);

            command.Parameters.AddWithValue("@Name", meal.Name);
            command.Parameters.AddWithValue("@Category", meal.Category);
            command.Parameters.AddWithValue("@Area", meal.Area);
            command.Parameters.AddWithValue("@Instructions", meal.Instructions);
            command.Parameters.AddWithValue("@Meal_thumb", meal.Meal_thumb ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Tags", meal.Tags ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Youtube", meal.Youtube ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Ingredient1", meal.Ingredient1);
            command.Parameters.AddWithValue("@Ingredient2", meal.Ingredient2 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Ingredient3", meal.Ingredient3 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Ingredient4", meal.Ingredient4 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Ingredient5", meal.Ingredient5 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Ingredient6", meal.Ingredient6 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Ingredient7", meal.Ingredient7 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Ingredient8", meal.Ingredient8 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Ingredient9", meal.Ingredient9 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Ingredient10", meal.Ingredient10 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Ingredient11", meal.Ingredient11 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Ingredient12", meal.Ingredient12 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Ingredient13", meal.Ingredient13 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Ingredient14", meal.Ingredient14 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Ingredient15", meal.Ingredient15 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Measure1", meal.Measure1);
            command.Parameters.AddWithValue("@Measure2", meal.Measure2 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Measure3", meal.Measure3 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Measure4", meal.Measure4 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Measure5", meal.Measure5 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Measure6", meal.Measure6 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Measure7", meal.Measure7 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Measure8", meal.Measure8 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Measure9", meal.Measure9 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Measure10", meal.Measure10 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Measure11", meal.Measure11 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Measure12", meal.Measure12 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Measure13", meal.Measure13 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Measure14", meal.Measure14 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Measure15", meal.Measure15 ?? (object)DBNull.Value);

            await connection.OpenAsync();
            await command.ExecuteNonQueryAsync();
        }

        public async Task DeleteByID(int id)
        {
            string query = "DELETE * FROM [RecipeFinder].[Meal] WHERE ID = @ID";

            SqlConnection connection = new(this._connectionString);

            SqlCommand command = new(query, connection);

            command.Parameters.AddWithValue("@ID", id);

            await connection.OpenAsync();
            await command.ExecuteNonQueryAsync();
        }
    }
}