using MarryMatesDotNet.Models;
using MySql.Data.MySqlClient;

namespace MarryMatesDotNet.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly string _connectionString;

        public EventRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Event> GetAllEvents()
        {
            var events = new List<Event>();

            using var connection = new MySqlConnection(_connectionString);
            connection.Open();
            var query = "SELECT * FROM Event";
            using var command = new MySqlCommand(query, connection);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                events.Add(new Event
                {
                    EventId = reader.GetInt32("EventId"),
                    ClientId = reader.GetInt32("ClientId"),
                    VendorId = reader.GetInt32("VendorId"),
                    VenueId = reader.GetInt32("VenueId"),
                    EventDate = reader.GetDateTime("EventDate"),
                    TotalPrice = reader.GetDecimal("TotalPrice")
                });
            }

            return events;
        }

        public Event GetEventById(int id)
        {
            Event eventEntity = null;

            using var connection = new MySqlConnection(_connectionString);
            connection.Open();
            var query = "SELECT * FROM Event WHERE EventId = @EventId";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@EventId", id);
            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                eventEntity = new Event
                {
                    EventId = reader.GetInt32("EventId"),
                    ClientId = reader.GetInt32("ClientId"),
                    VendorId = reader.GetInt32("VendorId"),
                    VenueId = reader.GetInt32("VenueId"),
                    EventDate = reader.GetDateTime("EventDate"),
                    TotalPrice = reader.GetDecimal("TotalPrice")
                };
            }

            return eventEntity;
        }

        public void AddEvent(Event eventEntity)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();
            var query = @"INSERT INTO Event (ClientId, VendorId, VenueId, EventDate, TotalPrice) 
                          VALUES (@ClientId, @VendorId, @VenueId, @EventDate, @TotalPrice)";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@ClientId", eventEntity.ClientId);
            command.Parameters.AddWithValue("@VendorId", eventEntity.VendorId);
            command.Parameters.AddWithValue("@VenueId", eventEntity.VenueId);
            command.Parameters.AddWithValue("@EventDate", eventEntity.EventDate);
            command.Parameters.AddWithValue("@TotalPrice", eventEntity.TotalPrice);
            command.ExecuteNonQuery();
        }

        public void UpdateEvent(Event eventEntity)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();
            var query = @"UPDATE Event 
                          SET ClientId = @ClientId, VendorId = @VendorId, VenueId = @VenueId, EventDate = @EventDate, TotalPrice = @TotalPrice 
                          WHERE EventId = @EventId";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@ClientId", eventEntity.ClientId);
            command.Parameters.AddWithValue("@VendorId", eventEntity.VendorId);
            command.Parameters.AddWithValue("@VenueId", eventEntity.VenueId);
            command.Parameters.AddWithValue("@EventDate", eventEntity.EventDate);
            command.Parameters.AddWithValue("@TotalPrice", eventEntity.TotalPrice);
            command.Parameters.AddWithValue("@EventId", eventEntity.EventId);
            command.ExecuteNonQuery();
        }

        public void DeleteEvent(int id)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();
            var query = "DELETE FROM Event WHERE EventId = @EventId";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@EventId", id);
            command.ExecuteNonQuery();
        }
    }
}
