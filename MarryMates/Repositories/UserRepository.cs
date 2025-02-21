using MarryMatesDotNet.Models;
using MySql.Data.MySqlClient;

namespace MarryMatesDotNet.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;

        public UserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<User> GetAllUsers()
        {
            var users = new List<User>();

            using var connection = new MySqlConnection(_connectionString);
            connection.Open();
            var query = "SELECT * FROM Users";
            using var command = new MySqlCommand(query, connection);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                users.Add(new User
                {
                    UserId = reader.GetInt32("UserId"),
                    Name = reader.GetString("Name"),
                    Email = reader.GetString("Email"),
                    PasswordHash = reader.GetString("PasswordHash"),
                    Role = reader.GetString("Role")
                });
            }

            return users;
        }

        public User GetUserById(int id)
        {
            User user = null;

            using var connection = new MySqlConnection(_connectionString);
            connection.Open();
            var query = "SELECT * FROM Users WHERE UserId = @UserId";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserId", id);
            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                user = new User
                {
                    UserId = reader.GetInt32("UserId"),
                    Name = reader.GetString("Name"),
                    Email = reader.GetString("Email"),
                    PasswordHash = reader.GetString("PasswordHash"),
                    Role = reader.GetString("Role")
                };
            }

            return user;
        }

        public User GetUserByEmail(string email)
        {
            User user = null;

            using var connection = new MySqlConnection(_connectionString);
            connection.Open();
            var query = "SELECT * FROM Users WHERE Email = @Email";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Email", email);
            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                user = new User
                {
                    UserId = reader.GetInt32("UserId"),
                    Name = reader.GetString("Name"),
                    Email = reader.GetString("Email"),
                    PasswordHash = reader.GetString("PasswordHash"),
                    Role = reader.GetString("Role")
                };
            }

            return user;
        }

        public void AddUser(User user)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();
            var query = @"INSERT INTO Users (Name, Email, PasswordHash, Role) 
                          VALUES (@Name, @Email, @PasswordHash, @Role)";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Name", user.Name);
            command.Parameters.AddWithValue("@Email", user.Email);
            command.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);
            command.Parameters.AddWithValue("@Role", user.Role);
            command.ExecuteNonQuery();
        }

        public void UpdateUser(User user)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();
            var query = @"UPDATE Users 
                          SET Name = @Name, Email = @Email, PasswordHash = @PasswordHash, Role = @Role 
                          WHERE UserId = @UserId";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Name", user.Name);
            command.Parameters.AddWithValue("@Email", user.Email);
            command.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);
            command.Parameters.AddWithValue("@Role", user.Role);
            command.Parameters.AddWithValue("@UserId", user.UserId);
            command.ExecuteNonQuery();
        }

        public void DeleteUser(int id)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();
            var query = "DELETE FROM Users WHERE UserId = @UserId";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserId", id);
            command.ExecuteNonQuery();
        }

        public IEnumerable<User> GetClients()
        {
            var clients = new List<User>();

            using var connection = new MySqlConnection(_connectionString);
            connection.Open();
            var query = "SELECT * FROM Users WHERE Role = 'Client'";
            using var command = new MySqlCommand(query, connection);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                clients.Add(new User
                {
                    UserId = reader.GetInt32("UserId"),
                    Name = reader.GetString("Name"),
                    Email = reader.GetString("Email"),
                    PasswordHash = reader.GetString("PasswordHash"),
                    Role = reader.GetString("Role")
                });
            }

            return clients;
        }

        public IEnumerable<User> GetVendors()
        {
            var vendors = new List<User>();

            using var connection = new MySqlConnection(_connectionString);
            connection.Open();
            var query = "SELECT * FROM Users WHERE Role = 'Vendor'";
            using var command = new MySqlCommand(query, connection);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                vendors.Add(new User
                {
                    UserId = reader.GetInt32("UserId"),
                    Name = reader.GetString("Name"),
                    Email = reader.GetString("Email"),
                    PasswordHash = reader.GetString("PasswordHash"),
                    Role = reader.GetString("Role")
                });
            }

            return vendors;
        }
    }
}
