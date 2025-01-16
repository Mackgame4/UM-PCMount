using System.ComponentModel.DataAnnotations;

#pragma warning disable CA1050 // Declare types in namespaces
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor
public class User
{
    [Key]
    public int Id { get; set; } // Maps to id in the Utilizador table

    [Required]
    [StringLength(45)] // Matches the Utilizador.name field
    public required string Name { get; set; }

    [Required]
    [StringLength(45)] // Matches the Utilizador.email field
    public required string Email { get; set; }

    [Required]
    [StringLength(45)] // Matches the Utilizador.password field
    public required string Password { get; set; }

    [StringLength(45)] // Matches the Utilizador.nif field
    public string? Nif { get; set; } // Optional field

    [StringLength(45)] // Matches the Utilizador.telemovel field
    public string? Telemovel { get; set; } // Optional field

    [Required]
    public byte IsAdmin { get; set; } // Maps to isAdmin (TINYINT) in the Utilizador table
}