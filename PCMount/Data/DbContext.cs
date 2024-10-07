using Microsoft.EntityFrameworkCore;

#pragma warning disable CA1050 // Declare types in namespaces
#pragma warning disable IDE0290 // Use primary constructor
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    // DbSets (tables)
    public DbSet<User> Users { get; set; }
    public DbSet<Part> Parts { get; set; }
}