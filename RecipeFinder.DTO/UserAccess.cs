using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using RecipeFinder.Logic.Model;

namespace RecipeFinder.DTO
{
    public class UserAccess
    {
        private string? _connectionString;

        public UserAccess(IConfiguration configuration)
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

        public User Login(string username, string password)
        {
            using SqlConnection conn = new(_connectionString);
            conn.Open();

            string query = "SELECT * FROM [User] WHERE Username = @Username AND Password = @Password";
            using SqlCommand cmd = new(query, conn);
            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@Password", password);
            using SqlDataReader reader = cmd.ExecuteReader();

            conn.Close();

            var user = new User();

            if (reader.HasRows)
            {
                while (reader.Read())
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

        public bool Register(User user)
        {
            try
            {
                using SqlConnection conn = new(_connectionString);
                conn.Open();

                string query = "INSERT INTO [User] (Username, Password, First_name, Last_name, Email) VALUES (@Username, @Password, @First_name, @Last_name, @Email)";
                using SqlCommand cmd = new(query, conn);
                cmd.Parameters.AddWithValue("@Username", user.Username);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@First_name", user.FirstName);
                cmd.Parameters.AddWithValue("@Last_name", user.LastName);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.ExecuteNonQuery();

                conn.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }

        public bool UpdateUser(int id, string username, string password, string firstName, string lastName, string email)
        {
            using SqlConnection conn = new(_connectionString);
            conn.Open();

            string query = "UPDATE [User] SET Username = @Username, Password = @Password, First_name = @First_name, Last_name = @Last_name, Email = @Email WHERE Id = @Id";
            using SqlCommand cmd = new(query, conn);
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@Password", password);
            cmd.Parameters.AddWithValue("@First_name", firstName);
            cmd.Parameters.AddWithValue("@Last_name", lastName);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.ExecuteNonQuery();

            conn.Close();

            return true;
        }

        public bool DeleteUser(int id)
        {
            using SqlConnection conn = new(_connectionString);
            conn.Open();

            string query = "DELETE FROM [User] WHERE Id = @Id";
            using SqlCommand cmd = new(query, conn);
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.ExecuteNonQuery();

            conn.Close();

            return true;
        }

        public User GetUser(int id)
        {
            using SqlConnection conn = new(_connectionString);
            conn.Open();

            string query = "SELECT * FROM [User] WHERE Id = @Id";
            using SqlCommand cmd = new(query, conn);
            cmd.Parameters.AddWithValue("@Id", id);
            using SqlDataReader reader = cmd.ExecuteReader();

            conn.Close();

            var user = new User();

            if (reader.HasRows)
            {
                while (reader.Read())
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

        public List<User> GetAllUsers()
        {
            using SqlConnection conn = new(_connectionString);
            conn.Open();

            string query = "SELECT * FROM [User]";
            using SqlCommand cmd = new(query, conn);
            using SqlDataReader reader = cmd.ExecuteReader();

            conn.Close();

            var users = new List<User>();

            if (reader.HasRows)
            {
                while (reader.Read())
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

            return users;
        }

    }
}
