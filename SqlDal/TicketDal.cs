using Dapper;
using EventPlanner.Models;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;

namespace EventPlanner.SqlDal
{
    public class TicketDal : ITicket
    {
        private readonly string _con;

        public TicketDal(string con)
        {
            _con = con;
        }

        public async Task<Ticket> GetTicketByIdAsync(int id)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_con))
                {
                    string sql = "SELECT * FROM tickets WHERE id = @id";
                    Ticket ticket = await connection.QueryFirstOrDefaultAsync<Ticket>(sql, new { id = id });
                    return ticket;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<List<Ticket>> GetAllTicketsAsync()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_con))
                {
                    string sql = "SELECT * FROM tickets";
                    List<Ticket> tickets = (await connection.QueryAsync<Ticket>(sql)).ToList();
                    return tickets;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<bool> DeleteTicketAsync(int id)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_con))
                {
                    string sql = "DELETE FROM tickets WHERE id = @id";
                    int result = await connection.ExecuteAsync(sql, new { id = id });
                    return result > 0;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<bool> UpdateTicketAsync(Ticket ticket)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_con))
                {
                    string sql =
                        "UPDATE tickets SET idEvents = @IdEvents, cost = @Cost, createdAt = @CreatedAt WHERE id = @Id";
                    int result = await connection.ExecuteAsync(sql, ticket);
                    return result > 0;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<int> InsertTicketAsync(Ticket ticket)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_con))
                {
                    string sql = @"
                    INSERT INTO tickets (idEvents, cost, createdAt) 
                    VALUES (@IdEvents, @Cost, @CreatedAt);
                    SELECT LAST_INSERT_ID();";

                    int id = await connection.QuerySingleAsync<int>(sql, ticket);
                    return id;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<List<Ticket>> GetTicketsByEventIdAsync(int id)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_con))
                {
                    string sql = "SELECT * FROM tickets WHERE idEvents = @id";
                    List<Ticket> tickets = (await connection.QueryAsync<Ticket>(sql, new { id = id })).ToList();
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
}
