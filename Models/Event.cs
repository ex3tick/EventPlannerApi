namespace EventPlanner.Models;

public class Event
{ 
    public int Id { get; set; }
    public string? EventName { get; set; }
    public string? Ort { get; set; }
    public DateTime Datum { get; set; }
    public string? Infos { get; set; }
    public int IdPlaner { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    
}