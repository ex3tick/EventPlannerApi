using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventPlanner.Models
{
    public interface IRegistration
    {
        Task<Registration> GetRegistrationById(int id);
        Task<List<Registration>> GetAllRegistrations();
        Task<bool> DeleteRegistration(int id);
        Task<bool> UpdateRegistration(Registration registration);
        Task<int> InsertRegistration(Registration registration);
    }
}