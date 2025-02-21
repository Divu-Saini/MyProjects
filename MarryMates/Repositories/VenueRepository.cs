using MarryMatesDotNet.Models;
using MySql.Data.MySqlClient;

namespace MarryMatesDotNet.Repositories
{
    public class VenueRepository : IVenueRepository
    {
        private readonly string _connectionString;

        public VenueRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Venue> GetAllVenues()
        {
            var venues = new List<Venue>();

            using var connection = new MySqlConnection(_connectionString);
            connection.Open();
            var query = "SELECT * FROM Venue";
            using var command = new MySqlCommand(query, connection);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                venues.Add(new Venue
                {
                    VenueId = reader.GetInt32("VenueId"),
                    VenueName = reader.GetString("VenueName"),
                    Location = reader.GetString("Location"),
                    Capacity = reader.GetInt32("Capacity"),
                    Price = reader.GetDecimal("Price")
                });
            }

            return venues;
        }

        public Venue GetVenueById(int id)
        {
            Venue venue = null;

            using var connection = new MySqlConnection(_connectionString);
            connection.Open();
            var query = "SELECT * FROM Venue WHERE VenueId = @VenueId";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@VenueId", id);
            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                venue = new Venue
                {
                    VenueId = reader.GetInt32("VenueId"),
                    VenueName = reader.GetString("VenueName"),
                    Location = reader.GetString("Location"),
                    Capacity = reader.GetInt32("Capacity"),
                    Price = reader.GetDecimal("Price")
                };
            }
            return venue; 


        }

        public void AddVenue(Venue venue)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();
            var query = @"INSERT INTO Venue (VenueName, Location, Capacity, Price) 
                          VALUES (@VenueName, @Location, @Capacity, @Price)";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@VenueName", venue.VenueName);
            command.Parameters.AddWithValue("@Location", venue.Location);
            command.Parameters.AddWithValue("@Capacity", venue.Capacity);
            command.Parameters.AddWithValue("@Price", venue.Price);
            command.ExecuteNonQuery();
        }

        public void UpdateVenue(Venue venue)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();
            var query = @"UPDATE Venue 
                          SET VenueName = @VenueName, Location = @Location, Capacity = @Capacity, Price = @Price 
                          WHERE VenueId = @VenueId";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@VenueName", venue.VenueName);
            command.Parameters.AddWithValue("@Location", venue.Location);
            command.Parameters.AddWithValue("@Capacity", venue.Capacity);
            command.Parameters.AddWithValue("@Price", venue.Price);
            command.Parameters.AddWithValue("@VenueId", venue.VenueId);
            command.ExecuteNonQuery();
        }

        public void DeleteVenue(int id)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();
            var query = "DELETE FROM Venue WHERE VenueId = @VenueId";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@VenueId", id);
            command.ExecuteNonQuery();
        }
    }
}
