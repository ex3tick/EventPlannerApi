namespace EventPlanner.Models;

public interface IEvent
{
    public  Task<Event> GetEventById(int id);
    public Task<List<Event>> GetAllEvents();
    public Task<bool> DeleteEvent(int id);
    public Task<bool> UpdateEvent(Event events);
    public Task<int> InsertEvent(Event events);
}