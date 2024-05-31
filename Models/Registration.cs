namespace EventPlanner.Models;

public class Registration
{
    public int Id { get; set; }
    public int IdEvents { get; set; }
    public int IdUsers { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}