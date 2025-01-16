namespace PCMount.Data;

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
            new User { Id = 1, UserName = "admin", Password = "admin", Role = "Admin" }
        );
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Part> Componentes { get; set; }
    public DbSet<Inventario> Inventario { get; set; } // Add this if you have an Inventario table
}