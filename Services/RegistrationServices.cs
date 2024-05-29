using EventPlanner.Models;
using EventPlanner.SqlDal;

namespace EventPlanner.Services;

public class RegistrationServices
{
     private readonly  IRegistration _dal;
     
     
     public RegistrationServices(IConfiguration configuration)
     {
         string _con = configuration.GetConnectionString("DefaultConnection");
         _dal = new RegistrationDal(_con);
     }
     
     
        public Registration GetRegistrationById(int id)
        {
            return _dal.GetRegistrationById(id);
        }
        public List<Registration> GetAllRegistrations()
        {
            return _dal.GetAllRegistrations();
        }
        public bool DeleteRegistration(int id)
        {
            return _dal.DeleteRegistration(id);
        }
        public bool UpdateRegistration(Registration registration)
        {
            return _dal.UpdateRegistration(registration);
        }
        public int InsertRegistration(Registration registration)
        {
            return _dal.InsertRegistration(registration);
        }
        
}