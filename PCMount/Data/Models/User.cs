namespace PCMount.Data.Models;

using System.ComponentModel.DataAnnotations;

public class User
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public required string UserName { get; set; }

    [Required]
    [StringLength(100)]
    public required string Password { get; set; }

    [Required]
    [StringLength(100)]
    public required string Role { get; set; }
}