using System.ComponentModel.DataAnnotations;

#pragma warning disable CA1050 // Declare types in namespaces
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor
public class Part
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(30)] // max length of part number will normally be 17 characters but we'll allow for more
    public required string PartNum { get; set; }

    [Required]
    [StringLength(120)]
    public required string Name { get; set; }

    [StringLength(500)]
    public string Description { get; set; }

    public int Price { get; set; }
}