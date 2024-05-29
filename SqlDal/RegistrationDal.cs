using Dapper;
using EventPlanner.Models;
using MySql.Data.MySqlClient;

namespace EventPlanner.SqlDal;

public class RegistrationDal : IRegistration
{ 
    private readonly string _con;
    public RegistrationDal(string con)
    {
        _con = con;
    }
    
    
    public Registration GetRegistrationById(int id)
    {
        try
        {
            using (MySqlConnection connection = new MySqlConnection(_con))
            {
                string sql  = "SELECT * FROM registrations WHERE id = @id";
                Registration registration = connection.QueryFirstOrDefault<Registration>(sql, new { id = id });
                return registration;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public List<Registration> GetAllRegistrations()
    {
        try
        {
            using (MySqlConnection connection = new MySqlConnection(_con))
            {
                string sql = "SELECT * FROM registrations";
                List<Registration> registrations = connection.Query<Registration>(sql).ToList();
                return registrations;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }

    public bool DeleteRegistration(int id)
    {
        try
        {
            using (MySqlConnection connection = new MySqlConnection(_con))
            {
                string sql = "DELETE FROM registrations WHERE id = @id";
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

    public bool UpdateRegistration(Registration registration)
    {
        try
        {
            using (MySqlConnection connection = new MySqlConnection(_con))
            {
                string sql = "UPDATE registrations SET idEvents = @idEvents, idUsers = @idUsers , createdAt = @createdAt   WHERE id = @id";
                int result = connection.Execute(sql, registration);
                return result > 0;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }

    public int InsertRegistration(Registration registration)
    {
        try
        {
            using (MySqlConnection connection = new MySqlConnection(_con))
            {
                string sql = "INSERT INTO registrations (idEvents, idUsers, createdAt) VALUES (@idEvents, @idUsers, @createdAt); SELECT LAST_INSERT_ID();";
                int id = connection.QueryFirstOrDefault<int>(sql, registration);
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