using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using RecipeFinder.Logic.Model;

namespace RecipeFinder.DTO
{
    public class UserAccess
    {
        private string? _connectionString;

        public UserAccess(string conString)
        {
            try
            {
                _connectionString = conString;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Error with connection string...");
                Environment.Exit(1);
            }
        }

        public async Task<User> Login(string username, string password)
        {
            using SqlConnection conn = new(_connectionString);
            await conn.OpenAsync();

            string query = "SELECT * FROM [RecipeFinder].[User] WHERE Username = @Username AND Password = @Password";
            using SqlCommand cmd = new(query, conn);
            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@Password", password);
            using SqlDataReader reader = await cmd.ExecuteReaderAsync();

            await conn.CloseAsync();

            var user = new User();

            if (reader.HasRows)
            {
                while (await reader.ReadAsync())
                {
                    user.Id = reader.GetInt32(0);
                    user.Username = reader.GetString(1);
                    user.Password = reader.GetString(2);
                    user.FirstName = reader.GetString(3);
                    user.LastName = reader.GetString(4);
                    user.Email = reader.GetString(5);
                }
            }

            return user;
        }

        public async Task Register(User user)
        {
            try
            {
                using SqlConnection conn = new(_connectionString);
                await conn.OpenAsync();

                string query = "INSERT INTO [RecipeFinder].[User] (Username, Password, First_name, Last_name, Email) VALUES (@Username, @Password, @First_name, @Last_name, @Email)";
                using SqlCommand cmd = new(query, conn);
                cmd.Parameters.AddWithValue("@Username", user.Username);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@First_name", user.FirstName);
                cmd.Parameters.AddWithValue("@Last_name", user.LastName);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                await cmd.ExecuteNonQueryAsync();

                await conn.CloseAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(1);
            }

        }

        public async Task UpdateUser(int id, string username, string password, string firstName, string lastName, string email)
        {
            using SqlConnection conn = new(_connectionString);
            await conn.OpenAsync();

            string query = "UPDATE [RecipeFinder].[User] SET Username = @Username, Password = @Password, First_name = @First_name, Last_name = @Last_name, Email = @Email WHERE Id = @Id";
            using SqlCommand cmd = new(query, conn);
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@Password", password);
            cmd.Parameters.AddWithValue("@First_name", firstName);
            cmd.Parameters.AddWithValue("@Last_name", lastName);
            cmd.Parameters.AddWithValue("@Email", email);
            await cmd.ExecuteNonQueryAsync();

            await conn.CloseAsync();
        }

        public async Task DeleteUser(int id)
        {
            try
            {
                using SqlConnection conn = new(_connectionString);
                await conn.OpenAsync();

                string query = "DELETE FROM [RecipeFinder].[User] WHERE Id = @Id";
                using SqlCommand cmd = new(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                await cmd.ExecuteNonQueryAsync();

                await conn.CloseAsync();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(1);
            }
        }

        public async Task<User> GetUser(int id)
        {
            using SqlConnection conn = new(_connectionString);
            await conn.OpenAsync();

            string query = "SELECT * FROM [RecipeFinder].[User] WHERE Id = @Id";
            using SqlCommand cmd = new(query, conn);
            cmd.Parameters.AddWithValue("@Id", id);
            using SqlDataReader reader = await cmd.ExecuteReaderAsync();

            

            var user = new User();

            if (reader.HasRows)
            {
                while (await reader.ReadAsync())
                {
                    user.Id = reader.GetInt32(0);
                    user.Username = reader.GetString(1);
                    user.Password = reader.GetString(2);
                    user.FirstName = reader.GetString(3);
                    user.LastName = reader.GetString(4);
                    user.Email = reader.GetString(5);
                }
            }

            await conn.CloseAsync();
            return user;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            using SqlConnection conn = new(_connectionString);
            await conn.OpenAsync();

            string query = "SELECT * FROM [RecipeFinder].[User]";
            using SqlCommand cmd = new(query, conn);
            using SqlDataReader reader = cmd.ExecuteReader();

            

            var users = new List<User>();

            if (reader.HasRows)
            {
                while (await reader.ReadAsync())
                {
                    var user = new User();
                    user.Id = reader.GetInt32(0);
                    user.Username = reader.GetString(1);
                    user.Password = reader.GetString(2);
                    user.FirstName = reader.GetString(3);
                    user.LastName = reader.GetString(4);
                    user.Email = reader.GetString(5);
                    users.Add(user);
                }
            }

            await conn.CloseAsync();
            return users;
        }

    }
}
