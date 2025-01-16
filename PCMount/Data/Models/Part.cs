namespace PCMount.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Componente")] // Explicitly map to the Componente table
public class Part
{
    [Key]
    public int PartId { get; set; } // Maps to partId in the Componente table

    [Required]
    [StringLength(45)] // Matches the Componente.name field
    public required string Name { get; set; }

    [Required]
    public required double Preco { get; set; } // Matches the Componente.preco field (FLOAT)

    [Required]
    [StringLength(45)] // Matches the Componente.tipo field
    public required string Tipo { get; set; }

    [StringLength(600)] // Matches the Componente.descricao field
    public string? Descricao { get; set; }

    [StringLength(45)] // Matches the Componente.image field
    public string? Image { get; set; }

    public int? PortId { get; set; } // Matches the Componente.portId field
}