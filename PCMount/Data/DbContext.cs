namespace PCMount.Data;

using System.Buffers.Text;
using Microsoft.EntityFrameworkCore;

using PCMount.Data.Models;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options) {
    // Populate the database with the tables
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);
        // Create the table for the User model
        //modelBuilder.Entity<User>().ToTable("users");
        // Pre-populate the table with data
        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, UserName = "admin", Password = PasswordHasher.Base64Encode("admin"), Role = "Admin" }
        );

        modelBuilder.Entity<Part>().ToTable("componentes");
        modelBuilder.Entity<Inventario>().ToTable("inventario");
        // Pre-populate the table with data
        modelBuilder.Entity<Part>().HasData(
            new Part { PartId = 1, 
                       Name = "Intel Core i9-14900K 3.2/6GHz", 
                       Preco = 599.99, 
                       Tipo = "Processor", 
                       Descricao = "The Intel Core i9-14900K is a high-performance 14th-generation desktop processor designed for demanding workloads. With a base clock speed of 3.2GHz and a turbo boost up to 6.0GHz, it offers exceptional performance for gaming, content creation, and multitasking. Featuring multiple cores and threads, advanced overclocking capabilities, and support for DDR5 and PCIe 5.0, it ensures seamless performance for the most intensive applications. Perfect for enthusiasts and professionals seeking top-tier computing power.",
                       Image = "/assets/intelCorei9.png",
                       PortId = 1
                       }
        );
        // Pre-populate the table with data
        modelBuilder.Entity<Inventario>().HasData(
            new Inventario { PartId = 1, Quantidade = 10 }
        );
        
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Part> Componentes { get; set; }
    public DbSet<Inventario> Inventario { get; set; } // Add this if you have an Inventario table
}