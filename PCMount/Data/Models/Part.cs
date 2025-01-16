using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#pragma warning disable CA1050 // Declare types in namespaces
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor
[Table("Componente")] // Explicitly map to the Componente table
public class Part
{
    [Key]
    public int partId { get; set; } // Maps to partId in the Componente table

    [Required]
    [StringLength(45)] // Matches the Componente.name field
    public required string name { get; set; }

    [Required]
    public double preco { get; set; } // Matches the Componente.preco field (FLOAT)

    [Required]
    [StringLength(45)] // Matches the Componente.tipo field
    public required string tipo { get; set; }

    [StringLength(500)] // Matches the Componente.descricao field
    public string descricao { get; set; }

    [StringLength(45)] // Matches the Componente.image field
    public string image { get; set; }

    public int portId { get; set; } // Matches the Componente.portId field
}