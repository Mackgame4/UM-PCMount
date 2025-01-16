namespace PCMount.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("users")]
public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [Column("username")]
    [StringLength(100)]
    public required string UserName { get; set; }

    [Required]
    [Column("password")]
    [StringLength(100)]
    public required string Password { get; set; }

    [Required]
    [Column("role")]
    [StringLength(100)]
    public required string Role { get; set; }
}