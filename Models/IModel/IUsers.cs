namespace EventPlanner.Models;

public interface IUsers
{
    User GetUserById(int id);
    List<User> GetAllUsers();
    bool DeleteUser(int id);
    bool UpdateUser(User user);
    int InsertUser(User user);
    bool emailExists(string email);
}