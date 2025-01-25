namespace PCMount.Data;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PCMount.Data.Models;

public static class DbContextConfig {
    private static string? _connectionString;

    public static void Initialize(IConfiguration configuration) {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public static string ConnectionString {
        get {
            if (string.IsNullOrEmpty(_connectionString))
                throw new InvalidOperationException("Connection string is not initialized. Call Initialize() first.");
            return _connectionString;
        }
    }
}

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options) {
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);
        // Pre-populate the table with data
        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, UserName = "admin", Password = PasswordHasher.HashPassword("admin"), Role = "Admin" }
        );
        modelBuilder.Entity<Part>().HasData(
            new Part { PartId = 1, Name = "Intel Core i9-14900K",  Preco = 599.99,  Tipo = PartTipo.Processor, Descricao = "The Intel Core i9-14900K is a high-performance 14th-generation desktop processor designed for demanding workloads. With a base clock speed of 3.2GHz and a turbo boost up to 6.0GHz, it offers exceptional performance for gaming, content creation, and multitasking. Featuring multiple cores and threads, advanced overclocking capabilities, and support for DDR5 and PCIe 5.0, it ensures seamless performance for the most intensive applications. Perfect for enthusiasts and professionals seeking top-tier computing power.", Image = "/assets/cdn/part-intelcore-i9-14900k.png", PortId = 1 },
            new Part { PartId = 2, Name = "NVIDIA GeForce RTX 4090", Preco = 2189.69, Tipo = PartTipo.GraphicsCard, Descricao = "The NVIDIA GeForce RTX 4090 is the pinnacle of gaming and creative performance, powered by the advanced NVIDIA Ada Lovelace architecture. With an unprecedented level of GPU power, it delivers stunning 4K and beyond gaming experiences, lightning-fast ray tracing, and AI-enhanced graphics through DLSS 3. Equipped with 24GB of GDDR6X memory, it handles the most demanding games and creative applications with ease. Perfect for gamers, 3D artists, and professionals seeking unmatched graphics performance and efficiency.", Image = "/assets/cdn/part-nvidia-rtx4090.png", PortId = 2 },
            new Part { PartId = 3, Name = "ASUS ROG Strix Z590-E", Preco = 300, Tipo = PartTipo.Motherboard, Descricao = "", Image = "/assets/cdn/part-asus-rog-strix-z590.png", PortId = 2 },
            new Part { PartId = 4, Name = "NVIDIA GeForce RTX 3080", Preco = 800, Tipo = PartTipo.GraphicsCard, Descricao = "", Image = "/assets/cdn/part-nvidia-rtx-3080.png", PortId = 3 },
            new Part { PartId = 5, Name = "Intel Core i9-11900K", Preco = 529.99, Tipo = PartTipo.Processor, Descricao = "", Image = "/assets/cdn/part-intel-i9-11900k.png", PortId = 4 },
            new Part { PartId = 6, Name = "Corsair Vengeance RGB Pro", Preco = 200, Tipo = PartTipo.Memory, Descricao = "", Image = "/assets/cdn/part-nvidia-rtx-3080.png", PortId = 5 },
            new Part { PartId = 7, Name = "Samsung 970 EVO Plus", Preco = 200, Tipo = PartTipo.Storage, Descricao = "", Image = "/assets/cdn/part-samsung-970-ssd.png", PortId = 6 },
            new Part { PartId = 8, Name = "Corsair RM850x", Preco = 150, Tipo = PartTipo.PowerSupply, Descricao = "", Image = "/assets/cdn/part-nvidia-rtx-3080.png", PortId = 7 },
            new Part { PartId = 9, Name = "NZXT H510", Preco = 100, Tipo = PartTipo.Case, Descricao = "", Image = "/assets/cdn/part-nvidia-rtx-3080.png", PortId = 8 },
            new Part { PartId = 10, Name = "Panorama Glass", Preco = 100, Tipo = PartTipo.Case, Descricao = "", Image = "/assets/cdn/computer-nzxt-h5.png", PortId = 9 },
            new Part { PartId = 11, Name = "Corsair 4000D Airflow", Preco = 100, Tipo = PartTipo.Case, Descricao = "", Image = "/assets/cdn/computer-nzxt-h5.png", PortId = 10 },
            new Part { PartId = 12, Name = "Lian Li PC-O11 Dynamic", Preco = 100, Tipo = PartTipo.Case, Descricao = "", Image = "/assets/cdn/computer-nzxt-h5.png", PortId = 11 },
            new Part { PartId = 13, Name = "Fractal Design Meshify", Preco = 100, Tipo = PartTipo.Case, Descricao = "", Image = "/assets/cdn/computer-nzxt-h5.png", PortId = 12 },
            new Part { PartId = 14, Name = "Phanteks Eclipse P500A", Preco = 100, Tipo = PartTipo.Case, Descricao = "", Image = "/assets/cdn/computer-nzxt-h5.png", PortId = 13 },
            new Part { PartId = 15, Name = "ASUS TUF Gaming GT501", Preco = 100, Tipo = PartTipo.Case, Descricao = "", Image = "/assets/cdn/computer-nzxt-h5.png", PortId = 14 },
            new Part { PartId = 16, Name = "Cooler Master", Preco = 100, Tipo = PartTipo.Cooling, Descricao = "", Image = "/assets/cdn/computer-nzxt-h5.png", PortId = 14 },
            new Part { PartId = 17, Name = "NVIDIA GeForce RTX 4060", Preco = 384.69, Tipo = PartTipo.GraphicsCard, Descricao = "", Image = "/assets/cdn/part-nvidia-rtx4060.png", PortId = 15 },
            new Part { PartId = 18, Name = "NVIDIA GeForce RTX 3060", Preco = 318.89, Tipo = PartTipo.GraphicsCard, Descricao = "", Image = "/assets/cdn/part-nvidia-rtx3060.png", PortId = 16 },
            new Part { PartId = 19, Name = "NVIDIA GeForce RTX 3050", Preco = 207.99, Tipo = PartTipo.GraphicsCard, Descricao = "", Image = "/assets/cdn/part-nvidia-rtx3050.png", PortId = 17 },
            new Part { PartId = 20, Name = "NVIDIA GeForce RTX 1060", Preco = 107.99, Tipo = PartTipo.GraphicsCard, Descricao = "", Image = "/assets/cdn/part-nvidia-rtx1060.png", PortId = 18 },
            new Part { PartId = 21, Name = "GIGABYTE Radeon Rx 7600 Gaming", Preco = 307.99, Tipo = PartTipo.GraphicsCard, Descricao = "", Image = "/assets/cdn/part-radeon-rx7600.png", PortId = 19 },
            new Part { PartId = 22, Name = "NVIDIA GeForce GTX 1060", Preco = 462.34, Tipo = PartTipo.GraphicsCard, Descricao = "", Image = "/assets/cdn/part-nvidia-gtx1660.png", PortId = 20 },
            new Part { PartId = 23, Name = "ZotacGaming GeForce RTX 4070TI", Preco = 872.61, Tipo = PartTipo.GraphicsCard, Descricao = "", Image = "/assets/cdn/part-zotac-rtx4070.png", PortId = 21 },
            new Part { PartId = 24, Name = "ZotacGaming GeForce RTX 3060", Preco = 435.12, Tipo = PartTipo.GraphicsCard, Descricao = "", Image = "/assets/cdn/part-zotac-rtx3060.png", PortId = 22 },
            new Part { PartId = 25, Name = "Asrock Taichi Radeon RX7900", Preco = 936.78, Tipo = PartTipo.GraphicsCard, Descricao = "", Image = "/assets/cdn/part-asrock-rx7900.png", PortId = 23 },
            new Part { PartId = 26, Name = "Asrock Radeon RX7700 XT", Preco = 444.00, Tipo = PartTipo.GraphicsCard, Descricao = "", Image = "/assets/cdn/part-asrock-rx7700.png", PortId = 24 },
            new Part { PartId = 27, Name = "Asus GeForce GT 730", Preco = 99.99, Tipo = PartTipo.GraphicsCard, Descricao = "", Image = "/assets/cdn/part-asus-gt730.png", PortId = 25 },
            new Part { PartId = 28, Name = "Intel Core i5-12600K", Preco = 199.99, Tipo = PartTipo.Processor, Descricao = "", Image = "/assets/cdn/part-intel-i5-12600k.png", PortId = 26 },
            new Part { PartId = 29, Name = "AMD Ryzen 5 3600", Preco = 99.99, Tipo = PartTipo.Processor, Descricao = "", Image = "/assets/cdn/part-amd-ryzen-5-3600.png", PortId = 26 },
            new Part { PartId = 30, Name = "AMD Ryzen 9 5950", Preco = 403.23, Tipo = PartTipo.Processor, Descricao = "", Image = "/assets/cdn/part-amd-ryzen-9-5950.png", PortId = 26 },
            new Part { PartId = 31, Name = "Intel Core i7-10700", Preco = 293.99, Tipo = PartTipo.Processor, Descricao = "", Image = "/assets/cdn/part-intel-i7-10700.png", PortId = 26 },
            new Part { PartId = 32, Name = "Intel Core i7-13700", Preco = 367.90, Tipo = PartTipo.Processor, Descricao = "", Image = "/assets/cdn/part-intel-i7-13700.png", PortId = 26 },
            new Part { PartId = 33, Name = "AMD Ryzen 7 5800", Preco = 198.90, Tipo = PartTipo.Processor, Descricao = "", Image = "/assets/cdn/part-amd-ryzen-7-5800.png", PortId = 26 },
            new Part { PartId = 34, Name = "Intel i3-14100", Preco = 95.95, Tipo = PartTipo.Processor, Descricao = "", Image = "/assets/cdn/part-i3-14100.png", PortId = 26 },
            new Part { PartId = 35, Name = "AMD Ryzen 3 3200", Preco = 75.23, Tipo = PartTipo.Processor, Descricao = "", Image = "/assets/cdn/part-amd-ryzen-3-3200.png", PortId = 26 }
        );

        modelBuilder.Entity<Inventario>().HasData(
            new Inventario { PartId = 1, Quantidade = 10 },
            new Inventario { PartId = 2, Quantidade = 10 },
            new Inventario { PartId = 3, Quantidade = 10 },
            new Inventario { PartId = 4, Quantidade = 10 },
            new Inventario { PartId = 5, Quantidade = 10 },
            new Inventario { PartId = 6, Quantidade = 10 },
            new Inventario { PartId = 7, Quantidade = 10 },
            new Inventario { PartId = 8, Quantidade = 10 }
        );
        modelBuilder.Entity<Computer>().HasData(
            new Computer { Id = 1, Name = "NZXT H5 Gaming Elite", Price = 1000, Image = "/assets/cdn/computer-nzxt-h5.png", Discount = 10, MotherboardId = 3, GraphicsCardId = 4, ProcessorId = 5, MemoryId = 6, StorageId = 7, PowerSupplyId = 8, CaseId = 9, CoolingId = 16 },
            new Computer { Id = 2, Name = "Panorama Glass Gaming", Price = 2000, Image = "/assets/cdn/computer-panorama-gaming.png", MotherboardId = 3, GraphicsCardId = 4, ProcessorId = 5, MemoryId = 6, StorageId = 7, PowerSupplyId = 8, CaseId = 9, CoolingId = 16 },
            new Computer { Id = 3, Name = "Periphio Astral 5600G", Price = 1500, Image = "/assets/cdn/computer-periphio-astral-5600g.png", Discount = 25, MotherboardId = 3, GraphicsCardId = 4, ProcessorId = 5, MemoryId = 6, StorageId = 7, PowerSupplyId = 8, CaseId = 9, CoolingId = 16 },
            new Computer { Id = 4, Name = "Elite AvaDirect 3687Y", Price = 1500, Image = "/assets/cdn/computer-elite-avadirect.png", MotherboardId = 3, GraphicsCardId = 4, ProcessorId = 5, MemoryId = 6, StorageId = 7, PowerSupplyId = 8, CaseId = 9, CoolingId = 16 },
            new Computer { Id = 5, Name = "CyberPower MultiColor", Price = 1000, Image = "/assets/cdn/computer-cyberpower-pc.png", MotherboardId = 3, GraphicsCardId = 4, ProcessorId = 5, MemoryId = 6, StorageId = 7, PowerSupplyId = 8, CaseId = 9, CoolingId = 16 },
            new Computer { Id = 6, Name = "Corsair Vengeance", Price = 1000, Image = "/assets/cdn/computer-vengeance-i5200.png", MotherboardId = 3, GraphicsCardId = 4, ProcessorId = 5, MemoryId = 6, StorageId = 7, PowerSupplyId = 8, CaseId = 9, CoolingId = 16 }
        );
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Part> Componentes { get; set; }
    public DbSet<Inventario> Inventario { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Computer> Computers { get; set; }
}