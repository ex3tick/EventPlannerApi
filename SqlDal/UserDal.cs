using Dapper;
using EventPlanner.Models;
using MySql.Data.MySqlClient;

namespace EventPlanner.SqlDal;

public class UserDal : IUsers
{
    private readonly string _con;
    public UserDal(string con)
    {
        _con = con;
    }
    
    public User GetUserById(int id)
    {
        User user = new User();
        try
        {
            using (MySqlConnection connection = new MySqlConnection(_con))
            {
                string sql = "SELECT * FROM users WHERE id = @id";
                user = connection.QueryFirstOrDefault<User>(sql, new { id = id });
                return user;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }

    public List<User> GetAllUsers()
    {
        try
        {
            using (MySqlConnection connection = new MySqlConnection(_con))
            {
                string sql = "SELECT * FROM users";
                List<User> users = connection.Query<User>(sql).ToList();
                return users;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }

    public bool DeleteUser(int id)
    {
        try
        {
            using (MySqlConnection connection = new MySqlConnection(_con))
            {
                string sql =" DELETE FROM users WHERE id = @id";
                connection.Execute(sql, new { id = id });
                return true;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public bool UpdateUser(User user)
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
                    id = @Id";                connection.Execute(sql, user);
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
    public int InsertUser(User user)
    {
        try
        {
            using (MySqlConnection connection = new MySqlConnection(_con))
            {
                string sql = @"
                INSERT INTO users 
                (firstname, lastname, email, wantAlert, password, salt, isPlaner, createdAt, updatedAt) 
                VALUES 
                (@FirstName, @LastName, @Email, @WantAlert, @Password, @Salt, @IsPlanner, @CreatedAt, @UpdatedAt)";
                int rows = connection.Execute(sql, user);
                return rows;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return 0;
        }
    }

    public bool emailExists(string email)
    {
         
        try
        {
            using (MySqlConnection connection = new MySqlConnection(_con))
            {
                string sql = "SELECT * FROM users WHERE email = @Email";
                User user = connection.QueryFirstOrDefault<User>(sql, new { email = email });
                return user != null;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }
}