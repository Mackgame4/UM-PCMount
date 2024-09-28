using System.ComponentModel.DataAnnotations;

#pragma warning disable CA1050 // Declare types in namespaces
public class User
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public required string Name { get; set; }

    [Required]
    [StringLength(100)]
    public required string Email { get; set; }
}