using Dapper;
using EventPlanner.Models;
using MySql.Data.MySqlClient;

namespace EventPlanner.SqlDal;

public class TicketDal : ITicket
{
    private readonly string _con;

    public TicketDal(string con)
    {
        _con = con;
    }

    public Ticket GetTicketById(int id)
    {
        try
        {
            using (MySqlConnection connection = new MySqlConnection(_con))
            {
                string sql = "SELECT * FROM tickets WHERE id = @id";
                Ticket ticket = connection.QueryFirstOrDefault<Ticket>(sql, new { id = id });
                return ticket;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public List<Ticket> GetAllTickets()
    {
        try
        {
            using (MySqlConnection connection = new MySqlConnection(_con))
            {
                string sql = "SELECT * FROM tickets";
                List<Ticket> tickets = connection.Query<Ticket>(sql).ToList();
                return tickets;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public bool DeleteTicket(int id)
    {
        try
        {
            using (MySqlConnection connection = new MySqlConnection(_con))
            {
                string sql = "DELETE FROM tickets WHERE id = @id";
                int result = connection.Execute(sql, new { id = id });
                return result > 0;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public bool UpdateTicket(Ticket ticket)
    {
        try
        {
            using (MySqlConnection connection = new MySqlConnection(_con))
            {
                string sql =
                    "UPDATE tickets SET idEvents = @IdEvents,cost = @Cost,createdAt = @CreatedAt WHERE id = @Id";
                int result = connection.Execute(sql, ticket);
                return result > 0;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public int InsertTicket(Ticket ticket)
    {
        try
        {
            using (MySqlConnection connection = new MySqlConnection(_con))
            {
                string sql = "INSERT INTO tickets (idEvents,cost,createdAt) VALUES (@IdEvents,@Cost,@CreatedAt)";
                int result = connection.Execute(sql, ticket);
                return result;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public List<Ticket> GetTicketsByEventId(int id)
    {
        try
        {
            using (MySqlConnection connection = new MySqlConnection(_con))
            {
                string sql = "SELECT * FROM tickets WHERE idEvents = @id";
                List<Ticket> tickets = connection.Query<Ticket>(sql, new { id = id }).ToList();
                return tickets;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}