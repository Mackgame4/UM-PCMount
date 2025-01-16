namespace PCMount.Data;

using Microsoft.EntityFrameworkCore;

using PCMount.Data.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<User> Utilizadores { get; set; }
    public DbSet<Part> Componentes { get; set; }
    public DbSet<Inventario> Inventario { get; set; } // Add this if you have an Inventario table
}