namespace EventPlanner.Models;

public interface ITicket
{
    Ticket GetTicketById(int id);
    List<Ticket> GetAllTickets();
    bool DeleteTicket(int id);
    bool UpdateTicket(Ticket ticket);
    int InsertTicket(Ticket ticket);
    List<Ticket> GetTicketsByEventId(int id);
      
    
}