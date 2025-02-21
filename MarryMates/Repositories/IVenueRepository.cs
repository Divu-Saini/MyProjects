using MarryMatesDotNet.Models;

namespace MarryMatesDotNet.Repositories
{
    public interface IVenueRepository
    {
        IEnumerable<Venue> GetAllVenues();
        Venue GetVenueById(int id);
        void AddVenue(Venue venue);
        void UpdateVenue(Venue venue);
        void DeleteVenue(int id);

      

    }
}
