using Microsoft.EntityFrameworkCore;

using PCMount.Data.Models;

namespace PCMount.Data;


public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

    // DbSets (tables)
    public DbSet<User> Users { get; set; }
    public DbSet<Part> Parts { get; set; }
}