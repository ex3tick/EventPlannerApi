namespace EventPlanner.Models;

public interface IEvent
{
    public Event GetEventById(int id);
    public List<Event> GetAllEvents();
    public bool DeleteEvent(int id);
    public bool UpdateEvent(Event events);
    public int InsertEvent(Event events);
}