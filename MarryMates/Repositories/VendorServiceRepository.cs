using MarryMatesDotNet.Models;
using MySql.Data.MySqlClient;

namespace MarryMatesDotNet.Repositories
{
    public class VendorServiceRepository : IVendorServiceRepository
    {
        private readonly string _connectionString;

        public VendorServiceRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<VendorService> GetAllServices()
        {
            var services = new List<VendorService>();

            using var connection = new MySqlConnection(_connectionString);
            connection.Open();
            var query = "SELECT * FROM VendorServices";
            using var command = new MySqlCommand(query, connection);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                services.Add(new VendorService
                {
                    ServiceId = reader.GetInt32("ServiceId"),
                    VendorId = reader.GetInt32("VendorId"),
                    ServiceName = reader.GetString("ServiceName"),
                    Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? null : reader.GetString("Description"),
                    Price = reader.GetDecimal("Price")
                });
            }

            return services;
        }

        public VendorService GetServiceById(int id)
        {
            VendorService service = null;

            using var connection = new MySqlConnection(_connectionString);
            connection.Open();
            var query = "SELECT * FROM VendorServices WHERE ServiceId = @ServiceId";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@ServiceId", id);
            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                service = new VendorService
                {
                    ServiceId = reader.GetInt32("ServiceId"),
                    VendorId = reader.GetInt32("VendorId"),
                    ServiceName = reader.GetString("ServiceName"),
                    Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? null : reader.GetString("Description"),
                    Price = reader.GetDecimal("Price")
                };
            }

            return service;
        }

        public void AddService(VendorService service)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();
            var query = @"INSERT INTO VendorServices (VendorId, ServiceName, Description, Price) 
                          VALUES (@VendorId, @ServiceName, @Description, @Price)";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@VendorId", service.VendorId);
            command.Parameters.AddWithValue("@ServiceName", service.ServiceName);
            command.Parameters.AddWithValue("@Description", service.Description);
            command.Parameters.AddWithValue("@Price", service.Price);
            command.ExecuteNonQuery();
        }

        public void UpdateService(VendorService service)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();
            var query = @"UPDATE VendorServices 
                          SET VendorId = @VendorId, ServiceName = @ServiceName, Description = @Description, Price = @Price 
                          WHERE ServiceId = @ServiceId";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@VendorId", service.VendorId);
            command.Parameters.AddWithValue("@ServiceName", service.ServiceName);
            command.Parameters.AddWithValue("@Description", service.Description);
            command.Parameters.AddWithValue("@Price", service.Price);
            command.Parameters.AddWithValue("@ServiceId", service.ServiceId);
            command.ExecuteNonQuery();
        }

        public void DeleteService(int id)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();
            var query = "DELETE FROM VendorServices WHERE ServiceId = @ServiceId";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@ServiceId", id);
            command.ExecuteNonQuery();
        }
    }
}