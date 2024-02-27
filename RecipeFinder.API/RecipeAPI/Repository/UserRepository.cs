using RecipeAPI.Model;
using System.Data.SqlClient;

namespace RecipeAPI.Repository
{
    public class UserRepository : IRepository<User>
    {
        private readonly string _connectionString;
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(string connectionString, ILogger<UserRepository> logger)
        {
            this._connectionString = connectionString;
            this._logger = logger;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            List<User> users = new();
            string query = "SELECT * FROM [RecipeFinder].[User]";

            using SqlConnection connection = new(this._connectionString);

            SqlCommand command = new(query, connection);

            await connection.OpenAsync();

            var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                User user = new()
                {
                    ID = reader.GetInt32(reader.GetOrdinal("ID")),
                    Username = reader.GetString(reader.GetOrdinal("Username")),
                    Password = reader.GetString(reader.GetOrdinal("Password")),
                    First_name = reader.GetString(reader.GetOrdinal("First_name")),
                    Last_name = reader.GetString(reader.GetOrdinal("Last_name")),
                    Email = reader.GetString(reader.GetOrdinal("Email"))
                };
                users.Add(user);
            }
            return users;
        }

        public async Task<User?> GetById(int id)
        {
            string query = @"SELECT * FROM [RecipeFinder].[User] WHERE ID = @ID";

            using SqlConnection connection = new(this._connectionString);
            await connection.OpenAsync();

            SqlCommand command = new(query, connection);
            command.Parameters.AddWithValue("@ID", id);

            var reader = await command.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                User user = new()
                {
                    ID = reader.GetInt32(reader.GetOrdinal("ID")),
                    Username = reader.GetString(reader.GetOrdinal("Username")),
                    Password = reader.GetString(reader.GetOrdinal("Password")),
                    First_name = reader.GetString(reader.GetOrdinal("First_name")),
                    Last_name = reader.GetString(reader.GetOrdinal("Last_name")),
                    Email = reader.GetString(reader.GetOrdinal("Email"))
                };
                return user;
            }
            else
            {
                return null;
            }
        }

        public async Task Add(User user)
        {
            string query = @"INSERT INTO [RecipeFinder].[User] (Username, Password, First_name, Last_name, Email) VALUES (@Username, @Password, @First_name, @Last_name, @Email)";

            using SqlConnection connection = new(this._connectionString);
            await connection.OpenAsync();
            SqlCommand command = new(query, connection);
            command.Parameters.AddWithValue("@Username", user.Username);
            command.Parameters.AddWithValue("@Password", user.Password);
            command.Parameters.AddWithValue("@First_name", user.First_name);
            command.Parameters.AddWithValue("@Last_name", user.Last_name);
            command.Parameters.AddWithValue("@Email", user.Email);

            await command.ExecuteNonQueryAsync();
        }

        public async Task DeleteByID(int id)
        {
            string query = @"DELETE FROM [RecipeFinder].[User] WHERE ID = @ID";

            using SqlConnection connection = new(this._connectionString);
            SqlCommand command = new(query, connection);
            command.Parameters.AddWithValue("@ID", id);
            await command.ExecuteNonQueryAsync();
        }

        public async Task<User?> GetByCredentials(string username, string password)
        {
            string query = @"SELECT * FROM [RecipeFinder].[User] WHERE Username = @UserName AND Password = @PassWord";

            using SqlConnection connection = new(this._connectionString);
            await connection.OpenAsync();
            SqlCommand command = new(query, connection);
            command.Parameters.AddWithValue("@UserName", username);
            command.Parameters.AddWithValue("@PassWord", password);

            using SqlDataReader reader = await command.ExecuteReaderAsync();

            if(await reader.ReadAsync())
            {
                return new User
                {
                    ID = reader.GetInt32(reader.GetOrdinal("ID")),
                    Username = reader.GetString(reader.GetOrdinal("Username")),
                    Password = reader.GetString(reader.GetOrdinal("Password")),
                    First_name = reader.GetString(reader.GetOrdinal("First_name")),
                    Last_name = reader.GetString(reader.GetOrdinal("Last_name")),
                    Email = reader.GetString(reader.GetOrdinal("Email"))
                };
            }
            else
            {
                return null;
            }

        }

    }
}
