namespace EventPlanner.Models;

public class Ticket
{
    public int Id { get; set; }
    public int IdEvents { get; set; }
    public decimal cost { get; set; }
    public DateTime CreatedAt { get; set; }
    
}