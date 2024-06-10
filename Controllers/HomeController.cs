using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EventPlanner.Models;
using EventPlanner.Services;

namespace EventPlanner.Controllers;

public class
    HomeController : Controller
{
    #region readonly
    private readonly ILogger<HomeController> _logger;
    private readonly  UserServices _userServices;
    private readonly EventServices _eventServices;
    private readonly RegistrationServices _registrationServices;
    private readonly TicketServices _ticketServices;
    #endregion
   
    public HomeController(ILogger<HomeController> logger,IConfiguration configuration)
    {
        _logger = logger;
        _userServices = new UserServices(configuration);
        _eventServices = new EventServices(configuration);
        _ticketServices = new TicketServices(configuration);
        _registrationServices = new RegistrationServices(configuration);
    }
 

    public IActionResult Index()
    { 
        
        return View();
    }

   

    #region UserRest
    [HttpGet]
    [Route("/api/User/AllUsers")]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _userServices.GetAllUsers();
        return Json(users);
    }

    [HttpGet]
    [Route("/api/User/GetUserById")]
    public async Task<IActionResult> GetUserById([FromQuery] int id)
    {
        var user = await _userServices.GetUserById(id);
        return Json(user);
    }

    [HttpPost]
    [Route("/api/User/InsertUser")]
    public async Task<IActionResult> InsertUser([FromBody] User user)
    {
        var id = await _userServices.InsertUser(user);
        return Json(id);
    }

    [HttpPut]
    [Route("/api/User/UpdateUser")]
    public async Task<IActionResult> UpdateUser([FromBody] User user)
    {
        var result = await _userServices.UpdateUser(user);
        return Json(result);
    }

    [HttpDelete]
    [Route("/api/User/DeleteUser")]
    public async Task<IActionResult> DeleteUser([FromQuery] int id)
    {
        var result = await _userServices.DeleteUser(id);
        return Json(result);
    }

    [HttpGet]
    [Route("/api/User/EmailExists")]
    public async Task<IActionResult> EmailExists([FromQuery] string email)
    {
        var result = await _userServices.emailExists(email);
        return Ok( result);
    }
    [HttpGet]
    [Route("/api/User/GetUserByEmail")]
    public async Task<IActionResult> GetUserByEmail([FromQuery] string email)
    {
        var user = await _userServices.GetUserByEmail(email);
        return Json(user);
    }

    #endregion

    #region   EventRest
    [HttpGet]
    [Route("/api/Event/AllEvents")]
    public async Task<IActionResult> GetAllEvents()
    {
        var events = await _eventServices.GetAllEvents();
        return Json(events);
    }

    [HttpGet]
    [Route("/api/Event/GetEventById")]
    public async Task<IActionResult> GetEventById([FromQuery] int id)
    {
        var events = await _eventServices.GetEventById(id);
        return Json(events);
    }

    [HttpPost]
    [Route("/api/Event/InsertEvent")]
    public async Task<IActionResult> InsertEvent([FromBody] Event events)
    {
        var id = await _eventServices.InsertEvent(events);
        return Ok(id);
    }

    [HttpPut]
    [Route("/api/Event/UpdateEvent")]
    public async Task<IActionResult> UpdateEvent([FromBody] Event events)
    {
        var result = await _eventServices.UpdateEvent(events);
        return Json(result);
    }

    [HttpDelete]
    [Route("/api/Event/DeleteEvent")]
    public async Task<IActionResult> DeleteEvent([FromQuery] int id)
    {
        var result = await _eventServices.DeleteEvent(id);
        return Json(result);
    }
    
    #endregion
    
    #region RegistrationRest
    [HttpGet]
    [Route("/api/Registration/AllRegistrations")]
    public async Task<IActionResult> GetAllRegistrations()
    {
        var registrations = await _registrationServices.GetAllRegistrations();
        return Ok(registrations);
    }

    [HttpGet]
    [Route("/api/Registration/GetRegistrationById")]
    public async Task<IActionResult> GetRegistrationById([FromQuery] int id)
    {
        var registration = await _registrationServices.GetRegistrationById(id);
        return Json(registration);
    }

    [HttpPost]
    [Route("/api/Registration/InsertRegistration")]
    public async Task<IActionResult> InsertRegistration([FromBody] Registration registration)
    {
        var id = await _registrationServices.InsertRegistration(registration);
        return Json(id);
    }

    [HttpPut]
    [Route("/api/Registration/UpdateRegistration")]
    public async Task<IActionResult> UpdateRegistration([FromBody] Registration registration)
    {
        var result = await _registrationServices.UpdateRegistration(registration);
        return Json(result);
    }

    [HttpDelete]
    [Route("/api/Registration/DeleteRegistration")]
    public async Task<IActionResult> DeleteRegistration([FromQuery] int id)
    {
        var result = await _registrationServices.DeleteRegistration(id);
        return Json(result);
    }
     #endregion
     
    #region TicketRest
    [HttpGet]
    [Route("/api/Ticket/AllTickets")]
    public async Task<IActionResult> GetAllTickets()
    {
        var tickets = await _ticketServices.GetAllTicketsAsync();
        return Json(tickets);
    }

    [HttpGet]
    [Route("/api/Ticket/GetTicketById")]
    public async Task<IActionResult> GetTicketById([FromQuery] int id)
    {
        var ticket = await _ticketServices.GetTicketByIdAsync(id);
        return Json(ticket);
    }

    [HttpPost]
    [Route("/api/Ticket/InsertTicket")]
    public async Task<IActionResult> InsertTicket([FromBody] Ticket ticket)
    {
        var id = await _ticketServices.InsertTicketAsync(ticket);
        return Json(id);
    }

    [HttpPut]
    [Route("/api/Ticket/UpdateTicket")]
    public async Task<IActionResult> UpdateTicket([FromBody] Ticket ticket)
    {
        var result = await _ticketServices.UpdateTicketAsync(ticket);
        return Json(result);
    }

    [HttpDelete]
    [Route("/api/Ticket/DeleteTicket")]
    public async Task<IActionResult> DeleteTicket([FromQuery] int id)
    {
        var result = await _ticketServices.DeleteTicketAsync(id);
        return Json(result);
    }

    [HttpGet]
    [Route("/api/Ticket/GetTicketsByEventId")]
    public async Task<IActionResult> GetTicketsByEventId([FromQuery] int id)
    {
        var tickets = await _ticketServices.GetTicketsByEventIdAsync(id);
        return Json(tickets);
    }
    #endregion
    
    
  
}