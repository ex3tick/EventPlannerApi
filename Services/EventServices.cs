using EventPlanner.Models;
using EventPlanner.SqlDal;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventPlanner.Services
{
    public class EventServices
    {
        private readonly IEvent _dal;

        public EventServices(IConfiguration configuration)
        {
            string _con = configuration.GetConnectionString("DefaultConnection");
            _dal = new EventDal(_con);
        }

        public async Task<Event> GetEventById(int id)
        {
            return await _dal.GetEventById(id);
        }

        public async Task<List<Event>> GetAllEvents()
        {
            return await _dal.GetAllEvents();
        }

        public async Task<bool> DeleteEvent(int id)
        {
            return await _dal.DeleteEvent(id);
        }

        public async Task<bool> UpdateEvent(Event events)
        {
            return await _dal.UpdateEvent(events);
        }

        public async Task<int> InsertEvent(Event events)
        {
            return await _dal.InsertEvent(events);
        }
    }
}