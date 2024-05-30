using EventPlanner.Models;
using EventPlanner.SqlDal;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventPlanner.Services
{
    public class UserServices
    {
        private readonly IUsers _dal;

        public UserServices(IConfiguration configuration)
        {
            string _con = configuration.GetConnectionString("DefaultConnection");
            _dal = new UserDal(_con);
        }

        public async Task<User> GetUserById(int id)
        {
            return await _dal.GetUserById(id);
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _dal.GetAllUsers();
        }

        public async Task<bool> DeleteUser(int id)
        {
            return await _dal.DeleteUser(id);
        }

        public async Task<bool> UpdateUser(User user)
        {
            return await _dal.UpdateUser(user);
        }

        public async Task<int> InsertUser(User user)
        {
            return await _dal.InsertUser(user);
        }

        public async Task<bool> emailExists(string email)
        {
            return await _dal.emailExists(email);
        }
    }
}