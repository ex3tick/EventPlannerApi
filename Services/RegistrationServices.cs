using System.Collections.Generic;
using System.Threading.Tasks;
using EventPlanner.Models;
using EventPlanner.SqlDal;
using Microsoft.Extensions.Configuration;

namespace EventPlanner.Services
{
    public class RegistrationServices
    {
        private readonly IRegistration _dal;

        public RegistrationServices(IConfiguration configuration)
        {
            string _con = configuration.GetConnectionString("DefaultConnection");
            _dal = new RegistrationDal(_con);
        }

        public async Task<Registration> GetRegistrationById(int id)
        {
            return await _dal.GetRegistrationById(id);
        }

        public async Task<List<Registration>> GetAllRegistrations()
        {
            return await _dal.GetAllRegistrations();
        }

        public async Task<bool> DeleteRegistration(int id)
        {
            return await _dal.DeleteRegistration(id);
        }

        public async Task<bool> UpdateRegistration(Registration registration)
        {
            return await _dal.UpdateRegistration(registration);
        }

        public async Task<int> InsertRegistration(Registration registration)
        {
            return await _dal.InsertRegistration(registration);
        }
    }
}