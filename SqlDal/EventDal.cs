using Dapper;
using EventPlanner.Models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventPlanner.SqlDal;

public class EventDal : IEvent
{
    private readonly string _con;

    public EventDal(string con)
    {
        _con = con;
    }

    public async Task<Event> GetEventById(int id)
    {
        try
        {
            using(MySqlConnection connection = new MySqlConnection(_con))
            {
                string sql = "SELECT * FROM events WHERE id = @id";
                Event events = await connection.QueryFirstOrDefaultAsync<Event>(sql, new { id = id });
                return events;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<List<Event>> GetAllEvents()
    {
        try
        {
            using (MySqlConnection connection = new MySqlConnection(_con))
            {
                string sql = "SELECT * FROM events";
                List<Event> events = (await connection.QueryAsync<Event>(sql)).ToList();
                return events;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<bool> DeleteEvent(int id)
    {
        try
        { 
            using (MySqlConnection connection = new MySqlConnection(_con))
            {
                string sql = "DELETE FROM events WHERE id = @id";
                await connection.ExecuteAsync(sql, new { id = id });
                return true;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<bool> UpdateEvent(Event events)
    {
        try
        {
            using (MySqlConnection connection = new MySqlConnection(_con))
            {
                string sql = "UPDATE events SET eventName = @eventName, ort = @ort, datum = @datum, infos = @infos, idPlaner = @idPlaner WHERE id = @id";
                await connection.ExecuteAsync(sql, events);
                return true;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<int> InsertEvent(Event events)
    {
        try
        {
            using (MySqlConnection connection = new MySqlConnection(_con))
            {
                string sql = @"
                INSERT INTO events (eventName, ort, datum, infos, idPlaner) 
                VALUES (@eventName, @ort, @datum, @infos, @idPlaner);
                SELECT LAST_INSERT_ID();"; // Fetch the last inserted ID

                int id = await connection.QuerySingleAsync<int>(sql, events); // Execute the query and get the ID
                return id;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
