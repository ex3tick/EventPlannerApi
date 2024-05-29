using EventPlanner.Models;
using EventPlanner.SqlDal;

namespace EventPlanner.Services;

public class EventServices
{
    private readonly IEvent _dal;
    public EventServices(IConfiguration configuration)
    {
        string _con = configuration.GetConnectionString("DefaultConnection");
        _dal = new EventDal(_con);
    }
    
    public Event  GetEventById(int id)
    {
        return _dal.GetEventById(id);
    }
    public List<Event> GetAllEvents()
    {
        return _dal.GetAllEvents();
    }
    public  bool DeleteEvent(int id)
    {
        return _dal.DeleteEvent(id);
    }
    public bool UpdateEvent(Event events)
    {
        return _dal.UpdateEvent(events);
    }
    public int InsertEvent(Event events)
    {
        return _dal.InsertEvent(events);
    }
    
}


