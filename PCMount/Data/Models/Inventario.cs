using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Inventario")] // Explicitly map to the Inventario table
public class Inventario
{
    [Key]
    [ForeignKey("Part")] // Explicitly define the foreign key
    public int partId { get; set; } // Foreign and primary key to Componente

    [Required]
    public int quantidade { get; set; }

    // Navigation property
    public Part Part { get; set; }
}