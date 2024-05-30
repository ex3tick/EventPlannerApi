namespace EventPlanner.Models;

public interface IUsers
{
    Task<User> GetUserById(int id);
    Task<List<User>> GetAllUsers();
    Task<bool> DeleteUser(int id);
    Task<bool> UpdateUser(User user);
    Task<int> InsertUser(User user);
    Task<bool> emailExists(string email);
}