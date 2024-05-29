using EventPlanner.Models;
using EventPlanner.SqlDal;

namespace EventPlanner.Services;

public class UserServices
{
    private readonly IUsers _dal;
   public UserServices(IConfiguration configuration)
    {
        string _con = configuration.GetConnectionString("DefaultConnection");
        _dal = new UserDal(_con);
    }
   
    
    
    public User  GetUserById(int id)
    {
       ; return _dal.GetUserById(id);
    }
    
    public List<User> GetAllUsers()
    {
        return _dal.GetAllUsers();
    }
    public bool DeleteUser(int id)
    {
        return _dal.DeleteUser(id);
    }
    public bool UpdateUser(User user)
    {
        return _dal.UpdateUser(user);
    }
    public int InsertUser(User user)
    {
        return _dal.InsertUser(user);
    }
}