using MarryMatesDotNet.Models;

namespace MarryMatesDotNet.Repositories
{
    public interface IEventRepository
    {
        IEnumerable<Event> GetAllEvents();
        Event GetEventById(int id);
        void AddEvent(Event eventEntity);
        void UpdateEvent(Event eventEntity);
        void DeleteEvent(int id);
     
    }
}
