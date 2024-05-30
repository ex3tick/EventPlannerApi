using Dapper;
using EventPlanner.Models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventPlanner.SqlDal
{
    public class UserDal : IUsers
    {
        private readonly string _con;
        public UserDal(string con)
        {
            _con = con;
        }

        public async Task<User> GetUserById(int id)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_con))
                {
                    string sql = "SELECT * FROM users WHERE id = @id";
                    User user = await connection.QueryFirstOrDefaultAsync<User>(sql, new { id = id });
                    return user;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<List<User>> GetAllUsers()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_con))
                {
                    string sql = @"
                SELECT 
                    id,
                    firstname,
                    lastname,
                    email,
                    CAST(wantAlert AS UNSIGNED) AS WantAlert,
                    password,
                    salt,
                    CAST(isPlaner AS UNSIGNED) AS IsPlanner,
                    createdAt,
                    updatedAt 
                FROM users";
                
                    var users = await connection.QueryAsync<User>(sql);
                    return users.ToList();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


        public async Task<bool> DeleteUser(int id)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_con))
                {
                    string sql = "DELETE FROM users WHERE id = @id";
                    await connection.ExecuteAsync(sql, new { id = id });
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public async Task<bool> UpdateUser(User user)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_con))
                {
                    string sql = @"
                    UPDATE users 
                    SET 
                        firstname = @FirstName, 
                        lastname = @LastName, 
                        email = @Email, 
                        wantAlert = @WantAlert, 
                        password = @Password, 
                        salt = @Salt, 
                        isPlaner = @IsPlanner, 
                        updatedAt = @UpdatedAt 
                    WHERE 
                        id = @Id";
                    await connection.ExecuteAsync(sql, user);
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        // insert need hash password and salt before insert
        public async Task<int> InsertUser(User user)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_con))
                {
                    string sql = @"
            INSERT INTO users 
            (firstname, lastname, email, wantAlert, password, salt, isPlaner, createdAt, updatedAt) 
            VALUES 
            (@FirstName, @LastName, @Email, @WantAlert, @Password, @Salt, @IsPlanner, @CreatedAt, @UpdatedAt);
            SELECT LAST_INSERT_ID();"; // Fetch the last inserted ID

                    user.CreatedAt = DateTime.Now;
                    user.UpdatedAt = DateTime.Now;

                    var parameters = new
                    {
                        user.FirstName,
                        user.LastName,
                        Email = user.Email,
                        user.WantAlert,
                        user.Password,
                        user.Salt,
                        IsPlanner = user.IsPlanner ? 1 : 0, // Convert bool to int
                        user.CreatedAt,
                        user.UpdatedAt
                    };

                    int id = await connection.QuerySingleAsync<int>(sql, parameters); 
                    return id;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return 0;
            }
        }


        public async Task<bool> emailExists(string email)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_con))
                {
                    string sql = "SELECT * FROM users WHERE email = @Email";
                    User user = await connection.QueryFirstOrDefaultAsync<User>(sql, new { email = email });
                    return user != null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public async Task<User> GetUserByEmail(string email)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_con))
                {
                    string sql = @"
                SELECT 
                    id,
                    firstname,
                    lastname,
                    email,
                    CAST(wantAlert AS UNSIGNED) AS WantAlert,
                    password,
                    salt,
                    CAST(isPlaner AS UNSIGNED) AS IsPlanner,
                    createdAt,
                    updatedAt 
                FROM users 
                WHERE email = @Email";
                
                    User user = await connection.QueryFirstOrDefaultAsync<User>(sql, new { Email = email });
                    return user;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

    }
}
