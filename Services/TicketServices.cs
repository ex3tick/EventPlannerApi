using EventPlanner.Models;
using EventPlanner.SqlDal;

namespace EventPlanner.Services;

public class TicketServices
{
    private readonly ITicket _dal;

    public TicketServices(IConfiguration configuration)
    {
        string _con = configuration.GetConnectionString("DefaultConnection");
        _dal = new TicketDal(_con);
    }
    
    public Ticket GetTicketById(int id)
    {
        return _dal.GetTicketById(id);
    }
    public List<Ticket> GetAllTickets()
    {
        return _dal.GetAllTickets();
    }
    public bool DeleteTicket(int id)
    {
        return _dal.DeleteTicket(id);
    }
    public bool UpdateTicket(Ticket ticket)
    {
        return _dal.UpdateTicket(ticket);
    }
    public int InsertTicket(Ticket ticket)
    {
        return _dal.InsertTicket(ticket);
    }
    public List<Ticket> GetTicketsByEventId(int id)
    {
        return _dal.GetTicketsByEventId(id);
    }
}