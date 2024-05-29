namespace EventPlanner.Models;

public interface IRegistration
{
    Registration GetRegistrationById(int id);
    List<Registration> GetAllRegistrations();
    bool DeleteRegistration(int id);
    bool UpdateRegistration(Registration registration);
    int InsertRegistration(Registration registration);
}