namespace PCMount.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Computers")] // Explicitly map to the Inventario table
public class Computer {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("Id")]
    public int Id { get; set; }

    [Required]
    [Column("Name")]
    [StringLength(45)]
    public required string Name { get; set; }

    [Required]
    [Column("Price")]
    public required decimal Price { get; set; }

    [Column("Discount")]
    public decimal? Discount { get; set; }

    [Column("Description")]
    [StringLength(255)]
    public string? Description { get; set; }

    [Required]
    [Column("Image")]
    [StringLength(255)]
    public required string Image { get; set; }

    [Column("MotherboardId")]
    [ForeignKey("Motherboard")]
    public int? MotherboardId { get; set; }

    [Column("ProcessorId")]
    [ForeignKey("Processor")]
    public int? ProcessorId { get; set; }

    [Column("MemoryId")]
    [ForeignKey("Memory")]
    public int? MemoryId { get; set; }

    [Column("StorageId")]
    [ForeignKey("Storage")]
    public int? StorageId { get; set; }

    [Column("GraphicsCardId")]
    [ForeignKey("GraphicsCard")]
    public int? GraphicsCardId { get; set; }

    [Column("PowerSupplyId")]
    [ForeignKey("PowerSupply")]
    public int? PowerSupplyId { get; set; }

    [Column("CaseId")]
    [ForeignKey("Case")]
    public int? CaseId { get; set; }

    // Navigation properties
    public Part? Motherboard { get; set; }
    public Part? Processor { get; set; }
    public Part? Memory { get; set; }
    public Part? Storage { get; set; }
    public Part? GraphicsCard { get; set; }
    public Part? PowerSupply { get; set; }
    public Part? Case { get; set; }
}