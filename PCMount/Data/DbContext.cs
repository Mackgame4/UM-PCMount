using Microsoft.EntityFrameworkCore;

#pragma warning disable CA1050 // Declare types in namespaces
#pragma warning disable IDE0290 // Use primary constructor
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<User> Utilizadores { get; set; }
    public DbSet<Part> Componentes { get; set; }
    public DbSet<Inventario> Inventario { get; set; } // Add this if you have an Inventario table
}