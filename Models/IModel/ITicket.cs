using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventPlanner.Models
{
    public interface ITicket
    {
        Task<Ticket> GetTicketByIdAsync(int id);
        Task<List<Ticket>> GetAllTicketsAsync();
        Task<bool> DeleteTicketAsync(int id);
        Task<bool> UpdateTicketAsync(Ticket ticket);
        Task<int> InsertTicketAsync(Ticket ticket);
        Task<List<Ticket>> GetTicketsByEventIdAsync(int id);
    }
}