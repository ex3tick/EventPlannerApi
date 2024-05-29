using System.ComponentModel.DataAnnotations;

namespace EventPlanner.Models;

public class User
{
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; }

    [Required]
    [MaxLength(50)]
    public string LastName { get; set; }

    [Required]
    [EmailAddress]
    [MaxLength(100)]
    public string Email { get; set; }

    public bool WantAlert { get; set; }

    [Required]
    public string Password { get; set; }

    [Required]
    public string Salt { get; set; }

    public bool IsPlanner { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}