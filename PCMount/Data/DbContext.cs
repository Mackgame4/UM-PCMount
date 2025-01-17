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
            new User { Id = 1, 
                       UserName = "admin", 
                       Password = PasswordHasher.HashPassword("admin"), 
                       Role = "Admin" 
            }
        );
        modelBuilder.Entity<Part>().HasData(
            new Part { PartId = 1,  
                       Name = "Intel Core i9-14900K 3.2/6GHz",  
                       Preco = 599.99,  
                       Tipo = "Processor", 
                       Descricao = "The Intel Core i9-14900K is a high-performance 14th-generation desktop processor designed for demanding workloads. With a base clock speed of 3.2GHz and a turbo boost up to 6.0GHz, it offers exceptional performance for gaming, content creation, and multitasking. Featuring multiple cores and threads, advanced overclocking capabilities, and support for DDR5 and PCIe 5.0, it ensures seamless performance for the most intensive applications. Perfect for enthusiasts and professionals seeking top-tier computing power.", 
                       Image = "/assets/intelCorei9.png", 
                       PortId = 1 
            },
            new Part { PartId = 2,  
                       Name = "NVIDIA GeForce RTX 4090 Graphics Card",
                       Preco = 2349.69,  
                       Tipo = "Graphics Card", 
                       Descricao = "The NVIDIA GeForce RTX 4090 is the pinnacle of gaming and creative performance, powered by the advanced NVIDIA Ada Lovelace architecture. With an unprecedented level of GPU power, it delivers stunning 4K and beyond gaming experiences, lightning-fast ray tracing, and AI-enhanced graphics through DLSS 3. Equipped with 24GB of GDDR6X memory, it handles the most demanding games and creative applications with ease. Perfect for gamers, 3D artists, and professionals seeking unmatched graphics performance and efficiency.",
                       Image = "/assets/nvidiaRTX4090.png", 
                       PortId = 2 
            }
        );
        modelBuilder.Entity<Inventario>().HasData(
            new Inventario { PartId = 1, Quantidade = 10 }
        );
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Part> Componentes { get; set; }
    public DbSet<Inventario> Inventario { get; set; }
}