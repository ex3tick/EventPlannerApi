using EventPlanner.Models;
using EventPlanner.SqlDal;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventPlanner.Services
{
    public class TicketServices
    {
        private readonly ITicket _dal;

        public TicketServices(IConfiguration configuration)
        {
            string _con = configuration.GetConnectionString("DefaultConnection");
            _dal = new TicketDal(_con);
        }
        
        public async Task<Ticket> GetTicketByIdAsync(int id)
        {
            return await _dal.GetTicketByIdAsync(id);
        }

        public async Task<List<Ticket>> GetAllTicketsAsync()
        {
            return await _dal.GetAllTicketsAsync();
        }

        public async Task<bool> DeleteTicketAsync(int id)
        {
            return await _dal.DeleteTicketAsync(id);
        }

        public async Task<bool> UpdateTicketAsync(Ticket ticket)
        {
            return await _dal.UpdateTicketAsync(ticket);
        }

        public async Task<int> InsertTicketAsync(Ticket ticket)
        {
            return await _dal.InsertTicketAsync(ticket);
        }

        public async Task<List<Ticket>> GetTicketsByEventIdAsync(int id)
        {
            return await _dal.GetTicketsByEventIdAsync(id);
        }
    }
}