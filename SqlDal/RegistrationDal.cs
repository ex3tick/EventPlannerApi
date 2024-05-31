using Dapper;
using EventPlanner.Models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace EventPlanner.SqlDal
{
    public class RegistrationDal : IRegistration
    {
        private readonly string _con;

        public RegistrationDal(string con)
        {
            _con = con;
        }

        public async Task<Registration> GetRegistrationById(int id)
        {
            try
            {
                using (IDbConnection connection = new MySqlConnection(_con))
                {
                    string sql = "SELECT * FROM registrations WHERE id = @id";
                    Registration registration = await connection.QueryFirstOrDefaultAsync<Registration>(sql, new { id = id });
                    return registration;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<List<Registration>> GetAllRegistrations()
        {
            try
            {
                using (IDbConnection connection = new MySqlConnection(_con))
                {
                    string sql = "SELECT * FROM registrations";
                    var registrations = await connection.QueryAsync<Registration>(sql);
                    return registrations.ToList();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<bool> DeleteRegistration(int id)
        {
            try
            {
                using (IDbConnection connection = new MySqlConnection(_con))
                {
                    string sql = "DELETE FROM registrations WHERE id = @id";
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

        public async Task<bool> UpdateRegistration(Registration registration)
        {
            try
            {
                using (IDbConnection connection = new MySqlConnection(_con))
                {
                    string sql = "UPDATE registrations SET idEvents = @idEvents, idUsers = @idUsers, createdAt = @createdAt WHERE id = @id";
                    int result = await connection.ExecuteAsync(sql, registration);
                    return result > 0;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<int> InsertRegistration(Registration registration)
        {
            try
            {
                using (IDbConnection connection = new MySqlConnection(_con))
                {
                    string sql = @"
                        INSERT INTO registrations (idEvents, idUsers, createdAt) 
                        VALUES (@idEvents, @idUsers, @createdAt);
                        SELECT LAST_INSERT_ID();";

                    int id = await connection.QuerySingleAsync<int>(sql, registration);
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
}
