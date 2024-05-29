using Dapper;
using EventPlanner.Models;
using MySql.Data.MySqlClient;

namespace EventPlanner.SqlDal;

public class EventDal : IEvent
{
    private readonly string _con;

    public EventDal(string con)
    {
        _con = con;
    }
    
    public Event GetEventById(int id)
    {
        try
        {
                using(MySqlConnection connection = new MySqlConnection(_con))
                {
                    string sql = "SELECT * FROM events WHERE id = @id";
                    Event events = connection.QueryFirstOrDefault<Event>(sql, new { id = id });
                    return events;
                }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }

    public List<Event> GetAllEvents()
    {
        try
        {
            using (MySqlConnection connection = new MySqlConnection(_con))
            {
                string sql = "SELECT * FROM events";
                List<Event> events = connection.Query<Event>(sql).ToList();
                return events;
            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }

    public bool DeleteEvent(int id)
    {
        try
        { 
            using (MySqlConnection connection = new MySqlConnection(_con))
            {
                string sql = "DELETE FROM events WHERE id = @id";
                connection.Execute(sql, new { id = id });
                return true;
            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public bool UpdateEvent(Event events)
    {
        try
        {
            using (MySqlConnection connection = new MySqlConnection(_con))
            {
                string sql = "UPDATE events SET eventName = @eventName, ort = @ort, datum = @datum, infos = @infos, idPlaner = @idPlaner WHERE id = @id";
                connection.Execute(sql, events);
                return true;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public int InsertEvent(Event events)
    {
        try
        {
            using (MySqlConnection connection = new MySqlConnection(_con))
            {
                string sql = "INSERT INTO events (eventName, ort, datum, infos,idPlaner) VALUES ( @eventName, @ort, @datum, @infos, @idPlaner)";
                int rows = connection.Execute(sql, events);
                return rows;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}